using UnityEngine;

public static class Helper
{
    public static T Either<T>(T a, T b) => Random.value < 0.5f ? a : b;
    
    public static bool LayerInLayerMask(int layer, LayerMask layerMask)
    {
        return ((1 << layer) & layerMask) != 0;
    }

    public static bool Contains(this LayerMask layerMask, int layer)
    {
        return LayerInLayerMask(layer, layerMask);
    }
}
