namespace Perceptrons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            KeyValuePair<Neuron, List<Neuron>> perceptron = run_training(build_training_set());

            Console.WriteLine("Training Complete");

            run(perceptron);

            Console.ReadKey();
        }


        /*******************************************************************
         * 
         * Perceptron Training Methods
         * 
         *******************************************************************/

        /// <summary>
        /// Prompts the user to build the training set
        /// </summary>
        /// <returns>The training set</returns>
        public static List<KeyValuePair<Boolean, Boolean[]>> build_training_set()
        {
            List<KeyValuePair<Boolean, Boolean[]>> training_set = new List<KeyValuePair<bool, bool[]>>();

            Console.WriteLine("How many neurons are in the input?");
            int size = 0;

            size = get_int();

            do
            {
                Boolean[] inputs = new Boolean[size];
                Boolean output;

                Console.WriteLine("All inputs should either be 0, 1, true, or false");

                for (int i = 0; i < size; ++i)
                {
                    Console.WriteLine("Input for " + i + ": ");
                    inputs[i] = get_boolean();
                }

                Console.WriteLine("Expected output: ");
                output = get_boolean();

                training_set.Add(new KeyValuePair<bool, bool[]>(output, inputs));

                Console.WriteLine("Add another training set?\ny/n");
            } while (yes_no());

            return training_set;
        } // End build_training_set

        /// <summary>
        /// Runs a given training set.
        /// </summary>
        /// <param name="set">The training set to base the training off of</param>
        /// <returns>The trained perceptron</returns>
        public static KeyValuePair<Neuron, List<Neuron>> run_training(List<KeyValuePair<Boolean, Boolean[]>> set)
        {
            // Initialize the Neurons
            Console.WriteLine("What is the output neuron's activation threshold?");
            Double thresh = Double.Parse(Console.ReadLine());
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
                foreach(Neuron temp in perceptron.Value){
                    Console.WriteLine("Give an Input of 0, 1, true, or false: ");
                    temp.UpdateInputValues(get_boolean());
                }
                Console.WriteLine("Output value of: " + perceptron.Key.Calculate());
                Console.WriteLine("Continue?  y/n");
            } while (yes_no());
        }

        /*******************************************************************
         * 
         * Input Data Validation Methods
         * 
         *******************************************************************/

        private static Boolean get_boolean()
        {
            while (true)
            {
                try
                {
                    String raw = Console.ReadLine();
                    if (raw == "1" || raw == "0")
                        return Convert.ToBoolean(Convert.ToInt16(raw));
                    else if (raw == "true" || raw == "false")
                        return Boolean.Parse(raw);
                    else
                        Console.WriteLine("Invalid input");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                }
            }
        }

        private static Boolean yes_no()
        {
            while (true)
            {
                try
                {
                    String raw = Console.ReadLine();
                    if (raw.ToLower() == "y" || raw.ToLower() == "yes")
                        return true;
                    else if (raw.ToLower() == "n" || raw.ToLower() == "no")
                        return false;
                    else
                        Console.WriteLine("Invalid input");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                }
            }
        }

        private static int get_int()
        {
            while (true)
            {
                try
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    return value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                }
            }
        }
    }
}
