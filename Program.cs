using System;
using System.Diagnostics;
using NAudio.Wave;  // Add NAudio namespace for audio playback
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Security;
namespace CybersecurityAwarenessBot
{
    class Program
    {
        // Method to play the voice greeting
        static void PlayVoiceGreeting()
        {
            // Path to the WAV file on your Desktop
            string path = @"C:\Users\RC_Student_lab\source\repos\CybersecurityAwarenessBot\Chatbot_voice_greeting.wav"; // Update with your actual file path

            try
            {
                // Check if the file exists
                if (System.IO.File.Exists(path))
                {
                    // Create an instance of AudioFileReader and WaveOutEvent
                    using (var audioFile = new AudioFileReader(path))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        // Initialize playback with the audio file
                        outputDevice.Init(audioFile);
                        outputDevice.Play();

                        // Wait for playback to finish
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);  // Wait until the sound finishes playing
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Error: The file '{path}' was not found. Please ensure the file path is correct.");
                }
            }
            catch (Exception e)
            {
                // Catch any error that occurs during playback
                Console.WriteLine($"An error occurred while trying to play the audio: {e.Message}");
            }
        }

        // Method to display ASCII Art
        static void DisplayAsciiArt()
        {
            string asciiArt = @"
              ___           ___     
    ___        /\  \         /\  \    
   /\  \      /::\  \       /::\  \   
   \:\  \    /:/\:\  \     /:/\ \  \  
   /::\__\  /:/  \:\  \   _\:\~\ \  \ 
  __/:/\/__/ /:/__/ \:\__\ /\ \:\ \ \__\
 /\/:/  /    \:\  \  \/__/ \:\ \:\ \/__/
 \::/__/      \:\  \        \:\ \:\__\  
  \:\__\       \:\  \        \:\/:/  /  
   \/__/        \:\__\        \::/  /   
                 \/__/         \/__/    
 Internet     Cyber           Security
            ";

            Console.WriteLine(asciiArt); // Output ASCII Art
        }

        // Method to greet the user
        static void GreetUser()
        {
            // Display greeting message with ASCII art
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello! I am the CyberCat, your cybersecurity awareness assistant!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("CyberCat>>> ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("   :What is your name?..........can you please write your name your name below !!!");
           
           
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.Write("User>>> :");
            Console.ForegroundColor = ConsoleColor.White;
            // Get user name and display a greeting message
            string userName = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please provide your name so I can greet you!");
                userName = Console.ReadLine()?.Trim();
                // Default name if nothing is provided
                Console.ForegroundColor = ConsoleColor.White;
                
                
            }




            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"CyberCat>>>");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"   :Nice to meet you, "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine($" ,{userName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            MainMenu(userName); // Proceed to main menu
        }

