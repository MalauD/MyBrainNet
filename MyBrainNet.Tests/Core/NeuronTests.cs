using MyBrainNet.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using MyBrainNet.Math;

namespace MyBrainNet.Core.Tests
{
    [TestClass()]
    public class NeuronTests
    {
        [TestMethod()]
        public void ProjectConnectionsTest()
        {
            Neuron[] testNeuronList = new Neuron[3] { new Neuron(0.3, null), new Neuron(0.5, null), new Neuron(0.7, null) };
            NeuronConnection[] testConnections = new NeuronConnection[3] { new NeuronConnection(0.2), new NeuronConnection(0.4), new NeuronConnection(0.9) };
            Neuron testNeuron = new Neuron(0.3d, new List<NeuronConnection>(testConnections));
            testNeuron.Output = 0.1;

            testNeuron.ProjectConnections(ref testNeuronList);

            Assert.AreEqual(0.38D, testNeuronList[0].Value,0.01);
            Assert.AreEqual(0.67D, testNeuronList[1].Value,0.01);
            Assert.AreEqual(1.08D, testNeuronList[2].Value, 0.01);
        }

        [TestMethod()]
        public void PushInputTest()
        {
            Neuron testNeuron = new Neuron(0.4);
            testNeuron.PushInput(0.5);
            Assert.AreEqual(0.5, testNeuron.Inputs.First());
        }

        [TestMethod()]
        public void GetValueTest()
        {
            Neuron testNeuron = new Neuron(0.4);
            testNeuron.PushInput(0.1);
            testNeuron.PushInput(0.2);
            Assert.AreEqual(0.7, testNeuron.Value, 0.01);
        }

        [TestMethod()]
        public void NeuronTest()
        {
            Neuron testNeuron = new Neuron(3);
            Assert.AreNotEqual(0, testNeuron.Bias);
            Assert.AreNotEqual(0, testNeuron.Connections[0]);
            Assert.AreEqual(3, testNeuron.Connections.Count);
        }
    }
}