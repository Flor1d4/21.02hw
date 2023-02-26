using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._02
{
    class Backpack
    {
        private string color;
        private string manufacturer;
        private string material;
        private int weight;
        private int volume;
        private List<Item> items = new List<Item>();

        public event EventHandler<ItemEventArgs> ItemAdded;

        public Backpack(string color, string manufacturer, string material, int weight, int volume)
        {
            this.color = color;
            this.manufacturer = manufacturer;
            this.material = material;
            this.weight = weight;
            this.volume = volume;
        }

        public void AddItem(Item item)
        {
            if (item.Volume > volume)
            {
                throw new Exception("The backpack volume is too small to add this item.");
            }

            items.Add(item);
            ItemAdded?.Invoke(this, new ItemEventArgs(item));
        }

        public string Color 
        { get 
            {
                return color;
            }
        }
        public string Manufacturer
        { 
            get
            { 
                return manufacturer;
            }
        }
        public string Material 
        { 
            get 
            {
                return material;
            }
        }
        public int Weight
        { 
            get 
            {
                return weight;
            }
        }
        public int Volume 
        { 
            get
            { 
                return volume;
            }
        }
        public List<Item> Items 
        {
            get 
            { 
                return items;
            } 
        }
    }

    class Item
    {
        private string name;
        private int volume;

        public Item(string name, int volume)
        {
            this.name = name;
            this.volume = volume;
        }

        public string Name { get { return name; } }
        public int Volume { get { return volume; } }
    }

    class ItemEventArgs : EventArgs
    {
        private Item item;

        public ItemEventArgs(Item item)
        {
            this.item = item;
        }

        public Item Item { get { return item; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TAsk 1\n");
            Func<string, int[]> getRGB = color =>
            {
                switch (color.ToLower())
                {
                    case "red":return new int[] { 255, 0, 0 };
                    case "orange": return new int[] { 255, 165, 0 };
                    case "yellow": return new int[] { 255, 255, 0 };
                    case "green": return new int[] { 0, 255, 0 };
                    case "blue": return new int[] { 0, 0, 255 };
                    case "indigo": return new int[] { 75, 0, 130 };
                    case "violet": return new int[] { 238, 130, 238 };
                    default: return new int[] { 0, 0, 0 };
                }
            }; 

            int[] rgb = getRGB("red");
            Console.WriteLine("Red: R={0}, G={1}, B={2}", rgb[0], rgb[1], rgb[2]);

            rgb = getRGB("blue");
            Console.WriteLine("Blue: R={0}, G={1}, B={2}", rgb[0], rgb[1], rgb[2]);

            rgb = getRGB("indigo");
            Console.WriteLine("Indigo: R={0}, G={1}, B={2}", rgb[0], rgb[1], rgb[2]);

            Console.ReadLine();

            Console.WriteLine("TAsk 2\n");

            Backpack backpack = new Backpack("black", "Nike", "nylon", 1000, 30);
            backpack.ItemAdded += (sender, e) =>
            {
                Console.WriteLine("Item added: " + e.Item.Name);
            };

            try
            {
                backpack.AddItem(new Item("Laptop", 10));


                backpack.AddItem(new Item("Water bottle", 2));
                backpack.AddItem(new Item("Textbook", 5));
                backpack.AddItem(new Item("Snacks", 1));
                backpack.AddItem(new Item("Hiking shoes", 8));
                backpack.AddItem(new Item("Jacket", 4));
                backpack.AddItem(new Item("Camera", 3));
                backpack.AddItem(new Item("Tent", 15));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

            Console.WriteLine("TAsk 3\n");
            int[] numbers = { 14, 7, 21, 35, 12, 77, 28, 49 };

            int count = Array.FindAll(numbers, x => x % 7 == 0).Length;

            Console.WriteLine($"Количество чисел, кратных семи: {count}");

            Console.ReadLine();
        }
    }
}