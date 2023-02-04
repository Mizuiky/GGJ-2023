using UnityEngine;

public class ColectItem : MonoBehaviour
{
    public bool CanCollect;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            CanCollect = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            CanCollect = false;
    }
}
