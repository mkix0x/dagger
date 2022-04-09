using System;
using UnityEngine;

public class WallSensor : MonoBehaviour, ISensor
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Triggered?.Invoke();
    }

    public event Action Triggered;
}

public interface ISensor
{
    event Action Triggered;
}
