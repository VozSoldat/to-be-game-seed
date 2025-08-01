using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class WrappStat
{
    public int min;
    public int max;
}

public class MB_PatronOrderGenerator : MonoBehaviour
{
    IMatrixCalculator _matrixCalculator;

    [SerializeField] ItemData[] _operandItemDataset;
    [SerializeField] int _combinationSize = 2;
    [SerializeField] CalculatorType _calculatorType;

    [Header("ItemData Stat Clamping")]
    [SerializeField] WrappStat _sweetnessClamp = new WrappStat { min = 0, max = 5 };
    [SerializeField] WrappStat _bitternessClamp = new WrappStat { min = 0, max = 5 };
    [SerializeField] WrappStat _temperatureClamp = new WrappStat { min = 0, max = 5 };


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

    // void Start()
    // {
    //     _matrixCombinationCalculator = new MatrixRepetitiveCombinationCalculator(
    //         ItemDataToArrayOfArray(_operandItemDataset)
    //     );
    // }

    public ItemData[] GetCombinations()
    {
        var resultArrays = _matrixCalculator.GetSumsForCombinationSize(_combinationSize);
        return ArrayOfArrayToItemData(resultArrays);
    }
    void OnValidate()
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


}

public enum CalculatorType
{
    MatrixCombinationCalculator,
    MatrixRepetitiveCombinationCalculator
}