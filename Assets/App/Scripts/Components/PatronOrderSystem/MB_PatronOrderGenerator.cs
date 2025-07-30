using System.Linq;
using UnityEngine;

public class MB_PatronOrderGenerator : MonoBehaviour
{
    [SerializeField] MatrixCombinationCalculator _matrixCombinationCalculator;

    [SerializeField] ItemData[] _operandItemDataset;
    [SerializeField] int _combinationSize = 2;


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

    void Start()
    {
        _matrixCombinationCalculator = new MatrixCombinationCalculator(
            ItemDataToArrayOfArray(_operandItemDataset)
        );
    }

    public ItemData[] GetCombinations()
    {
        var resultArrays = _matrixCombinationCalculator.GetSumsForCombinationSize(_combinationSize);
        return ArrayOfArrayToItemData(resultArrays);
    }


}