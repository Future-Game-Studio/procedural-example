using Examples.Constants;

namespace Examples.Scripts
{
    interface IGeneratorStrategy
    {
        void Process(PrefabType[,] map);
    }
}
