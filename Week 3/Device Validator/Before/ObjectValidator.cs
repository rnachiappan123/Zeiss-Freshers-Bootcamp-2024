using System.Collections.Generic;

namespace Code_Assignment
{
    internal class ObjectValidator
    {
        public static bool Validate(Device deviceObj, out List<string> errors)
        {
            bool isValid = true;
            var requiredAttribute = (Required)typeof(Device).GetProperty("Id").GetCustomAttributes(typeof(Required), true)[0];
            var rangeAttribute = (Range)typeof(Device).GetProperty("Code").GetCustomAttributes(typeof(Range), true)[0];
            var maxLengthAttribute = (MaxLength)typeof(Device).GetProperty("Description").GetCustomAttributes(typeof(MaxLength), true)[0];
            errors = new List<string>();

            if (deviceObj.Id == null || deviceObj.Id.Equals(""))
            {
                isValid = false;
                errors.Add(requiredAttribute.ErrorMessage);
            }

            if (deviceObj.Code < rangeAttribute.Start || deviceObj.Code > rangeAttribute.End)
            {
                isValid = false;
                errors.Add(rangeAttribute.ErrorMessage);
            }

            if (deviceObj.Description.Length > maxLengthAttribute.Length)
            {
                isValid = false;
                errors.Add(maxLengthAttribute.ErrorMessage);
            }

            return isValid;
        }
    }
}
