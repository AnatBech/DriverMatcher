using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;

public class Benchmark
{
    private DriverMatcher _matcher = null!;
    private Order _order = null!;


    [GlobalSetup]
    public void Setup()
    {
        _matcher = new DriverMatcher();
        for (int i = 0; i < 100000; i++)
        {
            _matcher.AddDriver(new Driver(i, i % 1000, i / 1000));
        }
        _order = new Order(500, 500);
    }

    [Benchmark]
    public void SimpleSearch()
    {
        _matcher.FindNearestSimple(_order);
    }

    [Benchmark]
    public void HeapSearch()
    {
        _matcher.FindNearestWithHeap(_order);
    }

    [Benchmark]
    public void QuickSelectSearch()
    {
        _matcher.FindNearestQuickSelect(_order);
    }
}