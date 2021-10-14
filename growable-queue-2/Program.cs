using System;

namespace Simple_Base_Code
{
    class Program
    {
        class GrowableQueue
        {
            private int[] _qArray;
            private int _front;
            private int _rear;
            private int _max;
            private int _size;

            public GrowableQueue(int qSize)
            {
                _max = qSize;
                _qArray = new int[_max];
                _front = 0;
                _rear = -1;
                _size = 0;
            }
            
            public bool enqueue(int item)
            {
                bool rv;

                if (_rear == _max - 1 && _size != _max)
                {
                    _rear = -1;
                }

                if (_size == _max)
                {
                    growQueue();
                }

                _rear++;
                _qArray[_rear] = item;
                _size++;
                rv = true;
                

                return rv;
            }

            public bool dequeue(ref int p)
            {
                bool rv = true;

                if (_size == 0)
                {
                    p = -1;
                    rv = false;
                }
                else
                {
                    p = _qArray[_front];
                    _front++;
                    if (_front == _max)
                    {
                        _front = 0;
                    }
                    _size--;
                }
                return rv;
            }

            public void growQueue()
            {
                int[] newArray = new int[_max * 2];

                int i = _front;
                do
                {
                    newArray[i] = _qArray[i];
                    if (i == _rear) break;
                    i++;
                    if (i == _max)
                    {
                        i = 0;
                    }
                } while (true);

                _qArray = newArray;
                _max = _max * 2;

                Console.WriteLine("\nThe queue has been updated and can now hold " + _qArray.Length + " items.");

            }

            public void printQueue()
            {

                if (_size == 0)
                {
                    Console.WriteLine("Queue is Empty");
                }
                else
                {
                    int i;
                    i = _front;
                    do
                    {
                        Console.WriteLine(_qArray[i]);
                        if (i == _rear) break;
                        i++;
                        if (i == _max)
                        {
                            i = 0;
                        }
                    } while (true);
                }
            }

            public int Size()
            {
                return _size;
            }

            public bool isEmpty()
            {
                if (_size == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool Peek(int item)
            {
                bool rv = false;

                if (_size > 0)
                {
                    if (item == _qArray[_front])
                    {
                        rv = true;
                    }
                }

                return rv;
            }

            public void Clear()
            {
                Array.Clear(_qArray, 0, _qArray.Length);
                _front = 0;
                _rear = -1;
                _size = 0;

                Console.WriteLine("Queue Cleared");
            }
        }

        static void Main(string[] args)
        {
            GrowableQueue Q = new GrowableQueue(10);
            int item = 0;

            Console.WriteLine("\nPrintout of queue\n--------------------");
            Q.printQueue();
            Console.WriteLine("\n This queue has " + Q.Size() + " items.");
            Console.WriteLine("\n Does that mean the queue is empty? " + Q.isEmpty());
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enqueue of {0} ", i * 10);
                if (Q.enqueue(i * 10))
                {
                    Console.WriteLine("Successful");
                }
                else
                {
                    Console.WriteLine("Unsuccessful");
                }
            }

            Console.WriteLine("\nPrintout of queue\n--------------------");
            Q.printQueue();
            Console.WriteLine("\n This queue has " + Q.Size() + " items.");
            Console.WriteLine("\n Does that mean the queue is empty? " + Q.isEmpty());
            Console.WriteLine("\n Is 0 next in Queue? " + Q.Peek(0));
            Console.WriteLine();

            Q.enqueue(1);

            Console.WriteLine("\nPrintout of queue\n--------------------");
            Q.printQueue();
            Console.WriteLine("\n This queue has " + Q.Size() + " items.");
            Console.WriteLine("\n Does that mean the queue is empty? " + Q.isEmpty());
            Console.WriteLine("\n Is 0 next in Queue? " + Q.Peek(0));
            Console.WriteLine();

            for (int i = 10; i < 20; i++)
            {
                Console.Write("Enqueue of {0} ", i * 10);
                if (Q.enqueue(i * 10))
                {
                    Console.WriteLine("Successful");
                }
                else
                {
                    Console.WriteLine("Unsuccessful");
                }
            }

            Console.WriteLine("\nPrintout of queue\n--------------------");
            Q.printQueue();
            Console.WriteLine("\n This queue has " + Q.Size() + " items.");
            Console.WriteLine("\n Does that mean the queue is empty? " + Q.isEmpty());
            Console.WriteLine("\n Is 0 next in Queue? " + Q.Peek(0));
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
