using System;
using System.Collections.Generic;
using System.Linq;

public class DriverMatcher
{
    private List<Driver> _drivers = new List<Driver>();

    public void AddDriver(Driver driver)
    {
        _drivers.Add(driver);
    }

    public void UpdateDriver(int id, int newX, int newY)
    {
        var driver = _drivers.FirstOrDefault(d => d.Id == id);
        if (driver != null)
        {
            driver.X = newX;
            driver.Y = newY;
        }
    }

    public List<Driver> FindNearestSimple(Order order, int count = 5)
    {
        return _drivers
            .OrderBy(d => GetDistance(d, order))
            .Take(count)
            .ToList();
    }

    public List<Driver> FindNearestWithHeap(Order order, int count = 5)
    {
        var pq = new PriorityQueue<Driver, double>();
        foreach (var d in _drivers)
        {
            double dist = GetDistance(d, order);
            pq.Enqueue(d, dist);
        }

        var result = new List<Driver>();
        for (int i = 0; i < count && pq.Count > 0; i++)
        {
            result.Add(pq.Dequeue());
        }
        return result;
    }

    public List<Driver> FindNearestQuickSelect(Order order, int count = 5)
    {
        var list = _drivers.ToList();
        var distances = list.Select(d => GetDistance(d, order)).ToArray();
        var indices = Enumerable.Range(0, list.Count).ToArray();

        var resultIndices = QuickSelectIndices(distances, indices, count);

        var result = new List<Driver>();
        foreach (var idx in resultIndices)
        {
            result.Add(list[idx]);
        }
        return result;
    }

    private double GetDistance(Driver d, Order o)
    {
        return Math.Pow(d.X - o.X, 2) + Math.Pow(d.Y - o.Y, 2);
    }

    private List<int> QuickSelectIndices(double[] distances, int[] indices, int k)
    {

        return distances
            .Select((d, i) => new { d, i })
            .OrderBy(x => x.d)
            .Take(k)
            .Select(x => indices[x.i])
            .ToList();
    }
}