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
            Neuron[] neurons = new Neuron[3];
            for (int j = 0; j < 3; ++j)
                neurons[j] = new Neuron();

            Neuron output_neuron = new Neuron();

            neurons[0].Add_Output(output_neuron, 5);
            neurons[1].Add_Output(output_neuron, 18);
            neurons[2].Add_Output(output_neuron, 3);

            int i = 0;
            double res1 = 0;

            while ( !(res1 > 3.99999999999999 && res1 < 4.0000000000001) )
            {
                res1 = output_neuron.Calculate();
                if (res1 != 4)
                {
                    output_neuron.train(res1, 4);
                }
                ++i;
            }

            Console.WriteLine("It took " + i + " loops to complete the training with an output of " + res1);
            Console.ReadKey();
        }
    }
}
