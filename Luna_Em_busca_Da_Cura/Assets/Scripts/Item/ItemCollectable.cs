
public class ItemCollectable : ItemCollectableBase
{
    public override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.NotifyUiController(_type);
    }
}
