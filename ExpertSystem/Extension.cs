namespace ExpertSystem
{
    using System;
    using System.Collections.Generic;

    public static class Extension
    {
        public static void GetAveraging(this Ensemble ensemble, string input)
        {
            var outputs = new List<double>();

            foreach (var net in ensemble)
            {
                var output = net.Test(input);
                outputs.Add(output);
                Console.WriteLine("Class {0:0}", output);
            }

            Console.WriteLine("Average of all the predictors: {0:0}", outputs.Median());
        }
    }
}
