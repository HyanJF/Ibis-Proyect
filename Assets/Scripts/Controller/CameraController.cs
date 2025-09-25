using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float moveTime = 0.7f;
    public AnimationCurve aesingCurve;
    public IEnumerator MoveRoutineCoroutine(Vector3 targetPos)
    {
        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < moveTime)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveTime);
            float curveT = aesingCurve.Evaluate(t);
            transform.position = Vector3.Lerp(startPos, targetPos, curveT);
            yield return null;
        }

        transform.position = targetPos;
    }
}
