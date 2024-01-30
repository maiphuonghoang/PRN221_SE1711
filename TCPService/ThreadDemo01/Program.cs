class Program
{
    static void Main()
    {
        Thread t1 = new Thread(new ThreadStart(MethodA));
        Thread t2 = new Thread(new ThreadStart(MethodB));
        t1.Start();
        t2.Start();

    }

    static void MethodA()
    {
        for (int i = 0; i < 100; i++)
            Console.WriteLine("0");
    }
    static void MethodB()
    {
        for (int i = 0; i < 100; i++)
            Console.WriteLine("1");
    }
}