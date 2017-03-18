﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem7;

namespace UnitTests
{
    [TestClass]
    public class Problem7Tests
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(13, V1.NthPrime(6));
            Assert.AreEqual(104743, V1.NthPrime(10001));
        }

        [TestMethod]
        public void Version2Tests()
        {
            Assert.AreEqual(13, V2.NthPrime(6));
            Assert.AreEqual(104743, V2.NthPrime(10001));
        }
    }
}
