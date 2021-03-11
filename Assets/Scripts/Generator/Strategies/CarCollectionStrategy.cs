using FUGAS.Examples.Constants;
using FUGAS.Examples.Misc.Extensions;
using FUGAS.Examples.Generator.Abstractions;
using UnityEngine;

namespace FUGAS.Examples.Generator.Strategies
{
    public class CarCollectionStrategy : IGeneratorStrategy
    {
        private int _carCountRow;
        private int _carCountColl;
        public CarCollectionStrategy()
        {

        }

        public CarCollectionStrategy(int row, int coll)
        {
            _carCountRow = row;
            _carCountColl = coll;
        }

        public void Process(PrefabType[,] map)
        {
            Debug.Log($"Executing strategy: {this.GetType().Name}");
            var (h, w) = map.Size();
            var offsetColl = h * 1f / Mathf.Min(_carCountColl + 1, h);
            var offsetRow = w * 1f / Mathf.Min(_carCountRow + 1, w);
            for (float i = offsetColl; i < h; i += offsetColl)
                for (float j = offsetRow; j < w; j += offsetRow)
                    map[(int)i, (int)j] = PrefabType.CarSport;
        }
    }
}
