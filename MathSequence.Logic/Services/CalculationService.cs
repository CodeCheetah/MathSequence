namespace MathSequence.Logic.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using MathSequence.Logic.Interfaces;

    public class CalculationService : ICalculationService
    {
        /// <summary>
        /// Calculate the Jacobsthal numbers (Integer Sequence)
        /// </summary>
        /// <returns>Returns the sequence of integers.</returns>
        public IEnumerable<int> Calculate()
        {
            var a = 2;
            var b = 1;
            var result = 0;

            yield return a;

            while (a < int.MaxValue - 1)
            {
                result = b;
                yield return result;
                result = b + (2 * a);
                a = b;
                b = result;
            }
        }

        /// <summary>
        /// Calculate the sum of sequence that are not a multiple of 5.
        /// </summary>
        /// <param name="limit">Maximum value in the sequence.</param>
        /// <returns>Returns the sum value of all sequence numbers.</returns>
        public int Sum(int limit)
        {
            var result = Calculate().Where(x => x <= limit);
            return result.Where(x => x % 5 != 0).Sum();
        }
    }
}
