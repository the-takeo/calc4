using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc4
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc4 _calc4 = new Calc4();
            string result;

            if (_calc4.IsOK(new int[4] { int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]) }, out result))
                Console.WriteLine(result);
            else
                Console.WriteLine("NG");

            Console.ReadLine();
        }
    }
}
