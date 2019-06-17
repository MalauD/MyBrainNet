namespace MyBrainNet.Core
{
    public abstract class BaseLayer : ILayer
    {
        public abstract void InitNeuron(int NeuronNumber, int ConnectionsCount);
        public abstract void SetActivation(bool Activation);
    }
}
