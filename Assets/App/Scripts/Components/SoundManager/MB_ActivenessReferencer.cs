using UnityEngine;

public class MB_ActivenessReferencer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
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
        if (audioSource != null)
        {
            audioSource.mute = !isSoundActive.Value;
        }
    }
}