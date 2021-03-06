﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solutions.Utils;

namespace Solutions.Problem016
{
    public static class V1
    {
        public static long Sum2PowDigits(int n)
        {
            var res = MiscUtils.GetDigits(2).ToArray();
            while (--n > 0)
            {
                res = MiscUtils.Add(res, res);
            }

            return res.Sum();
        }
    }
}
