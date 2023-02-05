
public class ItemCollectable : ItemCollectableBase
{
    public override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.NotifyItemManager(_type);
    }
}
