using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        TryGetComponent(out body);
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
    }

    private void Move()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = body.velocity;
        velocity.x = horizontal * moveSpeed;

        body.velocity = velocity;
        transform.eulerAngles = body.velocity.x switch
        {
            > 0 => Vector3.zero,
            < 0 => new Vector3(0, 180, 0),
            _ => transform.eulerAngles
        };
    }

    private void Jump()
    {
        Vector2 velocity = body.velocity;
        velocity.y = Mathf.Sqrt(desiredJumpHeight * -2 * Physics2D.gravity.y);
        body.velocity = velocity;
    }

    [SerializeField]
    private float desiredJumpHeight = 2;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D body;
}