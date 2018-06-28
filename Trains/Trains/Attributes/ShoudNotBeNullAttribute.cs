using System;

namespace Trains.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class ShoudNotBeNullAttribute : Attribute
    {
    }
}