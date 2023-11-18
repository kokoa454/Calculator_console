using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("計算機 ver.2.0");
            Console.WriteLine("終了するにはCtrl+Cを入力");

            while (true) //ver.2.0　3つ目以上の数字を入力できるようにした
            {
                Console.WriteLine();
                List<decimal> numbers = new List<decimal>();
                for (int i = 1; ; i++)
                {
                    Console.Write($"{i}つ目の数字（入力を終了し、計算するにはEnterキーを入力　：　）");
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        break;
                    }
                    
                    if(decimal.TryParse(input, out decimal number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("有効な数字を入力してください");
                        i--;
                    }
                }
                Console.Write("計算の種類(+ - * / %)　：　");
                string caluculateType = Console.ReadLine();

                decimal result = 0; //ここの意味がわからない
                switch (caluculateType)
                {
                    case "+":
                        foreach (decimal number in numbers)
                        {
                            result += number;
                        }
                        break;
                    case "-":
                        /*
                         *　-の場合は0を基点とした、他の計算方法とは違う処理にしないと計算が合わなくなる
                        　　例：「2,2,-」の計算結果が「-4」
                         */
                        result = numbers[0]; 
                        for(int i = 1; i<numbers.Count; i++) 
                         {
                            result -= numbers[i];
                         }
                         break;
                    case "*":
                        result = 1;
                        foreach(decimal number in numbers)
                        {
                            result *= number;
                        }
                        break;
                    case "/":
                        result = 1;
                        foreach(decimal number in numbers)
                        {
                            result /= number;
                        }
                        break;
                    case "%":
                        result = 1;
                        foreach (decimal number in numbers)
                        {
                            result %= number;
                        }
                        break;
                    default:
                        Console.WriteLine("+ - * / %　のいずれかを入力してください");
                        continue;

                }

                Console.WriteLine($"結果　：　{result}");

                /*ver1.1　ifからswitchにして処理速度向上
                Console.WriteLine();

                Console.Write("１つ目の数字　：　");
                string value1 = Console.ReadLine();
                decimal number1 = Convert.ToDecimal(value1);

                Console.Write("２つ目の数字　：　");
                string value2 = Console.ReadLine();
                decimal number2 = Convert.ToDecimal(value2);

                Console.Write("計算の種類（+ - * ? %）　：　");
                string calculateType = Console.ReadLine();

                Console.Write("結果　：　");

               switch (calculateType)
                {
                    case "+":
                        Console.WriteLine(number1 + number2);
                        break;
                    case "-":
                        Console.WriteLine(number1 - number2);
                        break;
                    case "*": 
                        Console.WriteLine(number1 * number2);
                        break;
                    case "/":
                        Console.WriteLine(number1 / number2);
                        break;
                    case "%":
                        Console.WriteLine(number1 % number2);
                        break;
                    default : Console.WriteLine("+ - * / %　のいずれかを入力してください");
                        break;
                
                }
                */
                /* ver.1.0 
                if (calculateType == "+")
                {
                    Console.WriteLine(number1 + number2);
                }
                else if (calculateType == "-") 
                {
                    Console.WriteLine(number1 - number2);
                }
                else if (calculateType == "*")
                {
                    Console.WriteLine(number1 * number2);
                }
                else if (calculateType == "/")
                {
                    Console.WriteLine(number1 / number2);
                }
                else if (calculateType == "%")
                {
                    Console.WriteLine(number1 % number2);
                }
                else
                {
                    Console.WriteLine("+ - * / %　のいずれかを入力してください");
                
                }
                */
            }
        }
    }
}