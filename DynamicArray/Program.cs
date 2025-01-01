using ASD_ADP;
using DynamicArrayProj.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        var dataset = DataSets.LijstFloat8001;
        var dynamicArray = new DynamicArray<object>();
        Stopwatch sw = Stopwatch.StartNew();
        foreach (var item in dataset)
        {
            dynamicArray.Add(item);
        }
        sw.Stop();
        Console.WriteLine("dynamic array filled with " + dynamicArray.Count + " items in " + sw.Elapsed.Milliseconds + " miliseconds" );
    }
}