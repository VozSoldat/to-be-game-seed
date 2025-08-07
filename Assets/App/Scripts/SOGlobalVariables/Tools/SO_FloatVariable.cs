using UnityEngine;

namespace ToolingSO.Tools
{


    [CreateAssetMenu(fileName = "SO_FloatVariable", menuName = "Scriptable Objects/SO_FloatVariable")]
    public class SO_FloatVariable : UnityEngine.ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DesignerDescription = "";
#endif
        public float Value;
        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetValue(SO_FloatVariable value)
        {
            Value = value.Value;
        }
        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(SO_FloatVariable amount)
        {
            Value += amount.Value;
        }
    }
}