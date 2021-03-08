using Examples.Constants;
using Examples.Extensions;

namespace Examples.Scripts
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
