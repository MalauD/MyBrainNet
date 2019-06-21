using System;

namespace MyBrainNet.Core
{
    public class NeuronConnection
    {
        public NeuronConnection(double InitialWeight)
        {
            Weight = InitialWeight;
        }

        public double Weight { get; set; }
        public Guid ToID { get; set; }

        public void Project(Guid Id,ref Neuron ProjectedNeuron, double Input)
        {
            double WeightedValue = Input * Weight;
            ProjectedNeuron.PushInput(WeightedValue);
            ProjectedNeuron.PushID(Id);
            ToID = ProjectedNeuron.id;
        }

    }
}
