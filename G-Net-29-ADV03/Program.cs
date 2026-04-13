using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment03
    {
    internal class Program
        {
        static void Main( string[] args )
            {
            Ex1();
            Ex2();
            Ex3();
            Ex4();
            Ex5();
            Ex6();
            }

        static void PrintTitle( string title )
            {
            Console.WriteLine("\n" + title);
            Console.WriteLine(new string('-', 40));
            }

        // ============================
        // Ex1
        // ============================
        static void Ex1()
            {
            PrintTitle("Ex1");

            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades: " + string.Join(", ", grades));
            Console.WriteLine("Count: " + grades.Count);
            Console.WriteLine("First: " + grades.First());
            Console.WriteLine("Last: " + grades.Last());

            grades.Sort();
            Console.WriteLine("Sorted: " + string.Join(", ", grades));

            Console.WriteLine("First > 90: " + grades.FirstOrDefault(g => g > 90));

            var failing = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing: " + string.Join(", ", failing));

            grades.RemoveAll(g => g < 75);
            Console.WriteLine("After Remove: " + string.Join(", ", grades));

            Console.WriteLine("Has 100: " + grades.Contains(100));

            var strings = grades.Select(g => $"Grade: {g}");
            Console.WriteLine(string.Join(" | ", strings));
            }

        // ============================
        // Ex2
        // ============================
        static void Ex2()
            {
            PrintTitle("Ex2");

            var leaderboard = new SortedDictionary<int, string>
            {
                {500, "Abdo"},
                {200, "Tamer"},
                {800, "Mahmoud"},
                {350, "Emam"}
            };

            foreach ( var item in leaderboard )
                Console.WriteLine($"{item.Key} = {item.Value}");

            Console.WriteLine("First Key: " + leaderboard.First().Key);
            Console.WriteLine("First Value: " + leaderboard.First().Value);

            Console.WriteLine("Has 500: " + leaderboard.ContainsKey(500));

            if ( leaderboard.TryGetValue(999, out var player) )
                Console.WriteLine(player);
            else
                Console.WriteLine("Not Found");

            leaderboard.Remove(200);

            Console.WriteLine("After Remove:");
            foreach ( var item in leaderboard )
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

        // ============================
        // Ex3
        // ============================
        static void Ex3()
            {
            PrintTitle("Ex3");

            var phoneBook = new Dictionary<string, string>
            {
                {"Abdo", "01011111111"},
                {"Tamer", "01022222222"},
                {"Mahmoud", "01033333333"},
                {"Emam", "01044444444"}
            };

            phoneBook["Abdo"] = "01099999999";

            try
                {
                phoneBook.Add("Abdo", "000");
                }
            catch ( Exception ex )
                {
                Console.WriteLine("Error: " + ex.Message);
                }

            Console.WriteLine("TryAdd: " + phoneBook.TryAdd("Tamer", "111"));

            Console.WriteLine(phoneBook.ContainsKey("Ali") ? "Found" : "Not Found");

            Console.WriteLine(phoneBook.GetValueOrDefault("Ali", "Not Found"));

            Console.WriteLine("Keys: " + string.Join(", ", phoneBook.Keys));
            Console.WriteLine("Values: " + string.Join(", ", phoneBook.Values));
            }

        // ============================
        // Ex4
        // ============================
        static void Ex4()
            {
            PrintTitle("Ex4");

            var emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "abdo@test.com",
                "ABDO@test.com",
                "tamer@test.com",
                "Tamer@Test.Com"
            };

            Console.WriteLine("Count: " + emails.Count);

            var A = new HashSet<int> { 1, 2, 3, 4, 5 };
            var B = new HashSet<int> { 4, 5, 6, 7, 8 };

            var union = new HashSet<int>(A);
            union.UnionWith(B);
            Console.WriteLine("Union: " + string.Join(", ", union));

            var inter = new HashSet<int>(A);
            inter.IntersectWith(B);
            Console.WriteLine("Intersect: " + string.Join(", ", inter));

            var except = new HashSet<int>(A);
            except.ExceptWith(B);
            Console.WriteLine("Except: " + string.Join(", ", except));

            Console.WriteLine("{1,2} subset of A: " + new HashSet<int> { 1, 2 }.IsSubsetOf(A));
            }

        // ============================
        // Ex5
        // ============================
        static void Ex5()
            {
            PrintTitle("Ex5");

            var queue = new Queue<string>();

            queue.Enqueue("Report.pdf");
            queue.Enqueue("Invoice.pdf");
            queue.Enqueue("Letter.docx");
            queue.Enqueue("Resume.pdf");
            queue.Enqueue("Photo.jpg");

            Console.WriteLine("Queue: " + string.Join(", ", queue));
            Console.WriteLine("Count: " + queue.Count);

            Console.WriteLine("Next: " + queue.Peek());

            while ( queue.Count > 0 )
                Console.WriteLine("Printing: " + queue.Dequeue());

            Console.WriteLine("TryDequeue: " + queue.TryDequeue(out var x));
            }

        // ============================
        // Ex6
        // ============================
        static void Ex6()
            {
            PrintTitle("Ex6");

            var stack = new Stack<string>();

            stack.Push("google.com");
            stack.Push("github.com");
            stack.Push("stackoverflow.com");
            stack.Push("youtube.com");
            stack.Push("claude.ai");

            Console.WriteLine("Current: " + stack.Peek());

            for ( int i = 0; i < 3; i++ )
                Console.WriteLine("Back from: " + stack.Pop());

            Console.WriteLine("Now at: " + stack.Peek());

            stack.Clear();

            Console.WriteLine("TryPop: " + stack.TryPop(out var page));
            }
        }
    }
