using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;


namespace OOP_Lab2csharp
{
    public class Triangle
    {
        private
        double[] x = new double[3];
        double[] y = new double[3];
        double[] lengths = new double[3];
        public Triangle()
        {
            for (int i = 0; i < 3; i++) { x[i] = i + 1; }
            y[0] = 0;
            y[1] = 2;
            y[2] = 0;
            SetLengths();
        }
        public Triangle(double[]a, double[]b) {
            x = a;
            y = b;
            SetLengths();
        }

        public Triangle(Triangle a) {
            this.x = a.x;
            this.y = a.y;
            this.lengths = a.lengths;
        }
        public double AreaOfTriangle() {
            double a = Perimeter() / 2;
            return Sqrt(a * (a - lengths[0]) * (a - lengths[1]) * (a - lengths[2]));
        }
        public double Perimeter() {
            return lengths[0] + lengths[1] + lengths[2];
        }
        public void SetLengths() {
            lengths[0] = CalcLength(0,1);
            lengths[1] = CalcLength(1, 2);
            lengths[2] = CalcLength(0, 2);
        }
        public double CalcLength(int a, int b) {
            return Sqrt(Pow((x[a] - x[b]), 2) + Pow((y[a] - y[b]), 2));
        }

        public void Print()
        {
            for (int i = 0; i < 3; i++) {
                Console.WriteLine("x  " + x[i] + "\t y  " + y[i]);
            }
            for (int i = 0; i < 3; i++) { 
                Console.WriteLine(lengths[i]); }
        }

        public double getX(int a) { return x[a]; }
        public double getY(int a) { return y[a]; }
        public void setX(int a) {
            string temp;
            Console.WriteLine("Введіть нову кординату точки по осі іксів");
            temp = Console.ReadLine();
            x[a] = Convert.ToDouble(temp);
        }
        public void setY(int a) {
            string temp;
            Console.WriteLine("Введіть нову кординату точки по осі ігриків");
            temp = Console.ReadLine();
            y[a] = Convert.ToDouble(temp);
        }

        ~Triangle() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = new double[3];
            double[] y = new double[3];
            Console.WriteLine("Використання констуктора за замовчуванням");
            Triangle _default = new Triangle();
            _default.Print();
            Console.WriteLine("Периметр трикутника:" + _default.Perimeter());
            Console.WriteLine("Площа трикутника:" + _default.AreaOfTriangle()+"\n");

            Console.WriteLine("Використання констуктора з параметрами");
            Console.WriteLine("Введіть кординати точок");
            string temp;
            for (int i = 0; i < 3; i++) {
                Console.WriteLine("Кординати точки " + i);
                temp = Console.ReadLine();
                x[i] = Convert.ToDouble(temp);
                temp = Console.ReadLine();
                y[i] = Convert.ToDouble(temp);
            }
            Console.WriteLine();
            Triangle wParams = new Triangle(x,y);
            wParams.Print();
            Console.WriteLine("Периметр трикутника:" + wParams.Perimeter());
            Console.WriteLine("Площа трикутника:" + wParams.AreaOfTriangle() +"\n");

            Console.WriteLine("Використання констуктора копіювання");
            Triangle cp = new Triangle(wParams);
            cp.Print();
            Console.WriteLine("Змінимо кординати точки 2");
            cp.setX(1);
            cp.setY(1);
            cp.SetLengths();
            cp.Print();
            Console.WriteLine("Периметр трикутника:" + cp.Perimeter());
            Console.WriteLine("Площа трикутника:" + cp.AreaOfTriangle());
        }
    }
}
