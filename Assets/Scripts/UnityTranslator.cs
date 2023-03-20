using UnityEngine;

public class UnityTranslator: MonoBehaviour
{
    [SerializeField] public CoroutineProvider _coroutineProvider;
    [SerializeField] public Creator _creator;

    public static CoroutineProvider CoroutineProvider { get; private set; }
    public static Creator Creator { get; private set; }

    private void Awake()
    {
        CoroutineProvider = _coroutineProvider;
        Creator = _creator;
    }
}
