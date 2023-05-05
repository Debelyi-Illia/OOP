using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Array;


namespace OOP_Lab2csh
{
    class Task1 {
        double []array;

        public Task1() {
            Console.WriteLine("Введіть розміри масива");
            int size = Convert.ToInt32(Console.ReadLine());
            array = new double[size];
            RewriteAr(ref this.array);
        }
        public void ArrMenu(double[] array) 
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Меню:\n" +
                "1.Змінити елемент в масиві чисел\n"+
                "2.Змінити розміри масива\n" +
                "3.Заповнити масив заново\n" +
                "4.Вийти\n");

                Console.Write("Ваш вибір: ");
            choice = int.Parse(Console.ReadLine());
            
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        PrintArray(array);
                        ChangeArEl(ref array);
                        break;
                    case 2:
                        Console.Clear();
                        ResizeAr(ref array);
                        PrintArray(array);
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.Clear();
                        RewriteAr(ref array);
                        break;
                    default: break;
                }
            } while (choice != 4);
        }
        
        public void FillWRand(ref double[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-99, 100);
            }
        }
        public void ManualInput(ref double[] array)
        {
            Console.WriteLine("Починайте ввід чисел");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write((i+1) + ":  ");
                array[i] = double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }
        public void ChangeArEl(ref double []array)
        {
            int[] temp = new int[2];
            Console.Write("Вкажіть номер елемента, котрий бажаєте змінити: ");
            temp[0] = (int.Parse(Console.ReadLine())) - 1;
            Console.Write("Вкажіть нове число для цього елемента: ");
            temp[1] = int.Parse(Console.ReadLine());
            array[temp[0]] = temp[1];
        }
        public void PrintArray(double[] array)
        {
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
        }
        public void ResizeAr(ref double[] array) {
            Console.Write("Вкажіть число, котре відповідатиме новим розмірам масива: ");
            int newSize = Convert.ToInt32(Console.ReadLine());
            double[] newArray = new double[newSize];
            
            int swapParam;
            bool turn = newSize > array.Length;
            swapParam = (newSize > array.Length?array.Length : newSize);
            for (int i = 0; i < swapParam; i++) {
                newArray[i] = array[i];
            }
            if (turn) {
                for (int i = swapParam; i < newSize; i++) {
                    newArray[i] = 0;
                }
            }

            array = newArray;
        }
        public void RewriteAr(ref double[] array) {
            int choice;
            Console.Clear();
            Console.WriteLine("Вкажіть варіант заповнення масиву\n" +
                "1. Ручне заповнення;\n" +
                "2. Автоматичне заповнення;\n");
            Console.WriteLine("Вкажіть відповідне число для способу вводу: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice) 
            {
                case 1:
                    ManualInput(ref array);
                    break;
                case 2:
                    FillWRand(ref array);
                    break;
                default: 
                    FillWRand(ref array);
                    break;
            }
        }
        public void Task1_1(double[] array)
        {
            int size = array.Length;
            double a = 1;
            bool flag = true;

            for (int i = 0; i < size; i++)
            {
                if (array[i] <= 0)
                {
                    flag = false;
                    break;
                }
                a *= array[i];
            }

            if (flag)
            {
                Console.WriteLine("Середнє геометричне чисел масиву дорівнює: " + Math.Pow(a, 1.0 / size) + " ;\n");
            }
            else
            {
                Console.WriteLine("Неможливо обчислити середнє геометричне,\nсеред чисел є від'ємне значення\n");
            }
            Console.WriteLine("Натисніть Enter, щоб повернутись до меню");
            Console.ReadLine();
        }
        public void Task1_2(double[] array) 
        {
            double scalar;
            Console.WriteLine("Введіть число на яке буде помножено вектор");
            Console.Write("Число: ");
            scalar = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Вектор перед множенням:");
            PrintArray(array);

            for (int i = 0; i < array.Length; i++) 
            {
                array[i] *= scalar;
            }

            Console.WriteLine("Вектор після множення");
            PrintArray(array);
            Console.WriteLine("Натисніть Enter, для повернення у попереднє меню");
            Console.ReadLine();
        }
        public void Task1_3(double[] array)
        {
            int ch;
            
            Console.WriteLine("Оберіть алгоритм за яким буде відсортовано масив\n" +
                "1.Бульбашкове сортування\n" +
                "2.Швидке сортування\n");
            ch = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Масив перед сортуванням:");
            PrintArray(array);
            Console.WriteLine();

            Console.WriteLine("Масив після сортування:");
            switch (ch) 
            {
                case 1:
                    PrintArray(BubbleSort(array));
                    break;
                case 2:
                    PrintArray(QuickSort(array));
                    break;

                default:
                    Console.WriteLine("Автоматично було використано алгоритм Швидкого сортування");
                    PrintArray(QuickSort(array));
                     break;
            }
            Console.WriteLine("Натисніть Enter, для повернення у попереднє меню");
            Console.ReadLine();
        }

        //Сортування бульбашкою
        static double[] BubbleSort(double[] array) {
            double temp;
            double[] result = array;
            for (int j = 0; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length-1; i++)
                {
                    temp = result[i];
                    if (result[i] < result[i + 1])
                    {
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                    }
                }
            }
            return result;
        }

        //Швидке сортування
        static void Swap(ref double x, ref double y) 
        {
            double temp = x;
            x = y;
            y = temp;
        }
        static int Partition(double[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static double[] QuickSort(double[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        static double[] QuickSort(double[]array) 
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        public void Menu() {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Меню для Завдання 1:\n" +
                    "\t 1.Знайти середнє геометричне значення чисел масиву;\n" +
                    "\t 2.Знайти добуток вектора на число;\n" +
                    "\t 3.Впорядкувати елементи масиву за спаданням;\n" +
                    "\t 4.Редагувати масив;\n" +
                    "\t 5.Вийти з меню");
                Console.Write("Введіть номер дії: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) 
                {
                    case 1:
                        Task1_1(this.array);                        
                        break;
                    case 2:
                        Task1_2(this.array);
                        Console.WriteLine();
                        PrintArray(this.array);
                        Console.WriteLine("Натисніть Enter, щоб повернутись до меню");
                        Console.ReadLine();
                        break;
                    case 3:
                        Task1_3(this.array);
                        break;
                    case 4:
                        ArrMenu(this.array);
                        break;
                    case 5: break;
                   default:
                        Console.WriteLine("Вказано некоректний варіант дії"); break;
                }
            } while (choice != 5);
        }

    }
    class Task2
    {
        public void StartAr(out int width, out int height, out int[,] array,  bool flag) {
            Console.WriteLine("Вкажіть розмірність матриці");
            Console.Write("Ширина: ");
            width = Convert.ToInt32(Console.ReadLine());
            height = 0;
            if (flag)
            {
                Console.Write("Висота: ");
                height = Convert.ToInt32(Console.ReadLine());
                array = new int[width,height];
            }
            else array = new int[width,width];
        }
        static int [,] SortSqrAr(int[,] array, int width) 
        {
            int temp1;
            int[,] temp2=new int[width,width];
            Array.Copy(array, temp2, array.Length);
            for (int h = 0; h < width; h+=2)
            {
                
                for (int j = 0; j < width; j++)
                {
                    for (int i = 0; i < width - 1; i++)
                    {
                        temp1 = temp2[i,h];
                        if (temp2[i,h] > temp2[i + 1,h])
                        {
                            temp2[i, h] = temp2[i + 1, h];
                            temp2[i + 1, h] = temp1;
                        }
                    }
                }
            }
            return temp2;
        }
        public void FillArr(ref int[,] array, int width, int height)
        {
            Random rand = new Random();
            Console.WriteLine("Оберіть варіант заповнення матриці\n" +
                "1.Вручну\n" +
                "2.Автоматично випадковими числами");
            Console.Write("Ваш вибір:");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch) 
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Розпочинайте введення:");
                    for (int j = 0; j < height; j++)
                    {
                        for (int i = 0; i < width; i++)
                        {
                            Console.WriteLine("Лишилось вказати: "+ (width*height-i-j));
                            array[i,j] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    break;
                case 2: 
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    array[i,j] = rand.Next(-5, 5);
                }
            }
                    break;
                default:
                    for (int j = 0; j < height; j++)
                    {
                        for (int i = 0; i < width; i++)
                        {
                            array[i,j] = rand.Next(-5, 5);
                        }
                    }
                    break;
            }
        }

        public void PrintMatrix(int[,] array, int w, int h) {
            for (int j=0; j<h; j++) 
            {
                for (int i = 0; i < w; i++) 
                {
                    Console.Write(array[i,j]+"  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        
        }
        public void PrintMatrix(int[][] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i][j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        public void Task2_1()
        {
            StartAr(out int width, out int height, out int[,] array, false);
            FillArr(ref array, width, width);
            Console.WriteLine("Матриця перед сортуванням:");
            PrintMatrix(array, width, width);
            Console.WriteLine("Матриця після сортування:");
            PrintMatrix(SortSqrAr(array, width), width, width);
            Console.WriteLine("Натисніть Enter, щоб перейти до наступного завдання");
            Console.ReadLine();
        }
        public void Task2_2() 
        {
            int[] list;
            int count; // кількість стовпців, де немає нульових елементів

            StartAr(out int width, out int height, out int[,] array, true);
            FillArr(ref array, width, height);
            list = new int[width];
            count = width;
            PrintMatrix(array, width, height);

            for (int i = 0; i< width; i++) 
            { 
                for (int j = 0; j< height; j++)
                {
                    if (array[i, j] == 0) 
                    {
                        list[i] += 1;
                        count--;
                        break;
                    }
                }
            }

            Console.WriteLine("Кількість стовпців, де немає нульових елементів: " + count);
            Console.Write("У стовпці ");
            for (int i = 0; i < width; i++) {
                if (list[i] == 0) 
                {
                    Console.Write((i+1)+"  "); 
                }
            }
            Console.WriteLine("немає нульових елементів");
            Console.Write("Натисніть Enter, щоб повернутись у стартове меню");
            Console.ReadLine();
        }
        public void Task2_3() {
            StartAr(out int width, out int height, out int[,] array, true);
            FillArr(ref array, width, height);
            Console.WriteLine("Матриця перед перестановкою:");
            PrintMatrix(array, width, height);

            int[,] arrCopy = new int[width,height];
            int[] list = new int[height]; // список, що зберігає характеристики рядків
            int temp;
            Array.Copy(array, arrCopy, array.Length);

            // цикл обчислення характеристик рядків
            for (int i = 0; i < height; i++) {
                list[i] = GetStrength(array, width, i);
            }

            // порівняння характеристик рядків, із переставлянням відповідних рядків матриці
            for (int j=0; j<height; j++) 
            {
                for (int i=0; i<height-1; i++) 
                {
                    temp = list[i];

            
                        if (list[i] > list[i + 1])
                        {
                            list[i] = list[i + 1];
                            list[i + 1] = temp;
                        SwapRows(ref arrCopy, width, i);
                        }
                } 
            }
            Console.WriteLine("Матриця після перестановки:");
            for (int j=0; j<height; j++) 
            {
                Console.Write("  " + list[j] + "  | ");
                for (int i=0; i<width; i++)
                {
                    Console.Write(arrCopy[i,j]+"  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Натисніть Enter, для повернення у попереднє меню");
            Console.ReadLine();
        }
        public int GetStrength(int [,] array, int width, int height)
        {
            int c = 0;
            for (int i = 1; i < width; i+=2) 
            {
                if (array[i, height] > 0)
                {
                    c += array[i, height];
                }
            }
            return c;
        }
        public void SwapRows(ref int[,] arrCopy, int width, int h) {
            int[] temp = new int[width];
            CopyRow(ref temp, arrCopy, width, h);
            for (int i =0; i<width; i++) 
            {
                arrCopy[i, h] = arrCopy[i,(h+1)];
                arrCopy[i, (h + 1)] = temp[i];
            }
        }
        public void CopyRow(ref int[]copy, int[,] array, int width, int height) {
            
            for (int i = 0; i < width; i++) 
            {
                copy[i] = array[i,height];
            }
            
        }

        public void Menu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Меню для Завдання 2:\n" +
                    "\t 1.Розмістити непарні рядки квадратної матриці в порядку зростання;\n" +
                    "\t 2.Визначити кількість стовпців, які не містять жодного нульового елемента;\n" +
                    "\t 3.Переставити рядки матриці в порядку зростання характеристики (сума всіх елементів);\n" +
                    "\t 4.Вийти з меню");
                Console.Write("Введіть номер дії: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Task2_1();
                        break;
                    case 2:
                        Task2_2();
                        break;
                    case 3:
                        Task2_3();
                        break;
                    default:
                        Console.WriteLine("Вказано некоректний варіант дії"); break;
                }
            } while (choice != 4);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int ch;
            Console.WriteLine("Проініціалізуємо масив для першого завдання:");
            Task1 t1 = new Task1();
            Task2 t2 = new Task2();
            do
            {
                Console.Clear();
                Console.WriteLine("Виберіть варіант:\n" +
                    "1.Завдання 1\n" +
                    "2.Завдання 2\n");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch) 
                { 
                case 1:
                        t1.Menu();
                        break;
                case 2:
                        t2.Menu();
                        break;
                default: break;
                }
            } while (true);
        }
    }
}
