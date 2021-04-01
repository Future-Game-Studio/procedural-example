using System;
using FUGAS.Examples.Generator.Abstractions;
using FUGAS.Examples.Generator.Unity;

namespace FUGAS.Examples.Generator.Configuration.Abstractions
{
    internal interface ILevelConfigurator
    {
        ILevelConfigurator OfSize(int size);
        ILevelConfigurator UseMapBinder(LevelBinder binder);
        ILevelConfigurator OnConfigureBinder(Action<LevelBinder> action);
        ILevelConfigurator UseStrategy(IGeneratorStrategy strategy);
        IMapBuilder GetBuilder();
    }
}
