using Core;

public class GameManager : Singleton<GameManager>
{
    public void Start()
    {
        RandomizeQuestItems();
    }

    public void RandomizeQuestItems()
    {
        ItemManager.Instance.RandomizeItems();
    }
}
