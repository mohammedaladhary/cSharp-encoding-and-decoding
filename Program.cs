using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PackageMeasurementConverterAPI
{
    class Program
    {
        static int ConvertToNumber(char c)
        {
            if (c == '_')
                return 0;

            return char.ToLower(c) - 'a' + 1;
        }

        static List<int> Decode(string encodedString)
        {
            List<int> results = new List<int>();
            int currentIndex = 0;

            if (!encodedString.All(char.IsLetter))
            {
                Console.WriteLine("Invalid input. Please enter only alphabetical characters.");
            }

            while (currentIndex < encodedString.Length)
            {

                int count = encodedString[currentIndex] - 'a' + 1;
                currentIndex++;

                string package = encodedString.Substring(currentIndex, count);
                currentIndex += count;

                int packageSum = 0;
                foreach (char character in package)
                {
                    packageSum += character - 'a' + 1;
                }
                results.Add(packageSum);


            }

            return results;
        }

        static void Main(string[] args)
        {

            Console.Write("Enter a sequence of characters: ");
            string sequence = Console.ReadLine();

            if (!sequence.All(c => char.IsLetter(c) || c == '_'))
            {
                Console.WriteLine("Invalid input. Please enter only alphabetical characters or underscores.");
                return;
            }
            else
            {
                List<int> decodedValues = Decode(sequence);
                //Console.WriteLine($"\n(firstLetter: {sequence[0]}, no.of letters to combine: {decodedValues.Count})");
                Console.WriteLine("\nThe Result is: " + "[" + string.Join(", ", decodedValues) + "]");
            }
        }
    }
}
