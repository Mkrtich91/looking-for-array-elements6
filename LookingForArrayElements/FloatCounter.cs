using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeEnd.Length != rangeStart.Length)
            {
                throw new ArgumentException("Method throws ArgumentException in case the range start value is greater than the range end value.");
            }
            else
            {
                for (int i = 0; i < rangeEnd.Length; i++)
                {
                    if (rangeStart[i] > rangeEnd[i])
                    {
                        throw new ArgumentException("Method throws ArgumentException in case the range start value is greater than the range end value.");
                    }
                }
            }

            int count = 0;

            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < rangeStart.Length; j++)
                {
                    if (arrayToSearch[i] >= rangeStart[j] && arrayToSearch[i] <= rangeEnd[j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (startIndex < 0 || startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0 || startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentException("Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
            }

            if (rangeEnd.Length != rangeStart.Length)
            {
                throw new ArgumentException("Method throws ArgumentException in case the range start value is greater than the range end value.");
            }
            else
            {
                for (int i = 0; i < rangeEnd.Length; i++)
                {
                    if (rangeStart[i] > rangeEnd[i])
                    {
                        throw new ArgumentException("Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
                    }
                }
            }

            int endIndex = startIndex + count;
            int searchIndex = startIndex;
            int searchCount = 0;

            do
            {
                for (int j = 0; j < rangeStart.Length; j++)
                {
                    if (arrayToSearch[searchIndex] >= rangeStart[j] && arrayToSearch[searchIndex] <= rangeEnd[j])
                    {
                        searchCount++;
                        break;
                    }
                }

                searchIndex++;
            }
            while (searchIndex < endIndex);

            return searchCount;
        }
    }
}
