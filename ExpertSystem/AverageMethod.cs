namespace ExpertSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class AverageMethod
    {
        public static double Median(this IEnumerable<double> list)
        {
            var sorted = list
                .OrderBy(x => x)
                .ToList();

            var result = 0.0;
            var size = sorted.Count;

            if (size % 2 == 0)
            {
                var mid = size / 2;
                result = (sorted.ElementAt(mid - 1) + sorted.ElementAt(mid)) / 2;
            }
            else
            {
                var element = (double)size / 2;
                element = Math.Round(element, MidpointRounding.AwayFromZero);
                result = sorted.ElementAt((int)(element - 1));
            }

            return result;
        }
    }
}
