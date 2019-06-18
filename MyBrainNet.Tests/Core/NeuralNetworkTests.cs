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

        [TestMethod()]
        public void ActivateTest()
        {
            NeuralNetwork nn = new NeuralNetwork(2,2, 1);

            Assert.AreNotEqual(new double[] {0d}, nn.Activate(new float[] { 0f, 1f }));
            Assert.AreNotEqual(new double[] { 1d }, nn.Activate(new float[] { 0f, 1f }));
            Assert.AreEqual(1, nn.Activate(new float[] { 0f, 1f }).Length);
        }
    }
}