using Contracts.DynamicCombinator.Finder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DynamicCombinator.Finder
{
    public class DecoratorFinder : IDecoratorFinder
    {
        #region Fields

        private readonly Assembly assembly;

        #endregion

        #region Constructors

        public DecoratorFinder(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public DecoratorFinder(string assemblyName)
        {
            assembly = Assembly.Load(assemblyName);
        }

        #endregion

        #region Methods

        public IList<Type> FindDecorators<TItem>()
        {
            return GetDecoratedTypes(typeof(TItem));
        }

        private Type[] GetDecoratedTypes(Type decoratedType)
        {
            return assembly
                .GetTypes()?
                .Where(t => IsDecorator(t, decoratedType))?
                .ToArray();
        }

        private static bool IsDecorator(Type type, Type decoratorType)
        {
            return type?.GetCustomAttribute<DynamicDecoratorAttribute>()?.Type == decoratorType;
        }

        #endregion
    }
}