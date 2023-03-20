using UnityEngine;

public class Creator: MonoBehaviour
{
    public UnityEngine.Object Create(UnityEngine.Object original, Vector3 position, Quaternion rotation)
    {
        return Instantiate(original, position, rotation);
    }
}
