using UnityEngine;

public class MB_GradeSystem : MonoBehaviour
{
    [SerializeField] private MB_BrewingStack brewingStack;
    [SerializeField] private SO_CharaDanPesan charaDanPesan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    int GradeInput(int target, int input)
    {
        target = Mathf.Clamp(target, 0, 5);
        input = Mathf.Clamp(input, 0, 5);

        if (target == input)
            return 50;

        int distance = Mathf.Abs(target - input);
        float normalized = distance / 5f;

        float penaltyCurve = Mathf.Pow(normalized, 2.5f);

        float score = Mathf.Lerp(-10f, -100f, penaltyCurve);

        return Mathf.RoundToInt(score);
    }



    public void Hasil()
    {
        int totalBitterness = (int)brewingStack.TotalBitterness;
        int totalSweetness = (int)brewingStack.TotalSweetness;
        int totalTemperature = (int)brewingStack.TotalTemperature;

        int orderBitterness = charaDanPesan.characterOrder?.bitterness ?? 0;
        int orderSweetness = charaDanPesan.characterOrder?.sweetness ?? 0;
        int orderTemperature = charaDanPesan.characterOrder?.temperature ?? 0;

        int scoreBitterness = GradeInput(totalBitterness, orderBitterness);
        int scoreSweetness = GradeInput(totalSweetness, orderSweetness);
        int scoreTemperature = GradeInput(totalTemperature, orderTemperature);

        int nilai = (scoreSweetness + scoreBitterness + scoreTemperature) / 3;
        // finalScore += nilai;
        Debug.Log("Bitterness Score: " + scoreBitterness);
        Debug.Log("Sweetness Score: " + scoreSweetness);
        Debug.Log("Temperature Score:" + scoreTemperature);
        Debug.Log("Total Nilai: " + nilai);

        // return nilai;
    }
}
