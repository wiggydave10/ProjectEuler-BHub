﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem023;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P023NonAbundantSums
    {
        [TestMethod]
        public void Version1_NonAbundantSums()
        {
            Assert.AreEqual(4179871, V1.NonAbundantSums());
        }
    }
}
