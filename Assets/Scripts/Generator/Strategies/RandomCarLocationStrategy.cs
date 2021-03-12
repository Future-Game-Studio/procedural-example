using System.Collections.Generic;
using System.Linq;
using FUGAS.Examples.Constants;
using FUGAS.Examples.Generator.Abstractions;
using FUGAS.Examples.Misc.Extensions;
using UnityEngine;

namespace FUGAS.Examples.Generator.Strategies
{
    internal class RandomCarLocationStrategy : IGeneratorStrategy
    {
        private int _maxItems;
        private float _safeRadius;

        public RandomCarLocationStrategy(int maxPossibleItems, float safeRadius)
        {
            _maxItems = maxPossibleItems;
            _safeRadius = safeRadius;
        }
        public void Process(PrefabType[,] map)
        {
            Debug.Log($"Executing strategy: {this.GetType().Name}");

            var (h, w) = map.Size();
            map.FillContour(PrefabType.Wall);
            
            // in this example there is no filtering or limits
            // and no collision checks
            // ideally you should add offsets and limits in your generator strategies
            
            var generated = new List<(float x, float y)>();
            for (int i = 0; i < _maxItems; i++)
            {
                // to enhance algorithm we will check possible 
                // possitions with minimally allowed radius 
                // like this >>>  x^2 + y^2 > safeRadius^2
                var retryFor = 5;
                while (--retryFor > 0)
                {
                    // make an offset from walls 
                    var randX = UnityEngine.Random.Range(5, h - 4);
                    var randY = UnityEngine.Random.Range(5, w - 4);
                    if (MinDistanceTest(_safeRadius, (randX, randY), generated))
                    {
                        map[randX, randY] = PrefabType.CarSport;
                        Debug.Log($"Randomly generated car at X:{randX} Y:{randY}");
                        // add generated point as restriction
                        generated.Add((randX, randY));
                        break; // sucessfully reserved position
                    }
                }
            }
        }

        private static bool MinDistanceTest(float safeRadius, (float x, float y) a, IEnumerable<(float x, float y)> excludePoints)
        {
            // Example how to test positions with radius
            // iterate over all available points
            // to test if generated position is valid
            // if not - just generate new position
            return excludePoints.Aggregate(true,
                (current, excludePoint) => current & MinDistanceTest(safeRadius, a, excludePoint));
        }

        private static bool MinDistanceTest(float safeRadius, (float x, float y) a, (float x, float y) b)
        {
            return Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.y - a.y, 2) > Mathf.Pow(safeRadius, 2);
        }
    }
}
