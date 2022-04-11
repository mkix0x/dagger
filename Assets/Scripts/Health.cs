using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void TakeDamage(int amount)
    {
        if (current - amount <= 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }

    private int current;
    public event Action Died;
}
