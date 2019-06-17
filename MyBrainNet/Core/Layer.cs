using System.Collections.Generic;

namespace MyBrainNet.Core
{
    public class Layer : ILayer
    {
        public Neuron[] Neurons { get => neurons;  set => neurons = value; }
        private Neuron[] neurons;

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

        public void Propagate(ref Layer ProjectedLayer)
        {
            foreach (Neuron neuron in Neurons)
                neuron.ProjectConnections(ref ProjectedLayer.neurons);
        }

        private void InitNeuron(int NeuronNumber,int ConnectionsCount)
        {
            Neurons = new Neuron[NeuronNumber];
            for (int i = 0; i < NeuronNumber; i++)
                Neurons[i] = new Neuron(ConnectionsCount);
        }
    }
}
