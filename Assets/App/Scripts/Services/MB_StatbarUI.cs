using UnityEngine;
using UnityEngine.UI;

public class MB_BarUI : MonoBehaviour
{
    [SerializeField] private Image[] segments;

    public void UpdateBar(int value)
    {
        int clampedValue = Mathf.Clamp(value, 0, segments.Length);

        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].enabled = i < clampedValue;
        }
    }
}
