using UnityEngine;

public class Player : MonoBehaviour
{
    //TODO: Input buffer, ground detection, dust particles, player teleport on falling bottom, enemy auto-spawner
    //TODO: Camera rotate due to the "weight" of the player in one of the sides
    //TODO: Stomp enemy head
    //TODO: Enraged enemy

    private void Awake()
    {
        TryGetComponent(out body);
    }

    private void FixedUpdate()
    {
        if (body.velocity.y <= -1f)
            IncreaseFallSpeed();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();

        if (Input.GetKeyUp(KeyCode.UpArrow))
            ReleaseJump();
    }

    private void ReleaseJump()
    {
        if (body.velocity.y < 1f)
            return;

        var velocity = body.velocity;
        velocity.y /= releaseJumpClampIntensity;
        body.velocity = velocity;
    }

    private void IncreaseFallSpeed()
    {
        var velocity = body.velocity;
        velocity.y += velocity.y * (1 + fallModifier) * Time.fixedDeltaTime;
        body.velocity = velocity;
    }

    private void Move()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var velocity = body.velocity;
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
        var velocity = body.velocity;
        velocity.y = Mathf.Sqrt(desiredJumpHeight * -2 * Physics2D.gravity.y);
        body.velocity = velocity;
    }

    [SerializeField]
    private float desiredJumpHeight = 2;

    [SerializeField]
    private float fallModifier;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D body;
    [SerializeField]
    private float releaseJumpClampIntensity = 2f;
}
