using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03_The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialNumber = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> pianoPiecesInfo = new Dictionary<string, List<string>>();

            for (int i = 1; i <= initialNumber; i++)
            {
                string[] initialPiecesInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if(!pianoPiecesInfo.ContainsKey(initialPiecesInfo[0]))
                {
                    pianoPiecesInfo.Add(initialPiecesInfo[0], new List<string> { initialPiecesInfo[1], initialPiecesInfo[2] });
                }
            }

            while (true)
            {
                string[] comand = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                string typeComand = comand[0].ToUpper();

                if(typeComand == "STOP")
                {
                    break;
                }

                string piece = comand[1];

                switch (typeComand)
                {
                    case "ADD":
                        string composer = comand[2];
                        string keyPiece = comand[3];
                        if(pianoPiecesInfo.ContainsKey(piece))
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        else
                        {
                            pianoPiecesInfo.Add(piece, new List<string> { composer, keyPiece });
                            Console.WriteLine($"{piece} by {composer} in {keyPiece} added to the collection!");
                        }

                        break;

                    case "REMOVE":
                        if(pianoPiecesInfo.ContainsKey(piece))
                        {
                            pianoPiecesInfo.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }

                        break;

                    case "CHANGEKEY":
                        string newKey = comand[2];
                        if(pianoPiecesInfo.ContainsKey(piece))
                        {
                            pianoPiecesInfo[piece][1] = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }

                        break;
                    
                    default:
                        break;
                }
            }

            foreach (var element in pianoPiecesInfo.OrderBy(x => x.Key).ThenBy(y => y.Value[0]))
            {
                Console.WriteLine($"{element.Key} -> Composer: {element.Value[0]}, Key: {element.Value[1]}");
            }
        }
    }
}
