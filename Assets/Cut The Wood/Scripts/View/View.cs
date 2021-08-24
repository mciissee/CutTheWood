/************************************************************************************************************************************
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/

namespace CutTheWood
{

    using UnityEngine;
    using InfinityEngine.Extensions;
    using InfinityEngine.Interpolations;
    using InfinityEngine.DesignPatterns;
    using UnityEngine.UI;
    using InfinityEngine;
    using System;
    using InfinityEngine.Attributes;


    /// <summary>
    ///    View component of MVC Design pattern
    /// </summary>
    [OverrideInspector]
    public abstract class View : MonoBehaviour, Observer
    {

        #region Fields


        [Accordion("Game Over Menu"), SerializeField] protected Sequencer endGameUI;
        [Accordion("Game Over Menu"), SerializeField] protected Text endScoreLabel;
        [Accordion("Game Over Menu"), SerializeField] protected Text endBestScoreLabel;



        [Accordion("Pause"), SerializeField] protected Sequencer pauseUI;
        [Accordion("Pause"), SerializeField] protected Button pauseButton;
        [Accordion("Pause"), SerializeField] protected Button resumeButton;

        [Accordion("HUD"), SerializeField] protected Text scoreLabel;
        [Accordion("HUD"), SerializeField] protected Text bestScoreLabel;


        private Camera mainCamera;
        private Interpolable cameraInterpolation;
        private Interpolable bestScoreAnim;
        protected IGameModel model;

        public static NotificationOptions NotificationOption { get; set; }

        #endregion Fields

        #region Methods

        #region Unity

        private void OnEnable()
        {
            Controller.onGameStartCallback += OnStart;
            Controller.onGameEndCallback += OnEnd;
        }

        private void OnDisable()
        {
            Controller.onGameStartCallback -= OnStart;
            Controller.onGameEndCallback -= OnEnd;
        }

        protected virtual void Start()
        {
            mainCamera = mainCamera ?? Camera.main;
            Action<Interpolable> onComplete = (arg => mainCamera.orthographicSize = 1.0f);
            cameraInterpolation = mainCamera.DOOrtho(1, .7f, .1f).SetCached().OnComplete(onComplete);

            bestScoreAnim = bestScoreAnim ?? bestScoreLabel.rectTransform
                                                           .DOScale(Vector3.one, Vector3.one * 1.5f, .3f)
                                                           .SetRepeat(1, LoopTypes.Reverse).Start();

            NotificationOption = new NotificationOptions();
            NotificationOption.EntryDuration = .5f;
            NotificationOption.CloseDelay = 1.0f;
        }

        protected virtual void Update()
        {
            if (!cameraInterpolation.IsPlaying && Math.Abs(mainCamera.orthographicSize - 1.0f) > double.Epsilon)
            {
                mainCamera.orthographicSize = 1.0f;
            }
        }

        #endregion Unity

        /// <summary>
        /// Invoked when <see cref="Controller.OnStart"/> method is called.
        /// </summary>
        protected virtual void OnStart()
        {
            if (endGameUI.isActiveAndEnabled)
            {
                endGameUI.PlaySequenceWithName("Close");
            }
            if (pauseUI.isActiveAndEnabled)
            {
                pauseUI.PlaySequenceWithName("Close");
            }

            pauseButton.enabled = true;
            resumeButton.enabled = false;

            bestScoreLabel.text = $"Best {model.BestScore}";
        }

        /// <summary>
        /// Invoked when <see cref="Controller.OnEnd"/> method is called.
        /// </summary>
        protected virtual void OnEnd()
        {
            if (pauseUI.isActiveAndEnabled)
            {
                pauseUI.PlaySequenceWithName("Close");
            }

            pauseButton.enabled = false;
            resumeButton.enabled = false;

            mainCamera.orthographicSize = 1.0f;
            endGameUI.PlaySequenceWithName("Open");
        }

        /// <summary>
        /// Shakes the camera
        /// </summary>
        public void PlayCameraAnimation()
        {
            cameraInterpolation.Start();
        }

        /// <summary>
        /// Called when the method <c>NotifyObservers</c> of the model is invoked
        /// </summary>
        /// <param name="obj">The model</param>
        public virtual void OnChanged(object obj)
        {
            model = obj as IGameModel;

            scoreLabel.text = model.Score.ToString();
            if (model.Score > model.BestScore)
            {
                bestScoreLabel.text = $"Best {model.Score}";
                if (bestScoreAnim != null && !bestScoreAnim.IsPlaying)
                {
                    bestScoreAnim.Start();
                }
            }
        }

        public static QuickNotification ShowNotification(string message, Vector3 position)
        {
            var notification = QuickNotificationManager.CreateScalableNotication("Notification", NotificationOption);
            notification.TextColor = Infinity.HexToColor("E7A900FF");
            notification.ShowNotification(message, position);
            return notification;
        }

        public static QuickNotification ShowNotification(string message, Vector3 position, Color color)
        {
            var notification = QuickNotificationManager.CreateScalableNotication("Notification", NotificationOption);
            notification.TextColor = color;
            notification.ShowNotification(message, position);
            return notification;
        }

        public static QuickNotification ShowNotification(string message, Vector3 position, float closeDelay)
        {
            var delay = NotificationOption.CloseDelay;
            NotificationOption.CloseDelay = closeDelay;
            var notification = QuickNotificationManager.CreateScalableNotication("Notification", NotificationOption, 1.5f);
            notification.TextColor = Infinity.HexToColor("E7A900FF");
            notification.ShowNotification(message, position);
            NotificationOption.CloseDelay = delay;
            return notification;
        }

        public static QuickNotification ShowNotification(string message, Vector3 position, float closeDelay, Color color)
        {
            var delay = NotificationOption.CloseDelay;
            NotificationOption.CloseDelay = closeDelay;
            var notification = QuickNotificationManager.CreateScalableNotication("Notification", NotificationOption, 1.5f);
            notification.TextColor = color;
            notification.ShowNotification(message, position);
            NotificationOption.CloseDelay = delay;
            return notification;
        }

        #endregion Methods

    }

}