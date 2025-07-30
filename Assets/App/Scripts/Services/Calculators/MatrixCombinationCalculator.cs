using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
/// <summary>
/// Sebuah kelas untuk menghitung semua kemungkinan hasil penjumlahan
/// dari kombinasi matriks-matriks (direpresentasikan sebagai array 1D) operan.
/// </summary>
public class MatrixCombinationCalculator
{
    // Field readonly untuk menyimpan matriks-matriks operan.
    private readonly int[][] _operandMatrices;
    private readonly int _numOperands;

    /// <summary>
    /// Menginisialisasi kalkulator dengan sekumpulan matriks operan.
    /// </summary>
    /// <param name="operands">Array dari matriks operan. Setiap matriks harus memiliki panjang yang sama.</param>
    public MatrixCombinationCalculator(params int[][] operands)
    {
        if (operands == null || operands.Length == 0)
        {
            throw new ArgumentException("Array operan tidak boleh null atau kosong.", nameof(operands));
        }

        int firstLength = operands[0].Length;
        for (int i = 1; i < operands.Length; i++)
        {
            if (operands[i].Length != firstLength)
            {
                throw new ArgumentException("Semua matriks operan harus memiliki panjang yang sama.");
            }
        }

        _operandMatrices = operands;
        _numOperands = operands.Length;
    }

    /// <summary>
    /// Menghitung dan mengembalikan hasil penjumlahan untuk kombinasi dengan JUMLAH TEPAT yang ditentukan.
    /// </summary>
    /// <param name="combinationSize">Jumlah pasti matriks yang akan dikombinasikan (misal: 2 untuk pasangan, 3 untuk triplet, dst.).</param>
    /// <returns>Sebuah array berisi matriks-matriks hasil penjumlahan.</returns>
    public int[][] GetSumsForCombinationSize(int combinationSize)
    {
        // Validasi input: ukuran kombinasi tidak boleh kurang dari 1 atau lebih besar dari total operan.
        if (combinationSize < 1 || combinationSize > _numOperands)
        {
            // Mengembalikan array kosong jika permintaan tidak valid, atau bisa juga melempar exception.
            // throw new ArgumentOutOfRangeException(nameof(combinationSize), "Ukuran kombinasi tidak valid.");
            return new int[0][];
        }

        var results = new List<int[]>();
        long totalCombinations = 1L << _numOperands;

        // Loop melalui semua kemungkinan kombinasi menggunakan bitmask.
        for (long i = 1; i < totalCombinations; i++)
        {
            // Cek berapa banyak bit '1' pada mask 'i'. Ini merepresentasikan jumlah operan dalam kombinasi.
            // Di C# 6.0+, kita bisa menggunakan System.Runtime.Intrinsics.Popcnt.PopCount((ulong)i) untuk performa tinggi.
            // Namun, cara manual ini bekerja di semua versi.
            int setBits = 0;
            for (int j = 0; j < _numOperands; j++)
            {
                if ((i & (1L << j)) != 0)
                {
                    setBits++;
                }
            }

            // Jika jumlah operan dalam kombinasi ini SAMA DENGAN yang diminta, proses lebih lanjut.
            if (setBits == combinationSize)
            {
                var currentCombination = new List<int[]>();
                for (int j = 0; j < _numOperands; j++)
                {
                    if ((i & (1L << j)) != 0)
                    {
                        currentCombination.Add(_operandMatrices[j]);
                    }
                }
                results.Add(SumMatricesInCombination(currentCombination));
            }
        }

        return results.ToArray();
    }

    /// <summary>
    /// Metode bantuan yang menjumlahkan semua kombinasi yang mungkin, mulai dari ukuran minimum tertentu.
    /// Ini mereplikasi fungsionalitas dari versi sebelumnya.
    /// </summary>
    /// <param name="minCombinationSize">Ukuran kombinasi minimum yang akan dihitung (default: 2).</param>
    /// <returns>Semua hasil penjumlahan yang memenuhi kriteria.</returns>
    public int[][] GetAllPossibleSums(int minCombinationSize = 2)
    {
        var allResults = new List<int[]>();
        for (int size = minCombinationSize; size <= _numOperands; size++)
        {
            allResults.AddRange(GetSumsForCombinationSize(size));
        }
        return allResults.ToArray();
    }

    /// <summary>
    /// Metode bantuan privat untuk menjumlahkan sekumpulan matriks.
    /// </summary>
    private int[] SumMatricesInCombination(List<int[]> matricesToSum)
    {
        int matrixLength = matricesToSum[0].Length;
        int[] sumResult = new int[matrixLength];

        foreach (var matrix in matricesToSum)
        {
            for (int i = 0; i < matrixLength; i++)
            {
                sumResult[i] += matrix[i];
            }
        }
        return sumResult;
    }
}