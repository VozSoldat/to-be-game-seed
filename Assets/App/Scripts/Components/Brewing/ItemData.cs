using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    [Range(-5, 5)]
    public int sweetness;

    [Range(-5, 5)]
    public int bitterness;

    [Range(-5, 5)]
    public int temperature;
}