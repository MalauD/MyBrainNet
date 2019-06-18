using System;
using System.Linq;

namespace MyBrainNet.Core
{
    public class Layer : BaseLayer
    {
        public Neuron[] Neurons { get => neurons;  set => neurons = value; }
        private Neuron[] neurons;

        public bool IsActivationEnabled { get => neurons[0].Activation; set => SetActivation(value); }

        public Layer(int NeuronCount, int ConnectionsCount) {
            InitNeuron(NeuronCount, ConnectionsCount);
        }
        public Layer(Neuron[] neurons)
        {
            Neurons = neurons;
        }

        public void Propagate(ref Neuron[] ProjectedNeurons)
        {
            foreach (Neuron neuron in Neurons)
                neuron.ProjectConnections(ref ProjectedNeurons);
        }

        [Obsolete("This method is obsolete, use with neuron array instead")]
        public void Propagate(ref Layer ProjectedLayer)
        {
            foreach (Neuron neuron in Neurons)
            {
                neuron.ProjectConnections(ref ProjectedLayer.neurons);
            }  
        }

        public override void InitNeuron(int NeuronCount, int ConnectionsCount)
        {
            Neurons = new Neuron[NeuronCount];
            for (int i = 0; i < NeuronCount; i++)
                Neurons[i] = new Neuron(ConnectionsCount);
        }

        public override void SetActivation(bool Activation)
        {
            for(int i =0; i< neurons.Length; i++)
            {
                neurons[i].Activation = Activation;
            }
        }

        public ref Neuron[] GetNeurons()
        {
            return ref neurons;
        }

        public double[] GetOutputs()
        {
            return (from Neuron n in neurons select n.Output).ToArray();
        }
    }
}
