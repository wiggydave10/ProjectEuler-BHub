﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem053;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P053ConbinatoricSelections
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.Main(100).First(x => x > 1000000).ShouldBe(1144066);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Main(100).Count(x => x > 1000000).ShouldBe(4075);
        }
    }
}
