using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Application
{
    class Program
    {
        static string[] WORDS = { "привет, как дела у тебят?",
                                  "ара едет по шоссе.",
                                  "У меня есть кактуск! Что такое, как так, почемуп ахаха",
                                  "укщ0п. ушкпту укщшптщу, укщпт!"
                                };
        static void Main(string[] args)
        {
            Execute();
        }

        static void Execute()
        {
            int[][] jagArray = new int[0][];
            bool IsEnd = false;
            do
            {
                int action = 0;
                Console.WriteLine("1. Задача 1 \n2. Задача 2\n3. Выход");
                try
                {
                    action = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Format, try again");
                }
                switch (action)
                {
                    case 1:
                        {
                            FirstTask(ref jagArray);
                            break;
                        }
                    case 2:
                        {
                            SecondTask();
                            break;
                        }
                    case 3:
                        {
                            IsEnd = true;
                            break;
                        }
                }
            } while (!IsEnd);
        }

        static void FirstTask(ref int[][] jagArray)
        {
            Console.WriteLine("Работа с рванным массивом");
            bool IsEnd = false;
            do
            {
                int action = 0;
                Console.WriteLine("1. Создать массив \n2. Вывести массив \n3. Удалить все строки, в которых есть не менее двух нулей\n4. Назад");
                try
                {
                    action = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Format, try again");
                }
                switch (action)
                {
                    case 1:
                        {
                            MakeJagArray(ref jagArray);
                            break;
                        }
                    case 2:
                        {
                            PrintJagArray(in jagArray);
                            break;
                        }
                    case 3:
                        {
                            DeleteRows(ref jagArray);
                            break;
                        }
                    case 4:
                        {
                            IsEnd = true;
                            break;
                        }
                }
            } while (!IsEnd);
        }

        static void MakeJagArray(ref int[][] jagArray)
        {
            bool IsEnd = false;
            Console.WriteLine("Создание раваного массива");
            do
            {

                Console.WriteLine("1. Создать вручную\n2. Создать с помощью ДСЧ\n3. Назад");
                int action = 0;
                try
                {
                    action = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Format, try again");
                }
                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("Формирование рваного массива");
                            int rows;
                            do
                            {
                                Console.WriteLine("Введите количество строк");
                            } while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0);
                            jagArray = new int[rows][];
                            for (int i = 0; i < rows; i++)
                            {
                                int columns;
                                do
                                {
                                    Console.WriteLine("Введите количество элементов");
                                } while (!int.TryParse(Console.ReadLine(), out columns) || columns <= 0);
                                jagArray[i] = new int[columns];
                                for (int j = 0; j < columns; j++)
                                {
                                    int temp;
                                    do
                                    {
                                        Console.Write($"Введите {j + 1} элемент: ");
                                    } while (!int.TryParse(Console.ReadLine(), out temp));
                                    jagArray[i][j] = temp;
                                }
                            }
                            Console.WriteLine("Массив создан");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Формирование рваного массива");
                            int rows;
                            do
                            {
                                Console.WriteLine("Введите количество строк");
                            } while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0);
                            jagArray = new int[rows][];
                            Random rnd = new Random();
                            for (int i = 0; i < rows; i++)
                            {
                                int columns;
                                do
                                {
                                    Console.WriteLine($"Введите количество элементов для {i + 1} строки");
                                } while (!int.TryParse(Console.ReadLine(), out columns) || columns <= 0);
                                jagArray[i] = new int[columns];
                                for (int j = 0; j < columns; j++)
                                {
                                    jagArray[i][j] = rnd.Next(0, 4);
                                }
                            }
                            Console.WriteLine("Массив создан");
                            break;
                        }
                    case 3:
                        {
                            IsEnd = true;
                            break;
                        }
                }
            } while (!IsEnd);
        }

        static void PrintJagArray(in int[][] jagArray)
        {
            if (jagArray.Length != 0)
            {
                for (int i = 0; i < jagArray.Length; i++)
                {
                    Console.Write("{");
                    for (int j = 0; j < jagArray[i].Length; j++)
                    {
                        if (j != jagArray[i].Length - 1)
                        {
                            Console.Write(jagArray[i][j] + ", ");
                        }
                        else
                        {
                            Console.Write(jagArray[i][j]);
                        }
                    }
                    Console.Write("}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Массив пустой");
            }
        }

        static void DeleteRows(ref int[][] jagArray)
        {
            if (jagArray.Length != 0)
            {
                int deletedCount = 0;
                int[][] newArray = new int[0][];
                for (int i = 0; i < jagArray.Length; i++)
                {
                    int zeroCount = 0;
                    for (int j = 0; j < jagArray[i].Length; j++)
                    {
                        if (jagArray[i][j] == 0)
                        {
                            zeroCount++;
                        }
                    }
                    if (zeroCount < 2)
                    {
                        Adding(in i, ref newArray, in jagArray);
                    }
                    else
                    {
                        deletedCount++;
                    }
                }
                jagArray = newArray;
                Console.WriteLine($"Удалено строк: {deletedCount}");
            }
            else
            {
                Console.WriteLine("Массив пустой");
            }
        }

        static void Adding(in int index, ref int[][] newArray, in int[][] jagArray)
        {
            int[][] tempArray = new int[newArray.Length + 1][];

            for (int i = 0; i < tempArray.Length - 1; i++)
            {
                tempArray[i] = new int[newArray[i].Length];
                Array.Copy(newArray[i], tempArray[i], newArray[i].Length);
            }
            tempArray[tempArray.Length - 1] = new int[jagArray[index].Length];
            Array.Copy(jagArray[index], 0, tempArray[tempArray.Length - 1], 0, jagArray[index].Length);
            newArray = tempArray;
        }

        static void SecondTask()
        {
            Console.WriteLine("Работа со строками");
            Console.WriteLine("Удаление слов, которые начинаются и заканчиваются на один и тот же символ");
            bool IsEnd = false;
            do
            {
                int deletedWords = 0;
                int action = 0;
                Console.WriteLine("1. Ручной ввод\n2. Создание из массива строк\n3. Назад");
                try
                {
                    action = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Format, try again");
                }
                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите строку");
                            string str = new string(Console.ReadLine());

                            string[] words = FindWords(in str, ref deletedWords);

                            //words = DeleteWords(ref words, ref deletedWords, in str);
                            PrintWords(in words, in deletedWords);
                            break;
                        }
                    case 2:
                        {
                            string str = GetString();
                            string[] words = FindWords(in str, ref deletedWords);

                            //words = DeleteWords(ref words, ref deletedWords, in str);

                            PrintWords(in words, in deletedWords);
                            break;
                        }
                    case 3:
                        {
                            IsEnd = true;
                            break;
                        }
                }
            } while (!IsEnd);
        }

        static string GetString()
        {
            Random rnd = new Random();
            string str = WORDS[rnd.Next(WORDS.Length)];
            
            return str;
        }

        static string[] FindWords(in string str, ref int deletedWords)
        {
            char[] punct = { ',', '!', '?', '.', ';', ':' };
            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 0)
            {
                Console.WriteLine($"Исходная строка: {str}");
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < punct.Length; j++)
                    {
                        try
                        {
                            if (words[i][words[i].Length - 1] == punct[j] && words[i][0] == words[i][words[i].Length - 2])
                            {
                                words[i] = punct[j].ToString();
                                deletedWords++;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Некорректный ввод строки");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод строки(строка пустая");
            }
            return words;

        }

        //static string[] DeleteWords(ref string[] words, ref int deletedWords, in string str)
        //{
        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        if (words[i] != null && words[i][0] == words[i][words[i].Length - 1])
        //        {
        //            deletedWords++;
        //            words[i] = "";
        //        }
        //        if (words[i] != null && words[i].Length == 1)
        //        {
        //            words[i] = "";
        //            deletedWords++;
        //        }
        //    }

        //    return words;
        //}

        static void PrintWords(in string[] words, in int deletedWords)
        {
            if (words.Length != 0)
            {
                Console.Write("Конечная строка: ");
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] != "")
                    {
                        Console.Write($"{words[i]} ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"Удалено слов: {deletedWords}");
            }
        }
    }
}
