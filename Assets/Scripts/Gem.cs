using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Experience experience))
            return;

        experience.Add(amount);
        Destroy(gameObject);
    }

    public void SetExperience(int amount)
    {
        this.amount = amount;
    }

    private int amount = 1;
}
