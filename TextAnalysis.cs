using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace TextAnalysis
{
    public class TextAnalysis
    {
        private string text;
        private Dictionary<string, int> wordsDict;

        public TextAnalysis(string text)
        {
            Text = text;
            wordsDict = new Dictionary<string, int>();
        }

        public string Text
        {
            get { return text; }
            set
            {
                if (value.Length == 0) throw new Exception("");
                text = value;
            }
        }


        public TextAnalysis StartAnalysis()
        {
            DelExtraCharacters();  // удаляем из текста все лишние

            string[] arrWords = ToArrayWords();  // получаем массив слов
            ToLowerWords(arrWords);  // все слова преобразуем в нижний регистр
            CountingNumberWords(arrWords);  // создаём dictionary и заполняем (считаем кол-во каждого слова)

            return this;  // для цепочки вызовов методов
        }

        public void SortByValue()
        {
            // получаем список типа KeyValuePair (ключ, значения)
            List<KeyValuePair<string, int>> sortedList = wordsDict.ToList();

            // сортируем список по значению, в параметр передаём лямбда ф-цию
            sortedList.Sort((val1, val2) => val2.Value.CompareTo(val1.Value));

            // заполняем dictionary отсортированными значениями
            wordsDict.Clear();
            foreach (var kvp in sortedList)
                wordsDict.Add(kvp.Key, kvp.Value);
        }

        public void ShowTable(int top)
        {
            int amount;

            if (top > wordsDict.Count) amount = wordsDict.Count;
            else if (top <= 0)
            {
                Console.WriteLine("The table empty...");
                return;
            }
            else amount = top;

            Console.WriteLine("+-----+--------------+-------------------+");
            Console.WriteLine("|  №  |  слово       |  встречается раз  |");
            Console.WriteLine("+-----+--------------+-------------------+");

            int i = 1;
            foreach (var kvp in wordsDict)
            {
                Console.WriteLine("{0,-3}{1,-3}{2,-3}{3,-12}{4,-3}{5,-17}{6}", "|", i, "|", kvp.Key, "|", kvp.Value, "|");

                if (i == amount) break;
                i++;
            }
            Console.WriteLine("+-----+--------------+-------------------+");
        }


        private void DelExtraCharacters()
        {
            // удаляем лишние символы, и короткие слова до 2 символов
            text = Regex.Replace(text, @"[\s,.!?;)(:«»—-]", match => " ");
            text = Regex.Replace(text, @"\b\w{1,3}\b", match => "");
            text = Regex.Replace(text, "( ){2,}", match => " ");
        }

        private string[] ToArrayWords()
        {
            // возвращаем массив слов из текста
            return text.Split(' ');
        }

        private void ToLowerWords(string[] arrWords)
        {
            for (int i = 0; i < arrWords.Length; i++)
                arrWords[i] = arrWords[i].ToLower();
        }

        private void CountingNumberWords(string[] arrWords)
        {
            // подсчёт кол-ва слов, ключ - слово, значение - количество
            foreach (var w in arrWords)
            {
                // если ключ уже есть, то добавляем к значение 1
                if (wordsDict.ContainsKey(w))
                {
                    wordsDict[w]++;
                }

                else // создаём новый ключ
                {
                    wordsDict.Add(w, 1);
                }
            }
        }
    }
}
