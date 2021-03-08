using Examples.Constants;
using Examples.Extensions;
using UnityEngine;

namespace Examples.Scripts
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
            var (h, w) = map.Size();
            var offsetRow = w / Mathf.Min(_carCountRow, w);
            var offsetColl = h / Mathf.Min(_carCountColl, h);
            for (int i = offsetRow - 1; i < w; i += offsetRow)
                for (int j = offsetColl - 1; j < h; j += offsetColl)
                    map[j, i] = PrefabType.CarSport;
        }
    }
}
