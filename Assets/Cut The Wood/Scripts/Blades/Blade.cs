/************************************************************************************************************************************
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Infinity Interactive Unity Asset Store catalog: http://u3d.as/riS	                                                                *
*************************************************************************************************************************************/

using UnityEngine;
using InfinityEngine.Extensions;
using InfinityEngine;

namespace CutTheWood
{
    /// <summary>
    /// Represents the default blade.
    /// </summary>
    public class Blade : MonoBehaviour
    {
        /// <summary>
        /// The minimum amount of time between swipe sounds play.
        /// </summary>
        [SerializeField] protected float timeBetweenSwipes = .4f;
        /// <summary>
        /// The speed of the blade
        /// </summary>
        [SerializeField] protected float speed = 30f;
        /// <summary>
        /// The sounds produced by the blade when it moves
        /// </summary>
        [SerializeField] protected AudioClip[] swipeSounds;

        /// <summary>
        /// Each time that this value is set to 0, the game play a random sound that represents the sound produced
        /// by slice gestures and resets the value to '<see cref="timeBetweenSwipes"/>'.
        /// </summary>
        private float nextBladeSoundTime;

        /// <summary>
        /// Called when the player hit an item, 
        /// you can uses this function to add extra point depending to the type of the or do anything you want.
        /// </summary>
        /// <param name="item">the item which the player hit</param>
        public virtual void OnHitItem(GameItem item)
        {

        }

        /// <summary>
        /// Moves the GameObject to the given position.
        /// The fact that the gameobject moves produces the trail renderer effect on screen.
        /// </summary>
        /// <param name="pos">The new position</param>
        public void MoveTo(Vector3 pos)
        {
            if (nextBladeSoundTime <= 0)
            {
                SoundManager.PlayEffect(swipeSounds.Random());
                nextBladeSoundTime = Controller.IsAutoPlayMode ? 1 : timeBetweenSwipes;
            }
            else
            {
                nextBladeSoundTime -= Time.deltaTime;
            }

            transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        }
    }
}