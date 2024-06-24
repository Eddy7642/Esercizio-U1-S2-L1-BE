using System;
using System.Collections.Generic;

namespace WebApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            while (true)
            {
                menu.DisplayMenu();
                Console.Write("Seleziona un'opzione: ");
                string? input = Console.ReadLine();  // Permetti a input di essere nullabile
                if (input == null)
                {
                    Console.WriteLine("Input non valido. Per favore, inserisci un numero.\n");
                    continue;
                }

                if (int.TryParse(input, out int choice))
                {
                    menu.SelectItem(choice);
                }
                else
                {
                    Console.WriteLine("Per favore, inserisci un numero valido.\n");
                }
            }
        }
    }

    class Menu
    {
        private readonly Dictionary<int, (string, double)> items = new Dictionary<int, (string, double)>
        {
            { 1, ("Coca Cola 150 ml", 2.50) },
            { 2, ("Insalata di pollo", 5.20) },
            { 3, ("Pizza Margherita", 10.00) },
            { 4, ("Pizza 4 Formaggi", 12.50) },
            { 5, ("Patatine fritte", 3.50) },
            { 6, ("Insalata di riso", 8.00) },
            { 7, ("Frutta di stagione", 5.00) },
            { 8, ("Pizza fritta", 5.00) },
            { 9, ("Piadina vegetariana", 6.00) },
            { 10, ("Panino Hamburger", 7.90) }
        };

        private readonly List<(string, double)> selectedItems = new List<(string, double)>();

        public void DisplayMenu()
        {
            Console.WriteLine("\n==============MENU==============");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}:  {item.Value.Item1} (€ {item.Value.Item2:F2})");
            }
            Console.WriteLine("11: Stampa conto finale e conferma");
            Console.WriteLine("==============MENU==============\n");
        }

        public void SelectItem(int choice)
        {
            if (items.ContainsKey(choice))
            {
                selectedItems.Add(items[choice]);
                Console.WriteLine($"Hai aggiunto: {items[choice].Item1} (€ {items[choice].Item2:F2})\n");
            }
            else if (choice == 11)
            {
                PrintReceipt();
            }
            else
            {
                Console.WriteLine("Scelta non valida, riprova.\n");
            }
        }

        private void PrintReceipt()
        {
            Console.WriteLine("\n==============CONTO==============");
            double total = 0;
            foreach (var item in selectedItems)
            {
                Console.WriteLine($"{item.Item1} (€ {item.Item2:F2})");
                total += item.Item2;
            }
            double serviceCharge = 3.00;
            total += serviceCharge;
            Console.WriteLine($"Servizio al tavolo (€ {serviceCharge:F2})");
            Console.WriteLine($"Totale da pagare: € {total:F2}");
            Console.WriteLine("=================================\n");
            selectedItems.Clear();
        }
    }
}
