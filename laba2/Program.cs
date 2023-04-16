//вар10
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace program {
    class Program {
        static void Main()
        {

            WriteLine("Введите название транспорта");
            string name = Console.ReadLine();
            WriteLine("Введите мощность транспорта");
            int pow = Convert.ToInt32(Console.ReadLine());
            WriteLine("Введите максимульную скорость транспорта");
            int maxs = Convert.ToInt32(Console.ReadLine());
            WriteLine("Введите дату поставки на учет в виде **.**.**");
            string date = Console.ReadLine();
            string[] dates = date.Split('.');
            DateTime dater = new DateTime(Convert.ToInt32(dates[0]), Convert.ToInt32(dates[1]), Convert.ToInt32(dates[2]));
            WriteLine("Введите обьем топливного бака в литрах");
            int volume = Convert.ToInt32(Console.ReadLine());
            WriteLine("Введите расход топлива в литрах на 100 километров");
            double cons = Convert.ToDouble(ReadLine());
            Car trans = new Car(name, pow, maxs, dater, volume, cons);

            WriteLine("Введите время для расчета расстояния");
            int time = Convert.ToInt32(ReadLine());
            WriteLine("Введите налоговую ставку");
            double taxrate = Convert.ToDouble(ReadLine());
            WriteLine("Налог: " + Convert.ToString(trans.Taxes(taxrate)));
            WriteLine("Расстояния пройдено: "+ trans.Distance(time) +"км" );
            WriteLine("Топлива потрачено: "+trans.FuelConsumed(time)+"л");
            Console.WriteLine("Количество заправок: "+trans.NumberOfFillings(time));

        }
    }



    
     
     
    public abstract class Transport
    {
        private string Name { get { return Name; }  set { Name = value; } }
        private int Powerful { get; set; }
        private int MaxSpeed { get; set; }
        private DateTime RegistrationDate { get; set; }
        private int HorsePower { get;}
        public Transport(string N, int P, int M, DateTime R)
        {
            this.Name = N;
            this.Powerful = P;
            this.MaxSpeed = M;
            this.RegistrationDate = R;
            this.HorsePower = Convert.ToInt32(Powerful / 735.499);
        }
        public virtual double Distance(int TimeSpanDuration)
        {
            return MaxSpeed / 2 * TimeSpanDuration;
        }
        public double Taxes(double TaxRate)
        {
           
            double tax;
            tax = TaxRate * Powerful * Convert.ToInt32(RegistrationDate.ToString().Split('.')[1]);
            return tax;
        }
    }

    public class Car : Transport
    {
        private int Volume;
        private double Consumption;

        public Car(string N, int P, int M, DateTime R, int volume, double consumption) : base(N, P, M, R)
        {
                this.Volume = volume;
                this.Consumption = consumption;
        }

        public override double Distance(int TimeSpanDuration)
        {
            return base.Distance(TimeSpanDuration);
        }

        public double FuelConsumed(int TimeSpanDuration)
        {
            return Distance(TimeSpanDuration)*Consumption/100;
        }

        public double NumberOfFillings(int TimeSpanDuration)
        {
            return Math.Floor(FuelConsumed(TimeSpanDuration)/Volume);
        }
    }
}
