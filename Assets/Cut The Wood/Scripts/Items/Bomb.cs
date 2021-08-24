/************************************************************************************************************************************													   *
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/

using InfinityEngine;
using InfinityEngine.ResourceManagement;
using UnityEngine;

namespace CutTheWood
{

    /// <summary>    
    /// Bomb item script
    /// </summary>
    public class Bomb : GameItem
    {

        public override ItemTypes ItemType => ItemTypes.Bomb;

        protected override void OnLaunch() => SoundManager.PlayEffect(R.audioclip.LaunchBomb, transform.position);

        /// <summary>
        /// Ends the game when the player hit the bomb
        /// </summary>
        protected override void OnHit() => Controller.InvokeGameEndEvent();

    }

}