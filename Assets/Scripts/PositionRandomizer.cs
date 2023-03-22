using UnityEngine;

public class PositionRandomizer
{
    public Vector3 GetRandomPosition(float minRadius, float maxRadius)
    {
        float x = GetRandomVectorValue(minRadius, maxRadius);
        float y = GetRandomVectorValue(minRadius, maxRadius);
        //float z = GetRandomVectorValue(minRadius, maxRadius);

        return new Vector3(x, y, 0);
    }

    private float GetRandomVectorValue(float minRadius, float maxRadius)
    {
        float sign = Random.Range(0, 2) * 2 - 1;
        return Random.Range(sign * minRadius, sign * maxRadius);
    }
}

