using FUGAS.Examples.Constants;
using FUGAS.Examples.Misc.Extensions;
using FUGAS.Examples.Generator.Abstractions;

namespace FUGAS.Examples.Generator.Strategies
{
    public class CarInGarageStrategy : IGeneratorStrategy
    {
        public void Process(PrefabType[,] map)
        {
            var (h, w) = map.Size();
            map.FillContour(PrefabType.Wall);
            map[h / 2, w / 2] = PrefabType.CarSport;
        }
    }
}
