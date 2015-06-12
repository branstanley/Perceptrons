using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptrons
{
    public class Synapse
    {
        // Static Variables
        public double learning_rate = 0.0001;

        // Member Variables
        private double weight;
        private double current_value;
        private Neuron input_neuron;
        private Neuron output_neuron;

        // Member properties
        /// <summary>
        /// Property used to set the current value, and get the value * weight
        /// </summary>
        public double data
        {
            get
            {
                is_ready = false;
                return weight * current_value;
            }
            set
            {
                is_ready = true;
                this.current_value = value;

            }
        }

        /// <summary>
        /// Currently not used, may be used later
        /// </summary>
        public Boolean is_ready
        {
            get;
            set;
        }

        // Member Methods
        /// <summary>
        /// The constructor for a synapse.
        /// </summary>
        /// <param name="input">The input side neuron</param>
        /// <param name="output">The output side neuron</param>
        /// <param name="Value">The starting calue at creation.</param>
        public Synapse(Neuron input, Neuron output, int Value)
        {
            input_neuron = input;
            output_neuron = output;
            output_neuron.Add_Input(this);

            this.weight = 0.5;
            current_value = Value;
            is_ready = true;
        }

        /// <summary>
        /// Used to train the synaptic link based on the output neuron's expected value vs the result it recieved
        /// </summary>
        /// <param name="output">The output we obtained from the output neuron</param>
        /// <param name="expected">The value we expected from the output neuron</param>
        public void train_weight(double output, double expected)
        {
            weight = weight + learning_rate * (expected - output) * current_value;
        }

    }
}
