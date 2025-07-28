using UnityEngine;
[CreateAssetMenu(fileName = "Pour", menuName = "Scriptable Objects/Pour")]
public class SO_Pour : ScriptableObject
{
    public string Name;
    public FloatReference Bitterness;
    public FloatReference Sweetness;
    public FloatReference Temperature;
}