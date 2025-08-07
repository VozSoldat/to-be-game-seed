using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahSceneWithTimer : PindahScene
{
    // [SerializeField] Scene targetscene;
    [SerializeField] Timer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        timer.OnTimerOutHandler += GantiScene;

    }

    void OnDisable()
    {
        timer.OnTimerOutHandler -= GantiScene;
    }


}
