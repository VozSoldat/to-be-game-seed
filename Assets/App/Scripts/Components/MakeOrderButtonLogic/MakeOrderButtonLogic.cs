using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeOrderButtonLogic : MonoBehaviour
{
    public void OnMakeOrderButtonClicked()
    {
        SceneManager.LoadScene("Brewing");
    }
}
