using UnityEngine;

public class Health : MonoBehaviour
{
    public void TakeDamage(int amount)
    {
        if (current - amount <= 0)
            Destroy(gameObject);
    }

    private int current;
}
