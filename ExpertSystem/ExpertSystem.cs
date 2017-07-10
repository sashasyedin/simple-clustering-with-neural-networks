namespace ExpertSystem
{
    using System;

    class ExpertSystem
    {
        static void Main()
        {
            Console.Write("Training datasets: ");
            var path = @Console.ReadLine();

            Console.Write("Number of experts: ");
            var numExpertsStr = Console.ReadLine();

            try
            {
                if (!string.IsNullOrEmpty(path)
                    && int.TryParse(numExpertsStr, out int numExperts))
                {
                    // Initialize an expert system:
                    var ensemble = new Ensemble(path, numExperts);

                    Console.WriteLine("\nPress CTRL+C to stop the command");

                    while (true)
                    {
                        try
                        {
                            Console.Write("\nEnter x y: ");
                            var values = Console.ReadLine() + " 0";

                            // Run the expert system:
                            ensemble.GetAveraging(values);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid input data. Failed to execute");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
