using System.Collections;
using UnityEngine;

public class MB_MoveElement : MonoBehaviour
{

    [SerializeField] private RectTransform uiRoot;
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private Vector2 targetPosition;

    public void SlideTo(Vector2 targetPos)
    {
        StartCoroutine(SlideRoutine(targetPos));
    }
    public void SlideTo()
    {
        StartCoroutine(SlideRoutine(targetPosition));
    }

    private IEnumerator SlideRoutine(Vector2 targetPos)
    {
        Vector2 startPos = uiRoot.anchoredPosition;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / slideDuration;
            uiRoot.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }
    }
}