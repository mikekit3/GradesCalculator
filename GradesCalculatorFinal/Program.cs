using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesCalculatorFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Measuring with Queue" + Environment.NewLine);
            Console.WriteLine("Students Count: 100");
            stopwatch.Start();
            CreateStudentsQueue(100);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 1000");
            stopwatch.Start();
            CreateStudentsQueue(1000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 10000");
            stopwatch.Start();
            CreateStudentsQueue(10000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 100000");
            stopwatch.Start();
            CreateStudentsQueue(100000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();


            Console.WriteLine(Environment.NewLine + "Measuring with List" + Environment.NewLine);
            Console.WriteLine("Students Count: 100");
            stopwatch.Start();
            CreateStudentsList(100);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 1000");
            stopwatch.Start();
            CreateStudentsList(1000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 10000");
            stopwatch.Start();
            CreateStudentsList(10000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 100000");
            stopwatch.Start();
            CreateStudentsList(100000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine(Environment.NewLine + "Measuring with LinkedList" + Environment.NewLine);
            Console.WriteLine("Students Count: 100");
            stopwatch.Start();
            CreateStudentsLinkedList(100);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 1000");
            stopwatch.Start();
            CreateStudentsLinkedList(1000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 10000");
            stopwatch.Start();
            CreateStudentsLinkedList(10000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.WriteLine("Students Count: 100000");
            stopwatch.Start();
            CreateStudentsLinkedList(100000);
            stopwatch.Stop();
            Console.WriteLine("Total Time Taken: {0}", stopwatch.Elapsed + Environment.NewLine);
            stopwatch.Reset();

            Console.ReadKey();
        }
        public static double GetFinalPoints(double homeworkAvg, double examResult)
        {
            return (0.3 * homeworkAvg) + (0.7 * examResult);
        }

        public static double GetMedian(List<double> homeworkResults, double examResult)
        {
            homeworkResults.Add(examResult);
            List<int> integers = homeworkResults.Select(d => (int)d).ToList();
            int[] numbers = integers.ToArray();

            int numberCount = numbers.Count();
            int halfIndex = numbers.Count() / 2;
            var sortedNumbers = numbers.OrderBy(n => n);
            double median;
            if ((numberCount % 2) == 0)
            {
                median = ((sortedNumbers.ElementAt(halfIndex) +
                    (sortedNumbers.ElementAt(halfIndex - 1))) / 2);
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
            }
            return median;
        }

        public static void PrintResults(List<Student> students)
        {
            Console.Clear();
            students = students.OrderBy(s => s.fullName.surname).ToList(); // sorting list by surname
            Console.WriteLine("Surname\t\tName\t\t\tFinalPoints (Avg.)  /  Final Points (Med.)");
            Console.WriteLine("------------------------------------------------------------------------------");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("{0}\t\t{1}\t\t\t{2}\t\t\t{3}", students[i].fullName.surname, students[i].fullName.name, Math.Round(students[i].finalPoints, 1), students[i].median);
            }
        }

        public static void CreateStudentsQueue(int count)
        {
            string name, surname;
            double homeworkResult;
            List<double> homeworkResults = new List<double>();
            Queue<Student> students = new Queue<Student>();
            double examResult;
            double finalPoints;
            double median;
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                homeworkResults.Clear();
                name = "Name" + (i + 1);
                surname = "Surname" + (i + 1);

                for (int j = 0; j < 4; j++)
                {
                    homeworkResult = random.Next(0, 10);
                    homeworkResults.Add(homeworkResult);
                }
                examResult = random.Next(0, 10);
                finalPoints = GetFinalPoints(homeworkResults.Average(), examResult);
                median = GetMedian(homeworkResults, examResult);
                Student student = new Student(name, surname, homeworkResults, examResult, finalPoints, median);
                students.Enqueue(student);
            }
            WriteToFileQueue(students);
        }

        public static void WriteToFileQueue(Queue<Student> students)
        {
            string fileName = "students_queue" + students.Count + ".txt";
            using (StreamWriter writetext = new StreamWriter(fileName))
            {
                writetext.WriteLine("Surname\t\tName\t\t\tFinalPoints (Avg.)  /  Final Points (Med.)");
                writetext.WriteLine("------------------------------------------------------------------------------");
                for (int i = 0; i < students.Count; i++)
                {
                    Student student = students.Dequeue();
                    writetext.WriteLine("{0}\t\t{1}\t\t\t{2}\t\t\t{3}", student.fullName.surname, student.fullName.name, Math.Round(student.finalPoints, 1), student.median);
                }
            }
        }

        public static void CreateStudentsList(int count)
        {
            string name, surname;
            double homeworkResult;
            List<double> homeworkResults = new List<double>();
            List<Student> students = new List<Student>();
            double examResult;
            double finalPoints;
            double median;
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                homeworkResults.Clear();
                name = "Name" + (i + 1);
                surname = "Surname" + (i + 1);

                for (int j = 0; j < 4; j++)
                {
                    homeworkResult = random.Next(0, 10);
                    homeworkResults.Add(homeworkResult);
                }
                examResult = random.Next(0, 10);
                finalPoints = GetFinalPoints(homeworkResults.Average(), examResult);
                median = GetMedian(homeworkResults, examResult);
                Student student = new Student(name, surname, homeworkResults, examResult, finalPoints, median);
                students.Add(student);
            }
            WriteToFileList(students);
        }
        public static void WriteToFileList(List<Student> students)
        {
            string fileName = "students_list" + students.Count + ".txt";

            using (StreamWriter writetext = new StreamWriter(fileName))
            {
                writetext.WriteLine("Surname\t\tName\t\t\tFinalPoints (Avg.)  /  Final Points (Med.)");
                writetext.WriteLine("------------------------------------------------------------------------------");
                for (int i = 0; i < students.Count; i++)
                {
                    writetext.WriteLine("{0}\t\t{1}\t\t\t{2}\t\t\t{3}", students[i].fullName.surname, students[i].fullName.name, Math.Round(students[i].finalPoints, 1), students[i].median);
                }
            }
        }

        public static void CreateStudentsLinkedList(int count)
        {
            string name, surname;
            double homeworkResult;
            List<double> homeworkResults = new List<double>();
            LinkedList<Student> students = new LinkedList<Student>();
            double examResult;
            double finalPoints;
            double median;
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                homeworkResults.Clear();
                name = "Name" + (i + 1);
                surname = "Surname" + (i + 1);

                for (int j = 0; j < 4; j++)
                {
                    homeworkResult = random.Next(0, 10);
                    homeworkResults.Add(homeworkResult);
                }
                examResult = random.Next(0, 10);
                finalPoints = GetFinalPoints(homeworkResults.Average(), examResult);
                median = GetMedian(homeworkResults, examResult);
                Student student = new Student(name, surname, homeworkResults, examResult, finalPoints, median);
                students.AddLast(student);
            }
            WriteToFileLinkedList(students);
        }
        public static void WriteToFileLinkedList(LinkedList<Student> students)
        {
            string fileName = "students_linked_list" + students.Count + ".txt";

            using (StreamWriter writetext = new StreamWriter(fileName))
            {
                writetext.WriteLine("Surname\t\tName\t\t\tFinalPoints (Avg.)  /  Final Points (Med.)");
                writetext.WriteLine("------------------------------------------------------------------------------");
                foreach (var student in students)
                {
                    writetext.WriteLine("{0}\t\t{1}\t\t\t{2}\t\t\t{3}", student.fullName.surname, student.fullName.name, Math.Round(student.finalPoints, 1), student.median);
                }
            }
        }

    }
}
