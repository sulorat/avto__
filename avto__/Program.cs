
using avto__;

Random rnd = new Random();
Bus bus = new Bus();
Gruz gruz = new Gruz();

List<avto> avtopark = new List<avto>();
Console.WriteLine("Введите количество машин на дороге");
int quantiti = int.Parse(Console.ReadLine());
try
{
    for (int i = 0; i < quantiti; i++)
    {
        avto avto = new avto();
        avto.info(i.ToString(),250+i,1500+i,0,4+i,rnd.Next(30,40),1000);
    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("MENU");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Z - Выбрать автобус\nX - выбрать грузовик");
    ConsoleKey selected_key = Console.ReadKey().Key;
    switch (selected_key)
    {
        case ConsoleKey.Z:
            Console.WriteLine();
            Console.WriteLine("Введите длину игрового поля. Максимум 10000");
            int length_1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите номер");
            string name_1 = Console.ReadLine();
            Console.WriteLine("Введите максимальный бак в машине(100-300)");
            float bak_1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите массу машиныюю(700-1300)");
            int mass_1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите пробег машины");
            int lineage_1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите затраты бензина на 100 км машины(3-7)");
            int gas_per_100_km_1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите скорость машины(30-100)");
            int speed_1 = int.Parse(Console.ReadLine());
            bus.info_bus(name_1,bak_1,mass_1,lineage_1,gas_per_100_km_1,speed_1,length_1);
            bus.move();
            break;
        case ConsoleKey.X:
            Console.WriteLine();
            Console.WriteLine("Введите длину игрового поля. Максимум 10000");
            int length_2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите номер");
            string name_2 = Console.ReadLine();
            Console.WriteLine("Введите максимальный бак в машине(100-300)");
            float bak_2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите массу машины(800-1200)");
            int mass_2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите пробег машины");
            int lineage_2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите затраты бензина на 100 км машины(4-8)");
            int gas_per_100_km_2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите скорость машины(40-90)");
            int speed_2 = int.Parse(Console.ReadLine());
            gruz.info_gruz(name_2, bak_2, mass_2, lineage_2, gas_per_100_km_2, speed_2,length_2);
            gruz.move();
            break;
    }

}
catch
{
    Console.WriteLine("Something wrong");
    Console.ReadLine();
}

