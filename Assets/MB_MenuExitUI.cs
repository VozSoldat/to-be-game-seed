using UnityEngine;

public class MB_MenuExitUI : MonoBehaviour
{
    [SerializeField] private GameObject groupA;
    [SerializeField] private GameObject confirmationGroup;

    public void ExitMenu()
    {
        groupA.SetActive(false);
        confirmationGroup.SetActive(true);
    }

    public void NoButton()
    {
        groupA.SetActive(true);
        confirmationGroup.SetActive(false);
    }

    public void YesButton()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
