using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextAnalysis
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TextAnalysis";

            // считывем текст из файла
            string text = MyFile.ReadFile(@"E:\!!!Даня - папка\Кобзарь.txt");

            // анализируем текст
            TextAnalysis textAnalysis = new TextAnalysis(text);
            textAnalysis.StartAnalysis().SortByValue();

            // выводим таблицу, топ 30 часто встречающих слов
            textAnalysis.ShowTable(30);

            Console.ReadKey();
        }
    }
}
