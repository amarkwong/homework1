using System;
namespace School
{
    public static class InputValidation
    {
        public static int checkCreditLimit(String input)
        {
            try
            {
                int i = Convert.ToInt16(input);
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static int checkMaxStudent(String input)
        {
            try
            {
                int i = Convert.ToInt16(input);
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static int checkCredit(String input)
        {
            try
            {
                int i = Convert.ToInt16(input);
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static int checkGrade(String input)
        {
            try
            {
                int i = Convert.ToInt16(input);
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static int checkChoice(String input)
        {
            try
            {
                int i = Convert.ToInt16(input);
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public static int checkGPARange(String input)
        {
            try
            {
                int i = Convert.ToInt16(input);
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
