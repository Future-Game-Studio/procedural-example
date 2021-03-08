using Examples.Extensions;
using UnityEngine;

namespace Examples.Scripts
{
    public class LevelController : MonoBehaviour
    {
        private SquareLevelGenerator generator;
        public LevelBinder binder;
        public int levelSize = 40;
        private GameObject _rootContainer;

        void Awake()
        {
            generator = new SquareLevelGenerator();
            _rootContainer = new GameObject("generator_root");
            _rootContainer.transform.parent = this.transform;
        }

        void Start()
        {
            Generate();
        }

        private void Generate()
        {
            _rootContainer.DestroyChildren();
            // create map
            var map = generator.OfSize(levelSize)
                  .Build(new CarCollectionStrategy(5, 5));
            
            // bind everything to scene "level" object
            binder.Target(_rootContainer)
                  .ApplyMap(map);
        } 
    }
}