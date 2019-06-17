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
    public class InputLayerTests
    {
        [TestMethod()]
        public void SetInputTest()
        {
            InputLayer inputLayerTest = new InputLayer(2, 3);
            inputLayerTest.SetInput(new float[] { 0.4f, 0.3f });
            Assert.AreEqual(0.4D, inputLayerTest.Neurons[0].Output,0.01);
            Assert.AreEqual(0.3D, inputLayerTest.Neurons[1].Output,0.01);
        }
    }
}