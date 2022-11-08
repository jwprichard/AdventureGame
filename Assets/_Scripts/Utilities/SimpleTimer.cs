using System;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{

    public event EventHandler<EventArgs> OnTimerElapsed;

    public bool isRunning;
    public float time;

    private bool autoReset;
    private float timer;

    public void Init(float time, bool autoReset = false)
    {
        timer = time;
        this.autoReset = autoReset;
        isRunning = true;
        this.autoReset = autoReset;
        time = 0;
    }

    public void Update()
    {
        time += Time.deltaTime;
        if (time > timer && isRunning)
        {
            TimerFinished();
            if (autoReset)
            {
                time = 0;
                isRunning = true;
            }
        }
    }

    private void TimerFinished()
    {
        OnTimerElapsed.Invoke(this, new EventArgs());
    }
}