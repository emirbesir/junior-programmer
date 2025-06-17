using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    private void Start()
    {
        ResumeTime();
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}
