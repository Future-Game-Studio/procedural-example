using System;
using FUGAS.Examples.Generator.Abstractions;
using FUGAS.Examples.Generator.Configuration.Abstractions;
using FUGAS.Examples.Generator.Unity;

namespace FUGAS.Examples.Generator.Configuration
{
    class SquareLevelConfigurator : ILevelConfigurator
    {
        private LevelParameters _parameters;

        public SquareLevelConfigurator()
        {
            _parameters = new LevelParameters();
        }

        public ILevelConfigurator OfSize(int size)
        {
            _parameters.Size = size;
            return this;
        }

        public ILevelConfigurator UseMapBinder(LevelBinder binder)
        {
            _parameters.Binder = binder;
            return this;
        }

        public ILevelConfigurator UseStrategy(IGeneratorStrategy strategy)
        {
            _parameters.Strategy = strategy;
            return this;
        }
        
        public ILevelConfigurator OnConfigureBinder(Action<LevelBinder> action)
        {
            _parameters.OnConfigureBinder = action;
            return this;
        }

        public IMapBuilder GetBuilder()
        {
            // just pass parameters to builder
            // in another scenario (e.g. multi instance) params should be cloned
            return new MapBuilder(_parameters);
        }

        private class LevelParameters : ILevelParameters
        {
            public int Size { get; internal set; }

            public IGeneratorStrategy Strategy { get; internal set; }

            public LevelBinder Binder { get; internal set; }
            public Action<LevelBinder> OnConfigureBinder { get; internal set; }
        }
    }
}
