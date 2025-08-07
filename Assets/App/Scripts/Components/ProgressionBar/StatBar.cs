using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
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

    public GameObject imagePrefab; 
    void Start()
    {

    }

    public void GenerateBar(int capacity, int filledValue)
    {
        ClearBar(filledBarRoot.transform);
        ClearBar(emptyBarRoot.transform);

        for (int i = 0; i < capacity; i++)
        {
            Sprite spriteEmpty = GetPartSprite(i, emptyLeft, emptyCenter, emptyRight, capacity);
            CreateImage(emptyBarRoot.transform, spriteEmpty);

            if (i < filledValue)
            {
                Sprite spriteFilled = GetPartSprite(i, filledLeft, filledCenter, filledRight, capacity);
                CreateImage(filledBarRoot.transform, spriteFilled);
            }
        }
    }

    public Sprite GetPartSprite(int index, Sprite left, Sprite center, Sprite right, int capacity)
    {
        if (index == 0) return left;
        if (index == capacity - 1) return right;
        return center;
    }

    public Sprite GetPartSprite(int index, Sprite left, Sprite center, Sprite right)
    {
        return GetPartSprite(index, left, center, right, 5);
    }

    public void CreateImage(Transform parent, Sprite sprite)
    {
        GameObject go = Instantiate(imagePrefab, parent);
        Image img = go.GetComponent<Image>();
        img.sprite = sprite;
    }

    public void ClearBar(Transform bar)
    {
        foreach (Transform child in bar)
            Destroy(child.gameObject);
    }
}
