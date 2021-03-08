
using Examples.Extensions;
using Examples.Constants;
using UnityEngine;

namespace Examples.Scripts
{
    class SquareLevelGenerator
    {
        private int _size;

        public SquareLevelGenerator OfSize(int size)
        {
            _size = size;
            return this;
        }
        public PrefabType[,] Build(IGeneratorStrategy strategy)
        {
            var temp = new PrefabType[_size, _size];

            strategy.Process(temp);

            return temp;
        }
    }
}
