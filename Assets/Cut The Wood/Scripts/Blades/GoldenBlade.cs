
namespace CutTheWood
{
    /// <summary>
    /// A golden blade
    /// </summary>
    public class GoldenBlade : Blade
    {
        /// <summary>
        /// Add extra points to the model if the item is a <see cref="GoldenWood"/>
        /// </summary>
        /// <param name="item"></param>
        public override void OnHitItem(GameItem item)
        {
            base.OnHitItem(item);

            if(item is GoldenWood)
            {
                var extra = (item as GoldenWood).point * 2;
                Controller.AddScore(extra);
                View.ShowNotification("Extra point " + extra, item.transform.position);
            }
        }
    }
}
