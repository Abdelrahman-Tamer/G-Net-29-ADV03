namespace Assignment03
    {
    internal class Program
        {
        static void Main( string[] args )
            {
            Exercise1();
            Console.WriteLine(new string('-', 50));

            Exercise2();
            Console.WriteLine(new string('-', 50));

            Exercise3();
            Console.WriteLine(new string('-', 50));

            Exercise4();
            Console.WriteLine(new string('-', 50));

            Exercise5();
            Console.WriteLine(new string('-', 50));

            Exercise6();
            }

        static void Exercise1()
            {
            Console.WriteLine("Exercise 1: Student Grade Manager");

            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades: " + string.Join(", ", grades));
            Console.WriteLine("Count: " + grades.Count);
            Console.WriteLine("First Grade: " + grades.First());
            Console.WriteLine("Last Grade: " + grades.Last());

            grades.Sort();
            Console.WriteLine("Sorted Grades: " + string.Join(", ", grades));

            int firstAbove90 = grades.FirstOrDefault(g => g > 90);
            Console.WriteLine("First Grade Above 90: " + firstAbove90);

            List<int> failingGrades = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing Grades: " + string.Join(", ", failingGrades));

            grades.RemoveAll(g => g < 75);
            Console.WriteLine("After Removing Failing Grades: " + string.Join(", ", grades));

            bool has100 = grades.Any(g => g == 100);
            Console.WriteLine("Any Grade Equals 100: " + has100);

            List<string> gradeStrings = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine("String List: " + string.Join(" | ", gradeStrings));
            }

        static void Exercise2()
            {
            Console.WriteLine("Exercise 2: Leaderboard");

            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>
            {
                { 500, "Ahmed" },
                { 200, "Sara" },
                { 800, "Ali" },
                { 350, "Mona" }
            };

            foreach ( var item in leaderboard )
                {
                Console.WriteLine($"{item.Key} = {item.Value}");
                }

            Console.WriteLine("First Key: " + leaderboard.First().Key);
            Console.WriteLine("First Value: " + leaderboard.First().Value);

            Console.WriteLine("Score 500 Exists: " + leaderboard.ContainsKey(500));

            if ( leaderboard.TryGetValue(999, out string player) )
                Console.WriteLine("Player with 999: " + player);
            else
                Console.WriteLine("Player with 999: Not Found");

            leaderboard.Remove(200);

            Console.WriteLine("After Removing Score 200:");
            foreach ( var item in leaderboard )
                {
                Console.WriteLine($"{item.Key} = {item.Value}");
                }
            }

        static void Exercise3()
            {
            Console.WriteLine("Exercise 3: Phone Book");

            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                { "Ahmed", "01011111111" },
                { "Sara", "01022222222" },
                { "Ali", "01033333333" },
                { "Mona", "01044444444" }
            };

            phoneBook["Omar"] = "01055555555";
            phoneBook["Ahmed"] = "01099999999";

            try
                {
                phoneBook.Add("Sara", "01000000000");
                }
            catch ( Exception ex )
                {
                Console.WriteLine("Add Error: " + ex.Message);
                }

            bool added = phoneBook.TryAdd("Ali", "01111111111");
            Console.WriteLine("TryAdd Ali Succeeded: " + added);

            if ( phoneBook.ContainsKey("Nour") )
                Console.WriteLine("Nour: " + phoneBook["Nour"]);
            else
                Console.WriteLine("Nour: Contact does not exist");

            string result = phoneBook.GetValueOrDefault("Khaled", "Not Found");
            Console.WriteLine("Khaled: " + result);

            Console.WriteLine("Keys: " + string.Join(" ", phoneBook.Keys));
            Console.WriteLine("Values: " + string.Join(" ", phoneBook.Values));
            }

        static void Exercise4()
            {
            Console.WriteLine("Exercise 4: Unique Email Validator");

            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            Console.WriteLine("Stored Emails Count: " + emails.Count);
            Console.WriteLine("Stored Emails: " + string.Join(", ", emails));
            Console.WriteLine("Reason: HashSet is case-insensitive, so duplicate emails are counted once.");

            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            HashSet<int> union = new HashSet<int>(setA);
            union.UnionWith(setB);
            Console.WriteLine("UnionWith: " + string.Join(", ", union));

            HashSet<int> intersect = new HashSet<int>(setA);
            intersect.IntersectWith(setB);
            Console.WriteLine("IntersectWith: " + string.Join(", ", intersect));

            HashSet<int> except = new HashSet<int>(setA);
            except.ExceptWith(setB);
            Console.WriteLine("ExceptWith: " + string.Join(", ", except));

            HashSet<int> smallSet = new HashSet<int> { 1, 2 };
            Console.WriteLine("{1,2} Is Subset Of Set A: " + smallSet.IsSubsetOf(setA));
            }

        static void Exercise5()
            {
            Console.WriteLine("Exercise 5: Print Queue Simulator");

            Queue<string> printQueue = new Queue<string>();
            printQueue.Enqueue("Report.pdf");
            printQueue.Enqueue("Invoice.pdf");
            printQueue.Enqueue("Letter.docx");
            printQueue.Enqueue("Resume.pdf");
            printQueue.Enqueue("Photo.jpg");

            Console.WriteLine("Queue: " + string.Join(", ", printQueue));
            Console.WriteLine("Count: " + printQueue.Count);

            Console.WriteLine("Next Document: " + printQueue.Peek());

            while ( printQueue.Count > 0 )
                {
                string doc = printQueue.Dequeue();
                Console.WriteLine("Printing: " + doc);
                }

            bool success = printQueue.TryDequeue(out string emptyDoc);
            Console.WriteLine("TryDequeue Success: " + success);
            Console.WriteLine("Value: " + ( emptyDoc ?? "null" ));
            }

        static void Exercise6()
            {
            Console.WriteLine("Exercise 6: Browser History");

            Stack<string> history = new Stack<string>();
            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai");

            Console.WriteLine("Current Page: " + history.Peek());

            for ( int i = 0; i < 3; i++ )
                {
                if ( history.Count > 0 )
                    {
                    string leftPage = history.Pop();
                    Console.WriteLine("Leaving Page: " + leftPage);
                    }
                }

            if ( history.Count > 0 )
                Console.WriteLine("Current Page After Back: " + history.Peek());

            history.Clear();
            bool popped = history.TryPop(out string page);
            Console.WriteLine("TryPop Success: " + popped);
            Console.WriteLine("Value: " + ( page ?? "null" ));
            }
        }
    }