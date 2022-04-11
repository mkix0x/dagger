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
        GetComponent<Health>().Died += OnDied;
        foreach (var sensor in sensors)
        {
            sensor.Triggered += OnSensorTriggered;
        }
    }

    private void OnDisable()
    {
        GetComponent<Health>().Died -= OnDied;
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

    private void OnDied()
    {
        var gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
        gem.SetExperience(givenExperience);
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
    private Gem gemPrefab;

    [SerializeField]
    private int givenExperience;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D body;
    private int direction;
    private ISensor[] sensors;
}
