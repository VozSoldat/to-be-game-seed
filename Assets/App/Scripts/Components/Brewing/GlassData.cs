using UnityEngine;

[System.Serializable]
public class GlassOption
{
    public string name;
    public Sprite glassImage;
    public int capacity;
}

// [JANGAN DIUBAH, NANTI AKU BENERIN] 

[CreateAssetMenu(fileName = "New Glass", menuName = "Items/Glass")]
public class GlassData : ItemData
{
    public int maxCapacity;
    public Sprite glassSprite;
    private void OnValidate()
    {
        category = ItemCategory.Glass;
    }
}