using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBrainNet.Core
{
    public sealed class InputLayer : Layer
    {

        public InputLayer(int NeuronCount, int ConnectionsCount) : base(NeuronCount,ConnectionsCount) {
            SetActivation(false);
        }

       public void SetInput(float[] NNInputs)
        {
            for(int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].Output = NNInputs[i];
            }
        }

    }
}
