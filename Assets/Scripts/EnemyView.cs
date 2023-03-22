using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView: MonoBehaviour
{
    [SerializeField] private Image _view;
    [SerializeField] private AnimationCurve _fading;

    private Coroutine _coroutine;

    public bool IsVisible => _view.color.a > 0.2;

    public void Init()
    {
        _view.color *= new Vector4(1, 1, 1, 0);
    }

    public void Show()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fading());
    }

    private IEnumerator Fading()
    {
        float elapsedTime = 0f;
        float time = 1.3f;
        Color color = _view.color;
        Color targetColor = color;
        targetColor.a = 0f;
        color.a = 1f;

        float lerp = 1;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            lerp = _fading.Evaluate(elapsedTime / time);
            color.a = lerp;
            _view.color = color;

            yield return null;
        }
    }
}
