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
        private Neuron input_neuron;
        private Neuron output_neuron;


        // Member properties
        public Boolean current_value;

        public double data
        {
            get
            {
                return weight * Convert.ToInt32(current_value);
            }
        }

        // Member Methods
        /// <summary>
        /// The constructor for training_set synapse.
        /// </summary>
        /// <param name="input">The input side neuron</param>
        /// <param name="output">The output side neuron</param>
        /// <param name="Value">The starting value at creation.</param>
        public Synapse(Neuron input, Neuron output, Boolean Value)
        {
            input_neuron = input;
            output_neuron = output;
            output_neuron.Add_Input(this);

            this.weight = 0.5;
            current_value = Value;
        }

        /// <summary>
        /// Used to train the synaptic link based on the output neuron's expected value vs the result it recieved
        /// </summary>
        /// <param name="output">The output we obtained from the output neuron</param>
        /// <param name="expected">The value we expected from the output neuron</param>
        public void train_weight(Boolean result, Boolean expected)
        {

            weight = weight + learning_rate * (Convert.ToInt32(expected) - Convert.ToInt32(result)) * Convert.ToInt32(current_value);
        }

    }
}
