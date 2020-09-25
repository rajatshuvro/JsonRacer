``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G2021) [Darwin 19.6.0]
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.102
  [Host]     : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT


```
|                   Method |    Mean |    Error |   StdDev |  Median | Ratio | RatioSD | Rank |       Gen 0 |      Gen 1 |     Gen 2 | Allocated |
|------------------------- |--------:|---------:|---------:|--------:|------:|--------:|-----:|------------:|-----------:|----------:|----------:|
|       Utf8JsonSerializer | 1.646 s | 0.0309 s | 0.0665 s | 1.657 s |  0.91 |    0.06 |    1 | 242000.0000 | 63000.0000 | 3000.0000 |   1.87 GB |
|    NirvanaJsonSerializer | 1.806 s | 0.0358 s | 0.0912 s | 1.770 s |  1.00 |    0.00 |    2 | 441000.0000 | 93000.0000 | 3000.0000 |   3.42 GB |
| SystemTextJsonSerializer | 2.252 s | 0.0341 s | 0.0407 s | 2.239 s |  1.25 |    0.07 |    3 | 248000.0000 | 64000.0000 | 3000.0000 |   1.91 GB |
|     NewtonSoftSerializer | 3.150 s | 0.0281 s | 0.0249 s | 3.156 s |  1.72 |    0.09 |    4 | 381000.0000 | 94000.0000 | 3000.0000 |   2.95 GB |
