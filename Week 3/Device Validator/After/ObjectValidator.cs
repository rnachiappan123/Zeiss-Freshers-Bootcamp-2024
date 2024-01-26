using System;
using System.Collections.Generic;
using System.Reflection;

namespace DeviceValidation
{
    class ObjectValidator
    {
        public static bool Validate(object Object, out List<string> errors)
        {
            errors = new List<string>();
            Type type = Object.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                ValidationAttribute[] validationAttributes = (ValidationAttribute[])property.GetCustomAttributes(typeof(ValidationAttribute), true);
                
                foreach (ValidationAttribute validationAttribute in validationAttributes)
                {
                    object value = property.GetValue(Object);
                    if (!validationAttribute.IsValid(value))
                    {
                        errors.Add(validationAttribute.ErrorMessage);
                    }
                }
            }

            return errors.Count == 0;
        }
    }
}
