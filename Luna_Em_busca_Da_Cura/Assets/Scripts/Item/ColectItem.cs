using UnityEngine;

public class ColectItem : MonoBehaviour
{
    [SerializeField]
    private ItemCollectable _item;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _item.OnCollect();       
    }
}
