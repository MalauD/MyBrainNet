using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            NeuralNetwork nn = new NeuralNetwork(2, 2, 1);

            Assert.AreNotEqual(new double[] { 0d }, nn.Activate(new float[] { 0f, 1f }));
            Assert.AreNotEqual(new double[] { 1d }, nn.Activate(new float[] { 0f, 1f }));
            Assert.AreEqual(1, nn.Activate(new float[] { 0f, 1f }).Length);
        }

        [TestMethod()]
        public void TrainTest()
        {
            NeuralNetwork nn = new NeuralNetwork(2, 2, 1);
            nn.Train(new Tuple<float[], double[]>[] { new Tuple<float[], double[]>(new float[] { 1, 0 }, new double[] { 1 }), new Tuple<float[], double[]>(new float[] { 1, 1 }, new double[] { 0 }), new Tuple<float[], double[]>(new float[] { 0, 1 }, new double[] { 1 }), new Tuple<float[], double[]>(new float[] { 0, 0 }, new double[] { 0 }) }, 1000, 0.1f);
            Assert.AreEqual(1D, nn.Activate(new float[] { 0f, 1f })[0], 0.2);
        }
    }
}