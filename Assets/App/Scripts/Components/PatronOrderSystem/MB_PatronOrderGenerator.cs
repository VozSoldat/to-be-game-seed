using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class CombinationResult
{
    public ItemData combinedItem;
    public ItemData[] sourceItems;

    public CombinationResult(ItemData combined, ItemData[] sources)
    {
        combinedItem = combined;
        sourceItems = sources;
    }
}

[Serializable]
public class WrappStat
{
    public int min;
    public int max;
}

public class MB_PatronOrderGenerator : MonoBehaviour
{
    IMatrixCalculator _matrixCalculator;

    [SerializeField] private ItemData[] _operandItemDataset;
    [SerializeField] int _combinationSize = 2;
    [SerializeField] CalculatorType _calculatorType;
    [SerializeField] private SO_CharaDanPesan charaDanPesan;

    [Header("ItemData Stat Clamping")]
    [SerializeField] WrappStat _sweetnessClamp = new WrappStat { min = 0, max = 5 };
    [SerializeField] WrappStat _bitternessClamp = new WrappStat { min = 0, max = 5 };
    [SerializeField] WrappStat _temperatureClamp = new WrappStat { min = 0, max = 5 };

    private void Start()
    {

        // Initialize the matrix calculator
        InitializeMatrixCalculator();
    }

    void InitializeMatrixCalculator()
    {
        _matrixCalculator = _calculatorType switch
        {
            CalculatorType.MatrixCombinationCalculator => new MatrixCombinationCalculator(
                ItemDataToArrayOfArray(_operandItemDataset)
            ),
            CalculatorType.MatrixRepetitiveCombinationCalculator => new MatrixRepetitiveCombinationCalculator(
                ItemDataToArrayOfArray(_operandItemDataset)
            ),
            _ => throw new System.NotImplementedException($"Calculator type {_calculatorType} is not implemented.")
        };
    }


    int[][] ItemDataToArrayOfArray(ItemData[] items)
    {
        return items.Select(item => new int[]
        {
            item.sweetness,
            item.bitterness,
            item.temperature
        }).ToArray();
    }

    ItemData[] ArrayOfArrayToItemData(int[][] arrays)
    {
        return arrays.Select<int[], ItemData>(array =>
        {
            var itemData = ScriptableObject.CreateInstance<ItemData>();
            itemData.sweetness = Math.Clamp(array[0], _sweetnessClamp.min, _sweetnessClamp.max);
            itemData.bitterness = Math.Clamp(array[1], _bitternessClamp.min, _bitternessClamp.max);
            itemData.temperature = Math.Clamp(array[2], _temperatureClamp.min, _temperatureClamp.max);
            return itemData;
        })
        .ToArray();
    }

    public ItemData[] GetCombinations()
    {
        var resultArrays = _matrixCalculator.GetSumsForCombinationSize(_combinationSize);

        return ArrayOfArrayToItemData(resultArrays);
    }

    public void CreateCombinationsWithSources()
    {
        // Get all possible combinations from the calculator
        var combinations = GetAllCombinationIndices(_combinationSize);
        var results = new CombinationResult[combinations.Count];

        for (int i = 0; i < combinations.Count; i++)
        {
            var indices = combinations[i];
            var sourceItems = indices.Select(index => _operandItemDataset[index]).ToArray();

            // Calculate the combined stats
            int combinedSweetness = sourceItems.Sum(item => item.sweetness);
            int combinedBitterness = sourceItems.Sum(item => item.bitterness);
            int combinedTemperature = sourceItems.Sum(item => item.temperature);

            // Create the combined item
            var combinedItem = ScriptableObject.CreateInstance<ItemData>();
            combinedItem.sweetness = Math.Clamp(combinedSweetness, _sweetnessClamp.min, _sweetnessClamp.max);
            combinedItem.bitterness = Math.Clamp(combinedBitterness, _bitternessClamp.min, _bitternessClamp.max);
            combinedItem.temperature = Math.Clamp(combinedTemperature, _temperatureClamp.min, _temperatureClamp.max);
            combinedItem.itemName = string.Join(" + ", sourceItems.Select(item => item.itemName));

            var allBuffs = new System.Collections.Generic.HashSet<ItemBuff>();
            foreach (var item in sourceItems)
            {
                if (item.itemBuffs != null)
                {
                    foreach (var buff in item.itemBuffs)
                    {
                        allBuffs.Add(buff);
                    }
                }
            }
            combinedItem.itemBuffs = allBuffs.ToArray();

            results[i] = new CombinationResult(combinedItem, sourceItems);
        }

        // Select a random combination
        if (results.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, results.Length);
            var selectedResult = results[randomIndex];
            
            Debug.Log($"Generated order: {selectedResult.combinedItem.itemName}");
            Debug.Log($"Source items: {string.Join(", ", System.Array.ConvertAll(selectedResult.sourceItems, item => item.itemName))}");
            Debug.Log($"Combined Sweetness: {selectedResult.combinedItem.sweetness}, Bitterness: {selectedResult.combinedItem.bitterness}, Temperature: {selectedResult.combinedItem.temperature}");
            
            charaDanPesan.characterOrder.itemName = selectedResult.combinedItem.itemName;
            charaDanPesan.characterOrder.sweetness = selectedResult.combinedItem.sweetness;
            charaDanPesan.characterOrder.bitterness = selectedResult.combinedItem.bitterness;
            charaDanPesan.characterOrder.temperature = selectedResult.combinedItem.temperature;
            charaDanPesan.characterOrder.itemBuffs = selectedResult.combinedItem.itemBuffs;
        }
        else
        {
            Debug.LogWarning("No combinations were generated!");
        }
    }

    private System.Collections.Generic.List<int[]> GetAllCombinationIndices(int combinationSize)
    {
        var results = new System.Collections.Generic.List<int[]>();
        int numOperands = _operandItemDataset.Length;

        if (_calculatorType == CalculatorType.MatrixCombinationCalculator)
        {
            // Generate combinations without repetition
            GenerateCombinations(new int[combinationSize], 0, 0, numOperands, results);
        }
        else
        {
            // Generate combinations with repetition
            GenerateCombinationsWithRepetition(new int[combinationSize], 0, 0, numOperands, results);
        }

        return results;
    }

    private void GenerateCombinations(int[] current, int currentIndex, int start, int numOperands, System.Collections.Generic.List<int[]> results)
    {
        if (currentIndex == current.Length)
        {
            results.Add((int[])current.Clone());
            return;
        }

        for (int i = start; i < numOperands; i++)
        {
            current[currentIndex] = i;
            GenerateCombinations(current, currentIndex + 1, i + 1, numOperands, results);
        }
    }

    private void GenerateCombinationsWithRepetition(int[] current, int currentIndex, int start, int numOperands, System.Collections.Generic.List<int[]> results)
    {
        if (currentIndex == current.Length)
        {
            results.Add((int[])current.Clone());
            return;
        }

        for (int i = start; i < numOperands; i++)
        {
            current[currentIndex] = i;
            GenerateCombinationsWithRepetition(current, currentIndex + 1, i, numOperands, results);
        }
    }

    void OnValidate()
    {
        InitializeMatrixCalculator();
    }
}

public enum CalculatorType
{
    MatrixCombinationCalculator,
    MatrixRepetitiveCombinationCalculator
}