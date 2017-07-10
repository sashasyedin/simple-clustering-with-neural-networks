namespace Network
{
    using System;

    public class Pattern
    {
        private double[] inputs;
        private double output;

        public Pattern(string value, int inputSize)
        {
            var line = value.Split(' ');

            if (line.Length - 1 != inputSize)
            {
                throw new Exception("Bad data");
            }

            this.inputs = new double[inputSize];

            for (int i = 0; i < inputSize; i++)
            {
                this.inputs[i] = double.Parse(line[i]);
            }

            this.output = double.Parse(line[inputSize]);
        }

        public double[] Inputs
        {
            get
            {
                return this.inputs;
            }
        }

        public double Output
        {
            get
            {
                return this.output;
            }
        }
    }
}
