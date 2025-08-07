using UnityEngine;

[CreateAssetMenu(fileName = "SO_Character", menuName = "Scriptable Objects/SO_Character", order = 1)]
public class SO_Character : ScriptableObject
{
    public string characterName;
    public Sprite staticSprite;
    public AnimationClip idleAnimation;
    public AnimationClip drinkAnimation;
    public RuntimeAnimatorController animatorController;
}