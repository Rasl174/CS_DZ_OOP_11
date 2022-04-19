using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_OOP_11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fish> fishs = new List<Fish>();
            Aquarium aquarium = new Aquarium(fishs);
            Console.WriteLine("Вам подарили аквариум.");
            aquarium.Work();
        }
    }

    class Aquarium
    {
        private List<Fish> _fishs;

        public Aquarium(List<Fish> fishs)
        {
            _fishs = fishs;
        }

        public void Work()
        {
            bool isWork = true;
            int maximumAge = 10;

            while (isWork)
            {
                Console.WriteLine("Для того что бы добавить рыбку введите 1");
                Console.WriteLine("Для того что бы убрать рыбку введите 2");
                Console.WriteLine("Для выхода введите 3");
                Console.SetCursorPosition(0, 10);
                ShowStats();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddFish();
                        break;
                    case "2":
                        DeleteFish();
                        break;
                    case "3":
                        isWork = false;
                        break;
                }
                AgingFishs();
                DeleteOldFishs(maximumAge);
                Console.Clear();
            }
        }

        private void DeleteOldFishs(int maximumAge)
        {
            foreach (var fish in _fishs)
            {
                if(fish.Age >= maximumAge)
                {
                    Console.Clear();
                    Console.WriteLine("Рыбка - " + fish.Name + " умерла!");
                    _fishs.Remove(fish);
                    Console.ReadKey();
                    break;
                }
            }
        }

        private void AgingFishs()
        {
            foreach (var fish in _fishs)
            {
                fish.Aging();
            }
        }

        private void ShowStats()
        {
            if(_fishs.Count > 0)
            {
                foreach (var fish in _fishs)
                {
                    Console.WriteLine("Рыбка - " + fish.Name + "  ее возраст " + fish.Age);
                }
            }
            else
            {
                Console.WriteLine("Пока нет ни одной рыбки");
            }
        }

        private void AddFish()
        {
            Console.Clear();
            if(_fishs.Count < 5)
            {
                bool correctInput = false;
                int age = 0;
                Console.Write("Введите имя рыбки: ");
                string name = Console.ReadLine();
                Console.Write("Введите ее возраст не более 2: ");
                while (correctInput == false)
                {
                    if (int.TryParse(Console.ReadLine(), out int userInput) && userInput >= 0 && userInput <= 2)
                    {
                        correctInput = true;
                        age = userInput;
                    }
                    else
                    {
                        Console.WriteLine("Не верный ввод повторите попытку!");
                    }
                }
                _fishs.Add(new Fish(name, age));
                Console.WriteLine("Рыбка добалена!");
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                Console.WriteLine("Аквариум полный!");
            }
        }

        private void DeleteFish()
        {
            Console.Clear();
            if (_fishs.Count > 0)
            {
                Console.WriteLine("Введите имя рыбки");
                string userInput = Console.ReadLine();
                foreach (var fish in _fishs)
                {
                    if(userInput == fish.Name)
                    {
                        _fishs.Remove(fish);
                        Console.WriteLine("Рыбка удалена!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("В аквариуме нет таких рыбок!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Еще нет рыб!");
            }
            Console.ReadKey();
        }
    }

    class Fish
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public Fish(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Aging()
        {
            Age += 1;
        }
    }
}
