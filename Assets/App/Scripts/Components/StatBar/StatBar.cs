using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [Header("Values")]
    public int maxValue = 5;   
    [Range(0, 5)] public int currentValue = 5;

    [Header("Filled Sprites")]
    public Sprite filledLeft;
    public Sprite filledCenter;
    public Sprite filledRight;

    [Header("Empty Sprites")]
    public Sprite emptyLeft;
    public Sprite emptyCenter;
    public Sprite emptyRight;

    [Header("UI Prefab References")]
    public GameObject filledBarRoot;
    public GameObject emptyBarRoot;

    public GameObject imagePrefab; // simple Image prefab for left, center, right parts

    void Start()
    {
        GenerateBar();
    }

    public void SetValue(int value)
    {
        currentValue = Mathf.Clamp(value, 0, maxValue);
        GenerateBar();
    }

    public void GenerateBar()
    {
        ClearBar(filledBarRoot.transform);
        ClearBar(emptyBarRoot.transform);

        for (int i = 0; i < maxValue; i++)
        {
            // Create empty
            Sprite spriteEmpty = GetPartSprite(i, emptyLeft, emptyCenter, emptyRight);
            CreateImage(emptyBarRoot.transform, spriteEmpty);

            // Create filled if within currentValue
            if (i < currentValue)
            {
                Sprite spriteFilled = GetPartSprite(i, filledLeft, filledCenter, filledRight);
                CreateImage(filledBarRoot.transform, spriteFilled);
            }
        }
    }

    Sprite GetPartSprite(int index, Sprite left, Sprite center, Sprite right)
    {
        if (index == 0) return left;
        if (index == maxValue - 1) return right;
        return center;
    }

    void CreateImage(Transform parent, Sprite sprite)
    {
        GameObject go = Instantiate(imagePrefab, parent);
        Image img = go.GetComponent<Image>();
        img.sprite = sprite;
    }

    void ClearBar(Transform bar)
    {
        foreach (Transform child in bar)
            Destroy(child.gameObject);
    }
}
