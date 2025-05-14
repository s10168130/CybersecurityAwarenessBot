using System.Collections.Generic;
using System.IO;
using System;

namespace CybersecurityAwarenessBot
{
    public class recall
    {

        //Since AppDomain as global gives an error of static
        //Lets do a return method for it to return the path
        private string path_return()
        {
            //App Domain get full path
            string fullpath = AppDomain.CurrentDomain.BaseDirectory;
            //then replace the bin/Debug/
            //so its bin\\Debug\\ inside the "" no space
            string new_path = fullpath.Replace("bin\\Debug\\", "");
            //now combine the path of new_path and the txt file
            string path = Path.Combine(new_path, "memory.txt");

            return path;
        }//end of return path method

        //Now lets do the three methods

        //Method to check the txt file and create if not found
        public void check_file()
        {
            //get the path
            string path = path_return();
            //Now check if the path exists or not
            //then if not found then create the txt file
            if (!File.Exists(path))
            {
                //it means if not, the path of the file is
                //not found the create or do something
                File.CreateText(path);
            }
            else
            {
                //then if the file is found 
                Console.WriteLine("checking memory, please ask again");
            }

        }//end of method check_file

        public void add_interest(string username, string topic)
        {
            string path = path_return();
            string entry = $"{username} - {topic}";

            var lines = new List<string>(File.ReadAllLines(path));

            if (!lines.Contains(entry))
            {
                lines.Add(entry);
                File.WriteAllLines(path, lines);
            }
        }

        public List<string> get_interests(string username)
        {
            string path = path_return();
            var lines = new List<string>(File.ReadAllLines(path));
            return lines.FindAll(line => line.StartsWith(username + " - "));
        }

        public string pick_random_interest(string username)
        {
            var interests = get_interests(username);
            if (interests.Count > 0)
            {
                Random rnd = new Random();
                string interestLine = interests[rnd.Next(interests.Count)];
                return interestLine.Split('-')[1].Trim();
            }
            return null;
        }


    }//end of class
}//end of namespace