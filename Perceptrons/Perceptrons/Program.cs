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

            Neuron output_neuron = new Neuron(2.3);

            neurons[0].Add_Output(output_neuron, 1);
            neurons[1].Add_Output(output_neuron, 0);
            neurons[2].Add_Output(output_neuron, 1);

            int i = 0, k = 0;
            Boolean res1 = false, res2 = false, res3 = false;
            Boolean a, b, c;

            do
            {
                res1 = res2 = res3 = false;
                neurons[0].UpdateInputValues(1);
                neurons[1].UpdateInputValues(0);
                neurons[2].UpdateInputValues(1);

                while (!(res1))
                {
                    res1 = output_neuron.Calculate();
                    if (res1 != true)
                    {
                        output_neuron.train(0, 1);
                    }
                    k++;
                }

                neurons[0].UpdateInputValues(1);
                neurons[1].UpdateInputValues(1);
                neurons[2].UpdateInputValues(0);

                while ((res2))
                {
                    res2 = output_neuron.Calculate();
                    if (res2 == true)
                    {
                        output_neuron.train(1, 0);
                    }
                    k++;
                }

                neurons[0].UpdateInputValues(0);
                neurons[1].UpdateInputValues(1);
                neurons[2].UpdateInputValues(1);

                while (!(res3))
                {
                    res3 = output_neuron.Calculate();
                    if (res3 != true)
                    {
                        output_neuron.train(0, 1);
                    }
                    k++;
                }

                neurons[0].UpdateInputValues(1);
                neurons[1].UpdateInputValues(0);
                neurons[2].UpdateInputValues(1);
                res1 = output_neuron.Calculate();
                neurons[0].UpdateInputValues(1);
                neurons[1].UpdateInputValues(1);
                neurons[2].UpdateInputValues(0);
                res2 = output_neuron.Calculate();
                neurons[0].UpdateInputValues(0);
                neurons[1].UpdateInputValues(1);
                neurons[2].UpdateInputValues(1);
                res3 = output_neuron.Calculate();
                ++i;

            } while (!res1 || res2 || !res3);

            Console.WriteLine("It took " + i + " outer loops, "+ k + " inner loops to complete the training");
            Console.WriteLine("\nResults:\n\t1) " + res1 + "\n\t2) " + res2 + "\n\t3) " + res3);



            Console.ReadKey();
        }
    }
}
