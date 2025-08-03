using UnityEngine;

[CreateAssetMenu(fileName = "SO_CharaDanPesan", menuName = "Scriptable Objects/SO_CharaDanPesan")]
public class SO_CharaDanPesan : ScriptableObject
{
    public string characterName;
    public Sprite staticSprite;
    public Animation idleAnimation;
    public Animation drinkAnimation;
    public ItemData characterOrder;
}
