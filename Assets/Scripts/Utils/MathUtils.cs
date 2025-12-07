using UnityEngine;

public class MathUtils
{
    public static float MirroredValueNormalize(float value, float maxValue)
    {
        value = Mathf.Clamp01(value / maxValue);

        return 1f - value;
    }
}
