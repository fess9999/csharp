using System;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NonDefaultAttribute : Attribute
    {

    }
}