using System.IO;
using System.Media;
using System;

namespace CybersecurityAwarenessBot
{
    public class welcome_massage
    {
        public welcome_massage()
        {
            //INSIDE CONSTRUCTOR
            //getting the full location for the project
            string full_location = AppDomain.CurrentDomain.BaseDirectory;
            // replace the bin\Debug folder in the full_location
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //try and catch
            try
            {
                string full_path = Path.Combine(new_path, "welcome.wav");
                //creat an instance to play sound
                using (SoundPlayer play = new SoundPlayer(full_path))

                {
                    play.PlaySync();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}