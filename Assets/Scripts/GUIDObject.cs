using System;
using Unity.Collections;
using UnityEngine;

[Serializable]
public class GUIDObject: MonoBehaviour
{
    [ReadOnly, SerializeField] private string _guid;

    public string GUID => _guid;

    public void RegenerateGUID()
    {
        _guid = Guid.NewGuid().ToString();
    }
}
