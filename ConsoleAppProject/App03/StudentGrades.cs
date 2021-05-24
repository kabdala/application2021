using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{

    /// <summary>
    /// This is a small app to store, calculate and display
    /// student grades. It should use an SQL database to hold the
    /// data
    /// 
    /// Outline of program:
    /// 1. Input marks
    /// 2. Output marks
    /// 3. Output stats
    /// 4. Output grade profile
    /// 5. Quit
    /// </summary>
    public class StudentGrades
    {
        // Setup the application constants

        public const int NoGrade = 0;
        public const int LowGradeD = 40;
        public const int LowGradeC = 50;
        public const int LowGradeB = 60;
        public const int LowGradeA = 70;
        public const int HighGrade = 100;

        // Setup the main properties
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        // Main constructor

        // Populate the Students string with some
        // sample student names (extra points for knowing
        // the last 7 names on this list 😁
        public StudentGrades()
        {
            Students = new string[]
            {
                "Rod", "Jane", "Freddie",
                "Zoltar", "Keyop", "Jason",
                "Tiny", "Prince", "Mark",
                "Zark"
            };

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
        }

        /// <summary>
        /// Output a heading on the console app version
        /// using the consolehelper
        /// </summary>
        public void OutputHeading()
        {
            ConsoleHelper.OutputHeading("Simple Student Mark App",0.5);
            SelectChoice();
        }

        /// <summary>
        /// Dispay all the students along with their marks
        /// </summary>
        public void OutputMarks()
        {
            //TODO: Tidy up output
            //throw new NotImplementedException();
            //Console.WriteLine("\nStudent Grade Information");
            ConsoleHelper.OutputTitle("\nStudent Grade Information");
            // foreach loop to go through the list of students and grades
            // Call the ConvertToGrades to convert the marks to grade values

            for (int i = 0; i < Students.Length; i++)
            {
                Console.WriteLine($"Student No:{i+1}\t{Students[i]}\t{Marks[i]}\t{ConvertToGrade(Marks[i])}");
            }
            SelectChoice();

        }

        /// <summary>
        /// Convert a student grade from F to A
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= NoGrade && mark < LowGradeD)
            {
                return Grades.F;
            }
            else if (mark >= LowGradeD && mark < LowGradeC)
            {
                return Grades.D;
            }
            else if (mark >= LowGradeC && mark < LowGradeB)
            {
                return Grades.C;
            }
            else if (mark >= LowGradeB && mark < LowGradeA)
            {
                return Grades.B;
            }
            else if (mark >= LowGradeA && mark <= HighGrade)
            {
                return Grades.A;
            }
            // return Grades.N;
            return Grades.N;
        }

        /// <summary>
        /// Calculate and output min, max and mean marks for
        /// all 10 students
        /// </summary>
        public void CalculateStats()
        {
            Min = Marks[0];
            Max = Marks[0];

            double total = 0;
            foreach (int mark in Marks)
            {
                if (mark > Max) Max = mark;
                if (mark < Min) Min = mark;
                total = total + mark;
            }
            Mean = total / Marks.Length;
        }

        /// <summary>
        /// Display the student mark statistics: Mean, minumum and maximum marks
        /// Then when done, return to the main menu
        /// </summary>
        public void OutputStats()
        {
            CalculateStats();
            Console.WriteLine("\n### Student Grade Statistics ###");
            Console.WriteLine("");
            Console.WriteLine($"The minimum mark achieved by a student: {Min}");
            Console.WriteLine($"The maximum mark achieved by a student: {Max}");
            Console.WriteLine($"The mean marks achieved across all students: {Mean}");

            SelectChoice();
        }

        // Testing
        public void CalculateMin()
        {
            Min = Marks[0];
            Max = Marks[0];

            double total = 0;
            foreach (int mark in Marks)
            {
                if (mark > Max) Max = mark;
                if (mark < Min) Min = mark;
                Mean = total / Marks.Length;
            }
        }

        // Testing
        public void CalculateMax()
        {
            Min = Marks[0];
            Max = Marks[0];

            double total = 0;
            foreach (int mark in Marks)
            {
                if (mark > Max) Max = mark;
                if (mark < Min) Min = mark;
                Mean = total / Marks.Length;
            }
        }

        /// <summary>
        /// Calculate the grade profile. Loop through the marks and 
        /// assign
        /// </summary>
        public void CalculateGradeProfile()
        {
            for(int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }
        }

        /// <summary>
        /// Display the grade profile for all 10 students
        /// then go back to the main menu. First we need to get the
        /// grade profile then display the results
        /// </summary>
        public void OutputGradeProfile()
        {
            CalculateGradeProfile();
            // Start with the default grade of N (NA)
            // TODO: Do not need to display the 'N' grade in the output
            ConsoleHelper.OutputTitle("\n## STUDENT GRADE PROFILE ##\n");
            //Console.WriteLine("\n## STUDENT GRADE PROFILE ##\n");
            Grades grade = Grades.N;
            foreach (int count in GradeProfile)
            {
                int percent = count * 100 / Marks.Length;

                // Trying \t tabstops to make output easier to read
                Console.WriteLine($"Grade {grade}\t {percent}% \tCount \t{count}");
                grade++;
            }
            Console.WriteLine("\n--- END ---\n");
            SelectChoice();
            
        }

        /// <summary>
        /// Prompt the user to enter a choice from the main menu
        /// 1. Enter Marks
        /// 2. Display Marks
        /// 3. Display Stats
        /// 4. Display Grade Profile
        /// 5. Quit the program
        /// NOTE: Switch maybe would be more elegant here?
        /// </summary>
        public void SelectChoice()
        {
            Console.WriteLine("### MAIN MENU ###");
            Console.WriteLine("\n*** Please select one of the following options ***\n");
            string[] choices = { "Enter Marks", "Display Marks",
                                 "Display Stats", "Display Grade Profile", "Quit" };
            int choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1)
            {
                EnterMarks();
            }
            else if (choice == 2)
            {
                OutputMarks();
            }
            else if (choice == 3)
            {
                OutputStats();
            }
            else if (choice == 4)
            {
                OutputGradeProfile();
            }
            else if (choice == 5)
            {
                // Thanks to https://dotnetcodr.com/2015/10/02/how-to-terminate-a-net-console-application-with-an-exit-code/
                // for the 'how to exit a console app'
                Environment.Exit(-1);
            }
            else
            {
                Console.WriteLine("* Error. Please select a choice (1-5 *");
                SelectChoice(); // Loop back to choose again
            }
        }

        /// <summary>
        /// Ask the user for the marks for 10 students plus
        /// display the student number in the input string
        /// </summary>
        public void EnterMarks()
        {
            Console.WriteLine("Please enter marks: ");
            // Create a loop to enter the 10 students marks
            for(int i = 0; i < Students.Length; i++)
            {
                // Thanks StackOverflow for the 'Cast' reminder 😁
                // Limit the input between min & max marks (0 to 100)
                Marks[i] = (int)ConsoleHelper.InputNumber
                    ($"\nPlease enter the mark for student #"+(i+1)+$" {Students[i]}: ", 0, 100);
            }
            // Now, go back to the main menu
            SelectChoice();
        }

    }

}
