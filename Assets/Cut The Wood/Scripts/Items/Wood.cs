/************************************************************************************************************************************
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/

namespace CutTheWood
{
    using UnityEngine;
    using InfinityEngine.ResourceManagement;
    using InfinityEngine;

    /// <summary> 
    /// Wood item script
    /// </summary>
    public class Wood : GameItem
    {

        [SerializeField] protected GameObject slicedWood;

        ///<summary>
        ///The number of point reported by the item when the player hit it.
        /// </summary>
        [SerializeField] public int point = 1;

        public override ItemTypes ItemType => ItemTypes.Wood;

        protected override void OnLaunch()
        {
            SoundManager.PlayEffect(R.audioclip.LaunchWood, transform.position);
            slicedWood.SetActive(false);
        }

        /// <summary>
        /// Removes one life when the item fall down and active the particle effect of the item
        /// </summary>
        protected override void OnFallDown()
        {
            if (!IsTouched)
            {
                AudioSource.PlayClipAtPoint(R.audioclip.Falldown, Vector3.zero);
                Controller.OnItemFalldown(this);
            }
            particle.SetActive(false);
        }

        /// <summary>
        /// Plays the cut animation of the item and increments the score of the player by <see cref="point"/>
        /// </summary>
        protected override void OnHit()
        {
            Controller.AddScore(point);
            slicedWood.SetActive(true);
        }
    }
}