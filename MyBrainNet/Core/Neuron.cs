using MyBrainNet.Math;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBrainNet.Core
{
    public class Neuron
    {
        public Guid id = Guid.NewGuid();
        public double Value { get => GetValue(); }
        public List<double> Inputs { get; set; }
        public List<Guid> InputsIDs { get; set; }
        private double output { get; set; }
        public double Output { get => GetOutput(); set => output = value; }
        public double Error { get; set; }

        public double Bias { get; set; }
        public List<NeuronConnection> Connections { get; set; }

        public bool Activation { get; set; }

        public Neuron() {
            id = Guid.Empty;
        }

        public Neuron(double InitialBias, List<NeuronConnection> neuronConnections)
        {
            Bias = InitialBias;
            Connections = neuronConnections;
            Inputs = new List<double>();
            InputsIDs = new List<Guid>();
            Activation = true;
        }

        public Neuron(double bias)
        {
            Bias = bias;
            Inputs = new List<double>();
            InputsIDs = new List<Guid>();
            Connections = new List<NeuronConnection>();
            Activation = true;
        }

        public Neuron(int ConnectionsNumber, bool IsInput)
        {
            var rdn = new Random();
            //get random between -1 to 1
            Bias = rdn.NextDouble() * 2 - 1;
            Inputs = new List<double>();
            InputsIDs = new List<Guid>();
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
            InputsIDs = new List<Guid>();
            Connections = new List<NeuronConnection>();
            for (int i = 0; i < ConnectionsNumber; i++)
                Connections.Add(new NeuronConnection(rdn.NextDouble()));
            Activation = true;
        }

        public void ProjectConnections(ref Neuron[] ProjectedNeurons)
        {
            for (int i = 0; i < Connections.Count; i++)
                Connections[i].Project(this.id,ref ProjectedNeurons[i], Output);

        }

        public void PushInput(double Input) => Inputs.Add(Input);

        public void PushID(Guid ID) => InputsIDs.Add(ID);

        private double GetValue()
         => Inputs.Sum() + Bias;

        private double GetOutput()
         => Activation ? ActivationFunc.Sigmoid(Value) : output;

        public NeuronConnection GetNeuronConnectionByNodeId(Guid guid)
             => (from NeuronConnection n in Connections where n.ToID == guid select n).FirstOrDefault();
       
        public void AddNeuronConnectionWeightByDestID(Guid DestID, double Weight)
        {
            for (int i = 0; i < Connections.Count; i++)
                if (Connections[i].ToID == DestID)
                    Connections[i].Weight += Weight; 
        }

        public void ResetConnections()
        {
            Inputs.Clear();
            InputsIDs.Clear();
        }

        public double GetDeltaError()
            => Error * ActivationFunc.SigmoidDerivativeOfOut(GetOutput());

        public void AdjustWeights()
        {
            for (int i = 0; i < Connections.Count; i++)
            {
                Connections[i].Weight += Error * Inputs[i];
            }
        }
    }
}
