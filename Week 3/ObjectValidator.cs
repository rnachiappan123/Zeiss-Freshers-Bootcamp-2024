using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Code_Assignment
{
    internal class ObjectValidator
    {
        public static bool Validate(Device deviceObj, out List<string> errors)
        {
            bool isValid = true;
            var requiredAttributes = (Required[])typeof(Device).GetCustomAttributes(typeof(Required), true);
            var rangeAttributes = (Range[])typeof(Device).GetCustomAttributes(typeof(Range), true);
            var maxLengthAttributes = (MaxLength[])typeof(Device).GetCustomAttributes(typeof(MaxLength), true);
            errors = new List<string>();

            foreach ( var requiredAttribute in requiredAttributes)
            {
                if (deviceObj.Id == null)
                {
                    isValid = false;
                    errors.Append(requiredAttribute.ErrorMessage);
                }
            }

            foreach ( var rangeAttribute in rangeAttributes)
            {
                if (deviceObj.Code <= rangeAttribute.Start || deviceObj.Code >= rangeAttribute.End)
                {
                    isValid = false;
                    errors.Append(rangeAttribute.ErrorMessage);
                }
            }

            foreach ( var maxLengthAttribute in maxLengthAttributes)
            {
                if (deviceObj.Description.Length > maxLengthAttribute.Length)
                {
                    isValid = false;
                    errors.Append(maxLengthAttribute.ErrorMessage);
                }
            }
            return isValid;
        }
    }
}