using System;
using FUGAS.Examples.Generator.Abstractions;
using FUGAS.Examples.Generator.Unity;

namespace FUGAS.Examples.Generator.Configuration
{
    internal interface ILevelParameters
    {
        int Size { get; }
        IGeneratorStrategy Strategy { get; }
        LevelBinder Binder { get; }
        Action<LevelBinder> OnConfigureBinder { get;  }
    }
}
