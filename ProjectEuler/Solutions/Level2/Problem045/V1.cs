﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Solutions.Problem045
{
    /*
        Triangular, pentagonal, and hexagonal
        Problem 45 
        Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:

        Triangle	 	Tn=n(n+1)/2	 	1, 3, 6, 10, 15, ...
        Pentagonal	 	Pn=n(3n−1)/2	 	1, 5, 12, 22, 35, ...
        Hexagonal	 	Hn=n(2n−1)	 	1, 6, 15, 28, 45, ...
        It can be verified that T285 = P165 = H143 = 40755.

        Find the next triangle number that is also pentagonal and hexagonal.
    */
    public static class V1
    {
        public static IEnumerable<BigInteger> Satisfies(IEnumerable<Func<BigInteger, BigInteger>> polyFormulas)
        {
            var formulas = polyFormulas.ToArray();
            if (formulas.Length == 0) yield break;

            var formulaHistories = formulas.Select(x => new SortedSet<BigInteger>()).ToArray();
            var baseFormula = formulas[0];
            var n = 1;

            while(true)
            {
                var satisfies = true;
                var res = baseFormula(n++);

                for (var i = 1; i < formulas.Length; i++)
                {
                    var formula = formulas[i];
                    var set = formulaHistories[i];
                    var n2 = set.Count;
                    while (res > set.Max) set.Add(formula(++n2));
                    if (!set.Contains(res))
                    {
                        satisfies = false;
                        break;
                    }
                }

                if (satisfies) yield return res;
            }
        }

        public static BigInteger Triangle(BigInteger n)
        {
            return n * (n + 1) / 2;
        }

        public static BigInteger Pentagonal(BigInteger n)
        {
            return n * (3 * n - 1) / 2;
        }

        public static BigInteger Hexagonal(BigInteger n)
        {
            return n * (2 * n - 1);
        }
    }
}
