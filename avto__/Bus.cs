using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avto__
{
    internal class Bus : avto
    {
        Random random = new Random();
        public void info_bus(string name, float bak, int mass, int lineage, float gas_per_100_km, int speed, int length)
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
        protected override void infoOut()
        {
            base.infoOut();
            Console.WriteLine("Пассажиры: " + passaj);
        }
        protected float passaj=0;
        public override void move()
        {
            base.move();
            while (true)
            {
                Console.Clear();
                try
                {
                    full_length += speed;
                    distantion -= speed;
                    lineage += speed;
                    bak -= (speed / 100) * gas_per_100_km;
                    if (weight > 2500)
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
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Q:
                                Console.WriteLine("Сколько литров?");
                                bak += int.Parse(Console.ReadLine());
                                break;
                            case ConsoleKey.W:
                                Console.WriteLine("Вы проиграли");
                                Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                                Console.ReadKey();
                                return;
                        }
                    }
                    if (speed <= 0)
                    {
                        Console.WriteLine("Недостаточная скорость\n Хотите ли вы разогнаться?\nQ - да\nW - нет");
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
                Console.WriteLine("A - вывести информацию\nS - заправить машину\nD - Остановить машину\nF - Ускориться или замедлиться\nG - запустить пассажиров\nH - выпустить пассажирова");
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
                        passaj_vpusk();
                        Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.H:
                        Console.WriteLine();
                        passaj_vipusk();
                        Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                        Console.ReadKey();
                        break;
                }
            }
        }
        protected void passaj_vpusk()
        {
            Console.WriteLine("Введите сколько пассажиров заходит");
            float dop_passaj = int.Parse(Console.ReadLine());
            if ((dop_passaj > 50) || (dop_passaj < 0))
            {
                Console.WriteLine("Слишком много или слишком мало");
                return;
            }
            passaj += dop_passaj;
            weight += dop_passaj * 80;
            Console.WriteLine("Вес сейчас: " + weight);
        }
        protected void passaj_vipusk()
        {
            Console.WriteLine("Введите сколько пассажиров выходит");
            float min_passaj = int.Parse(Console.ReadLine());
            if ((min_passaj > passaj) || (min_passaj < 0))
            {
                Console.WriteLine("Слишком много или слишком мало");
                return;
            }
            passaj -= min_passaj;
            weight -= min_passaj * 80;
            Console.WriteLine("Вес сейчас: " + weight);
        }
    }
}
