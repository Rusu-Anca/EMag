using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.HelperMethods
{
    public static class Randomise
    {

        public static Random _random = new Random();

        /// <summary>
        /// Generate a random number from a specific interval.
        /// </summary>
        /// <param name="min">The interval starting point.</param>
        /// <param name="max">The interval end point.</param>
        /// <returns></returns>
        public static string RandomFromInterval(int min, int max)
        {
            Random _random = new Random();

            return _random.Next(min, max).ToString();
        }

        /// <summary>
        /// Generate a random number giving only the interval's end point.
        /// </summary>
        /// <param name="number">The interval's end point.</param>
        /// <returns></returns>
        public static int Random(int number)
        {
          //  Random _random = new Random();

            return _random.Next(number);
        }

        /// <summary>
        /// Generates a random month in XX format.
        /// </summary>
        /// <returns>The month as string.</returns>
        public static string RandomMonth()
        {
            int random = Random(12);
            if (random / 10 == 0)
            {
                return $"0{random}";
            }
            else return random.ToString();
        }

        /// <summary>
        /// Split the month XX (09) format and return the 2nd digit.
        /// </summary>
        /// <param name="month">The month as a string.</param>
        /// <returns>Month as int X format.</returns>
        public static int SplitMonth(string month)
        {
            if (int.Parse(month) / 10 == 0)
            {
                var ch = month.ToCharArray()[1];
                return (int)Char.GetNumericValue(ch);
            }
            else return int.Parse(month);
        }

        /// <summary>
        /// Generate a random day XX format.
        /// </summary>
        /// <param name="year">A given year.</param>
        /// <param name="month">A given month.</param>
        /// <returns>The day as a string.</returns>
        public static string RandomDay(string year, string month)
        {
           // Random _random = new Random();
            if (int.Parse(year) % 4 == 0 && SplitMonth(month) == 2)
            {
                int randomDay = _random.Next(28);
                if (randomDay / 10 == 0)
                {
                    return $"0{randomDay}";
                }
                else return randomDay.ToString();
            }
            else
            {
                int randomDay = _random.Next(30);
                if ((randomDay / 10 == 0))
                 {
                    return $"0{randomDay}";
                }
                else return randomDay.ToString();
            }
        }

        public static string RandomNumberOfLength(int length)
        {
            //Random _random = new Random();
            string number = _random.Next(9).ToString();
            while (number.Length < length)
            {
                number += _random.Next(9).ToString();
            }
            return number.ToString();
        }

        public static string RandomStringOfLength(int stringLength)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[_random.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
