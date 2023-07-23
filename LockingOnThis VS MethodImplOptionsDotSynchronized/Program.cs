using System;
using System.Runtime.CompilerServices;

//ref link:https://www.youtube.com/watch?v=CSqYgzLHLow&list=PLRwVmtr-pp06KcX24ycbC-KkmAISAFKV5&index=22
//ctrl+l -- remove blank line
//ctrl+m+o -- collapse all
//ctrl+k+d -- align all
// object baton = new object();  // private lock -- recommended lock
// lock (stall1)   // public lock --- lock(this) -- causes disruption be wary

class BathroomStall
{
    //[MethodImpl(MethodImplOptions.Synchronized)]
    //object baton = new object();  // private lock -- recommended lock
    //public void BeUsed()
    public static void BeUsed()
    {
        lock (typeof (BathroomStall))
        {
            Console.WriteLine("Doing our thing...");
            Thread.Sleep(5000);
        }
        //lock(baton)
        /*lock (this)     // public lock --- lock(this) -- 
        {
            Console.WriteLine("Doing our thing...");
            Thread.Sleep(3000);
        }*/
        
    }
    [MethodImpl(MethodImplOptions.Synchronized)]
    //public void FlushToilet()
    public static void FlushToilet()
    {
        //lock (baton)
        /*lock (this)
        {
            Console.WriteLine("Flushing the toilet...");
            Thread.Sleep(3000);
        }*/
        Console.WriteLine("Flushing the toilet...");
        Thread.Sleep(5000);
    }
}


class MainClass
{
    static void Main()
    {
        /*var stall = new BathroomStall(); //instance
        new Thread(stall.BeUsed).Start();
        new Thread(stall.FlushToilet).Start();*/
        new Thread(BathroomStall.BeUsed).Start();
        new Thread(BathroomStall.FlushToilet).Start();
    }
}