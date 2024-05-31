using System;
using System.IO;
using System.Linq;

namespace Galg
{
    internal class Program
    {
        static string[] words;
        static char[] splitCharacters;
        static bool[] guessedCharacters;
        static int[] playerLives;
        static int currentPlayer = 0;
        static int totalPlayers;

        static void Main(string[] args)
        {
            LoadWordsFromFile("D:\\Repositories\\c--GalgGaem\\Galg\\words.txt");
            Start();
            Init();
            GameLoop();
            Console.ReadLine();
        }

        public static void LoadWordsFromFile(string filePath)
        {
            words = File.ReadAllLines(filePath);
        }

        public static void Start()
        {
            Console.WriteLine("Hangman");
            Console.WriteLine("Player amount");
            totalPlayers = int.Parse(Console.ReadLine());
            playerLives = new int[totalPlayers];

            for (int i = 0; i < totalPlayers; i++)
            {
                playerLives[i] = 6;
            }
        }

        public static void Init()
        {
            Random rand = new Random();
            string word = words[rand.Next(words.Length)];

            splitCharacters = new char[word.Length];
            guessedCharacters = new bool[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                splitCharacters[i] = word[i];
            }

            Console.WriteLine($"Your word has {word.Length} letters.");
        }

        public static void GameLoop()
        {
            while (true)
            {
                if (playerLives[currentPlayer] <= 0)
                {
                    Console.WriteLine($"Player {currentPlayer + 1} is out of lives.");
                    currentPlayer = (currentPlayer + 1) % totalPlayers;
                    continue;
                }

                PrintWordState();

                Console.WriteLine($"Player {currentPlayer + 1} turn Lives left: {playerLives[currentPlayer]}");
                Console.Write("Guess a letter: ");
                char userinput = Console.ReadLine().ToLower()[0];

                bool correctGuess = false;
                for (int i = 0; i < splitCharacters.Length; i++)
                {
                    if (splitCharacters[i] == userinput)
                    {
                        guessedCharacters[i] = true;
                        correctGuess = true;
                    }
                }

                if (!correctGuess)
                {
                    playerLives[currentPlayer]--;
                }

                if (IsWordGuessed())
                {
                    PrintWordState();
                    Console.WriteLine($"Player {currentPlayer + 1} has guessed the word!!!");
                    return;
                }

                bool allPlayersOut = true;
                for (int i = 0; i < totalPlayers; i++)
                {
                    if (playerLives[i] > 0)
                    {
                        allPlayersOut = false;
                        break;
                    }
                }

                if (allPlayersOut)
                {
                    Console.WriteLine("All players are out of lives, The word was: " + new string(splitCharacters));
                    return;
                }

                currentPlayer = (currentPlayer + 1) % totalPlayers;
            }
        }

        public static void PrintWordState()
        {
            for (int i = 0; i < splitCharacters.Length; i++)
            {
                if (guessedCharacters[i])
                {
                    Console.Write(splitCharacters[i] + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        public static bool IsWordGuessed()
        {
            foreach (bool guessed in guessedCharacters)
            {
                if (!guessed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
