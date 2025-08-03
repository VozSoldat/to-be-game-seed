using UnityEngine;

public class MB_SoundActiveness : MonoBehaviour
{
    [SerializeField] private SO_BooleanVariable isActive;
    [Header("Reset Settings")]
    [SerializeField] bool resetToDefault = false;
    [SerializeField] bool defaultValue = true;

    void Start()
    {
        if (resetToDefault)
            isActive.SetValue(defaultValue);
    }
    public void SetSoundActive(bool value)
    {
        isActive.SetValue(value);
    }
    public void ToggleSoundActive()
    {
        isActive.SetValue(!isActive.Value);
    }
    

}