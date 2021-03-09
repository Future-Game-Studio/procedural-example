using FUGAS.Examples.Constants;

namespace FUGAS.Examples.Generator.Abstractions
{
    interface IGeneratorStrategy
    {
        void Process(PrefabType[,] map);
    }
}
