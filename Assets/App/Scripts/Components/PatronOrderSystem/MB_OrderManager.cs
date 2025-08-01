using UnityEngine;

public class MB_OrderManager : MonoBehaviour
{
  [SerializeField] private MB_PatronOrderGenerator patronOrderGenerator;
  [SerializeField] private MB_BrewingStack brewingStack;
  [SerializeField] private MB_ShowScoreSubmit showScoreSubmit;
  public ItemData order;

    void OnEnable()
    {
        showScoreSubmit.OnScoreSubmittedHandler += Hasil;
    }

    public void GenerateOrder()
  {
    ItemData[] combination = patronOrderGenerator.GetCombinations();
    int totalCombination = combination.Length;
    order = combination[(Random.Range(0, totalCombination))];
    Debug.Log(order);
  }

  private int GetSimilarityScore(int a, int b)
  {
    int difference = Mathf.Abs(a - b);
    int score = 100 - (difference * 10);
    return Mathf.Clamp(score, 0, 100);
  }

  public int Hasil()
  {
    int totalBitterness = (int)brewingStack.TotalBitterness;
    int totalSweetness = (int)brewingStack.TotalSweetness;
    int totalTemperature = (int)brewingStack.TotalTemperature;

    int orderBitterness = order?.bitterness ?? 0;
    int orderSweetness = order?.sweetness ?? 0;
    int orderTemperature = order?.temperature ?? 0;

    int scoreBitterness = GetSimilarityScore(totalBitterness, orderBitterness);
    int scoreSweetness = GetSimilarityScore(totalSweetness, orderSweetness);
    int scoreTemperature = GetSimilarityScore(totalTemperature, orderTemperature);

    int nilai = (scoreSweetness + scoreBitterness + scoreTemperature) / 3;
    Debug.Log(scoreBitterness);
    Debug.Log(scoreSweetness);
    Debug.Log(scoreTemperature);
    Debug.Log(nilai);
    
    return nilai;
  }

}
