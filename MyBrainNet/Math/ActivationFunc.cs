namespace MyBrainNet.Math
{
    public static class ActivationFunc
    {
        public static double Sigmoid(double value)
        {
            return 1.0D / (1.0D + System.Math.Exp(value));
        }

        public static double SigmoidDerivativeOfOut(double Output)
        {
            return Output * (1.0 - Output);
        }
    }
}