        // Main menu with options
        static void MainMenu(string userName)
        {
            bool exit = false;
            while (!exit)
            {

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"CyberCat>>>  ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("  :What do you want to do," );
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($",{userName}");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("2. Pet the cat for an advice!");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.ForegroundColor=ConsoleColor.Red;

                Console.WriteLine("3. Exit");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("CyberCat>>>  ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("  :Choose an option so that you can proceed");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.Write($"{userName}>>> :");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string choice = Console.ReadLine()?.Trim(); // User input for menu selection

                Console.WriteLine("");
                switch (choice)
                {
                    case "1":
                        AskQuestion(userName); // Call the question asking method
                        break;
                    case "2":
                        PetTheCat(userName); // Pet the cat method
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("CyberCat>>>  :Goodbye......");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" { userName} ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("!!!, Stay safe online!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("CyberCat>>>  :Invalid input. Please choose 1, 2, or 3.");
                        break;
                }
            }
        }

        // Method to ask questions related to cybersecurity
        static void AskQuestion(string userName)
        {
            var responses = new System.Collections.Generic.Dictionary<string, List<string>>
{
    { "what is a password", new List<string>
        {
            "A strong password includes a mix of letters, numbers, and special characters to secure your accounts.",
            "Passwords should be unique and hard to guess. Avoid using common words or dates.",
            "Think of a password like a toothbrush – don't share it and change it regularly!",
            "Consider using a passphrase that’s easy to remember but hard to crack.",
            "Using two-factor authentication along with a strong password adds extra security."
        }
    },
    { "password", new List<string>
        {
            "A strong password includes a mix of letters, numbers, and special characters to secure your accounts.",
            "Avoid using '123456' or 'password' – these are among the most hacked passwords.",
            "Use at least 12 characters, and avoid predictable patterns like birthdays.",
            "Using a password manager can help you create and store strong passwords safely.",
            "Change your passwords regularly to reduce the risk of unauthorized access."
        }
    },
    { "cybersecurity", new List<string>
        {
            "Cybersecurity is the practice of protecting systems and networks from digital attacks.",
            "It helps keep your data safe from hackers, viruses, and online threats.",
            "Cybersecurity includes firewalls, encryption, and antivirus tools.",
            "Staying informed is key to protecting yourself from cyber threats.",
            "Cybersecurity also involves good habits, like updating your software and not clicking unknown links."
        }
    },
    { "what is cybersecurity", new List<string>
        {
            "Cybersecurity involves defending computers and networks against unauthorized access.",
            "It includes measures to prevent identity theft, data breaches, and other attacks.",
            "Cybersecurity protects information from being stolen or compromised.",
            "The goal is to ensure data confidentiality, integrity, and availability.",
            "It's like digital hygiene – essential to staying safe online."
        }
    },
    { "tell me about cybersecurity", new List<string>
        {
            "Cybersecurity helps protect your personal information from online threats.",
            "It involves tools and practices to prevent and detect cyberattacks.",
            "Hackers target systems to steal data or cause damage, and cybersecurity defends against that.",
            "From antivirus to secure passwords, cybersecurity involves many layers.",
            "Think of it as the digital equivalent of locking your doors."
        }
    },
    { "malware", new List<string>
        {
            "Malware is software designed to harm your device or steal your data.",
            "It can come in forms like viruses, worms, spyware, and ransomware.",
            "Avoid downloading files from unknown sources to prevent malware infection.",
            "Antivirus software can detect and remove malware threats.",
            "Malware often spreads through fake emails or infected websites."
        }
    },
    { "what is a malware", new List<string>
        {
            "Malware stands for 'malicious software' – it's built to cause damage or steal data.",
            "It's one of the biggest online threats and can crash systems or spy on users.",
            "You might encounter malware through email attachments or shady downloads.",
            "Ransomware is a type of malware that locks your files until you pay a ransom.",
            "Good cybersecurity hygiene helps protect you from malware infections."
        }
    },
    { "tell me about malware", new List<string>
        {
            "Malware comes in many types and is designed to damage or disrupt systems.",
            "It can silently collect your data or take control of your system.",
            "Keeping software updated can help prevent malware attacks.",
            "Be cautious when clicking unknown links or popups – they might be malware traps.",
            "Using trusted antivirus programs is one defense against malware."
        }
    },
    { "phishing", new List<string>
        {
            "Phishing is a scam where attackers trick you into revealing personal information.",
            "These scams often appear as emails from trusted sources.",
            "Never click suspicious links or enter personal info on unverified sites.",
            "Phishing is like online bait – don't fall for it!",
            "Multi-factor authentication helps protect you even if you fall for a phishing attempt."
        }
    },
    { "tell me about phishing", new List<string>
        {
            "Phishing tries to trick people into giving away sensitive data like passwords or credit cards.",
            "Scammers might send fake emails or texts pretending to be your bank or a known service.",
            "Always check URLs and email addresses carefully before clicking anything.",
            "Phishing is one of the most common types of cyberattacks.",
            "If it looks suspicious or too good to be true, it probably is – be cautious."
        }
    },
    { "what is phishing", new List<string>
        {
            "Phishing is when attackers pose as trustworthy entities to steal your information.",
            "It usually happens through fake emails or websites.",
            "You might be asked to 'confirm' your password or personal details – that's a red flag!",
            "Learning to recognize phishing attempts can help you avoid falling victim.",
            "Always verify sources before taking action on emails or messages."
        }
    },
    { "virus", new List<string>
        {
            "A virus is a type of malware that spreads and replicates to damage your files.",
            "It can attach itself to programs and spread when you run them.",
            "Viruses can slow down your system, corrupt files, or even wipe data.",
            "Avoid inserting unknown USBs or installing cracked software – they might carry viruses.",
            "Good antivirus software can detect and remove viruses before they cause harm."
        }
    },
    { "tell me about virus", new List<string>
        {
            "A computer virus spreads like a biological one – from system to system.",
            "They often disguise themselves in legitimate-looking files or apps.",
            "Viruses can do anything from annoying popups to full system crashes.",
            "Keeping your operating system updated is one way to defend against viruses.",
            "If your computer is acting strange, a virus could be the cause."
        }
    },
    { "what is a virus", new List<string>
        {
            "A virus is a malicious program that replicates and spreads to other systems.",
            "They can be triggered by running infected files or visiting harmful websites.",
            "Viruses often work silently in the background, causing damage over time.",
            "Some viruses are harmless pranks, but others can destroy valuable data.",
            "Use antivirus software and avoid risky downloads to stay protected."
        }
    }
};
            Random random = new Random();
            int questionCount = 0;
            recall memory = new recall();

            string reminders = memory.pick_random_interest(userName);
            if (reminders != null)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" '{userName}':> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"last you had interest in '{reminders}' , just a reminder, enjoy");
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("CyberCat>>>  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  :Ask me a cybersecurity question, or type 'menu' to return to the main menu.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.Write($"{userName}>>>  :");
            string question = Console.ReadLine()?.ToLower()?.Trim();
            if (question == "menu") { 
                return; // Go back to main menu
            }
           
            memory.check_file();

            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"{userName}>>>  :");
                Console.ForegroundColor = ConsoleColor.White;

                question = Console.ReadLine()?.ToLower()?.Trim();

                if (question == "menu") break;

                if (question.StartsWith("i am interested in ") || question.StartsWith("favourite is "))
                {
                    string topic = question.Replace("i am interested in ", "").Replace("favourite is ", "").Trim();
                    memory.add_interest(userName, topic);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Got it! I've saved your interest in '{topic}'.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (question.Contains("show history"))
                {
                    var history = memory.get_interests(userName);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Your interests:");
                    foreach (var item in history)
                    {
                        Console.WriteLine("- " + item.Split('-')[1].Trim());
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                string sentiment = BasicSentiment(question);
                Boolean found = false;
                // Respond based on sentiment
                if (sentiment == "positive")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("I can see you're excited! Great! Let's keep learning!");
                    found = true;
                }
                else if (sentiment == "negative")
                {
                    found = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("It seems you're feeling a bit down. Don't worry, I'm here to help you!");
                }
                else if (sentiment == "neutral")
                {
                    found = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Your question is neutral. Let's dive into cybersecurity!");
                }

                // Check if the user is worried and provide a warm response
                if (sentiment == "negative" || question.Contains("worried") || question.Contains("anxious"))
                {
                    found = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("I understand that you might be feeling concerned. Take a deep breath. It's okay, we’ll get through this together. Feel free to ask any questions, I'm here to help!");
                }

                
                string matchedKey = responses.Keys.FirstOrDefault(k => question.Contains(k));
                if (matchedKey != null)
                {
                    questionCount++;

                    var answers = responses[matchedKey];
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("ChatBot:> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(answers[random.Next(answers.Count)] + " \nI hope the feedback was helpful");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (questionCount % 5 == 0)
                    {
                        string reminder = memory.pick_random_interest(userName);
                        if (reminder != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"\nJust a reminder — you showed interest in '{reminder}' earlier. Want to ask about it?");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                else
                {
                    if (!found)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, I don't know about that topic.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

            } while (true);

        }

        static string BasicSentiment(string text)
        {
            // Keywords for positive, negative, and worried sentiments
            string[] positiveWords = { "love", "like", "enjoy", "interested", "amazing", "good", "favourite" };
            string[] negativeWords = { "hate", "boring", "bad", "dislike", "terrible", "worst" };
            string[] worriedWords = { "worried", "anxious", "concerned", "scared", "nervous", "fear" };

            int score = 0;

            // Check for positive words
            foreach (var word in positiveWords)
                if (text.ToLower().Contains(word)) score++;

            // Check for negative words
            foreach (var word in negativeWords)
                if (text.ToLower().Contains(word)) score--;

            // Check for worried words
            foreach (var word in worriedWords)
                if (text.ToLower().Contains(word)) score--;

            // Determine sentiment based on score
            if (score > 0) return "positive";
            if (score < 0) return "negative";
            return "neutral";
        }


        // Method for petting the cat
        static void PetTheCat(string userName)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"ChatBot>>>    :Aw, thanks ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{userName}!!  ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("  I'm glad you like me!, dont forget to protect your devices from cyber threats!!!!");
        }

        // Main method where execution starts
        static void Main(string[] args)
        {
            new recall() { };
            new  welcome_massage(){ };
            // Play the voice greeting before starting the program
            
            new logo() { };
            // Greet the user and proceed with the program
            GreetUser();
            
        }
    }
}
