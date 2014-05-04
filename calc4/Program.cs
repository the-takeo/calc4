using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc4
{
    class Program
    {
        static void Main(string[] args)
        {
            helper _helper = new helper();

            Console.WriteLine("1桁目の数字を入力してください");
            double i1 = double.Parse(Console.ReadLine().ToString());
            Console.WriteLine("2桁目の数字を入力してください");
            double i2 = double.Parse(Console.ReadLine().ToString());
            Console.WriteLine("3桁目の数字を入力してください");
            double i3 = double.Parse(Console.ReadLine().ToString());
            Console.WriteLine("4桁目の数字を入力してください");
            double i4 = double.Parse(Console.ReadLine().ToString());

            double[] iarray = new double[4] { i1, i2, i3, i4 };

            double[] answer = new double[4];

            helper.calcoperator[] calcoperators;

            foreach(double j1 in iarray)
            {
                List<double> notUsedNumbers = new List<double>(iarray);

                answer[0] = j1;
                notUsedNumbers.Remove(j1);

                foreach (double j2 in iarray)
                {
                    List<double> saveNotUsedNumbers2 = new List<double>(notUsedNumbers);
                    if (!notUsedNumbers.Contains(j2))
                        continue;
                    answer[1] = j2;
                    notUsedNumbers.Remove(j2);

                    foreach (double j3 in iarray)
                    {
                        List<double> saveNotUsedNumbers3 = new List<double>(notUsedNumbers);
                        if (!notUsedNumbers.Contains(j3))
                            continue;
                        answer[2] = j3;
                        notUsedNumbers.Remove(j3);

                        foreach (double j4 in iarray)
                        {
                            if (!notUsedNumbers.Contains(j4))
                                continue;
                            answer[3] = j4;
                            notUsedNumbers.Remove(j4);

                            if(_helper.isOK(answer, out calcoperators))
                            {
                                Console.WriteLine("OK");
                                for (int i = 0; i < 4; i++)
                                {
                                    if (i != 3)
                                    {
                                        string operatorSymbol = string.Empty;

                                        switch (calcoperators[i])
                                        {
                                            case helper.calcoperator.plus:
                                                operatorSymbol = "+";
                                                break;
                                            case helper.calcoperator.minus:
                                                operatorSymbol = "-";
                                                break;
                                            case helper.calcoperator.times:
                                                operatorSymbol = "*";
                                                break;
                                            case helper.calcoperator.par:
                                                operatorSymbol = "/";
                                                break;
                                            default:
                                                break;
                                        }

                                        Console.Write(answer[i].ToString() + operatorSymbol);
                                    }
                                        
                                    else
                                        Console.Write(answer[i].ToString());

                                }

                                Console.WriteLine();
                                Console.WriteLine("You can calc again if you input \"more\"");

                                if(Console.ReadLine().ToString()=="more")
                                    Main(new string[0]);
                                
                                return;
                            }
                        }
                        notUsedNumbers = saveNotUsedNumbers3;
                    }
                    notUsedNumbers = saveNotUsedNumbers2;
                }
            }

            Console.WriteLine("NG"); 
            Console.WriteLine("You can calc again if you input more");

            if (Console.ReadLine().ToString() == "more")
                Main(new string[0]);
        }
    }

    public class helper
    {

        public enum calcoperator
        {
            plus, minus, times, par
        }

        public bool isOK(double[] iarray,out calcoperator[] operators)
        {
            calcoperator[] calcs = new calcoperator[4]{
            calcoperator.plus,calcoperator.minus,calcoperator.times,calcoperator.par};

            operators = new calcoperator[3];


            foreach (calcoperator c1 in calcs)
            {
                operators[0] = c1;

                foreach (calcoperator c2 in calcs)
                {
                    operators[1] = c2;

                    foreach (calcoperator c3 in calcs)
                    {
                        operators[2] = c3;

                        double answer = 0;

                        if (operators[0] == calcoperator.plus)
                            answer += iarray[0] + iarray[1];
                        else if (operators[0] == calcoperator.minus)
                            answer += iarray[0] - iarray[1];
                        else if (operators[0] == calcoperator.times)
                            answer += iarray[0] * iarray[1];
                        else if (operators[0] == calcoperator.par)
                        {
                            if (iarray[0] == 0)
                                break;
                            answer += iarray[0] / iarray[1];
                        }

                        if (operators[1] == calcoperator.plus)
                            answer += iarray[2];
                        else if (operators[1] == calcoperator.minus)
                            answer -= iarray[2];
                        else if (operators[1] == calcoperator.times)
                            answer *= iarray[2];
                        else if (operators[1] == calcoperator.par)
                        {
                            if (iarray[1] == 0)
                                break;
                            answer /= iarray[2];
                        }

                        if (operators[2] == calcoperator.plus)
                            answer += iarray[3];
                        else if (operators[2] == calcoperator.minus)
                            answer -= iarray[3];
                        else if (operators[2] == calcoperator.times)
                            answer *= iarray[3];
                        else if (operators[2] == calcoperator.par)
                        {
                            if (iarray[1] == 0)
                                break;
                            answer /= iarray[3];
                        }
                        if (answer == 10)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
