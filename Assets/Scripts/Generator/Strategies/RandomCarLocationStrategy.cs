 using FUGAS.Examples.Constants;
using FUGAS.Examples.Generator.Abstractions;
using FUGAS.Examples.Misc.Extensions;
using UnityEngine;

namespace FUGAS.Examples.Generator.Strategies
{
    internal class RandomCarLocationStrategy : IGeneratorStrategy
    {
        public void Process(PrefabType[,] map)
        {
            Debug.Log($"Executing strategy: {this.GetType().Name}");
            var (h, w) = map.Size();
            map.FillContour(PrefabType.Wall);
            var randX = UnityEngine.Random.Range(2, h - 1);
            var randY = UnityEngine.Random.Range(2, w - 1);
            map[randX, randY] = PrefabType.CarSport;
            Debug.Log($"Randomly generated car at X:{randX} Y:{randY}");
        }
    }
}