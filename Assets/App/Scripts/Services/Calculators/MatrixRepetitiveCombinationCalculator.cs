using System;
using System.Collections.Generic;

/// <summary>
/// Sebuah kelas untuk menghitung hasil penjumlahan dari kombinasi matriks
/// DI MANA elemen operan yang sama BOLEH DIGUNAKAN BERULANG.
/// </summary>
[Serializable]
public class MatrixRepetitiveCombinationCalculator : IMatrixCalculator
{
    // Field readonly untuk menyimpan matriks-matriks operan.
    private readonly int[][] _operandMatrices;
    private readonly int _numOperands;

    /// <summary>
    /// Menginisialisasi kalkulator dengan sekumpulan matriks operan.
    /// </summary>
    /// <param name="operands">Array dari matriks operan. Setiap matriks harus memiliki panjang yang sama.</param>
    public MatrixRepetitiveCombinationCalculator(params int[][] operands)
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
    /// Menghitung dan mengembalikan hasil penjumlahan untuk kombinasi dengan pengulangan
    /// untuk ukuran yang ditentukan.
    /// </summary>
    /// <param name="combinationSize">Jumlah matriks yang akan dikombinasikan (boleh berulang).</param>
    /// <returns>Sebuah array berisi matriks-matriks hasil penjumlahan.</returns>
    public int[][] GetSumsForCombinationSize(int combinationSize)
    {
        if (combinationSize < 1)
        {
            // Tidak ada kombinasi yang mungkin jika ukurannya kurang dari 1.
            return new int[0][];
        }

        var results = new List<int[]>();
        var currentCombination = new List<int[]>();

        // Memulai proses rekursif
        GenerateAndSumCombinationsRecursive(combinationSize, 0, currentCombination, results);

        return results.ToArray();
    }

    /// <summary>
    /// Metode rekursif privat untuk menghasilkan semua kombinasi dengan pengulangan.
    /// </summary>
    /// <param name="targetSize">Ukuran akhir dari kombinasi yang diinginkan.</param>
    /// <param name="startIndex">Indeks awal untuk iterasi (untuk menghindari duplikat seperti A+B dan B+A).</param>
    /// <param name="currentCombination">Kombinasi yang sedang dibangun dalam path rekursi ini.</param>
    /// <param name="results">List untuk menyimpan hasil akhir (matriks yang sudah dijumlahkan).</param>
    private void GenerateAndSumCombinationsRecursive(
        int targetSize,
        int startIndex,
        List<int[]> currentCombination,
        List<int[]> results)
    {
        // === Base Case: Kondisi berhenti rekursi ===
        // Jika kombinasi yang sedang dibangun telah mencapai ukuran yang diinginkan.
        if (currentCombination.Count == targetSize)
        {
            // Jumlahkan matriks-matriks dalam kombinasi ini dan tambahkan ke hasil.
            results.Add(SumMatricesInCombination(currentCombination));
            return; // Hentikan path rekursi ini.
        }

        // === Recursive Step ===
        // Loop melalui operan yang tersedia.
        for (int i = startIndex; i < _numOperands; i++)
        {
            // 1. Pilih: Tambahkan operan saat ini ke kombinasi.
            currentCombination.Add(_operandMatrices[i]);

            // 2. Jelajahi (Explore): Lakukan panggilan rekursif untuk membangun sisa kombinasi.
            // PENTING: startIndex tetap 'i', bukan 'i + 1'. Ini yang memungkinkan
            // elemen yang sama untuk dipilih lagi di level rekursi berikutnya.
            GenerateAndSumCombinationsRecursive(targetSize, i, currentCombination, results);

            // 3. Batalkan Pilihan (Backtrack): Hapus elemen yang baru ditambahkan agar iterasi
            // berikutnya pada loop for ini bisa bekerja dengan benar.
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }

    /// <summary>
    /// Metode bantuan untuk menjumlahkan sekumpulan matriks.
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