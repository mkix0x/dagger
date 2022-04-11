using System;
using UnityEngine;

public class WallSensor : MonoBehaviour, ISensor
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!layerMask.Contains(other.gameObject.layer))
            return;

        Triggered?.Invoke();
    }

    public event Action Triggered;

    [SerializeField]
    private LayerMask layerMask;
}

public interface ISensor
{
    event Action Triggered;
}
