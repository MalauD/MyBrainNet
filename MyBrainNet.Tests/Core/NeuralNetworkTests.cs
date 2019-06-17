using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBrainNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBrainNet.Core.Tests
{
    [TestClass()]
    public class NeuralNetworkTests
    {
        [TestMethod()]
        public void NeuralNetworkTest()
        {
            NeuralNetwork nnTest = new NeuralNetwork(3, 2, 5);
            Assert.AreEqual(3, nnTest.Layers.Length);

            Assert.AreEqual(3, nnTest.Layers[0].Neurons.Length);
            Assert.AreEqual(2, nnTest.Layers[1].Neurons.Length);
            Assert.AreEqual(5, nnTest.Layers[2].Neurons.Length);
        }
    }
}