using MoreMountains.Feedbacks;
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
        var dagger = Instantiate(daggerPrefab, castingPoint.position, castingPoint.rotation);
        dagger.Launch(throwForce);
        cooldown.Reset();
        castFeedback.PlayFeedbacks();
    }

    [SerializeField]
    private int attacksPerSecond;

    [SerializeField]
    private MMF_Player castFeedback;

    [SerializeField]
    private Transform castingPoint;

    [SerializeField]
    private Dagger daggerPrefab;

    [SerializeField]
    private float throwForce;

    private Cooldown cooldown;
}
