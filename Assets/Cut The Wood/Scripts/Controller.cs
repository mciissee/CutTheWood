/************************************************************************************************************************************													   *
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/

namespace CutTheWood
{
    using System;
    using UnityEngine;
    using System.Collections;
    using InfinityEngine;
    using InfinityEngine.Extensions;
    using InfinityEngine.Serialization;
    using InfinityEngine.ResourceManagement;
    using InfinityEngine.Attributes;
    using Random = UnityEngine.Random;
    using System.Linq;

    /// <summary>    
    /// Controller component of MVC Design pattern.
    /// This class makes the link between <see cref="View"/> and <see cref="IGameModel"/> classes in scene.
    /// </summary>
    [OverrideInspector]
    public class Controller : MonoBehaviour
    {

        #region Fields
        private static Controller Instance;

        /// <summary>
        /// Gets a value indicating whether the game is played automatically.
        /// </summary>
        public static bool IsAutoPlayMode => Instance.isAutoPlayMode;

        /// <summary>
        /// Starts the game
        /// </summary>
        public static Action onGameStartCallback;
        /// <summary>
        /// Ends the game
        /// </summary>
        public static Action onGameEndCallback;

        /// <summary>
        /// Pauses the game
        /// </summary>
        public static Action onGamePausedCallback;

        [SerializeField] private bool isAutoPlayMode;
        [SerializeField] private float requiredSliceForce = 200.0f;
        [SerializeField] private Blade blade;
        /// <summary>
        /// The items to instantiate
        /// </summary>
        [SerializeField] private GameObject[] prefabs;

        /// <summary>
        /// The current model.
        /// </summary>
        private IGameModel model;
        private View view;

        private Vector3 targetItemPosition;
        private Vector3 screenPosition;
        private Camera mainCamera;
        private bool isTargetMode;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the last position of the mouse (in desktop) or the finger (in mobile)
        /// </summary>
        private Vector3 LastMousePos { get; set; }

        /// <summary>
        /// Gets or sets the position of the last item that was cutted by the player.
        /// </summary>
        private Vector3 LastCuttedItemPosition { get; set; }

        /// <summary>
        /// All items that overlaps the current position of the mouse
        /// </summary>
        private GameItem[] ItemsToCut { get; set; }

        /// <summary>
        /// Each time that this value is set to 0, the <see cref="Controller"/> checks the last combo of the player
        /// and resets the value to <see cref="Model.ComboCheckInterval"/>.
        /// </summary>
        private float NextComboTime { get; set; }
        /// <summary>
        /// The last value of <c>Time.timeScale</c> before the game enter on pause state
        /// </summary>

        ///<summary>
        /// The value of Time.timeScale before the game enter on pause state
        /// </summary>
        private float TimeScaleBeforePause { get; set; }

        /// <summary>
        /// Playing status of the game
        /// </summary>
        private bool IsPlaying { get; set; }

        /// <summary>
        /// Gets a value indicating whether the game is paused
        /// </summary>
        private bool IsPaused { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is a bomb item in the items hitted by the player in the current frame.
        /// </summary>
        private bool HasBombInItemsToCut => ItemsToCut.Any(item => item.ItemType == ItemTypes.Bomb);

        #endregion Properties

        #region Methods

        #region Unity

        private void Awake()
        {
            Instance = this;
            isAutoPlayMode = isAutoPlayMode && Application.isEditor;
            mainCamera = Camera.main;
            model = FindObjectOfType<Model>();
            view = FindObjectOfType<View>();

            model.AddObserver(view);
            model.NotifyObservers();
        }

        private void Start()
        {
            Application.targetFrameRate = 60;
            blade = Instantiate(blade);
            OnStart();
        }

        private void Update()
        {
            if (IsPlaying)
            {
                ProcessInput();
                NextComboTime -= Time.deltaTime;

                if (NextComboTime <= 0)
                {
                    NextComboTime = model.ComboCheckInterval;
                    ChechCombo();
                }

                if (model.CheckGameState())
                {
                    InvokeGameEndEvent();
                }
            }
        }

        #endregion Unity

        /// <summary>
        /// Starts the game and invokes <see cref="onGameStartCallback"/> event.
        /// </summary>
        public void OnStart()
        {

            model.OnStart();

            LaunchItems();

            onGameStartCallback?.Invoke();

            SoundManager.StopMusic();
            IsPlaying = true;
        }

        /// <summary>
        /// Ends the game and invokes <see cref="onGameEndCallback"/> event.
        /// </summary>
        public void OnEnd()
        {
            SoundManager.PlayEffect(R.audioclip.MetalGongSound);

            model.OnGameEnd();

            // Save visual prefs to not lose modified data.
            VP.Save();

            // Recycle all gameobject pools
            PoolManager.ResetAllPools();

            // Invokes all methods linked to this GameEndEvent.
            onGameEndCallback?.Invoke();
        }

        /// <summary>
        /// Pauses the game and invokes <see cref="onGamePausedCallback"/> event.
        /// </summary>
        public void OnPause()
        {
            IsPaused = !IsPaused;
            IsPlaying = !IsPaused;

            onGamePausedCallback?.Invoke();

            if (IsPaused)
            {
                TimeScaleBeforePause = Time.timeScale;
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = TimeScaleBeforePause;
            }
        }

        /// <summary>
        /// Starts launch items
        /// </summary>
        private void LaunchItems()
        {
            StartCoroutine(_LaunchItems());
        }

        private IEnumerator _LaunchItems()
        {
            yield return new WaitForSeconds(model.LaunchDelay);

            SoundManager.PlayEffect(R.audioclip.TempleBellSound);
            yield return new WaitForSeconds(1.0f);
            var count = 0;
            var launchInterval = 0.0f;
            var bombCount = 0;
            var minVelocity = 0.0f;
            var maxVelocity = 0.0f;
            var randomX = 0.0f;
            var randomVelocity = 0.0f;
            GameObject prefab;
            GameItem item;

            while (true)
            {
                count = Random.Range(model.MinItemToLaunch, model.MaxItemToLaunch);
                launchInterval = Random.Range(model.LaunchInterval.min, model.LaunchInterval.max);

                bombCount = 0;
                minVelocity = 0.0f;
                maxVelocity = 0.0f;
                prefabs.Shuffle();
                for (var i = 0; i < count; i++)
                {
                    minVelocity = 1.65f;
                    maxVelocity = 2.75f;
                    prefab = prefabs.Random();
                    if ((Random.value < model.BombProbability) && (bombCount < model.MaxBombToLaunch))
                    {
                        prefab = R.gameobject.Bomb;
                        bombCount++;
                    }

                    item = PoolManager.Pop(prefab).GetComponent<GameItem>();

                    randomX = Random.Range(-1.60f, 1.60f);
                    randomVelocity = Random.Range(minVelocity, maxVelocity);
                    item.Launch(randomVelocity, randomX, -randomX);

                    yield return new WaitForSeconds(launchInterval);
                }
                yield return new WaitForSeconds(model.LaunchRepeatRate);
            }
        }

        /// <summary>
        /// Gets a value indicating whether force of the slice gesture that starts at '<see cref="LastMousePos"/>' and ends at '<paramref name="mousePosition"/>'
        /// is enough to cut an item
        /// </summary>
        /// <param name="mousePosition">The current position of the mouse</param>
        /// <returns><c>true</c> if the force of the slice gesture is enough to cut an item <c>false</c> otherwise</returns>
        private bool IsRequiredSliceForce(Vector3 mousePosition)
        {
            return (mousePosition - LastMousePos).sqrMagnitude >= requiredSliceForce;
        }

        /// <summary>
        /// Checks and process player inputs
        /// </summary>
        private void ProcessInput()
        {
            if (Input.GetMouseButton(0) || isTargetMode)
            {
                var mousePosition = Input.mousePosition;
                if (isTargetMode)
                {
                    screenPosition = targetItemPosition;
                }
                else
                {
                    screenPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                }
                screenPosition.z = -1;

                if (isTargetMode || IsRequiredSliceForce(mousePosition))
                {
                    FindItemsAtMousePosition();

                    if (isTargetMode && HasBombInItemsToCut)
                    {
                        return;
                    }

                    var combo = 0;
                    blade.MoveTo(screenPosition);
                    foreach (var item in ItemsToCut)
                    {
                        if (!item.IsTouched)
                        {
                            LastCuttedItemPosition = item.transform.position;
                            item.DOHitAction();
                            blade.OnHitItem(item);
                            if (item.ItemType == ItemTypes.Wood)
                            {
                                GenerateFragments();
                                combo++;
                            }
                            view.PlayCameraAnimation();
                        }
                    }
                    model.LastCombo += combo;
                }
            }
            if (!isTargetMode)
            {
                LastMousePos = Input.mousePosition;
                return;
            }
            isTargetMode = false;
        }

        /// <summary>
        /// Finds all GameObjects with the layer <see cref="R.layers.GameItem"/> and the component
        /// GameItem that overlaps the current position of the mouse.
        /// </summary>
        private void FindItemsAtMousePosition()
        {
            ItemsToCut = Physics2D.OverlapPointAll(new Vector2(screenPosition.x, screenPosition.y), R.layers.GameItem)
                                        .Select(collider => collider.GetComponent<GameItem>())
                                        .ToArray();

        }

        /// <summary>
        /// Genarates wood fragments and deletes them after a certains delay
        /// </summary>
        private void GenerateFragments()
        {
            var fragment = R.gameobject.WoodFragments.FromPool();
            fragment.transform.localPosition = LastCuttedItemPosition;
            Infinity.After(2.5f, fragment.ToPool);
        }

        /// <summary>
        /// Checks if the player has cutted at least '<see cref="Model.numberNeededToMakeCombo"/>' items during the '<see cref="Model.ComboCheckInterval"/>' seconds.
        /// </summary>
        private void ChechCombo()
        {
            if (model.HasCombo)
            {
                model.AddScore(model.LastCombo);
                var message = string.Format("{0} WOOD\nCOMBO\nX{0}", model.LastCombo);
                View.ShowNotification(message, LastCuttedItemPosition);
                SoundManager.PlayEffect(R.audioclip.Combo, LastCuttedItemPosition);
                model.NotifyObservers();
            }
            model.LastCombo = 0;
        }

        /// <summary>
        /// Add a score.
        /// </summary>
        /// <param name="value">The value to add to the current score</param>
        public static void AddScore(int value)
        {
            Instance.model.AddScore(value);
        }

        /// <summary>
        /// Plays the falldown sound and tell the model that an element has fallen.
        /// </summary>
        /// <param name="item">The item</param>
        public static void OnItemFalldown(GameItem item)
        {
            if (!Instance.IsPlaying)
                return;

            Instance.model.OnItemFalldown(item);
        }

        /// <summary>
        /// Invokes the game end event
        /// </summary>
        public static void InvokeGameEndEvent()
        {
            Instance.IsPlaying = false;
            Instance.StopAllCoroutines();

            Infinity.Clear();

            Time.timeScale = 1.0f;

            Infinity.After(.5f, Instance.OnEnd);
        }

        /// <summary>
        /// Moves automatically the blade to the position of the item and cut hit.
        /// </summary>
        /// <param name="item">The item</param>
        public static void TargetItem(GameItem item)
        {
            Instance.targetItemPosition = item.transform.position;
            Instance.isTargetMode = true;

        }

        #endregion Methods

    }
}