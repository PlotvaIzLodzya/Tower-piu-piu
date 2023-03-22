using System.Collections;
using UnityEngine;

public class SonarWave: MonoBehaviour
{
    public void Init()
    {
        StartCoroutine(Expanding());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.View.Show();
        }
    }

    private IEnumerator Expanding()
    {
        float elapsedTime = 0f;
        float time = 1.5f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;

            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 10, elapsedTime / time);

            yield return null;
        }

        Destroy(gameObject);
    }
}
