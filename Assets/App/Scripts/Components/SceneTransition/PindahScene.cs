using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    // [SerializeField] Scene targetscene;
    [SerializeField] Timer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnEnable()
    {
        timer.OnTimerOutHandler += GantiScene;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GantiScene()
    {
        SceneManager.LoadScene("Tes");
    }
}
