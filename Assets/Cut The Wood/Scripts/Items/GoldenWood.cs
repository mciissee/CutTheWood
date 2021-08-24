/************************************************************************************************************************************
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/

using InfinityEngine;
using UnityEngine;

namespace CutTheWood
{
 

    /// <summary> 
    /// Golden Wood item script
    /// </summary>
    public class GoldenWood : Wood
    {
        private static Color textColor = Infinity.HexToColor("F0E9B5FF");

        protected override void OnHit()
        {
            base.OnHit();
            View.ShowNotification(string.Concat("GOLDEN WOOD\n+", point), transform.position, textColor);
        }
    }
}