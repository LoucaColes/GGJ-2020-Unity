using System;
using System.Collections;
using System.Collections.Generic;

public class Timer
{
    private float duration;
    private float timer;

    private bool resetOnFinish;

    public event Action OnTimerEnd;

    public Timer(float _duration, bool _resetOnFinish)
    {
        duration = _duration;
        timer = duration;
        resetOnFinish = _resetOnFinish;
    }

    public void Tick(float _deltaTime)
    {
        if (timer == 0) { return; }

        timer -= _deltaTime;

        // If timer is finished
        if (isTimerFinished())
        {
            // If there are any listeners then invoke the event
            OnTimerEnd?.Invoke();
        }
    }

    private bool isTimerFinished()
    {
        if (timer < 0)
        {
            if (resetOnFinish)
            {
                timer = duration;
            }
            else
            {
                timer = 0;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
