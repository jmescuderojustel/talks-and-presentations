using System;
using System.Collections.Generic;
using System.IO;

namespace Before
{
    public static class Executor
    {
        internal static void Run()
        {
            int count = 0;

            int yahooUsers = 0;         // Number of users that have a Yahoo email
            int gmailUsers = 0;         // Number of users that have a Gmail email
            int otherUser = 0;          // Number of users that have other unlisted email

            Dictionary<string, int> emailTimes = new Dictionary<string, int>();

            // File downloaded from https://www.briandunning.com/sample-data/
            FileStream file = new FileStream("uk-500.csv", FileMode.Open);
            using (StreamReader reader = new StreamReader(file))
            {
                Console.Write("\nSTARTED\n");

                while (!reader.EndOfStream)
                {
                    count++;
                    string content = reader.ReadLine();     // Read just one line

                    if (count == 1)
                    {
                        continue;
                    }

                    string[] items = content.Split(new string[] { "\",\"" }, StringSplitOptions.None);

                    if (items[9].Contains("@yahoo.com"))    // The 9th item is the email
                    {
                        yahooUsers++;
                    }
                    else if (items[9].Contains("@gmail.com"))
                    {
                        gmailUsers++;
                    }
                    else
                    {
                        // Get the server from the email
                        // string server = items[8].Substring(items[8].IndexOf("@"), items[8].Length - items[8].IndexOf("@"));
                        string server = items[9].Substring(items[9].IndexOf("@"), items[9].Length - items[9].IndexOf("@"));

                        if (emailTimes.ContainsKey(server))
                        {
                            emailTimes[server] += 1;
                        }
                        else
                        {
                            emailTimes.Add(server, 1);
                        }
                        otherUser++;
                    }

                    Console.Write($"{ count - 1 }, ");
                }

                Console.Write("\nFINISHED\n");
            }

            string mostUsed = GetMostUsed(emailTimes);

            Console.WriteLine();

            Console.WriteLine($"Yahoo: { yahooUsers }");
            Console.WriteLine($"Gmail: { gmailUsers }");
            Console.WriteLine($"Most used not tracked email: { mostUsed }");
        }

        private static string GetMostUsed(Dictionary<string, int> emailTimes)
        {
            int max = 0;
            string mostUsed = string.Empty;

            foreach (var email in emailTimes)
            {
                if (email.Value > max)
                {
                    max = email.Value;
                    mostUsed = email.Key;
                }
            }

            return mostUsed;
        }
    }
}