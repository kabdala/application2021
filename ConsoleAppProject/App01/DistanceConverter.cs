using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This is a console app to convert distance from one unit to another
    /// It will prompt the user for a distance in one unit (fromUnit) to
    /// be converted into another unit (toUnit)
    /// 
    /// The units available for conversion are:
    /// 1. Miles
    /// 2. Feet
    /// 3. Metres
    /// </summary>
    /// <author>
    /// Phill Horrocks version 0.6
    /// </author>
    public class DistanceConverter
    {
        // Setup the distance variables
        public double FromDistance { get; set; }
        public double ToDistance { get; set; }
        public DistanceUnits FromUnit { get; set; }
        public DistanceUnits ToUnit { get; set; }

        // Conversions
        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;
        public const double FEET_IN_METRES = 3.28084;

        public DistanceConverter()
        {
            FromUnit = DistanceUnits.Miles;
            ToUnit = DistanceUnits.Feet;
        }
        /// <summary>
        /// Output the results of the conversion back
        /// to the user
        /// </summary>
        public void OutputDistance()
        {
            Console.WriteLine($"\n {FromDistance} {FromUnit} is {ToDistance} {ToUnit}");
        }
        public void ConvertDistance()
        {
            ConsoleHelper.OutputHeading("Distance Converter", 0.6);
            FromUnit = SelectUnit(" Please select the 'from' distance unit: ");
            ToUnit = SelectUnit(" Please select the 'to' distance unit: ");

            Console.WriteLine($"\n Convert {FromUnit} to {ToUnit}");

            FromDistance = InputDistance($" Please enter the number of {FromUnit}: ");
            CalculateDistance();
            OutputDistance();
        }
        /// <summary>
        /// Calculate the conversion, referencing the enum
        /// to get the units
        /// </summary>
        public void CalculateDistance()
        {
            if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }
        }

        /// <summary>
        /// Ask the user for the unit
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private DistanceUnits SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);
            DistanceUnits unit = ExecuteChoice(choice);
            return unit;
        }


        private DistanceUnits ExecuteChoice(string choice)
        {
            //used to store local choice of unit
            DistanceUnits unit;

            switch (choice)
            {
                case "1": unit = DistanceUnits.Feet; break;
                case "2": unit = DistanceUnits.Metres; break;
                case "3": unit = DistanceUnits.Miles; break;
                default: unit = DistanceUnits.NoUnit; break;
            }

            if (unit == DistanceUnits.NoUnit)
            {
                Console.WriteLine("\n\nI'm sorry Dave, I'm afraid I can't do that...");
                Console.WriteLine("You must select a digit between 1 and 3");
                Console.WriteLine("Daisy... Daisy...\n\n");
            }
            Console.WriteLine($"\n You have selected: {unit}");
            return unit;
        }

        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($"1. {DistanceUnits.Feet}");
            Console.WriteLine($"2. {DistanceUnits.Metres}");
            Console.WriteLine($"3. {DistanceUnits.Miles}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }

        /// <summary>
        /// General purpose imput method
        /// Ask the user to input a distance unit
        /// Input the unit as a double
        /// </summary>
        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }



        /// <summary>
        /// Output header to the user
        /// </summary> 
        private void OutputHeader()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     Convert units of distance      ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("         by Phill Horrocks          ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-");
        }


    }
}
