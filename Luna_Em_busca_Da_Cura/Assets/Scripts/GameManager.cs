using Core;
using NaughtyAttributes;
public class GameManager : Singleton<GameManager>
{
    public void Start()
    {
        
    }

    [Button]
    public void RandomizeQuestItems()
    {
        ItemManager.Instance.RandomizeItems();
    }
}
