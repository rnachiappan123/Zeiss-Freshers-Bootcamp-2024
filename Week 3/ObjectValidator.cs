using System.Collections.Generic;

namespace Code_Assignment
{
    internal class ObjectValidator
    {
        public static bool Validate(Device deviceObj, out List<string> errors)
        {
            bool isValid = true;
            var requiredAttributes = (Required[]) typeof(Device).GetProperty("Id").GetCustomAttributes(typeof(Required), true);
            var rangeAttributes = (Range[]) typeof(Device).GetProperty("Code").GetCustomAttributes(typeof(Range), true);
            var maxLengthAttributes = (MaxLength[]) typeof(Device).GetProperty("Description").GetCustomAttributes(typeof(MaxLength), true);
            errors = new List<string>();

            foreach ( var requiredAttribute in requiredAttributes)
            {
                if (deviceObj.Id == null)
                {
                    isValid = false;
                    errors.Add(requiredAttribute.ErrorMessage);
                }
            }

            foreach ( var rangeAttribute in rangeAttributes)
            {
                if (deviceObj.Code < rangeAttribute.Start || deviceObj.Code > rangeAttribute.End)
                {
                    isValid = false;
                    errors.Add(rangeAttribute.ErrorMessage);
                }
            }

            foreach ( var maxLengthAttribute in maxLengthAttributes)
            {
                if (deviceObj.Description.Length > maxLengthAttribute.Length)
                {
                    isValid = false;
                    errors.Add(maxLengthAttribute.ErrorMessage);
                }
            }
            return isValid;
        }
    }
}