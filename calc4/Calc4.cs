using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc4
{
    class Calc4
    {
        private List<string> CalcOperators = new List<string> { "+", "-", "*", "/" };

        public List<string[]> CalcOperatorArrays
        {
            get
            {
                List<string[]> result = new List<string[]>();

                foreach (var calcOperator1 in CalcOperators)
                {
                    foreach (var calcOperator2 in CalcOperators)
                    {
                        foreach (var calcOperator3 in CalcOperators)
                        {
                            result.Add(new string[3] { calcOperator1, calcOperator2, calcOperator3 });
                        }
                    }
                }

                return result;
            }
        }

        public List<int[]> PlacesOfParenthesis
        {
            get
            {
                List<int[]> result = new List<int[]>();
                foreach (var beginNum in new int[4] { 1, 2, 3, 4 })
                {
                    foreach (var endNum in new int[4] { 1, 2, 3, 4 })
                    {
                        if (endNum > beginNum)
                            result.Add(new int[2] { beginNum, endNum });
                    }
                }
                return result;
            }
        }

        public List<int[]> Generate4IntArrays(int[] ints)
        {
            if (ints.Length != 4)
                throw new ApplicationException();

            List<int[]> result = new List<int[]>();

            int[] sequence = new int[4] { 0, 1, 2, 3 };
            List<int> UsedSequence = new List<int>();

            foreach (var i1 in sequence)
            {
                UsedSequence.Add(i1);

                foreach (var i2 in sequence)
                {
                    if (UsedSequence.Contains(i2))
                        continue;

                    UsedSequence.Add(i2);

                    foreach (var i3 in sequence)
                    {
                        if (UsedSequence.Contains(i3))
                            continue;

                        UsedSequence.Add(i3);

                        foreach (var i4 in sequence)
                        {
                            if (UsedSequence.Contains(i4))
                                continue;

                            result.Add(new int[4] { ints[i1], ints[i2], ints[i3], ints[i4] });
                        }
                        UsedSequence.Remove(i3);
                    }
                    UsedSequence.Remove(i2);
                }
                UsedSequence.Remove(i1);
            }

            return result;
        }

        public bool IsOK(int[] Numbers, out string formula)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            formula = string.Empty;

            List<int[]> NumberArrays = Generate4IntArrays(Numbers);

            StringBuilder sb = new StringBuilder();

            foreach (var placeOfParenthesis in PlacesOfParenthesis)
            {
                foreach (var numberArray in NumberArrays)
                {
                    foreach (var calcOperatorArray in CalcOperatorArrays)
                    {
                        if (placeOfParenthesis[0] == 1)
                            sb.Append("(");
                        sb.Append(numberArray[0]);
                        if (placeOfParenthesis[1] == 1)
                            sb.Append(")");
                        sb.Append(calcOperatorArray[0]);

                        if (placeOfParenthesis[0] == 2)
                            sb.Append("(");
                        sb.Append(numberArray[1]);
                        if (placeOfParenthesis[1] == 2)
                            sb.Append(")");
                        sb.Append(calcOperatorArray[1]);

                        if (placeOfParenthesis[0] == 3)
                            sb.Append("(");
                        sb.Append(numberArray[2]);
                        if (placeOfParenthesis[1] == 3)
                            sb.Append(")");
                        sb.Append(calcOperatorArray[2]);

                        if (placeOfParenthesis[0] == 4)
                            sb.Append("(");
                        sb.Append(numberArray[3]);
                        if (placeOfParenthesis[1] == 4)
                            sb.Append(")");

                        int result;

                        if (int.TryParse(dt.Compute(sb.ToString(), "").ToString(), out result) && result == 10)
                        {
                            formula = sb.ToString();
                            return true;
                        }

                        else
                            sb.Clear();
                    }
                }
            }

            return false;
        }
    }
}