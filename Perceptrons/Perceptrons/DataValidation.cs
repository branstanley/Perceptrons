using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptrons
{
    static class DataValidation
    {

        /*******************************************************************
         * 
         * Data Pasring Methods
         * 
         *******************************************************************/
        public static Boolean parseBoolean(String raw)
        {
            if (raw.ToLower() == "true" || raw == "1")
                return true;
            else if (raw.ToLower() == "false" || raw == "0")
                return false;
            else
                throw new Exception("Invalid input of " + raw + ".  Expected values: 0, 1, true, false");
        }

        /*******************************************************************
         * 
         * User Input Data Validation Methods
         * 
         *******************************************************************/

        public static Boolean get_boolean()
        {
            while (true)
            {
                try
                {
                    String raw = Console.ReadLine();
                    if (raw == "1" || raw == "0")
                        return Convert.ToBoolean(Convert.ToInt16(raw));
                    else if (raw == "true" || raw == "false")
                        return Boolean.Parse(raw);
                    else
                        Console.WriteLine("Invalid input");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                }
            }
        }

        public static Boolean yes_no()
        {
            while (true)
            {
                try
                {
                    String raw = Console.ReadLine();
                    if (raw.ToLower() == "y" || raw.ToLower() == "yes")
                        return true;
                    else if (raw.ToLower() == "n" || raw.ToLower() == "no")
                        return false;
                    else
                        Console.WriteLine("Invalid input");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                }
            }
        }

        public static int get_int()
        {
            while (true)
            {
                try
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    return value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                }
            }
        }
    }
}
