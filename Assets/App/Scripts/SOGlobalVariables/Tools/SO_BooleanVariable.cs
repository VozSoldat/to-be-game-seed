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
        Value = value;
        NotifyValueChanged();
    }

    public void SetValue(SO_BooleanVariable value)
    {
        Value = value.Value;
        NotifyValueChanged();
    }

    public Action OnValueChanged;

    public void NotifyValueChanged()
    {
        OnValueChanged?.Invoke();
    }
}