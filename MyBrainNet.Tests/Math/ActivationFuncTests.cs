using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBrainNet.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBrainNet.Math.Tests
{
    [TestClass()]
    public class ActivationFuncTests
    {
        [TestMethod()]
        public void SigmoidTest()
        {
            Assert.AreEqual(0.5D, ActivationFunc.Sigmoid(0));
        }
    }
}