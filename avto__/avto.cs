using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace avto__
{
    internal class avto
    {
        static List<avto> avtopark = new List<avto>();
        Random random = new Random();
        protected string name;
        protected float bak;
        protected int mass;
        protected float lineage;
        protected float gas_per_100_km;
        protected float speed;
        protected int direction = 0;
        protected float distantion = 0;
        protected float weight = 0;
        protected float length;
        protected float full_length;
        protected float templ = 0;

        public void info(string name, float bak, int mass, int lineage, float gas_per_100_km, int speed,int length)
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
            avtopark.Add(this);
        }
        protected virtual void infoOut()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Gas tank: " + bak);
            Console.WriteLine("Mass: " + weight);
            Console.WriteLine("Lineage: " + lineage);
            Console.WriteLine("Gas per 100 km: " + gas_per_100_km);
            Console.WriteLine("Speed: " + speed);
            Console.WriteLine("Directoin: " + direction);
        }
        protected virtual void zapravka()
        {
            Console.WriteLine("Введите сколько литров нужно заправить (не больше 100): ");
            int popoln = int.Parse(Console.ReadLine());
            if ((popoln < 0) || (popoln > 100))
            {
                Console.WriteLine("Не больше 100 и не меньше 0");
            }
            bak += popoln;
        }
        protected virtual void boost_breaking()
        {
            Console.WriteLine("Q - оставить без изменений\nW - ускориться на 5\nD - замедлиться на 5");
            ConsoleKey selected_key = Console.ReadKey().Key;
            switch (selected_key)
            {
                case ConsoleKey.Q:
                    Console.WriteLine("Скорость сохранена.  Скорость сейчас: " + speed);
                    break;
                case ConsoleKey.S:
                speed += 5;
                gas_per_100_km += 1;
                Console.WriteLine("Скорость увеличена. Скорость сейчас: " + speed);
                    break;
                case ConsoleKey.D:
                    speed -= 5;
                    gas_per_100_km -= 1;
                    Console.WriteLine("Скорость уменьшена. Скорость сейчас: " + speed);
                    break;
            }
        }
        protected virtual void ostanovka()
        {
            speed = 0;
            Console.WriteLine("Вы остановились");
        }
        public virtual void move()
        {
            for (int i = 0; i < avtopark.Count-1; i++)
            {
                if ((avtopark[i].direction == direction) && (length - distantion - avtopark[i].distantion < 0))
                {
                    float temp = length - distantion - avtopark[i].distantion;
                    Console.WriteLine($"Вы врежитесь в автомобиль номер " + i + " в " + -temp + " точках");
                    
                }
                Console.WriteLine("Нажмите на любую кнопку, чтобы продолжить");
                Console.ReadKey();
                break;
            }
            weight = mass;
            
        }
    }
}
