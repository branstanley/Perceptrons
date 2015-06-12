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

            int i = 0, k = 0;
            double res1 = 0, res2 = 0, res3 = 0;
            Boolean a, b, c;

            do
            {
                res1 = res2 = res3 = 0;
                while (!(res1 > 3.9999999999 && res1 < 4.000000001))
                {
                    neurons[0].UpdateInputValues(5);
                    neurons[1].UpdateInputValues(18);
                    neurons[2].UpdateInputValues(3);
                    res1 = output_neuron.Calculate();
                    if (res1 != 4)
                    {
                        output_neuron.train(res1, 4);
                    }
                    k++;
                }

                while (!(res2 > 9.9999999999 && res1 < 10.000000001))
                {
                    neurons[0].UpdateInputValues(10.2);
                    neurons[1].UpdateInputValues(-20);
                    neurons[2].UpdateInputValues(3.192);
                    res2 = output_neuron.Calculate();
                    if (res2 != 10)
                    {
                        output_neuron.train(res2, 10);
                    }
                    k++;
                }

                while (!(res3 > 91.9999999999 && res3 < 92.000000001))
                {
                    neurons[0].UpdateInputValues(11);
                    neurons[1].UpdateInputValues(-72);
                    neurons[2].UpdateInputValues(7);
                    res3 = output_neuron.Calculate();
                    if (res3 != 10)
                    {
                        output_neuron.train(res3, 92);
                    }
                    k++;
                }

                neurons[0].UpdateInputValues(5);
                neurons[1].UpdateInputValues(18);
                neurons[2].UpdateInputValues(3);
                res1 = output_neuron.Calculate();
                neurons[0].UpdateInputValues(10.2);
                neurons[1].UpdateInputValues(-20);
                neurons[2].UpdateInputValues(3.192);
                res2 = output_neuron.Calculate();
                neurons[0].UpdateInputValues(11);
                neurons[1].UpdateInputValues(-72);
                neurons[2].UpdateInputValues(7);
                res3 = output_neuron.Calculate();
                ++i;
                a = (!(res1 > 3.9999999999 && res1 < 4.000000001));
                b = (!(res2 > 9.9999999999 && res2 < 10.000000001));
                c = (!(res3 > 91.9999999999 && res3 < 92.000000001));
            } while ( a || b || c);

            Console.WriteLine("It took " + i + " outer loops, "+ k + " inner loops to complete the training with an output of " + res1);

            neurons[0].UpdateInputValues(192);
            neurons[1].UpdateInputValues(10);
            neurons[2].UpdateInputValues(-554);

            Console.WriteLine("New calculated value with these weights is: " + output_neuron.Calculate());

            Console.ReadKey();
        }
    }
}
