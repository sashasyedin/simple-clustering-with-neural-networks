namespace Network
{
    using System;
    using System.Collections.Generic;

    public class Neuron
    {
        #region Fields

        private double _bias;
        private double _error;
        private double _input;
        private double _lambda;
        private double _learnRate;
        private double _output;

        private List<Weight> _weights;

        #endregion Fields

        #region Constructors

        public Neuron()
        {
            this._lambda = 6.0;
            this._learnRate = 0.5;
            this._output = double.MinValue;
        }

        public Neuron(Layer inputs, Random rnd) : this()
        {
            this._weights = new List<Weight>();

            foreach (var input in inputs)
            {
                this._weights.Add(new Weight()
                {
                    Input = input,
                    Value = rnd.NextDouble() * 2 - 1,
                });
            }
        }

        #endregion Constructors

        public void Activate()
        {
            this._input = 0;

            foreach (var w in this._weights)
            {
                this._input += w.Value * w.Input.Output;
            }
        }

        public double ErrorFeedback(Neuron input)
        {
            var w = this._weights.Find(delegate (Weight t)
            {
                return t.Input == input;
            });

            return this._error * this.Derivative * w.Value;
        }

        public void AdjustWeights(double value)
        {
            this._error = value;

            for (int i = 0; i < this._weights.Count; i++)
            {
                this._weights[i].Value += this._error * this.Derivative * this._learnRate * this._weights[i].Input.Output;
            }

            this._bias += this._error * this.Derivative * this._learnRate;
        }

        private double Derivative
        {
            get
            {
                var activation = this.Output;
                return activation * (1 - activation);
            }
        }

        public double Output
        {
            get
            {
                if (this._output != double.MinValue)
                {
                    return this._output;
                }

                return 1 / (1 + Math.Exp(-this._lambda * (this._input + this._bias)));
            }
            set
            {
                this._output = value;
            }
        }
    }
}
