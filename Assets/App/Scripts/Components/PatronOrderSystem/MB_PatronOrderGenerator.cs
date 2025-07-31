using System.Linq;
using UnityEngine;

public class MB_PatronOrderGenerator : MonoBehaviour
{
    IMatrixCalculator _matrixCalculator;

    [SerializeField] ItemData[] _operandItemDataset;
    [SerializeField] int _combinationSize = 2;
    [SerializeField] CalculatorType _calculatorType;


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
            itemData.sweetness = array[0];
            itemData.bitterness = array[1];
            itemData.temperature = array[2];
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