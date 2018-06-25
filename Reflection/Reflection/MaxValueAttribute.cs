using System;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxValueAttribute : Attribute
    {
        public MaxValueAttribute()
        {
            
        }

        public MaxValueAttribute(int maxValue) => MaxValue = maxValue;

        public int MaxValue { get; set; }
    }
}