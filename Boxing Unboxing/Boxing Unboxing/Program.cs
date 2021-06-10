using System;
using System.Collections;

namespace Boxing_Unboxing
{
    struct Point
    {
        public Int32 x, y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList a = new ArrayList();
            Point p; // Memory allocated for Point(not on the heap)
            for (Int32 i = 0; i < 10; i++)
            {
                p.x = p.y = i; // Initializing members in our value type
                a.Add(p); //  Significant type packing and adding
                          // references in ArrayList

            }
        }
    }
}
