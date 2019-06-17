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
    public class NeuronConnectionTests
    {
        [TestMethod()]
        public void ProjectTest()
        {
            Neuron testNeuron = new Neuron(0.5D);
            NeuronConnection testConnection = new NeuronConnection(0.2D);
            testConnection.Project(ref testNeuron, 0.4D);
            Assert.AreEqual(0.58D, testNeuron.Value, 0.1);
        }

        [TestMethod()]
        public void NeuronConnectionTest()
        {
            NeuronConnection testConnection = new NeuronConnection(0.1D);
            Assert.AreEqual(0.1D,testConnection.Weight);
        }
    }
}