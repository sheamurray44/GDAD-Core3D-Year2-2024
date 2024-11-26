using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class CacheBenchmark : MonoBehaviour
{
    private Renderer cachedRenderer;
    void Start()
    {
        cachedRenderer = GetComponent<Renderer>();
    }

    public void RunBenchMarks()
    {
        BenchmarkNonCachedLoop();
        BenchmarkCachedLoop();
    }

    private void BenchmarkNonCachedLoop()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < 100000; i++)
        {
            GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log($"Non-Cached Loop Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    private void BenchmarkCachedLoop()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < 100000; i++)
        {
            cachedRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log($"Cached Loop Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
