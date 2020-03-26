using System;

namespace DynamicCombinator.Finder
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class DynamicDecoratorAttribute : Attribute
    {
        #region Properties

        public Type Type { get; }
        public int Rank  { get; }
        #endregion

        #region Constructors

        public DynamicDecoratorAttribute(Type type, int rank)
        {
            Type = type;
            Rank = rank;
        }

        #endregion
    }
}