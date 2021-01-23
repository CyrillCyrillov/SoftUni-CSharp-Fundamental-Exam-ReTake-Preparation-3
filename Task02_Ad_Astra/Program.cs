using System;
using System.Text.RegularExpressions;

namespace Task02_Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\||#)([A-z ]+)\1(0[1-9]|[1-2][0-9]|3[0-1])\/(0[1-9]|1[0-9])\/([0-9]{2})\1([0-9]{1,4})\1";

            Regex extractInfo = new Regex(pattern);

            string textInfo = Console.ReadLine();

            MatchCollection foodInfo = extractInfo.Matches(textInfo);

            int totalCalories = 0;

            foreach (Match element in foodInfo)
            {
                totalCalories += int.Parse(element.Groups[6].Value);
            }

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");

            foreach (Match element in foodInfo)
            {
                Console.WriteLine($"Item: {element.Groups[2].Value}, Best before: {element.Groups[3].Value}/{element.Groups[4].Value}/{element.Groups[5].Value}, Nutrition: {element.Groups[6].Value}");
            }
        }
    }
}
