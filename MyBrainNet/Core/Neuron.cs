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

        public bool Activation { get; set; }

        public Neuron(double InitialBias, List<NeuronConnection> neuronConnections)
        {
            Bias = InitialBias;
            Connections = neuronConnections;
            Inputs = new List<double>();
            Activation = true;
        }

        public Neuron(double bias)
        {
            Bias = bias;
            Inputs = new List<double>();
            Connections = new List<NeuronConnection>();
            Activation = true;
        }

        public Neuron(int ConnectionsNumber, bool IsInput)
        {
            var rdn = new Random();
            //get random between -1 to 1
            Bias = rdn.NextDouble() * 2 - 1;
            Inputs = new List<double>();
            Connections = new List<NeuronConnection>();
            for (int i = 0; i < ConnectionsNumber; i++)
                Connections.Add(new NeuronConnection(rdn.NextDouble() * 2 -1));
            Activation = !IsInput;
        }

        public Neuron(int ConnectionsNumber)
        {
            var rdn = new Random();
            Bias = rdn.NextDouble();
            Inputs = new List<double>();
            Connections = new List<NeuronConnection>();
            for (int i = 0; i < ConnectionsNumber; i++)
                Connections.Add(new NeuronConnection(rdn.NextDouble()));
            Activation = true;
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
         => Activation ? ActivationFunc.Sigmoid(Value) : output;

    }
}
