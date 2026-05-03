using System;
using System.Linq;

class Program
{
    static void Main()
    {
        double[] data = {
            115,182,191,31,196,1099,5,172,10,179,83,21,20,21,
            186,177,195,193,188,199,62,109,105,183,110
        };

        Array.Sort(data);

        double mean = data.Average();
        double median = data[data.Length / 2];

        var mode = data.GroupBy(x => x)
                       .OrderByDescending(g => g.Count())
                       .First().Key;

        double variance = data.Select(x => Math.Pow(x - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        double range = data.Max() - data.Min();

        double Q1 = Percentile(data, 25);
        double Q2 = Percentile(data, 50);
        double Q3 = Percentile(data, 75);

        double IQR = Q3 - Q1;

        double P20 = Percentile(data, 20);
        double P50 = Percentile(data, 50);

        double sumDeviation = data.Sum(x => x - mean);

        Console.WriteLine($"Mean = {mean}");
        Console.WriteLine($"Mode = {mode}");
        Console.WriteLine($"Median = {median}");
        Console.WriteLine($"Variance = {variance}");
        Console.WriteLine($"Std Dev = {stdDev}");
        Console.WriteLine($"Range = {range}");
        Console.WriteLine($"Q1 = {Q1}, Q2 = {Q2}, Q3 = {Q3}");
        Console.WriteLine($"IQR = {IQR}");
        Console.WriteLine($"P20 = {P20}, P50 = {P50}");
        Console.WriteLine($"Sum of Deviations = {sumDeviation}");
    }

    static double Percentile(double[] sortedData, double percentile)
    {
        double position = (sortedData.Length + 1) * percentile / 100.0;
        int index = (int)position;

        if (index < 1) return sortedData[0];
        if (index >= sortedData.Length) return sortedData[sortedData.Length - 1];

        double fraction = position - index;
        return sortedData[index - 1] + fraction * (sortedData[index] - sortedData[index - 1]);
    }
}