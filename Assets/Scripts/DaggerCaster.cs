using UnityEngine;

public class DaggerCaster : MonoBehaviour
{
    private void Start()
    {
        cooldown = new Cooldown(1f / attacksPerSecond, Cast);
    }

    private void Update()
    {
        cooldown.Update();
    }

    private void Cast()
    {
        Dagger dagger = Instantiate(daggerPrefab, castingPoint.position, castingPoint.rotation);
        dagger.Launch(throwForce);
        cooldown.Reset();
    }

    [SerializeField]
    private int attacksPerSecond;

    [SerializeField]
    private Transform castingPoint;

    [SerializeField]
    private Dagger daggerPrefab;

    [SerializeField]
    private float throwForce;

    private Cooldown cooldown;
}
