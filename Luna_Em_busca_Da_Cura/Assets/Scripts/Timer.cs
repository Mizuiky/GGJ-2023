using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 0f;
    public bool IsPlay = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsPlay)
            timer += Time.deltaTime;
    }

    public void Play()
    {
        IsPlay = true;
    }

    public void Pause()
    {
        IsPlay = false;
    }

    public void AddTime(float timeAdd)
    {
        timer += timeAdd;
    }
}
