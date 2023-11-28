using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFIntroduktion.BIZ
{

    public class ClassBIZ
    {
        private static readonly Random random = new Random();

        public ClassBIZ()
        {
            // Constructor
        }

        /// <summary>
        /// Genererer en liste af tilfældige tal som strenge inden for intervallet 100.000 til 1.000.000.
        /// </summary>
        /// <param name="numsToGenerate">Antallet af tilfældige strenge, der skal genereres.</param>
        /// <returns>En liste af tilfældigt genererede strenge med tal.</returns>
        public static List<string> GenerateRandomNums(int numsToGenerate)
        {
            List<string> randomNumbers = new List<string>();
            Random random = new Random();

            for (int i = 0; i < numsToGenerate; i++)
            {
                randomNumbers.Add(random.Next(100000, 1000001).ToString());
            }

            return randomNumbers;
        }

        /// <summary>
        /// Genererer en liste af tilfældige heltal inden for intervallet 100.000 til 1.000.000.
        /// </summary>
        /// <param name="numsToGenerate">Antallet af tilfældige tal, der skal genereres.</param>
        /// <returns>En liste af tilfældigt genererede heltal.</returns>
        public static List<int> GenerateRandomNumbers(int numsToGenerate)
        {
            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < numsToGenerate; i++)
            {
                randomNumbers.Add(random.Next(100000, 1000001));
            }

            return randomNumbers;
        }


        /// <summary>
        /// Tilføjer tal fra 4711 til 4736 i en ListBox. Dette udføres gennem et for-loop.
        /// </summary>
        /// <param name="listbox">ListBoxen, der skal opdateres med tal.</param>
        public static void Opgave2(ListBox listbox)
        {
            listbox.Items.Clear();

            for (int i = 4711; i <= 4736; i++)
            {
                listbox.Items.Add(i);
            }
        }

        /// <summary>
        /// Tilføjer 25 tilfældige tal mellem 100.000 og 1.000.000 til en ListBox.
        /// De tilfældige tal genereres ved hjælp af metoden "GenerateRandomNumbers".
        /// </summary>
        /// <param name="listbox">ListBoxen, der skal opdateres med tilfældige tal.</param>
        public static void Opgave3(ListBox listbox)
        {
            listbox.Items.Clear();

            List<int> randomNumbers = GenerateRandomNumbers(25);

            foreach (int number in randomNumbers)
            {
                listbox.Items.Add(number);
            }
        }

        /// <summary>
        /// Funktioner som Opgave3, men tilføjer de tilfældige tal i sorteret rækkefølge.
        /// </summary>
        /// <param name="listbox">ListBoxen, der skal opdateres med sorteret tilfældige tal.</param>
        public static void Opgave4(ListBox listbox)
        {
            listbox.Items.Clear();

            List<int> randomNumbers = GenerateRandomNumbers(25);
            randomNumbers.Sort();

            foreach (int number in randomNumbers)
            {
                listbox.Items.Add(number);
            }
        }

        /// <summary>
        /// Genererer og sorterer en liste af tilfældige tal, og tilføjer hvert tal sammen med dets oprindelige position i den usorterede liste til en ListBox.
        /// </summary>
        /// <param name="listbox">ListBoxen, der skal opdateres med tal og deres oprindelige positioner.</param>
        public static void Opgave5(ListBox listbox)
        {
            listbox.Items.Clear();

            // Generer en liste af tilfældige tal
            List<int> randomNumbers = GenerateRandomNumbers(25);

            // Kopier og sorter listen
            List<int> sortedNumbers = new List<int>(randomNumbers);

            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                // Find det mindste tal i listen
                int min = sortedNumbers[i];
                int minIndex = i;

                for (int j = i + 1; j < sortedNumbers.Count; j++)
                {
                    if (sortedNumbers[j] < min)
                    {
                        min = sortedNumbers[j];
                        minIndex = j;
                    }
                }

                // Byt rundt på det mindste tal og det tal vi er nået til
                sortedNumbers[minIndex] = sortedNumbers[i];
                sortedNumbers[i] = min;

                // Tilføj det mindste tal til listboxen
                listbox.Items.Add($"{min} - position før: {randomNumbers.IndexOf(min)}");
            }
        }

        /// <summary>
        /// Tilføjer 25 tilfældige tal til en ListBox og beregner og viser også deres gennemsnit.
        /// </summary>
        /// <param name="listbox">ListBoxen, hvor tal og gennemsnittet vises.</param>
        public static void Opgave6(ListBox listbox)
        {
            listbox.Items.Clear();

            List<int> randomNumbers = GenerateRandomNumbers(25);

            int sum = 0;

            foreach (int number in randomNumbers)
            {
                listbox.Items.Add(number);
                sum += number;
            }

            listbox.Items.Add($"");
            listbox.Items.Add($"Gennemsnitsværdi: {sum / randomNumbers.Count}");
        }

        /// <summary>
        /// Tilføjer 25 tilfældige tal til en ListBox og viser forskellen mellem hvert tal og gennemsnittet af alle tal.
        /// </summary>
        /// <param name="listbox">ListBoxen, hvor tal og deres afvigelser fra gennemsnittet vises.</param>
        public static void Opgave7(ListBox listbox)
        {
            listbox.Items.Clear();

            List<int> randomNumbers = GenerateRandomNumbers(25);

            int sum = 0;

            foreach (int number in randomNumbers)
            {
                sum += number;
            }

            sum /= randomNumbers.Count;

            foreach (int number in randomNumbers)
            {
                listbox.Items.Add($"{number} - {sum} = {number - sum}");
            }
        }

        /// <summary>
        /// Tilføjer 25 sorteret tilfældige tal til en ListBox, hver med en baggrundsfarve afhængig af om tallet er lige eller ulige. Viser også forskellen mellem hvert tal og gennemsnittet af alle tal.
        /// </summary>
        /// <param name="listBox">ListBoxen, hvor tal, deres baggrundsfarve og afvigelser fra gennemsnittet vises.</param>
        public static void Opgave9(ListBox listBox)
        {
            // Generer en liste af tilfældige tal
            var randomNumbers = GenerateRandomNumbers(25);

            // Sorter listen
            randomNumbers.Sort();

            // Find gennemsnittet af listen
            double average = randomNumbers.Average();

            // Clear listbox
            listBox.Items.Clear();

            // For hvert tal i listen af tilfældige tal
            foreach (var number in randomNumbers)
            {
                ListBoxItem listBoxItem = new ListBoxItem
                {
                    // Hvis tallet er lige, så er baggrunden pink, ellers er den blå - super effektiv måde at skrive bool handling på.
                    Background = number % 2 == 0 ? Brushes.HotPink : Brushes.AliceBlue,
                    // Average må maks være 2 decimaler langt
                    Content = $"{number} - {average:F2} = {number - average:F2}"
                };

                // Tilføj item til listbox
                listBox.Items.Add(listBoxItem);
            }
        }

        /// <summary>
        /// Genererer en liste af ListBoxItem objekter baseret på 25 sorteret tilfældige tal. Hvert ListBoxItem's baggrundsfarve bestemmes af om tallet er lige eller ulige, og indholdet viser tallets afvigelse fra gennemsnittet.
        /// </summary>
        /// <returns>En liste af ListBoxItem objekter.</returns>
        public static List<ListBoxItem> Opgave10()
        {
            Random random = new Random();
            List<int> randomNumbers = new List<int>();

            // Generer 25 tilfældige tal
            for (int i = 0; i < 25; i++)
            {
                randomNumbers.Add(random.Next(100000, 1000001));
            }

            // Sortér listen
            randomNumbers.Sort();

            // Beregn gennemsnittet
            double average = randomNumbers.Average();

            List<ListBoxItem> listBoxItems = new List<ListBoxItem>();

            // Opret ListBoxItem for hvert tal med passende baggrund og tekst
            foreach (var number in randomNumbers)
            {
                ListBoxItem listBoxItem = new ListBoxItem();

                // Bestem baggrundsfarven baseret på om tallet er lige eller ulige
                listBoxItem.Background = number % 2 == 0 ? Brushes.HotPink : Brushes.AliceBlue;

                // Sæt teksten for ListBoxItem
                listBoxItem.Content = $"{number} - {average:F2} = {number - average:F2}";

                // Tilføj ListBoxItem til listen
                listBoxItems.Add(listBoxItem);
            }

            return listBoxItems;
        }
    }
}