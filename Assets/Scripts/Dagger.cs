using UnityEngine;

public class Dagger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        enabled = false;
        Destroy(gameObject, 5f);
    }

    public void Launch(float force)
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * force;
    }
}
