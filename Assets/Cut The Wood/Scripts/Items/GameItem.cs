/************************************************************************************************************************************													   *
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/

namespace CutTheWood
{
    using InfinityEngine;
    using InfinityEngine.Extensions;
    using UnityEngine;

    /// <summary>    
    /// Base Class of all game items
    /// </summary>
    public abstract class GameItem : MonoBehaviour
    {

        #region Fields

        private const float GRAVITY = 2.0f;
        private float lastFrameYpos;
        private float currentFrameYPos;

        /// <summary>
        /// The vertical velocity of the item
        /// </summary>
        protected float verticalVelocity;

        /// <summary>
        /// The speed of the item
        /// </summary>
        protected float speed;

        /// <summary>
        /// The sprite renderer of the item
        /// </summary>
        protected SpriteRenderer spriteRenderer;


        /// <summary>
        /// The particle system of the item
        /// </summary>
        [SerializeField] protected GameObject particle;

        /// <summary>
        /// Sound to play when the player hit the item
        /// </summary>
        [SerializeField] protected AudioClip onHitSound;

        /// <summary>
        /// Gets a value indicating if the item is touched by the player
        /// </summary>
        public bool IsTouched { get; protected set; }

        /// <summary>
        /// The type of the item
        /// </summary>
        public abstract ItemTypes ItemType { get; }

        /// <summary>
        /// Gets a value indicating indicating if the item is falling down
        /// </summary>
        public bool IsFallingDown => currentFrameYPos < lastFrameYpos;

        #endregion Fields

        #region Methods

        private void Update()
        {
            verticalVelocity -= GRAVITY * Time.deltaTime;

            currentFrameYPos = transform.position.y;
            transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;

            if (Controller.IsAutoPlayMode && IsFallingDown && ItemType == ItemTypes.Wood)
            {
                Controller.TargetItem(this);
            }

            if (transform.position.y <= -1)
            {
                OnFallDown();
                gameObject.ToPool();
            }

            lastFrameYpos = currentFrameYPos;
        }

        /// <summary>
        /// Launchs the item from the bottom of the screen
        /// </summary>
        /// <param name="velocity">the vertical velocity of this item</param>
        /// <param name="speed">the speed of this item</param>
        /// <param name="xStart">the starts position of this item on x axis</param>
        public virtual void Launch(float velocity, float speed, float xStart)
        {
            this.verticalVelocity = velocity;
            this.speed = speed;

            transform.position = new Vector3(xStart, 0, 0);

            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
            }

            OnLaunch();

            spriteRenderer.enabled = true;
            if (particle != null)
            {
                particle.SetActive(false);
            }

            IsTouched = false;
            lastFrameYpos = currentFrameYPos = transform.position.y;
        }

        /// <summary>
        /// Invokes <see cref="OnHit"/> method.
        /// </summary>
        public virtual void DOHitAction()
        {
            if (IsTouched)
                return;

            SlowDown();

            AudioSource.PlayClipAtPoint(onHitSound, transform.position);

            spriteRenderer.enabled = false;

            if (particle != null)
            {
                particle.SetActive(true);
            }

            OnHit();

            IsTouched = true;
        }

        /// <summary>
        /// Called when the item is launched
        /// </summary>
        protected virtual void OnLaunch() { }

        /// <summary>
        /// Called when the item fall down
        /// </summary>
        protected virtual void OnFallDown() { }

        /// <summary>
        /// Called when the player hit the item
        /// </summary>
        protected virtual void OnHit() { }

        /// <summary>
        /// Slow down the velocity of the item
        /// </summary>
        protected void SlowDown()
        {
            if (verticalVelocity <= 0.5f)
            {
                verticalVelocity = 0.5f;
                speed = speed * 0.5f;
            }
        }

        #endregion Methods

    }
}