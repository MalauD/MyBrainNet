using System;
using System.Linq;

namespace MyBrainNet.Core
{
    public class NeuralNetwork
    {
        public Layer[] Layers;
        public NeuralNetwork(params int[] LayersNeurons)
        {
            Layers = new Layer[LayersNeurons.Length];
            Layers[0] = new InputLayer(LayersNeurons[0], LayersNeurons[1]);
            for (int i = 1; i < Layers.Length - 1; i++)
            {
                Layers[i] = new Layer(LayersNeurons[i], LayersNeurons[i + 1]);
            }
            Layers[Layers.Length - 1] = new Layer(LayersNeurons[LayersNeurons.Length - 1], 0);
        }

        public double[] Activate(float[] input)
        {
            ((InputLayer)Layers[0]).SetInput(input);
            Layers[0].Propagate(ref Layers[1].GetNeurons());

            for(int i = 1; i < Layers.Length - 1; i++)
            {
                Layers[i].Propagate(ref Layers[i+1].GetNeurons());
            }
           
            return Layers[Layers.Length - 1].GetOutputs();
        }

        public void Train(Tuple<float[],double[]>[] trainingSet, int Epoch, float learningRate)
        {
            Random rnd = new Random();

            for (int i = 0; i < Epoch; i++)
            {
                Tuple<float[], double[]> DataElement = trainingSet[rnd.Next(trainingSet.Length)];
                double[] NNResult = Activate(DataElement.Item1);
                double[] NNError = NNResult.Select((elem, index) => System.Math.Pow(elem - DataElement.Item2[index], 2)).ToArray();
                double NNCost = NNError.Sum();

                for (int l = Layers.Length - 1; l > 0; l--)
                {
                    for(int n = 0; n < Layers[l].Neurons.Length; n++)
                    {
                        Layers[l].Neurons[n].Error = MyBrainNet.Math.ActivationFunc.SigmoidDerivativeOfOut(Layers[l].Neurons[n].Output) * (DataElement.Item2[n] - Layers[l].Neurons[n].Output);
                        Layers[l].Neurons[n].AdjustWeights();
                    }
                }

                double err = Layers.Last().Neurons.Last().Error;
            }
            
        }

        public void ResetConnections()
        {
            for(int i = 1; i < Layers.Length; i++)
            {
                Layers[i].ResetNeuronsConnection();
            }
        }
    }
}
