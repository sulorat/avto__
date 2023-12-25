using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace avto__
{ 

    internal class Gruz : avto
    {
        private int going;
        Random random = new Random();
        public void info_gruz(string name, float bak, int mass, int lineage, float gas_per_100_km, int speed, int length)
        {
            this.name = name;
            this.bak = bak;
            this.mass = mass;
            this.lineage = lineage;
            this.gas_per_100_km = gas_per_100_km;
            this.speed = speed;
            distantion = random.Next(1200, 2000);
            direction = random.Next(4);
            this.length = length;
        }
        protected virtual void zagruzka()
        {
            Console.WriteLine("Введите сколько нужно загрузить. Максимум 100");
            int dop_weight = int.Parse(Console.ReadLine());
            if ((dop_weight > 100) || (dop_weight < 0))
            {
                Console.WriteLine("Слишком много или слишком мало");
                return;
            }
            weight += dop_weight;
            Console.WriteLine("Вес сейчас: " + weight);
            
        }
        protected virtual void razgruzka() 
        {
                Console.WriteLine("Введите сколько нужно разгрузить");
                int min_weight = int.Parse(Console.ReadLine());
                if ((min_weight > weight) || (min_weight < 0))
                {
                    Console.WriteLine("Слишком много или слишком мало");
                    return;
                }
                weight -= min_weight;
                Console.WriteLine("Вес сейчас: " + weight);
        }
        public override void move()
        {

            base.move();
            while (true)
            {
                Console.Clear();
                try
                {
                    distantion -= speed;
                    lineage += speed;
                    full_length += speed;
                    bak -= (speed / 100) * gas_per_100_km;
                    infoOut();
                    
                    if (weight > 1500)
                    {

                        if (weight > 2600)
                        {
                            if (weight > 2700)
                            {
                                if (weight > 2800)
                                {
                                    if (weight > 2900)
                                    {
                                        if (weight > 3000)
                                        {
                                            weight -= 200;
                                            Console.WriteLine("Вес слишком большой. Вы скинули 200 кг");
                                            Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                                            Console.ReadKey();
                                            continue;

                                        }
                                        speed -= 15;
                                        gas_per_100_km += 3;
                                    }
                                    speed -= 12;
                                    gas_per_100_km += 2;
                                }
                                speed -= 9;
                                gas_per_100_km += 2;
                            }
                            speed -= 6;
                            gas_per_100_km += 1;
                        }
                        speed -= 3;
                        gas_per_100_km += 1;
                    }
                    if (full_length >= length)
                    {
                        Console.WriteLine("Вы доехали");
                        Console.ReadKey();
                        return;
                    }
                    if (bak <= 0)
                    {
                        Console.WriteLine("Бак пуст.\nХотите заправиться?\nQ - да\nW - нет");
                        Console.WriteLine();
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Q:
                                Console.WriteLine("Сколько литров?");
                                bak += int.Parse(Console.ReadLine());
                                break;
                            case ConsoleKey.W:
                                Console.WriteLine("Вы проиграли");
                                Console.WriteLine("Нажмите на любую кнопку, чтобы выйти");
                                Console.ReadKey();
                                return;
                        }
                    }
                    if (speed <= 0)
                    {
                        Console.WriteLine("Недостаточная скорость\n Хотите ли вы разогнаться?\nQ - да\nW - нет");
                        Console.WriteLine();
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Q:
                                Console.WriteLine("Вы разогнались до 30 км/ч");
                                Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                                Console.ReadKey();
                                speed = 30;
                                break;
                            case ConsoleKey.W:
                                Console.WriteLine("Вы остановились");
                                Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                                Console.ReadKey();
                                break;
                        }
                    }

                }
                catch
                {
                    Console.WriteLine("Someting wrong");
                    Console.ReadLine();
                }

                Console.WriteLine("A - вывести информацию\nS - заправить машину\nD - Остановить машину\nF - Ускориться или замедлиться\nG - Загрузиться\nH - Разгрузиться");
                ConsoleKey selected_key = Console.ReadKey().Key;
                switch (selected_key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine();
                        infoOut();
                        Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine();
                        zapravka();
                        Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine();
                        ostanovka();
                        Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F:
                        Console.WriteLine();
                        boost_breaking();
                        Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.G:
                        Console.WriteLine();
                        zagruzka();
                        Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.H:
                        Console.WriteLine();
                        razgruzka();
                        Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}

