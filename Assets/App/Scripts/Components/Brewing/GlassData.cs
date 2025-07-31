using UnityEngine;

[System.Serializable]
public class GlassOption
{
    public string name;
    public Sprite glassImage;
    public int capacity;
}

[CreateAssetMenu(fileName = "New Glass", menuName = "Items/Glass")]
public class GlassData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int maxCapacity;

}