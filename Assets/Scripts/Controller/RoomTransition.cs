using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoomTransition : MonoBehaviour
{
    [Header("Panel de transición")]
    public RectTransform blackPanel;
    public Image blackImage;
    public float transitionTime = 0.7f;
    public AnimationCurve easingCurve;

    [Header("Referencias")]
    public CameraController cameraController;

    private Vector2 hiddenPos;
    private Vector2 visiblePos;

    private Transform currentRoomTarget;

    public Transform initialRoom;

    private void Start()
    {
        SwitchRoomWithTransition(initialRoom);

        hiddenPos = new Vector2(0, -Screen.height);
        visiblePos = Vector2.zero;

        blackPanel.anchoredPosition = hiddenPos;

        if (blackImage != null )
        {
            blackImage.color = new Color(0, 0, 0, 0); 
        }
    }

    public void SwitchRoomWithTransition(Transform targetCamera)
    {
        if (currentRoomTarget == targetCamera)
        {
            Debug.Log("Ya estás en esta sala, no se activa esta mamada");
            return;
        }

        StartCoroutine(TransitionRoutine(targetCamera));
    }

    private IEnumerator TransitionRoutine(Transform targetCamera)
    {
        yield return StartCoroutine(MoveAndFade(hiddenPos, visiblePos, 0f, 1f));

        if (cameraController != null && targetCamera != null)
        {
            yield return StartCoroutine(cameraController.MoveRoutineCoroutine(targetCamera.position));
        }

        currentRoomTarget = targetCamera;

        yield return StartCoroutine(MoveAndFade(visiblePos , visiblePos, 1f, 0f));
    }    

    private IEnumerator MoveAndFade(Vector2 startPos, Vector2 endPos, float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color imgColor = blackImage != null ? blackImage.color : Color.black;

        while (elapsed < transitionTime)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / transitionTime);
            float curveT = easingCurve.Evaluate(t);

            blackPanel.anchoredPosition = Vector2.Lerp(startPos, endPos, curveT);

            if (blackImage != null)
            {
                blackImage.color = new Color(
                    imgColor.r,
                    imgColor.g,
                    imgColor.b,
                    Mathf.Lerp(startAlpha, endAlpha, curveT)
                );
            }

            yield return null;
        }

        blackPanel.anchoredPosition = endPos;
        if (blackImage != null)
            blackImage.color = new Color(imgColor.r, imgColor.g, imgColor.b, endAlpha);
    }
}
