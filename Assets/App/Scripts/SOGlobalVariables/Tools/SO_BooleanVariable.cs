using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_BooleanVariable", menuName = "Scriptable Objects/SO_BooleanVariable", order = 0)]
public class SO_BooleanVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DesignerDescription = "";
#endif
    public bool Value;
    public void SetValue(bool value)
    {
        // Only trigger the event if the value is actually changing.
        if (Value == value)
        {
            return;
        }
        Value = value;
        // NotifyValueChanged();
        OnValueChanged?.Invoke(value);

    }

    public void SetValue(SO_BooleanVariable value)
    {
        Value = value.Value;
        // OnValueChanged?.Invoke(Value);
    }

    public Action<bool> OnValueChanged;

    // public void NotifyValueChanged()
    // {
    //     OnValueChanged?.Invoke();
    // }
}