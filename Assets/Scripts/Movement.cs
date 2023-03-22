using System.Collections;
using UnityEngine;

public class Movement
{
    public float Speed { get; private set; }
    public float Multiplier { get; private set; } = 1f;
    public bool CanMove { get; private set; }

    public void SetSpeedMultiplier(float value)
    {
        Multiplier = value;
    }

    public void Stop()
    {
        CanMove = false;
    }

    public void Move(Transform mover, Transform point, float speed)
    {
        Speed = speed;
        CanMove = true;
        UnityTranslator.CoroutineProvider.StartCoroutine(MoveToPoint(mover, point));
    }

    private IEnumerator MoveToPoint(Transform mover, Transform point)
    {
        float speed = 0;
        Vector3 targetPosition = point.position;

        while (CanMove)
        {
            speed = Time.deltaTime *Speed *Multiplier;

            mover.transform.position = Vector3.MoveTowards(mover.position, targetPosition, speed);

            yield return null;
        }
    }
}

