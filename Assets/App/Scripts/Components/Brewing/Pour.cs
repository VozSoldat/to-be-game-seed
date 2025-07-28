using UnityEngine;
[CreateAssetMenu(fileName = "Pour", menuName = "Scriptable Objects/Pour")]
public class Pour : ScriptableObject
{
    public string Name;
    public FloatReference Bitterness;
    public FloatReference Sweetness;
    public FloatReference Temperature;
}