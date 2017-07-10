namespace Network
{
    using System;
    using System.Collections.Generic;

    public class Network
    {
        #region Fields

        private int _hiddenDims;
        private int _inputDims;
        private int _iteration;
        private int _restartAfter;

        private Layer _hidden;
        private Layer _inputs;

        private List<string> _data;
        private List<Pattern> _patterns;

        private Neuron _output;

        private Random _rnd;

        #endregion Fields

        #region Constructors

        private Network()
        {
            this._hiddenDims = 2;
            this._inputDims = 2;
            this._restartAfter = 2000;
            this._rnd = new Random();
        }

        public Network(List<string> data) : this()
        {
            this._data = data;
            this.LoadPatterns();
            this.Initialise();
            this.Train();
        }

        #endregion Constructors

        public double Test(string values)
        {
            return Activate(new Pattern(values, this._inputDims));
        }

        private void Train()
        {
            double error;

            do
            {
                error = 0.0;

                foreach (var pattern in this._patterns)
                {
                    double delta = pattern.Output - this.Activate(pattern);
                    this.AdjustWeights(delta);
                    error += Math.Pow(delta, 2);
                }

                this._iteration++;

                if (this._iteration > this._restartAfter)
                {
                    this.Initialise();
                }
            }
            while (error > 0.1);
        }

        private double Activate(Pattern pattern)
        {
            for (int i = 0; i < pattern.Inputs.Length; i++)
            {
                this._inputs[i].Output = pattern.Inputs[i];
            }

            foreach (var neuron in this._hidden)
            {
                neuron.Activate();
            }

            this._output.Activate();
            return this._output.Output;
        }

        private void AdjustWeights(double delta)
        {
            this._output.AdjustWeights(delta);

            foreach (var neuron in this._hidden)
            {
                neuron.AdjustWeights(this._output.ErrorFeedback(neuron));
            }
        }

        private void Initialise()
        {
            this._inputs = new Layer(this._inputDims);
            this._hidden = new Layer(this._hiddenDims, this._inputs, this._rnd);
            this._output = new Neuron(this._hidden, this._rnd);
            this._iteration = 0;
        }

        private void LoadPatterns()
        {
            this._patterns = new List<Pattern>();

            foreach (var line in this._data)
            {
                this._patterns.Add(new Pattern(line, this._inputDims));
            }
        }
    }
}
