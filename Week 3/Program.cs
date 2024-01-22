using System;
using System.Collections.Generic;

namespace Code_Assignment
{
    class Device
    {
        [Required(ErrorMessage = "ID Property Requires Value")]
        public string Id { get; set; }

        [Range(10, 100, "Code Value Must Be Within 10-100")]
        public int Code { get; set; }

        [MaxLength(100, "Max of 100 Charcters are allowed")]
        public string Description { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Device deviceObj = new Device();
            deviceObj.Id = null;
            deviceObj.Code = 0;
            deviceObj.Description = "Hello";

            List<string> errors;
            bool isValid = ObjectValidator.Validate(deviceObj, out errors);
            if (!isValid)
            {
                foreach (string item in errors)
                {
                    System.Console.WriteLine(item);
                }
            }
            Console.ReadLine();
        }
    }
}
