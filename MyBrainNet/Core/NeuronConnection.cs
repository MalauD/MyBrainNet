namespace MyBrainNet.Core
{
    public class NeuronConnection
    {
        public NeuronConnection(double InitialWeight)
        {
            Weight = InitialWeight;
        }

        public double Weight { get; set; }
        public void Project(ref Neuron ProjectedNeuron, double Input)
        {
            double WeightedValue = Input * Weight;
            ProjectedNeuron.PushInput(WeightedValue);
        }

    }
}
