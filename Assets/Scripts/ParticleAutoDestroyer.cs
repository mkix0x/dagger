using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!enabled || particleSystem.IsAlive())
            return;

        Destroy(gameObject);
    }

    private new ParticleSystem particleSystem;
}
