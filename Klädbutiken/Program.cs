using System;
using System.Collections.Generic;

namespace Klädbutiken
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cloth> store = new List<Cloth>();
            List<Cloth> cart = new List<Cloth>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välj ett alternativ mellan 1-4!");
                Console.WriteLine("_____MENU____");
                Console.WriteLine("1.___ADMIN___");
                Console.WriteLine("2.___STORE___");
                Console.WriteLine("3.___CART!___");
                Console.WriteLine("4.___QUIT!___");

                var input = Console.ReadKey(true);
                switch (input.KeyChar)
                {
                    case '1':
                        Admin(store);
                        break;
                    case '2':
                        Store(store, cart);
                        break;
                    case '3':
                        Cart(cart);
                        break;
                    case '4':
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        public static void Admin(List<Cloth> store)
        {
            bool runAdmin = true;

            while (runAdmin)
            {
                Console.Clear();
                Console.WriteLine("1.___ADD_ITEM___");
                Console.WriteLine("2._____MENU_____");
                var input = Console.ReadKey(true);

                switch (input.KeyChar)
                {
                    case '1':
                        Cloth cloth = new Cloth();
                        Console.Write("Klädestyp: ");
                        int c1 = 1;
                        foreach (string w in Enum.GetNames(typeof(Type)))
                        {
                            Console.Write($"{c1}-{w}, ");
                            c1++;
                        }

                        int typeIndex = int.Parse(Console.ReadLine());
                        cloth.Type = typeIndex;

                        Console.Write("Storlek: ");
                        int c2 = 1;
                        foreach (string w in Enum.GetNames(typeof(Size)))
                        {
                            Console.Write($"{c2}-{w}, ");
                            c2++;
                        }

                        int sizeIndex = int.Parse(Console.ReadLine());
                        cloth.Size = sizeIndex;

                        Console.Write("Färg: ");
                        int c3 = 1;
                        foreach (string w in Enum.GetNames(typeof(Color)))
                        {
                            Console.Write($"{c3}-{w}, ");
                            c3++;
                        }

                        int colorIndex = int.Parse(Console.ReadLine());
                        cloth.Color = colorIndex;

                        Console.Write("Skriv in varans pris: ");
                        cloth.Price = int.Parse(Console.ReadLine());

                        store.Add(cloth);

                        Console.WriteLine("");

                        foreach (Cloth c in store)
                        {
                            Console.WriteLine(Enum.GetName(typeof(Type), c.Type));
                            Console.WriteLine(Enum.GetName(typeof(Size), c.Size));
                            Console.WriteLine(Enum.GetName(typeof(Color), c.Color));
                            Console.WriteLine(c.Price);
                            Console.WriteLine("");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        runAdmin = false;
                        break;
                    default:
                        break;
                }
            }
            
        }
        public static void Store(List<Cloth> store, List<Cloth> cart)
        {
            Console.Clear();
            bool runStore = true;
            int buyItem = 0;

            while (runStore)
            {
                Console.Clear();
                Console.WriteLine("Bläddra bland varorna med [A] och [Z]. Välj vara med [ENTER], gå tillbaka till menyn med [Q]");
                int pCount = 1;
                foreach (var p in store)
                {
                    Console.WriteLine($"{pCount}: {Enum.GetName(typeof(Type), p.Type)}, {Enum.GetName(typeof(Size), p.Size)}, {Enum.GetName(typeof(Color), p.Color)}, {p.Price}:-");
                    pCount++;
                }
                Console.WriteLine(buyItem + 1);

                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.A:
                        if (buyItem > 0)
                        {
                            buyItem--;
                        }
                        
                        break;
                    case ConsoleKey.Z:
                        if (buyItem < (store.Count -1))
                        {
                            buyItem++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        cart.Add(store[buyItem]);
                        break;
                    case ConsoleKey.Q:
                        runStore = false;
                        break;
                }
            }
        }
        public static void Cart(List<Cloth> cart)
        {
            Console.Clear();
            int pCount = 1;
            int sum = 0;

            foreach (var p in cart)
            {
                Console.WriteLine($"{pCount}: {Enum.GetName(typeof(Type), p.Type)}, {Enum.GetName(typeof(Size), p.Size)}, {Enum.GetName(typeof(Color), p.Color)}, {p.Price}:-");
                pCount++;
                sum += p.Price;
            }
            Console.WriteLine("");
            Console.WriteLine($"Price:{sum}:-");
            Console.ReadKey();
        }
        enum Type
        {
            Sweater = 1,
            Trousers,
            Shoes
        }
        enum Size
        {
            SX = 1,
            S,
            M,
            L,
            XL
        }
        enum Color
        {
            Red = 1,
            Blue,
            Green,
            Pink
        }
    }
    struct Cloth
    {
        public int Type;
        public int Size;
        public int Color;
        public int Price;
    }
}
