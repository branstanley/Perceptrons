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
            //KeyValuePair<Neuron, List<Neuron>> perceptron = Perceptron.run_training(Perceptron.user_built_perceptron());

            KeyValuePair<Neuron, List<Neuron>> perceptron = Perceptron.xml_built_perceptron("SupportFiles/training_set1.xml");

            Console.WriteLine("Training Complete");

            Perceptron.run(perceptron);

            Console.WriteLine("About to exit program.  Press Any Key to Continue.");
            Console.ReadKey();
        }

    }
}
