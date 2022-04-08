using System.Collections;
using MoreMountains.Tools;

public class MKISquashAndStretch : MMSquashAndStretch
{
    private void Awake()
    {
        defaultSpringValue = Spring;
        Spring = false;
    }

    protected override void Initialization()
    {
        base.Initialization();
        if (defaultSpringValue)
            StartCoroutine(ReenableSpringRoutine());
    }

    private IEnumerator ReenableSpringRoutine()
    {
        yield return null;
        Spring = true;
    }

    private bool defaultSpringValue;
}
