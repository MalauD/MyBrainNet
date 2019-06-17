namespace MyBrainNet.Core
{
    public interface ILayer
    {
        void InitNeuron(int NeuronNumber, int ConnectionsCount);
        void SetActivation(bool Activation);
    }
}
