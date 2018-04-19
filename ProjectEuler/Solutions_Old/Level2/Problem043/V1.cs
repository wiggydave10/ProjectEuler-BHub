﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem043
{
    /*
        Sub-string divisibility
        Problem 43
        The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.

        Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

        d2d3d4=406 is divisible by 2
        d3d4d5=063 is divisible by 3
        d4d5d6=635 is divisible by 5
        d5d6d7=357 is divisible by 7
        d6d7d8=572 is divisible by 11
        d7d8d9=728 is divisible by 13
        d8d9d10=289 is divisible by 17
        Find the sum of all 0 to 9 pandigital numbers with this property.
    */
    public static class V1
    {
        public static IEnumerable<long> Get()
        {
            var pandigitals =
                SetUtils.Permutations(Enumerable.Range(0, 10).Select(x => (long)x))
                    .Select(d => d.Reverse())
                    .Where(digits => digits.First() != 0);

            return pandigitals.Where(HasSubstringDivisibility).Select(x => x.DigitsToNumber());
        }

        public static bool HasSubstringDivisibility(IEnumerable<long> digits)
        {
            var arr = digits.Reverse().ToArray();
            var primes = PrimeUtils.Primes.Take(8).ToArray();

            for (var i = 0; i < 7; i++)
            {
                var substring = arr.Skip(i + 1).Take(3);
                if (substring.Reverse().DigitsToNumber() % primes[i] != 0)
                    return false;
            }

            return true;
        }
    }
}
