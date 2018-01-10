using System;
using System.Collections.Generic;

namespace Rubik
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Cube();
            /*Random random = new Random();

            Console.WriteLine("Creating Cube");
            for (int i = 1; i <= 10; i++){
                if(random.Next() % 2 == 0) a.FaceTop.Rotate();
                if (random.Next() % 2 == 0) a.FaceBottom.Rotate();
                if (random.Next() % 2 == 0) a.FaceLeft.Rotate();
                if (random.Next() % 2 == 0) a.FaceRight.Rotate();
                if (random.Next() % 2 == 0) a.FaceFront.Rotate();
                if (random.Next() % 2 == 0) a.FaceBack.Rotate();
            }*/

            var dtStart = DateTime.Now;
            var solver = new Solver(a);

            Console.WriteLine(a.SolvedCount);

            var actions = solver.Solve();

            var dtEnd = DateTime.Now;

            Log("Solved Count:{0} ", a.SolvedCount);
            Log("Time: {0} ms", (dtEnd - dtStart).TotalMilliseconds); 
        }

       public static void Log(string format, params object[] args){
            Console.WriteLine(String.Format(format,args) );
       }
    }
}
