using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 04 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Phill Horrocks 25/03/21
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            ConsoleHelper.OutputHeading("CO453 C# Programming - MAIN MENU", 0.2);
            string[] choices = {
                "APP01: Distance Converter",
                "APP02: BMI Calculator",
                "APP03: Student Grades System",
                "APP04: Social Network"
            };
            int choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1)
            {
                DistanceConverter converter = new DistanceConverter();
                converter.ConvertDistance();
            }
            if (choice == 2)
            {
                BMI bmi = new BMI();
                bmi.MainMenu();
            }
            if (choice == 3)
            {
                StudentGrades studentGrades = new StudentGrades();
                studentGrades.OutputHeading();
            }
            if (choice == 4)
            {
                NetworkApp networkApp = new NetworkApp();
                networkApp.DisplayMenu();
            }
            else
            {
                Console.WriteLine("Please make your choice");
            }

        }
    }
}
