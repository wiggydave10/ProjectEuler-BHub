﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem047
{
    /*
        Distinct primes factors
        Problem 47 
        The first two consecutive numbers to have two distinct prime factors are:

        14 = 2 × 7
        15 = 3 × 5

        The first three consecutive numbers to have three distinct prime factors are:

        644 = 2² × 7 × 23
        645 = 3 × 5 × 43
        646 = 2 × 17 × 19.

        Find the first four consecutive integers to have four distinct prime factors each. What is the first of these numbers?
    */
    public static class V1
    {
        public static long Main(int distinctCount)
        {
            var primes = new SortedSet<long>();
            var prevPrimeFactors = new Stack<HashSet<PrimeFactor>>();
            var n = 2L;
            while (prevPrimeFactors.Count != distinctCount)
            {
                if (primes.Max < n) primes.Add(PrimeUtils.NextPrime(primes));
                // stop collecting factors if more than distinct count
                var factors = new HashSet<PrimeFactor>(GetPrimeFactors(n, primes).TakeWhile((x,i) => i <= distinctCount));

                if (factors.Count != distinctCount)
                {
                    prevPrimeFactors.Clear();
                }
                else
                {
                    prevPrimeFactors = new Stack<HashSet<PrimeFactor>>(prevPrimeFactors.TakeWhile(fs => !fs.Overlaps(factors)).Reverse());
                    prevPrimeFactors.Push(factors);
                }

                n++;
            }

            return prevPrimeFactors.Last().Select(x => x.Value).Aggregate((a, b) => a * b);
        }

        public static IEnumerable<PrimeFactor> GetPrimeFactors(long n, SortedSet<long> primes)
        {
            if (primes.Max == n)
            {
                yield return new PrimeFactor(n, 1);
                yield break;
            }

            foreach (var prime in primes)
            {
                var exponant = 0;
                var remainder = n;
                while (remainder > 1 && remainder % prime == 0)
                {
                    exponant++;
                    remainder /= prime;
                }

                if (exponant == 0) continue;

                yield return new PrimeFactor(prime, exponant);
            }
        }
    }

    public class PrimeFactor : Tuple<long, int>
    {
        public PrimeFactor(long prime, int exponant) : base(prime, exponant) {}
        public long Value => (long) Math.Pow(Item1, Item2);
    }
}
