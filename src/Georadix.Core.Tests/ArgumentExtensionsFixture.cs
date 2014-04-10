﻿namespace Georadix.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Extensions;

    public class ArgumentExtensionsFixture
    {
        #region Generic Arguments

        [Fact]
        public void AssertNotNullOnClassDoesNotThrowException()
        {
            object sut = new object();

            sut.AssertNotNull("sut");
        }

        [Fact]
        public void AssertNotNullOnNullClassThrowsArgumentNullException()
        {
            object sut = null;

            var ex = Assert.Throws<ArgumentNullException>(() => sut.AssertNotNull("sut"));

            Assert.Equal("sut", ex.ParamName);
        }

        [Fact]
        public void AssertNotNullOnNullStructThrowsArgumentNullException()
        {
            int? sut = null;

            var ex = Assert.Throws<ArgumentNullException>(() => sut.AssertNotNull("sut"));

            Assert.Equal("sut", ex.ParamName);
        }

        [Fact]
        public void AssertNotNullOnStructDoesNotThrowException()
        {
            int? sut = 0;

            sut.AssertNotNull("sut");
        }

        #endregion Generic Arguments

        #region Enumerable Arguments

        [Fact]
        public void AssertNotNullExcludingContentsOnEnumerableWithNullValuesDoesNotThrowException()
        {
            var sut = new List<string>();
            sut.Add("one");
            sut.Add(null);

            sut.AssertNotNull(false, "sut");
        }

        [Fact]
        public void AssertNotNullIncludingContentsOnEnumerableWithNullValuesThrowsArgumentException()
        {
            var sut = new List<string>();
            sut.Add("one");
            sut.Add(null);

            var ex = Assert.Throws<ArgumentException>(() => sut.AssertNotNull(true, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertNotNullOnEmptyEnumerableDoesNotThrowException()
        {
            var sut = new List<string>();

            sut.AssertNotNull(true, "sut");
        }

        [Fact]
        public void AssertNotNullOnNonEmptyEnumerableDoesNotThrowException()
        {
            var sut = new List<string>();
            sut.Add("one");
            sut.Add("two");

            sut.AssertNotNull(true, "sut");
        }

        [Fact]
        public void AssertNotNullOnNullEnumerableThrowsArgumentNullException()
        {
            IEnumerable sut = null;

            var ex = Assert.Throws<ArgumentNullException>(() => sut.AssertNotNull(true, "sut"));

            Assert.Equal("sut", ex.ParamName);
        }

        [Fact]
        public void AssertNotNullOrEmptyExcludingContentsOnEnumerableWithNullValuesDoesNotThrowException()
        {
            var sut = new List<string>();
            sut.Add("one");
            sut.Add(null);

            sut.AssertNotNullOrEmpty(false, "sut");
        }

        [Fact]
        public void AssertNotNullOrEmptyIncludingContentsOnEnumerableWithNullValuesThrowsArgumentException()
        {
            var sut = new List<string>();
            sut.Add("one");
            sut.Add(null);

            var ex = Assert.Throws<ArgumentException>(() => sut.AssertNotNullOrEmpty(true, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertNotNullOrEmptyOnEmptyEnumerableThrowsArgumentException()
        {
            var sut = new List<string>();

            var ex = Assert.Throws<ArgumentException>(() => sut.AssertNotNullOrEmpty(true, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertNotNullOrEmptyOnNonEmptyEnumerableDoesNotThrowException()
        {
            var sut = new List<string>();
            sut.Add("one");
            sut.Add("two");

            sut.AssertNotNullOrEmpty(true, "sut");
        }

        [Fact]
        public void AssertNotNullOrEmptyOnNullEnumerableThrowsArgumentNullException()
        {
            IEnumerable<string> sut = null;

            var ex = Assert.Throws<ArgumentNullException>(() => sut.AssertNotNullOrEmpty(true, "sut"));

            Assert.Equal("sut", ex.ParamName);
        }

        #endregion Enumerable Arguments

        #region String Arguments

        [Fact]
        public void AssertNotNullOrEmptyOnEmptyStringThrowsArgumentException()
        {
            string sut = string.Empty;

            var ex = Assert.Throws<ArgumentException>(() => sut.AssertNotNullOrEmpty("sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertNotNullOrEmptyOnNonEmptyStringDoesNotThrowException()
        {
            string sut = "test";

            sut.AssertNotNullOrEmpty("sut");
        }

        [Fact]
        public void AssertNotNullOrEmptyOnNullStringThrowsArgumentException()
        {
            string sut = null;

            var ex = Assert.Throws<ArgumentException>(() => sut.AssertNotNullOrEmpty("sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertNotNullOrWhitespaceOnEmptyStringThrowsArgumentException()
        {
            string sut = string.Empty;

            var ex = Assert.Throws<ArgumentException>(() => sut.AssertNotNullOrWhitespace("sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertNotNullOrWhitespaceOnNonEmptyStringDoesNotThrowException()
        {
            string sut = "test";

            sut.AssertNotNullOrWhitespace("sut");
        }

        [Fact]
        public void AssertNotNullOrWhitespaceOnNullStringThrowsArgumentException()
        {
            string sut = null;

            var ex = Assert.Throws<ArgumentException>(() => sut.AssertNotNullOrWhitespace("sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertNotNullOrWhitespaceOnWhitespaceStringThrowsArgumentException()
        {
            string sut = "     ";

            var ex = Assert.Throws<ArgumentException>(() => sut.AssertNotNullOrWhitespace("sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.NotNull(ex.Message);
        }

        #endregion String Arguments

        #region Numeric Arguments

        [Fact]
        public void AssertGreaterThanOnGreaterDoubleDoesNotThrowException()
        {
            double sut = 0.2;

            sut.AssertGreaterThan(0.1, "sut");
        }

        [Fact]
        public void AssertGreaterThanOnGreaterIntegerDoesNotThrowException()
        {
            int sut = 1;

            sut.AssertGreaterThan(0, "sut");
        }

        [Fact]
        public void AssertGreaterThanOnGreaterShortDoesNotThrowException()
        {
            short sut = 1;

            sut.AssertGreaterThan(0, "sut");
        }

        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(0.1, 0.2)]
        public void AssertGreaterThanOnLesserOrEqualDoubleThrowsArgumentOutOfRangeException(double sut, double value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertGreaterThan(value, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        public void AssertGreaterThanOnLesserOrEqualIntegerThrowsArgumentOutOfRangeException(int sut, int value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertGreaterThan(value, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Theory]
        [InlineData((short)0, (short)0)]
        [InlineData((short)0, (short)1)]
        public void AssertGreaterThanOnLesserOrEqualShortThrowsArgumentOutOfRangeException(short sut, short value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertGreaterThan(value, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Theory]
        [InlineData(0.2, 0.2)]
        [InlineData(0.2, 0.1)]
        public void AssertGreaterThanOrEqualToOnGreaterOrEqualDoubleDoesNotThrowException(double sut, double value)
        {
            sut.AssertGreaterThanOrEqualTo(value, "sut");
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 0)]
        public void AssertGreaterThanOrEqualToOnGreaterOrEqualIntegerDoesNotThrowException(int sut, int value)
        {
            sut.AssertGreaterThanOrEqualTo(value, "sut");
        }

        [Theory]
        [InlineData((short)1, (short)1)]
        [InlineData((short)1, (short)0)]
        public void AssertGreaterThanOrEqualToOnGreaterOrEqualShortDoesNotThrowException(short sut, short value)
        {
            sut.AssertGreaterThanOrEqualTo(value, "sut");
        }

        [Fact]
        public void AssertGreaterThanOrEqualToOnLesserDoubleThrowsArgumentOutOfRangeException()
        {
            double sut = 0.1;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertGreaterThanOrEqualTo(0.2, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertGreaterThanOrEqualToOnLesserIntegerThrowsArgumentOutOfRangeException()
        {
            int sut = 0;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertGreaterThanOrEqualTo(1, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertGreaterThanOrEqualToOnLesserShortThrowsArgumentOutOfRangeException()
        {
            short sut = 0;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertGreaterThanOrEqualTo(1, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Theory]
        [InlineData(1.0, 1.0, 5.0)]
        [InlineData(3.0, 1.0, 5.0)]
        [InlineData(4.9, 1.0, 5.0)]
        public void AssertInRangeOnDoubleInRangeDoesNotThrowException(double sut, double min, double max)
        {
            sut.AssertInRange(min, max, "sut");
            sut.AssertInRange(Interval<double>.Bounded(min, true, max, true), "sut");
        }

        [Theory]
        [InlineData(0.9, 1.0, 5.0)]
        [InlineData(5.1, 1.0, 5.0)]
        public void AssertInRangeOnDoubleOutOfRangeThrowsArgumentOutOfRangeException(
            double sut, double min, double max)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertInRange(min, max, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);

            var ex2 = Assert.Throws<ArgumentOutOfRangeException>(() =>
                sut.AssertInRange(Interval<double>.Bounded(min, true, max, true), "sut"));

            Assert.Equal(ex.ParamName, ex2.ParamName);
            Assert.Equal(ex.ActualValue, ex2.ActualValue);
            Assert.Equal(ex.Message, ex2.Message);
        }

        [Theory]
        [InlineData(1, 1, 5)]
        [InlineData(3, 1, 5)]
        [InlineData(5, 1, 5)]
        public void AssertInRangeOnIntegerInRangeDoesNotThrowException(int sut, int min, int max)
        {
            sut.AssertInRange(min, max, "sut");
            sut.AssertInRange(Interval<int>.Bounded(min, true, max, true), "sut");
        }

        [Theory]
        [InlineData(0, 1, 5)]
        [InlineData(6, 1, 5)]
        public void AssertInRangeOnIntegerOutOfRangeThrowsArgumentOutOfRangeException(int sut, int min, int max)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertInRange(min, max, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);

            var ex2 = Assert.Throws<ArgumentOutOfRangeException>(() =>
                sut.AssertInRange(Interval<int>.Bounded(min, true, max, true), "sut"));

            Assert.Equal(ex.ParamName, ex2.ParamName);
            Assert.Equal(ex.ActualValue, ex2.ActualValue);
            Assert.Equal(ex.Message, ex2.Message);
        }

        [Theory]
        [InlineData((short)1, (short)1, (short)5)]
        [InlineData((short)3, (short)1, (short)5)]
        [InlineData((short)5, (short)1, (short)5)]
        public void AssertInRangeOnShortInRangeDoesNotThrowException(short sut, short min, short max)
        {
            sut.AssertInRange(min, max, "sut");
            sut.AssertInRange(Interval<short>.Bounded(min, true, max, true), "sut");
        }

        [Theory]
        [InlineData((short)0, (short)1, (short)5)]
        [InlineData((short)6, (short)1, (short)5)]
        public void AssertInRangeOnShortOutOfRangeThrowsArgumentOutOfRangeException(short sut, short min, short max)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertInRange(min, max, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);

            var ex2 = Assert.Throws<ArgumentOutOfRangeException>(() =>
                sut.AssertInRange(Interval<short>.Bounded(min, true, max, true), "sut"));

            Assert.Equal(ex.ParamName, ex2.ParamName);
            Assert.Equal(ex.ActualValue, ex2.ActualValue);
            Assert.Equal(ex.Message, ex2.Message);
        }

        [Fact]
        public void AssertLessThanOnGreaterDoubleDoesNotThrowException()
        {
            double sut = 0.1;

            sut.AssertLessThan(0.2, "sut");
        }

        [Fact]
        public void AssertLessThanOnGreaterIntegerDoesNotThrowException()
        {
            int sut = 0;

            sut.AssertLessThan(1, "sut");
        }

        [Theory]
        [InlineData((short)0, (short)0)]
        [InlineData((short)1, (short)0)]
        public void AssertLessThanOnGreaterOrEqualShortThrowsArgumentOutOfRangeException(short sut, short value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertLessThan(value, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(0.2, 0.1)]
        public void AssertLessThanOnLesserOrEqualDoubleThrowsArgumentOutOfRangeException(double sut, double value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertLessThan(value, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        public void AssertLessThanOnLesserOrEqualIntegerThrowsArgumentOutOfRangeException(int sut, int value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertLessThan(value, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertLessThanOnLesserShortDoesNotThrowException()
        {
            short sut = 0;

            sut.AssertLessThan(1, "sut");
        }

        [Fact]
        public void AssertLessThanOrEqualToOnGreaterDoubleThrowsArgumentOutOfRangeException()
        {
            double sut = 0.2;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertLessThanOrEqualTo(0.1, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertLessThanOrEqualToOnGreaterIntegerThrowsArgumentOutOfRangeException()
        {
            int sut = 1;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertLessThanOrEqualTo(0, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Fact]
        public void AssertLessThanOrEqualToOnGreaterShortThrowsArgumentOutOfRangeException()
        {
            short sut = 1;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.AssertLessThanOrEqualTo(0, "sut"));

            Assert.Equal("sut", ex.ParamName);
            Assert.Equal(sut, ex.ActualValue);
            Assert.NotNull(ex.Message);
        }

        [Theory]
        [InlineData(0.2, 0.2)]
        [InlineData(0.1, 0.2)]
        public void AssertLessThanOrEqualToOnLesserOrEqualDoubleDoesNotThrowException(double sut, double value)
        {
            sut.AssertLessThanOrEqualTo(value, "sut");
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 1)]
        public void AssertLessThanOrEqualToOnLesserOrEqualIntegerDoesNotThrowException(int sut, int value)
        {
            sut.AssertLessThanOrEqualTo(value, "sut");
        }

        [Theory]
        [InlineData((short)1, (short)1)]
        [InlineData((short)0, (short)1)]
        public void AssertLessThanOrEqualToOnLesserOrEqualShortDoesNotThrowException(short sut, short value)
        {
            sut.AssertLessThanOrEqualTo(value, "sut");
        }

        #endregion Numeric Arguments
    }
}