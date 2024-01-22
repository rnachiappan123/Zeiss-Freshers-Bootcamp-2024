using System;

namespace DeviceValidation
{
    abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage {  get; set; }
        abstract public bool IsValid(object Value);
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class RequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object Value)
        {
            return Value != null && !Value.ToString().Equals("");
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class RangeAttribute : ValidationAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public RangeAttribute(int min, int max, string message)
        {
            Min = min;
            Max = max;
            ErrorMessage = message;
        }
        public override bool IsValid(object Value)
        {
            return (int)Value >= Min && (int)Value <= Max;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class MaxLengthAttribute : ValidationAttribute
    {
        int Max { get; set; }
        public MaxLengthAttribute(int max, string message)
        {
            Max = max;
            ErrorMessage = message;
        }
        public override bool IsValid(object Value)
        {
            return Value.ToString().Length <= Max;
        }
    }
}
