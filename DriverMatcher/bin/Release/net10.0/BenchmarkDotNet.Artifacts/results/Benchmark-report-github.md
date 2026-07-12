```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
11th Gen Intel Core i3-1115G4 3.00GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK 10.0.301
  [Host]     : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v4


```
| Method            | Mean      | Error     | StdDev    | Median    |
|------------------ |----------:|----------:|----------:|----------:|
| SimpleSearch      |  5.541 ms | 0.2418 ms | 0.7131 ms |  5.141 ms |
| HeapSearch        |  5.572 ms | 0.0979 ms | 0.1609 ms |  5.538 ms |
| QuickSelectSearch | 15.922 ms | 0.3078 ms | 0.5550 ms | 15.915 ms |
