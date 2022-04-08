using System;
using UnityEngine;

public class Cooldown
{
    public Cooldown(float cooldown, Action trigger, bool triggerOnStart = false)
    {
        this.cooldown = cooldown;
        this.trigger = trigger;

        if (triggerOnStart)
            nextTime = 0;
        else
            Reset();
    }

    public void Update()
    {
        if (Time.time > nextTime)
            trigger?.Invoke();
    }

    public void Reset()
    {
        nextTime = Time.time + cooldown;
    }

    private readonly float cooldown;
    private float nextTime;
    private readonly Action trigger;
}
