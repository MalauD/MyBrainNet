namespace MyBrainNet.Core
{
    public class NeuralNetwork
    {
        public Layer[] Layers;
        public NeuralNetwork(params int[] LayersNeurons)
        {
            Layers = new Layer[LayersNeurons.Length];
            for(int i = 0; i < Layers.Length - 1; i++)
            {
                Layers[i] = new Layer(LayersNeurons[i], LayersNeurons[i + 1]);
            }
        }
    }
}
