using MoreMountains.Feedbacks;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
            health.TakeDamage(damage);

        hitFeedback.PlayFeedbacks();
        Destroy(gameObject);
    }

    public void Launch(float force)
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * force;
    }

    [SerializeField]
    private int damage = 3;

    [SerializeField]
    private MMF_Player hitFeedback;
}
