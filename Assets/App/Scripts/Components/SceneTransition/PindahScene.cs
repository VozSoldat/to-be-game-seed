using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    // [SerializeField] Scene targetscene;
    [SerializeField] string targetScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void GantiScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
