using System;
using System.Globalization;
using System.Text;

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges == null || ranges.Any(r => r == null))
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            bool arrayContainsEmpty = Array.Exists(ranges, r => r is not null && r.Length == 0);

            if (ranges.Any(r => r == null || r.Length != 2) && !arrayContainsEmpty)
            {
                throw new ArgumentException("Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.");
            }
            else
            {
                int count = 0;

                for (int i = 0; i < arrayToSearch.Length; i++)
                {
                    decimal element = arrayToSearch[i];

                    for (int j = 0; j < ranges.Length; j++)
                    {
                        decimal[]? range = ranges[j];

                        if (range != null && range.Length == 2 && element >= range[0] && element <= range[1])
                        {
                            count++;
                            break;
                        }
                    }
                }

                return count;
            }
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (ranges.Any(r => r == null))
            {
                throw new ArgumentNullException(nameof(ranges), "One or more ranges are null.");
            }

            if (startIndex < 0 || startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0 || startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentException("Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
            }

            if (startIndex < 0 || count < 0 || startIndex > arrayToSearch.Length)
            {
                return 0;
            }

            int endIndex = Math.Min(startIndex + count, arrayToSearch.Length);

            int occurrences = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                decimal element = arrayToSearch[i];

                foreach (decimal[]? range in ranges)
                {
                    if (range is null)
                    {
                        continue;
                    }

                    decimal rangeStart = range[0];
                    decimal rangeEnd = range[1];

                    if (element >= rangeStart && element <= rangeEnd)
                    {
                        occurrences++;
                        break;
                    }
                }
            }

            return occurrences;
        }
    }
}
