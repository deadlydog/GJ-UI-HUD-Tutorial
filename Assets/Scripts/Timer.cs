using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;

    private void OnEnable()
    {
        time += Time.deltaTime;
    }
}
