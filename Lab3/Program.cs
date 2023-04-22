using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab3
{
    interface INumbers
    {
        void AddEl(int num);
        void RemoveEl(int num);
        int FindEl(int num);
    }
    
    class QNode
    {
        public int num;
        public QNode next;
        public QNode prev;
        public QNode(int num)
        {
            this.num = num;
            this.next = null;
            this.prev = null;
        }
    }

    class Queue : INumbers
    {
           

        public int size;
        QNode first; // перший ел-т черги
        QNode last;  // останній ел-т черги

        public Queue() {
            size = 0;
            first = null;
            last = null;
        }

        /* Додавання елемента в чергу відбувається таким чином,
         *що елемент розміщується в самому кінці
         */
        public void AddEl(int num) 
        {
            if (first == null) 
            {
                this.first = new QNode(num);
                this.last = this.first;
                size = 1;
            }
            else 
            {
                QNode cur = this.last;
                cur.next = new QNode(num);
                this.last = cur.next;
                last.prev = cur;
                ++size;
            }
        }

        /* Вилучення елемента з черги відбувається таким чином,
         * що перший елемент черги "йде" з неї
         * 
         * Окрема операція видалення елемента черги не прописується,
         * елементи, котрі неможливо використати будуть прибрані garbage collector-ом
         */
        public void RemoveEl(int num) 
        {
            QNode curNode, prevNode;
            curNode = first;
            prevNode = null;
            if (FindEl(num)>-1)
            {
                for (int i = 0; i < size; i++)
                { 
                if(curNode.num==num)
                    {
                        if (curNode == first)
                        {
                            first = curNode.next;
                        }
                        else {
                            prevNode.next = curNode.next;
                            curNode.next.prev = prevNode;
                        }
                        --size;
                        break;
                    }
                    prevNode = curNode;
                    curNode = curNode.next;
                }
            }
        }

        public int FindEl(int num) 
        {
            int index = -1;
            QNode cur;
            cur = first;
            for (int i = 0; i < size; i++) 
            {
                if (cur.num == num) 
                {
                    index = i;
                    break;
                }
                cur = cur.next;
            }
            if (index == -1)
            {
                Console.WriteLine("\n Такого числа немає в черзі");
            }
            return index;
        }
        public void Show() {
            QNode cur = first;
            Console.Write("Черга: ");
            for (int i = 0; i < size - 1; i++)
            {
                Console.Write(cur.num + ", ");
                cur = cur.next;
            }
            Console.WriteLine(cur.num + ";");
        }
        ~Queue() { }
    };

    class SNode
    {
        public int num;
        public SNode next;
        public SNode(int num)
        {
            this.num = num;
            this.next = null;
        }

    }

    class Stack : INumbers
    {
        public int size;
        SNode head; // вершина стеку

        /* Додавання елемента в стек відбувається таким чином,
         * що елемент розміщується на початку стеку та стає його вершиною
         */
        public void AddEl(int num) {
            if (head == null)
            {
                this.head = new SNode(num);
                size = 1;
            }
            else
            {
                SNode cur = this.head;
                head = new SNode(num);
                head.next = cur;
                ++size;
            }
        }

        /* Вилучення елемента зі стеку відбувається таким чином,
         * що перший елемент стеку вилучається
         */
        public void RemoveEl(int num)
        {
            SNode curNode, prevNode;
            curNode = head;
            prevNode = null;
            if (FindEl(num) > -1)
            {
                for (int i = 0; i < size; i++)
                {
                    if (curNode.num == num)
                    {
                        if (curNode == head)
                        {
                            head = curNode.next;
                        }
                        else
                        {
                            prevNode.next = curNode.next;
                        }
                        --size;
                        break;
                    }
                    prevNode = curNode;
                    curNode = curNode.next;
                }
            }
        }
        public int FindEl(int num) {
            int index = -1;
            SNode cur;
            cur = head;
            for (int i = 0; i < size; i++)
            {
                if (cur.num == num)
                {
                    index = i;
                    break;
                }
                cur = cur.next;
            }
            if (index == -1)
            {
                Console.WriteLine("\n Такого числа немає в стеку");
            }
            return index;
        }

        public void Show() {
            SNode cur = head;
            Console.Write("Стек: ");
            for (int i = 0; i < size-1; i++)
            {
                Console.Write(cur.num + ", ");
                cur = cur.next;
            }
            Console.WriteLine(cur.num +";");
        }
        public Stack ()
        {
            size = 0;
            head = null;
        }
        ~Stack() { }
    }

    class Program
    {
        static Stack stack = new Stack();
        static Queue queue = new Queue(); 

        static void Menu()
        {
            if (stack.size > 0)
            {
                stack.Show();
            }
            if (queue.size > 0)
            {
                queue.Show();
            }

            Console.WriteLine("1) Додати елемент в стек та чергу");
            Console.WriteLine("2) Видалити елемент зі стеку та черги");
            Console.WriteLine("3) Знайти елемент в стеку та черзі");
            Console.WriteLine("4) Вихід");

            Console.Write("\nУведіть номер пункту меню: ");

            int.TryParse(Console.ReadLine(), out int menuOption);
            switch (menuOption)
            {
                case 1:
                    AddNumber();
                    break;
                case 2:
                    if (stack.size == 0 || queue.size == 0) Console.WriteLine("Стек або черга порожні!");
                    RemoveNumber();
                    break;
                case 3:
                    if (stack.size == 0 || queue.size == 0) Console.WriteLine("Стек або черга порожні!");
                    FindNumber();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Уведіть число від 1 до 4!");
                    break;
            }

            Menu();
        }
        static void AddNumber()
        {
            Console.Clear();

            Console.Write("Уведіть число: ");
            int.TryParse(Console.ReadLine(), out int num);
            
            stack.AddEl(num);
            queue.AddEl(num);

            Console.Clear();
            Console.WriteLine("Число " + num + " додано в стек та чергу!\n");
        }

        static void RemoveNumber()
        {
            Console.Clear();

            Console.Write("Уведіть число: ");
            int.TryParse(Console.ReadLine(), out int num);

            try
            {
                stack.RemoveEl(num);
                queue.RemoveEl(num);

                Console.Clear();
                Console.WriteLine("Число " + num + " видалено зі стеку та черги!\n");
            }
            catch (System.Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message + "\n");
            }
        }

        static void FindNumber()
        {
            Console.Clear();

            Console.Write("Уведіть число: ");
            int.TryParse(Console.ReadLine(), out int num);
            

                int indexInStack = stack.FindEl(num);
                int indexIntStack = queue.FindEl(num);

                Console.Clear();
                Console.WriteLine("Число " + num + " знайдено в стеку та черзі!\n");
                Console.WriteLine("Індекс числа " + num + " в стеку: " + indexInStack);
                Console.WriteLine("Індекс числа " + num + " в черзі: " + indexIntStack + "\n");
        }
        static void Main(string[] args)
        {
            Console.Title = "Лабораторна робота №3";
            Menu();
        }
    }
}
