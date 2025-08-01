using UnityEngine;

public class StatBar : MonoBehaviour
{
    public GameObject Bar_1;
    public GameObject Bar_2;
    public GameObject Bar_3;
    public float stat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stat >= 1)
        {
            Bar_1.SetActive(true);
        }
        else
        {
            Bar_1.SetActive(false);
            
        }
        if (stat >= 2)
        {
            Bar_2.SetActive(true);
        }
        else{
            Bar_2.SetActive(false);
            
        }
        if (stat >= 3)
        {
            Bar_3.SetActive(true);
        }else
        {
            Bar_3.SetActive(false);
            
        }
        
        

    }
}
