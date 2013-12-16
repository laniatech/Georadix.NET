﻿namespace System
{
    using Georadix.Core;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines methods and properties that extend argument types.
    /// </summary>
    public static class ArgumentExtensions
    {
        #region Generic Arguments

        /// <summary>
        /// Ensures the argument is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of argument.</typeparam>
        /// <param name="arg">The argument.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="arg"/> is <see langword="null"/>.</exception>
        public static void AssertNotNull<T>(this T arg, string paramName)
            where T : class
        {
            if (arg == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Ensures the argument is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of argument.</typeparam>
        /// <param name="arg">The argument.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="arg"/> is <see langword="null"/>.</exception>
        public static void AssertNotNull<T>(this T? arg, string paramName)
            where T : struct
        {
            if (!arg.HasValue)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        #endregion Generic Arguments

        #region Enumerable Arguments

        /// <summary>
        /// Ensures the enumerable argument is not <see langword="null"/>, optionally checking that each item in the
        /// collection is not <see langword="null"/>.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="assertContentsNotNull">
        /// Whether to check the items in the collection for <see langword="null"/>.
        /// </param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="arg"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="assertContentsNotNull"/> is <see langword="true"/> and one of the items in the collection
        /// is <see langword="null"/>.
        /// </exception>
        public static void AssertNotNull(this IEnumerable arg, bool assertContentsNotNull, string paramName)
        {
            AssertNotNull(arg, paramName);

            if (assertContentsNotNull)
            {
                foreach (var item in arg)
                {
                    if (item == null)
                    {
                        throw new ArgumentException("An item inside the enumeration is null.", paramName);
                    }
                }
            }
        }

        /// <summary>
        /// Ensures the enumerable argument is not <see langword="null"/> or empty, optionally checking that each item
        /// in the collection is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of element in the enumeration.</typeparam>
        /// <param name="arg">The argument.</param>
        /// <param name="assertContentsNotNull">
        /// Whether to check the items in the collection for <see langword="null"/>.
        /// </param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="arg"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="arg"/> is empty.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="assertContentsNotNull"/> is <see langword="true"/> and one of the items in the collection
        /// is <see langword="null"/>.
        /// </exception>
        public static void AssertNotNullOrEmpty<T>(
            this IEnumerable<T> arg, bool assertContentsNotNull, string paramName)
        {
            AssertNotNull(arg, assertContentsNotNull, paramName);

            if (!arg.Any())
            {
                throw new ArgumentException("The enumeration is empty.", paramName);
            }
        }

        #endregion Enumerable Arguments

        #region String Arguments

        /// <summary>
        /// Ensures the string argument is not <see langword="null"/> or empty.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentException"><paramref name="arg"/> is <see langword="null"/> or empty.</exception>
        public static void AssertNotNullOrEmpty(this string arg, string paramName)
        {
            if (string.IsNullOrEmpty(arg))
            {
                throw new ArgumentException("The value cannot be null or empty.", paramName);
            }
        }

        /// <summary>
        /// Ensures the string argument is not <see langword="null"/>, empty, or consisting only of white-space
        /// characters.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="arg"/> is <see langword="null"/>, empty, or consists only of white-space characters.
        /// </exception>
        public static void AssertNotNullOrWhitespace(this string arg, string paramName)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                throw new ArgumentException(
                    "The value cannot be null, empty, or consisting only of white-space characters.", paramName);
            }
        }

        #endregion String Arguments

        #region Numeric Arguments

        /// <summary>
        /// Ensures the numeric argument is greater than a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than or equal to <paramref name="value"/>.
        /// </exception>
        public static void AssertGreaterThan(this short arg, short value, string paramName)
        {
            if (arg <= value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be greater than {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is greater than a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than or equal to <paramref name="value"/>.
        /// </exception>
        public static void AssertGreaterThan(this int arg, int value, string paramName)
        {
            if (arg <= value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be greater than {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is greater than a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than or equal to <paramref name="value"/>.
        /// </exception>
        public static void AssertGreaterThan(this double arg, double value, string paramName)
        {
            if (arg <= value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be greater than {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is greater than or equal to a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than <paramref name="value"/>.
        /// </exception>
        public static void AssertGreaterThanOrEqualTo(this short arg, short value, string paramName)
        {
            if (arg < value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be greater than or equal to {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is greater than or equal to a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than <paramref name="value"/>.
        /// </exception>
        public static void AssertGreaterThanOrEqualTo(this int arg, int value, string paramName)
        {
            if (arg < value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be greater than or equal to {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is greater than or equal to a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than <paramref name="value"/>.
        /// </exception>
        public static void AssertGreaterThanOrEqualTo(this double arg, double value, string paramName)
        {
            if (arg < value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be greater than or equal to {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is within a range of values.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than <paramref name="min"/> or greater than <paramref name="max"/>.
        /// </exception>
        public static void AssertInRange(this short arg, short min, short max, string paramName)
        {
            arg.AssertInRange(new ShortRange(min, max), paramName);
        }

        /// <summary>
        /// Ensures the numeric argument is within a range of values.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="range">The range.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is not contained by <paramref name="range"/>.
        /// </exception>
        public static void AssertInRange(this short arg, ShortRange range, string paramName)
        {
            if (!range.Contains(arg))
            {
                throw new ArgumentOutOfRangeException(
                    paramName,
                    arg,
                    string.Format("The value must be greater than {0} and less than {1}.", range.Start, range.End));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is within a range of values.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than <paramref name="min"/> or greater than <paramref name="max"/>.
        /// </exception>
        public static void AssertInRange(this int arg, int min, int max, string paramName)
        {
            arg.AssertInRange(new IntRange(min, max), paramName);
        }

        /// <summary>
        /// Ensures the numeric argument is within a range of values.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="range">The range.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is not contained by <paramref name="range"/>.
        /// </exception>
        public static void AssertInRange(this int arg, IntRange range, string paramName)
        {
            if (!range.Contains(arg))
            {
                throw new ArgumentOutOfRangeException(
                    paramName,
                    arg,
                    string.Format("The value must be greater than {0} and less than {1}.", range.Start, range.End));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is within a range of values.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is less than <paramref name="min"/> or greater than <paramref name="max"/>.
        /// </exception>
        public static void AssertInRange(this double arg, double min, double max, string paramName)
        {
            arg.AssertInRange(new DoubleRange(min, max), paramName);
        }

        /// <summary>
        /// Ensures the numeric argument is within a range of values.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="range">The range.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is not contained by <paramref name="range"/>.
        /// </exception>
        public static void AssertInRange(this double arg, DoubleRange range, string paramName)
        {
            if (!range.Contains(arg))
            {
                throw new ArgumentOutOfRangeException(
                    paramName,
                    arg,
                    string.Format("The value must be greater than {0} and less than {1}.", range.Start, range.End));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is less than a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is greater than or equal to <paramref name="value"/>.
        /// </exception>
        public static void AssertLessThan(this short arg, short value, string paramName)
        {
            if (arg >= value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be less than {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is less than a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is greater than or equal to <paramref name="value"/>.
        /// </exception>
        public static void AssertLessThan(this int arg, int value, string paramName)
        {
            if (arg >= value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be less than {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is less than a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is greater than or equal to <paramref name="value"/>.
        /// </exception>
        public static void AssertLessThan(this double arg, double value, string paramName)
        {
            if (arg >= value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be less than {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is less than or equal to a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is greater than <paramref name="value"/>.
        /// </exception>
        public static void AssertLessThanOrEqualTo(this short arg, short value, string paramName)
        {
            if (arg > value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be less than or equal to {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is less than or equal to a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is greater than <paramref name="value"/>.
        /// </exception>
        public static void AssertLessThanOrEqualTo(this int arg, int value, string paramName)
        {
            if (arg > value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be less than or equal to {0}.", value));
            }
        }

        /// <summary>
        /// Ensures the numeric argument is less than or equal to a specified value.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="arg"/> is greater than <paramref name="value"/>.
        /// </exception>
        public static void AssertLessThanOrEqualTo(this double arg, double value, string paramName)
        {
            if (arg > value)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, arg, string.Format("The value must be less than or equal to {0}.", value));
            }
        }

        #endregion Numeric Arguments
    }
}