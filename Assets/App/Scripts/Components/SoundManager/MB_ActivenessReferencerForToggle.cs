using UnityEngine;
using UnityEngine.UI;

public class MB_ActivenessReferencerForToggle : MonoBehaviour
{
    // [SerializeField] AudioSource audioSource;
    [SerializeField] Toggle toggle;
    [SerializeField] SO_BooleanVariable isSoundActive;

    void OnEnable()
    {
        isSoundActive.OnValueChanged += UpdateAudioSourceState;
    }

    void OnDisable()
    {
        isSoundActive.OnValueChanged -= UpdateAudioSourceState;
    }
    
    void UpdateAudioSourceState(bool isActive)
    {
        if (toggle != null)
        {
            toggle.isOn = isSoundActive.Value;
        }
    }
}