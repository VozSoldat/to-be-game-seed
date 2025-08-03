using UnityEngine;

public class MB_OrderManager : MonoBehaviour
{
    [SerializeField] private MB_PatronOrderGenerator patronOrderGenerator;
    [SerializeField] private MB_BrewingStack brewingStack;
    [SerializeField] private MB_ShowScoreSubmit showScoreSubmit;
    public ItemData order;
    public ItemData[] orderSourceItems;
    public int finalScore;

    void OnEnable()
    {
        showScoreSubmit.OnScoreSubmittedHandler += Hasil;
    }

    public void GenerateOrder()
    {
        CombinationResult[] combinations = patronOrderGenerator.GetCombinationsWithSources();
        int totalCombination = combinations.Length;
        var selectedCombination = combinations[Random.Range(0, totalCombination)];

        order = selectedCombination.combinedItem;
        orderSourceItems = selectedCombination.sourceItems;

        // Debug.Log($"Generated order: {order.itemName}");
        // Debug.Log($"Source items: {string.Join(", ", System.Array.ConvertAll(orderSourceItems, item => item.itemName))}");
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
        finalScore += nilai;
        Debug.Log(scoreBitterness);
        Debug.Log(scoreSweetness);
        Debug.Log(scoreTemperature);
        Debug.Log(nilai);

        return nilai;
    }
}
