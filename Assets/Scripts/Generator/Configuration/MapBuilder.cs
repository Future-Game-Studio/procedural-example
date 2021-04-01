using System;
using FUGAS.Examples.Constants;
using FUGAS.Examples.Generator.Configuration.Abstractions;

namespace FUGAS.Examples.Generator.Configuration
{
    class MapBuilder : IMapBuilder
    {
        private readonly ILevelParameters _parameters;
        private Action<PrefabType[,]> _transformer;

        public MapBuilder(ILevelParameters parameters)
        {
            _parameters = parameters;
        }

        public IMapBuilder Transform(Action<PrefabType[,]> action)
        {
            _transformer = action;
            return this;
        }
        
        public void Build()
        {
            var temp = new PrefabType[_parameters.Size, _parameters.Size];

            // apply main strategy
            _parameters.Strategy.Process(temp);

            // apply additional transformations
            _transformer?.Invoke(temp);

            // reconfigure binder
            _parameters.OnConfigureBinder?.Invoke(_parameters.Binder);
            
            // execute scene binder
            _parameters.Binder.ApplyMap(temp);
        }
    }
}
