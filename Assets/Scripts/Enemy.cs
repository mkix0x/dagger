using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Awake()
    {
        TryGetComponent(out body);
        direction = Helper.Either(-1, 1);
        sensors = GetComponentsInChildren<ISensor>();
    }

    private void OnEnable()
    {
        foreach (var sensor in sensors)
        {
            sensor.Triggered += OnSensorTriggered;
        }
    }

    private void OnDisable()
    {
        foreach (var sensor in sensors)
        {
            sensor.Triggered -= OnSensorTriggered;
        }
    }

    private void FixedUpdate()
    {
        var velocity = body.velocity;
        velocity.x = direction * moveSpeed;
        body.velocity = velocity;

        Flip();
        
        if (body.position.y > World.BottomHeightLimit)
            return;

        var position = transform.position;
        position.y = World.TopHeightLimit;
        transform.position = position;
        
        
    }

    private void Flip()
    {
        transform.eulerAngles = body.velocity.x switch
        {
            > 0 => Vector3.zero,
            < 0 => new Vector3(0, 180, 0),
            _ => transform.eulerAngles
        };
    }

    private void OnSensorTriggered()
    {
        direction = -direction;
    }

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D body;
    private int direction;
    private ISensor[] sensors;
}

internal static class World
{
    public const float BottomHeightLimit = -11;
    public const float TopHeightLimit = 11;
}

public static class Helper
{
    public static T Either<T>(T a, T b) => Random.value < 0.5f ? a : b;
}
