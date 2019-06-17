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
    public class LayerTests
    {
        [TestMethod()]
        public void PropagateTest()
        {
            Layer layer1 = new Layer(new Neuron[] { new Neuron(2), new Neuron(2), new Neuron(2) });
            Neuron[] neurons2 = new Neuron[] { new Neuron(0.2D), new Neuron(0.3D) };

            layer1.Propagate(ref neurons2);
            Assert.AreNotEqual(0, neurons2[0].Value);
            Assert.AreNotEqual(0, neurons2[1].Value);
        }

        [TestMethod()]
        public void LayerTest()
        {
            Layer l1 = new Layer(3, 2);
            Assert.AreNotEqual(0, l1.Neurons[0].Bias);
            Assert.AreNotEqual(0, l1.Neurons[1].Bias);
            Assert.AreNotEqual(0, l1.Neurons[2].Bias);
        }

        [TestMethod()]
        public void PropagateTest1()
        {
            Layer layer1 = new Layer(new Neuron[] { new Neuron(2), new Neuron(2), new Neuron(2) });
            Layer layer2 = new Layer(new Neuron[] { new Neuron(0.2D), new Neuron(0.4D) });

            layer1.Propagate(ref layer2);
            Assert.AreNotEqual(0, layer2.Neurons[0].Value);
            Assert.AreNotEqual(0, layer2.Neurons[1].Value);
        }
    }
}