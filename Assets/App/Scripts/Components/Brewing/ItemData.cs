using UnityEngine;

public enum ItemCategory
{
    Glass,
    Coffee,
    ElementalStone,
    Milk,
    MagicItem
}

public enum ItemBuff
{
    SharpInstinct,
    CreativitySpark,
    CalmMind,
    MindClarity
}

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    public VisualRepresentation visualRepresentation; 

    public ItemCategory category;

    public Color stackColor = Color.white;

    [Range(-5, 5)]
    public int sweetness;

    [Range(-5, 5)]
    public int bitterness;

    [Range(-5, 5)]
    public int temperature;

    public ItemBuff[] itemBuffs;
}