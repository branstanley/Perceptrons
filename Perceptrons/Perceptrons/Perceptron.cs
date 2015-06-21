namespace Perceptrons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    class Perceptron
    {

        /*******************************************************************
         * 
         * Perceptron Training Methods
         * 
         *******************************************************************/

        /// <summary>
        /// Suser built build the training set method
        /// </summary>
        /// <returns>The trained perceptront</returns>
        public static KeyValuePair<Neuron, List<Neuron>> user_built_perceptron()
        {
            // Initialize training set
            List<KeyValuePair<Boolean, Boolean[]>> training_set = new List<KeyValuePair<bool, bool[]>>();

            Console.WriteLine("How many neurons are in the input?");
            int size = 0;

            size = DataValidation.get_int();

            do
            {
                Boolean[] inputs = new Boolean[size];
                Boolean output;

                Console.WriteLine("All inputs should either be 0, 1, true, or false");

                for (int i = 0; i < size; ++i)
                {
                    Console.WriteLine("Input for " + i + ": ");
                    inputs[i] = DataValidation.get_boolean();
                }

                Console.WriteLine("Expected output: ");
                output = DataValidation.get_boolean();

                training_set.Add(new KeyValuePair<bool, bool[]>(output, inputs));

                Console.WriteLine("Add another training set?\ny/n");
            } while (DataValidation.yes_no());

            Console.WriteLine("What is the output neuron's activation threshold?");
            Double thresh = Double.Parse(Console.ReadLine());

            return run_training(training_set, thresh);
        } // End user_built_perceptron

        /// <summary>
        /// Provide training data based on an XML file.
        /// </summary>
        /// <param name="file">The XML File to parse</param>
        /// <returns>The trained perceptron</returns>
        public static KeyValuePair<Neuron, List<Neuron>> xml_built_perceptron(String file)
        {
            // Initialize training set
            List<KeyValuePair<Boolean, Boolean[]>> training_set = new List<KeyValuePair<bool, bool[]>>();

            // Prepare parsing of XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);

            XmlNodeList count = xmlDoc.GetElementsByTagName("number_of_input_neurons");
            int size = Convert.ToInt32(count[0].InnerXml);
            int i = 0;
            foreach (XmlNode nodeList in xmlDoc.GetElementsByTagName("training_set"))
            {
                i = 0;
                Boolean[] inputs = new Boolean[size];
                Boolean output;

                foreach (XmlNode node in nodeList)
                {
                    if (node.Name == "expected_output")
                        continue;
                    inputs[i++] = DataValidation.parseBoolean(node.InnerXml);
                }

                output = DataValidation.parseBoolean(nodeList["expected_output"].InnerXml);
                training_set.Add(new KeyValuePair<bool, bool[]>(output, inputs));
            }

            return run_training(training_set, Convert.ToDouble(xmlDoc.GetElementsByTagName("threshold")[0].InnerXml));
        } // End xml_built_perceptron

        /// <summary>
        /// Runs a given training set.
        /// </summary>
        /// <param name="set">The training set to base the training off of</param>
        /// <returns>The trained perceptron</returns>
        private static KeyValuePair<Neuron, List<Neuron>> run_training(List<KeyValuePair<Boolean, Boolean[]>> set, Double thresh = 1.8)
        {
            // Initialize the Neurons
            KeyValuePair<Neuron, List<Neuron>> perceptron = new KeyValuePair<Neuron, List<Neuron>>(new Neuron(thresh), new List<Neuron>());

            // Create all input neurons
            for (int i = 0; i < set[0].Value.Length; ++i)
            {
                Neuron new_input = new Neuron();
                new_input.Add_Output(perceptron.Key, true); // true for now, set later, whatever don't care to fix old design currently
                perceptron.Value.Add(new_input);
            }

            Boolean correctness_flag = true;
            do
            {
                // Perform training
                foreach (KeyValuePair<Boolean, Boolean[]> item in set)
                {
                    // Set all the training input values
                    for (int j = 0; j < item.Value.Length; j++)
                        perceptron.Value[j].UpdateInputValues(item.Value[j]);

                    // Train, passing the expected output value
                    perceptron.Key.train(item.Key);
                }

                //Check if all training sets still produce a correct output
                foreach (KeyValuePair<Boolean, Boolean[]> item in set)
                {
                    // Set all the training input values
                    for (int j = 0; j < item.Value.Length; j++)
                        perceptron.Value[j].UpdateInputValues(item.Value[j]);

                    // Check if Calculated is the same as expected
                    if (perceptron.Key.Calculate() != item.Key)
                    {
                        correctness_flag = false; // We need to do another pass through
                    }
                }

            } while (!correctness_flag);

            return perceptron;  // Return our trained perceptron
        } // End run_training

        /*******************************************************************
         * 
         * Running the Perceptron
         * 
         *******************************************************************/

        /// <summary>
        /// Allows the user to input values and see what the output is based on the given perceptron
        /// </summary>
        /// <param name="perceptron">The perceptron for the user to check inputs and their respective outputs</param>
        public static void run(KeyValuePair<Neuron, List<Neuron>> perceptron)
        {
            do
            {
                foreach (Neuron temp in perceptron.Value)
                {
                    Console.WriteLine("Give an Input of 0, 1, true, or false: ");
                    temp.UpdateInputValues(DataValidation.get_boolean());
                }
                Console.WriteLine("Output value of: " + perceptron.Key.Calculate());
                Console.WriteLine("Continue?  y/n");
            } while (DataValidation.yes_no());
        }

    }
}
