
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

        static List<int> Package(string sequence)
        {
            List<int> results = new List<int>();
            int currentIndex = 0;

            while (currentIndex < sequence.Length)
            {
                int count = ConvertToNumber(sequence[currentIndex]);
                currentIndex++;

                if (count == 0) // Handle underscore as zero
                {
                    Console.WriteLine("Invalid input. Please enter only alphabetical characters or underscores.");
                    return null;
                }

                if (currentIndex >= sequence.Length)
                {
                    Console.WriteLine("Invalid input sequence format.");
                    return null;
                }

                if (count == 26) // Counter is 'z'
                {
                    int nextValue = ConvertToNumber(sequence[currentIndex]);
                    int packageSum = count + nextValue;
                    results.Add(packageSum);

                    currentIndex++;
                }
                else
                {
                    string package = sequence.Substring(currentIndex, count);
                    currentIndex += count;

                    int packageSum = 0;
                    foreach (char character in package)
                    {
                        packageSum += ConvertToNumber(character);
                    }
                    results.Add(packageSum);
                }
            }

            return results;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\nEnter a sequence of characters (or type 'exit' to quit): ");
                string sequence = Console.ReadLine().ToLower();

                if (sequence == "exit")
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }

                if (!sequence.All(c => char.IsLetter(c) || c == '_'))
                {
                    Console.WriteLine("Invalid input. Please enter only alphabetical characters with underscores/without underscores.");
                    continue; // Go back to the beginning of the loop
                }
                else
                {
                    List<int> decodedValues = Package(sequence);
                    Console.WriteLine("\nThe Result is: " + "[" + string.Join(", ", decodedValues) + "]");
                }
            }
        }
    }
}

//static List<int> Package(string sequence)
//{
//    List<int> results = new List<int>();
//    int currentIndex = 0;

//    //if (!sequence.All(char.IsLetter))
//    //{
//    //    Console.WriteLine("Invalid input. Please enter only alphabetical characters.");
//    //}

//    while (currentIndex < sequence.Length)
//    {

//        int count = sequence[currentIndex] - 'a' + 1;
//        currentIndex++;

//        string package = sequence.Substring(currentIndex, count);
//        currentIndex += count;

//        int packageSum = 0;
//        foreach (char character in package)
//        {
//            packageSum += character - 'a' + 1;
//        }
//        results.Add(packageSum);


//    }

//    return results;
//}