using FUGAS.Examples.Generator.Abstractions;
using FUGAS.Examples.Generator.Configuration;
using FUGAS.Examples.Generator.Configuration.Abstractions;
using FUGAS.Examples.Generator.Strategies;
using FUGAS.Examples.Generator.Unity;
using FUGAS.Examples.Misc;
using UnityEngine;

namespace FUGAS.Examples
{
    public class LevelController : MonoBehaviour
    {
        private ILevelConfigurator _configurator;
        public LevelBinder binder;
        public int levelSize = 40;
        private GameObject _rootContainer;
        private IGeneratorStrategy[] _strategies;
        private int _currentStrategy;

        void Awake()
        {
            _configurator = new SquareLevelConfigurator();
            _rootContainer = new GameObject("generator_root");
            _rootContainer.transform.parent = this.transform;
            _strategies = new IGeneratorStrategy[]
            {
                new CarCollectionStrategy(5,5),
                new CarInGarageStrategy(),
                new CarCollectionStrategy(2,2),
                new CarInGarageStrategy(),
                // generate randomly up to 10 cars with radial offset of 7 units
                new RandomCarLocationStrategy(10, 7)
            };

            // preconfigure static values
            _configurator.OfSize(levelSize)
                    .UseMapBinder(binder)
                    .OnConfigureBinder(b => b.Target(_rootContainer));
        }

        void Start()
        {
            _currentStrategy = 0;
            Generate();
        }

        private void Generate()
        {
            _rootContainer.DestroyChildren();

            // create map
            var map = _configurator
                     .UseStrategy(_strategies[_currentStrategy])
                     .GetBuilder();
            BindScene(map);
        }
        void BindScene(IMapBuilder map)
        {
            // bind everything to scene "level" object
            map.Transform(m =>
            {
                // here we can apply additional transformations

                // let's replace some walls)
                var (mh, mw) = m.Size();

                for (var i = 0; i < mw; i++)
                    m[0, i] = Constants.PrefabType.Sphere;

            }).Build();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (++_currentStrategy == _strategies.Length)
                    _currentStrategy = 0;
                Generate();
            }
        }
    }
}