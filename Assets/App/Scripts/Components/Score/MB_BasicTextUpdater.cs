using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MB_BasicTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private SO_GradeScore GradeScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateText(GradeScore.GetCurrentScore());
    }

    /// <summary>
    /// Updates the text with the provided value
    /// </summary>
    /// <param name="value">The value to display</param>
    public void UpdateText(string value)
    {
        if (tmpText != null)
        {
            tmpText.text = value;
        }
    }

    /// <summary>
    /// Updates the text with the provided integer value
    /// </summary>
    /// <param name="value">The integer value to display</param>
    public void UpdateText(int value)
    {
        UpdateText(value.ToString());
    }

    /// <summary>
    /// Updates the text with the provided float value
    /// </summary>
    /// <param name="value">The float value to display</param>
    public void UpdateText(float value)
    {
        UpdateText(value.ToString());
    }
}
