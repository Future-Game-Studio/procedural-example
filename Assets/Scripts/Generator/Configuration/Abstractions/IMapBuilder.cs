using System;
using FUGAS.Examples.Constants;

namespace FUGAS.Examples.Generator.Configuration.Abstractions
{
    internal interface IMapBuilder
    {
        IMapBuilder Transform(Action<PrefabType[,]> action);
        void Build();
    }
}
