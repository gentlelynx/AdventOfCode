using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace AoC;

class Day1part1
{
    public static string filePath = "../../../input-test.txt";

    static void Main()
    {
        (char, int)[] inputList = ParseInput(filePath);
        Console.WriteLine(TimesStoppedAtZero(inputList));
        Console.ReadLine();
    }

    static int TimesStoppedAtZero((char, int)[] inputList)
    {
        int dialPosition = 50;
        int counter = 0;

        foreach (var inputLine in inputList)
        {
            dialPosition = OneRotation(inputLine, dialPosition);

            if (dialPosition == 0)
            {
                counter++;
            }
        }
        return counter;
    }

    static int OneRotation((char, int) inputLine, int dialPosition)
    {
        return inputLine.Item1 == 'L' ? LeftRotation(inputLine.Item2, dialPosition) : RightRotation(inputLine.Item2, dialPosition);
    }

    static int LeftRotation(int rotationValue, int dialPosition)
    {
        int newPosition = dialPosition - rotationValue;

        while (newPosition < 0)
        {
            newPosition = newPosition + 100;
        }

        return newPosition;
    }

    static int RightRotation(int rotationValue, int dialPosition)
    {
        return (dialPosition + rotationValue) % 100;
    }

    static (char, int)[] ParseInput(string filePath) //take in filePath, return tuple of strings
    {
        string[] lines = File.ReadAllText(filePath).Split("\n");
        (char, int)[] parsedArray = new (char, int)[10]; //empty array to fill

        for (int i = 0; i < 10; ++i)
        {
            parsedArray[i] = TupleFromLine(lines[i]);
        }

        return parsedArray;
    }

    static (char, int) TupleFromLine(string line) //take in line as a string, convert to char + int 
    {
        (char, int) parsedLine;

        parsedLine = (line[0], Int32.Parse(line.Substring(1)));

        return parsedLine;
    }

}