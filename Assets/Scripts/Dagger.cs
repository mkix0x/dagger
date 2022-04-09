using MoreMountains.Feedbacks;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(3);
            hitFeedback.PlayFeedbacks();
            Destroy(gameObject);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 5f);
        }
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