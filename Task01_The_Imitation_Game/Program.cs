using System;
using System.Text;
using System.Linq;

namespace Task01_The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            while (true)
            {
                string[] comand = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string typeComand = comand[0].ToUpper();

                if(typeComand == "DECODE")
                {
                    break;
                }

                switch (typeComand)
                {
                    case "MOVE":
                        int numbersOfLetters = int.Parse(comand[1]);
                        if(numbersOfLetters > 0)
                        {
                            string toMove = encryptedMessage.Substring(0, numbersOfLetters);
                            encryptedMessage = encryptedMessage.Remove(0, numbersOfLetters);
                            encryptedMessage = encryptedMessage + toMove;
                        }

                        break;

                    case "INSERT":
                        int indexToInsert = int.Parse(comand[1]);
                        string toInsert = comand[2];
                        encryptedMessage = encryptedMessage.Insert(indexToInsert, toInsert);

                        break;

                    case "CHANGEALL":
                        string toRemove = comand[1];
                        string toReplace = comand[2];
                        encryptedMessage = encryptedMessage.Replace(toRemove, toReplace);

                        break;
                    
                    default:
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
