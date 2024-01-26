using System;

namespace Code_Assignment
{
    public class Required : Attribute
    {
        public string ErrorMessage { get; set; }
    }

    public class Range : Attribute
    {
        public int Start { get; set; }
        public int End { get; set; }
        public string ErrorMessage { get; set; }
        public Range(int start, int end, string errorMessage)
        {
            Start = start;
            End = end;
            ErrorMessage = errorMessage;
        }
    }

    public class MaxLength : Attribute
    {
        public int Length { get; set; }
        public string ErrorMessage { get; set; }
        public MaxLength(int length, string error)
        {
            Length = length;
            ErrorMessage = error;
        }
    }
}
