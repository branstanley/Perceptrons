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
            Perceptron perceptron = null;

            Console.WriteLine("Choose an option:");
            Console.WriteLine("\t1: User Input Training Set");
            Console.WriteLine("\t2: Load Training Set From XML");
            int choice = DataValidation.get_int();
            switch (choice)
            {
                case 1:
                    perceptron = new Perceptron();
                    break;
                case 2:
                    perceptron = new Perceptron("SupportFiles/training_set1.xml");
                    break;
            }

            Console.WriteLine("Training Complete");

            perceptron.run();

            Console.WriteLine("About to exit program.  Press Any Key to Continue.");
            Console.ReadKey();
        }

    }
}
