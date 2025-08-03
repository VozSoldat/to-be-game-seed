using UnityEngine;
using Esper.ESave;
public class MB_GradeSystem : MonoBehaviour
{
    [SerializeField] private MB_BrewingStack brewingStack;
    [SerializeField] private SO_CharaDanPesan charaDanPesan;
    [SerializeField] private SO_GradeScore gradeScore;


    // [SerializeField] private SaveFileSetup saveFileSetup; // Reference to SaveFileSetup
    // private SaveFile saveFile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Try to get the SaveFileSetup component
        // if (saveFileSetup == null)
        // {
        //     saveFileSetup = GetComponent<SaveFileSetup>();

        //     // If still null, try to find it in the scene
        //     if (saveFileSetup == null)
        //     {
        //         saveFileSetup = FindObjectOfType<SaveFileSetup>();
        //         if (saveFileSetup == null)
        //         {
        //             Debug.LogError("SaveFileSetup component not found. Please add it to this GameObject or reference it in the Inspector.");
        //             return;
        //         }
        //     }
        // }

        // saveFile = saveFileSetup.GetSaveFile();
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

    int GradeBuff()
    {
        int buffScore = 0;
        ItemBuff[] playerBuffs = brewingStack.GetBuffs();
        ItemBuff[] targetBuffs = charaDanPesan.characterOrder?.itemBuffs ?? new ItemBuff[0];

        foreach (ItemBuff playerBuff in playerBuffs)
        {
            bool buffMatched = false;
            foreach (ItemBuff targetBuff in targetBuffs)
            {
                if (playerBuff == targetBuff)
                {
                    buffScore += 10;
                    buffMatched = true;
                    break;
                }
            }

            if (!buffMatched)
            {
                buffScore -= 5;
            }
        }

        foreach (ItemBuff targetBuff in targetBuffs)
        {
            bool buffFound = false;
            foreach (ItemBuff playerBuff in playerBuffs)
            {
                if (playerBuff == targetBuff)
                {
                    buffFound = true;
                    break;
                }
            }

            if (!buffFound)
            {
                buffScore -= 10;
            }
        }

        return buffScore;
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

        int scoreBuff = GradeBuff();

        int nilai = scoreSweetness + scoreBitterness + scoreTemperature + scoreBuff;

        Debug.Log("Bitterness Score: " + scoreBitterness);
        Debug.Log("Sweetness Score: " + scoreSweetness);
        Debug.Log("Temperature Score: " + scoreTemperature);
        Debug.Log("Buff Score: " + scoreBuff);
        Debug.Log("Total Nilai: " + nilai);

        // Save scores to the ScriptableObject
        if (gradeScore != null)
        {
            gradeScore.SaveScores(scoreBitterness, scoreSweetness, scoreTemperature, scoreBuff);
            Debug.Log("Score saved to ScriptableObject successfully!");
        }
        else

            Debug.LogError("Cannot save score: gradeScore ScriptableObject is null. Please assign it in the Inspector.");
    }

    // Check if saveFile is not null before attempting to save
    // if (saveFile != null)
    // {
    //     saveFile.AddOrUpdateData("leaderboard", nilai);
    //     saveFile.Save();
    //     Debug.Log("Score saved successfully!");
    // }
    // else
    // {
    //     Debug.LogError("Cannot save score: SaveFile is null. Make sure SaveFileSetup is properly configured.");
    // }
}
