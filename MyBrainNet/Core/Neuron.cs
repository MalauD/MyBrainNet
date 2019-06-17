using MyBrainNet.Math;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBrainNet.Core
{
    public class Neuron
    {
        public double Value { get => GetValue(); }
        public List<double> Inputs { get; set; }

        private double output { get; set; }
        public double Output { get => GetOutput(); set => output = value; }

        public double Bias { get; set; }
        public List<NeuronConnection> Connections { get; set; }

        public Neuron(double InitialBias, List<NeuronConnection> neuronConnections)
        {
            Bias = InitialBias;
            Connections = neuronConnections;
            Inputs = new List<double>();
        }

        public Neuron(double bias)
        {
            Bias = bias;
            Inputs = new List<double>();
            Connections = new List<NeuronConnection>();
        }

        public Neuron(int ConnectionsNumber)
        {
            var rdn = new Random();
            Bias = rdn.NextDouble();
            Inputs = new List<double>();
            Connections = new List<NeuronConnection>();
            for (int i = 0; i < ConnectionsNumber; i++)
                Connections.Add(new NeuronConnection(rdn.NextDouble()));
        }

        public void ProjectConnections(ref Neuron[] ProjectedNeurons)
        {
            for (int i = 0; i < Connections.Count; i++)
                Connections[i].Project(ref ProjectedNeurons[i], Output);

        }

        public void PushInput(double Input) => Inputs.Add(Input);

        private double GetValue()
         => Inputs.Sum() + Bias;

        private double GetOutput()
         => ActivationFunc.Sigmoid(Value);
    }
}
