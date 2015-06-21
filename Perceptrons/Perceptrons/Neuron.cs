namespace Perceptrons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Neuron
    {
        private List<Synapse> input_synapse;
        private List<Synapse> output_synapse;
        private double? threshold = null;

        public Neuron()
        {
            input_synapse = new List<Synapse>();
            output_synapse = new List<Synapse>();
        }

        public Neuron(double threshold): this()
        {
            this.threshold = threshold;
        }

        /*******************************************************************
         * 
         * Methods to create training_set synaptic link.
         * 
         *******************************************************************/

        /// <summary>
        /// Creates training_set synaptic link between two neurons, input neuron, the other the output neuron
        /// </summary>
        /// <param name="to_link">The output Neuron we're creating training_set synaptic link to</param>
        /// <param name="input">The initial input for our synaptic link</param>
        public void Add_Output(Neuron to_link, Boolean input)
        {
            output_synapse.Add(new Synapse(this, to_link, input));
        }

        /// <summary>
        /// The other end of the synaptic link created by Add Output.
        /// </summary>
        /// <param name="to_link">The input neuron we're creating training_set synaptic link with</param>
        public void Add_Input(Synapse to_link)
        {
            input_synapse.Add(to_link);
        }

        /*******************************************************************
         * 
         * Neruon input methods.
         * 
         *******************************************************************/

        public void UpdateInputValues(Boolean in_value)
        {
            foreach (Synapse s in output_synapse)
            {
                s.current_value = in_value;
            }
        }

        /*******************************************************************
         * 
         * Neuron output methods.
         * 
         *******************************************************************/

        /// <summary>
        /// Used by the output neuron to calculate the values of all input neurons.
        /// </summary>
        /// <returns>The value calculated by all the synaptic inputs</returns>
        public Boolean Calculate()
        {
            double sum = 0;
            foreach (Synapse s in input_synapse)
            {
                sum += s.data;
            }

            if (sum >= threshold)
                return true;
            else 
                return false;
        }

        /// <summary>
        /// Used for training the synaptic links.
        /// </summary>
        /// <param name="expected">The expected result</param>
        public void train(Boolean expected)
        {
            Boolean calc;
            while ((calc = Calculate()) != expected)
            {
                foreach (Synapse s in input_synapse)
                {
                    s.train_weight(calc, expected);
                }
            }
        }
    }
}
