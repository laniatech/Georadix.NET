﻿namespace Georadix.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;
    using Xunit.Extensions;

    public class GenericEqualityComparerFixture
    {
        private static IEnumerable<SubModel> sampleList = new SubModel[]
        {
            new SubModel(),
            new SubModel(dateTimeProp: DateTime.Now, intProp: new Random().Next()),
            new SubModel(new DateTime(5678901234), Enum.Third, Guid.NewGuid(), 21, "A string", new int[] { 1, 2, 3 })
        };

        private static Model sampleModel = new Model(
            DateTime.Now,
            Enum.First,
            Guid.NewGuid(),
            new Random().Next(),
            new Random().Next().ToString(),
            sampleSubModel,
            sampleList);

        private static SubModel sampleSubModel = new SubModel(
            DateTime.Now,
            Enum.Second,
            Guid.NewGuid(),
            new Random().Next(),
            new Random().Next().ToString(),
            new int[] { -987, -654, -321, 0, 123, 456, 789 });

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented",
            Justification = "No need to document this here.")]
        public enum Enum
        {
            First,
            Second,
            Third
        }

        public static IEnumerable<object[]> EqualsWithEnumerableStringsScenarios
        {
            get
            {
                return new object[][]
                {
                    new object[]
                    {
                        new string[] { "a", "b", "c" },
                        new string[] { "a", "b", "c" },
                        true
                    },
                    new object[]
                    {
                        new string[] { "a", "b", "c" },
                        new string[] { "c", "b", "a" },
                        false
                    },
                    new object[]
                    {
                        new string[] { "a", "b", "c" },
                        new string[] { "a", "b", "c", "d" },
                        false
                    },
                    new object[]
                    {
                        new string[] { "a", "b", "c" },
                        new string[] { "a", "b" },
                        false
                    }
                };
            }
        }

        public static IEnumerable<object[]> EqualsWithEnumerableSubModelsScenarios
        {
            get
            {
                return new object[][]
                {
                    new object[]
                    {
                        new SubModel[]
                        {
                            sampleSubModel,
                            new SubModel(),
                            new SubModel(dateTimeProp: new DateTime(123456), intProp: 1)
                        },
                        new SubModel[]
                        {
                            sampleSubModel,
                            new SubModel(),
                            new SubModel(dateTimeProp: new DateTime(123456), intProp: 1)
                        },
                        true
                    },
                    new object[]
                    {
                        new SubModel[]
                        {
                            sampleSubModel,
                            new SubModel(),
                            new SubModel(dateTimeProp: new DateTime(123456), intProp: 1)
                        },
                        new SubModel[]
                        {
                            new SubModel(dateTimeProp: new DateTime(123456), intProp: 1),
                            new SubModel(),
                            sampleSubModel
                        },
                        false
                    },
                    new object[]
                    {
                        new SubModel[]
                        {
                            sampleSubModel,
                            new SubModel(),
                            new SubModel(dateTimeProp: new DateTime(123456), intProp: 1)
                        },
                        new SubModel[]
                        {
                            sampleSubModel,
                            new SubModel(),
                            new SubModel(dateTimeProp: new DateTime(123456), intProp: 1),
                            new SubModel()
                        },
                        false
                    },
                    new object[]
                    {
                        new SubModel[]
                        {
                            sampleSubModel,
                            new SubModel(),
                            new SubModel(dateTimeProp: new DateTime(123456), intProp: 1)
                        },
                        new SubModel[]
                        {
                            sampleSubModel,
                            new SubModel()
                        },
                        false
                    }
                };
            }
        }

        public static IEnumerable<object[]> EqualsWithListsScenarios
        {
            get
            {
                return new object[][]
                {
                    new object[]
                    {
                        new List<int>(new int[] { 1, 2, 3 }),
                        new List<int>(new int[] { 1, 2, 3 }),
                        true
                    },
                    new object[]
                    {
                        new List<int>(new int[] { 1, 2, 3 }),
                        new List<int>(new int[] { 3, 2, 1 }),
                        false
                    },
                    new object[]
                    {
                        new List<int>(new int[] { 1, 2, 3 }),
                        new List<int>(new int[] { 1, 2, 3, 4 }),
                        false
                    },
                    new object[]
                    {
                        new List<int>(new int[] { 1, 2, 3 }),
                        new List<int>(new int[] { 1, 2 }),
                        false
                    }
                };
            }
        }

        public static IEnumerable<object[]> EqualsWithModelsScenarios
        {
            get
            {
                return new object[][]
                {
                    new object[]
                    {
                        sampleModel,
                        sampleModel,
                        true
                    },
                    new object[]
                    {
                        new Model(),
                        new Model(),
                        true
                    },
                    new object[]
                    {
                        new Model(
                            listProp: new SubModel[] { null, new SubModel() }),
                        new Model(
                            listProp: new SubModel[] { null, new SubModel() }),
                        true
                    },
                    new object[]
                    {
                        new Model(
                            new DateTime(2015, 06, 12),
                            Enum.Third,
                            new Guid("{2c623f7b-8dfe-4ed3-a1e6-90de4ff1a87f}"),
                            15,
                            "A simple string",
                            new SubModel(
                                new DateTime(1234567890),
                                Enum.Second,
                                Guid.Empty,
                                -100,
                                string.Empty,
                                new int[] { -5, 0, 5 }),
                            new SubModel[] { new SubModel(intProp: 8), new SubModel() }),
                        new Model(
                            new DateTime(2015, 06, 12),
                            Enum.Third,
                            new Guid("{2c623f7b-8dfe-4ed3-a1e6-90de4ff1a87f}"),
                            15,
                            "A simple string",
                            new SubModel(
                                new DateTime(1234567890),
                                Enum.Second,
                                Guid.Empty,
                                -100,
                                string.Empty,
                                new int[] { -5, 0, 5 }),
                            new SubModel[] { new SubModel(intProp: 8), new SubModel() }),
                        true
                    },
                    new object[]
                    {
                        null,
                        null,
                        true
                    },
                    new object[]
                    {
                        null,
                        new Model(),
                        false
                    },
                    new object[]
                    {
                        new Model(classProp: new SubModel()),
                        new Model(),
                        false
                    },
                    new object[]
                    {
                        new Model(),
                        new Model(guidProp: Guid.NewGuid()),
                        false
                    },
                    new object[]
                    {
                        new Model(classProp: new SubModel(dateTimeProp: DateTime.Now)),
                        new Model(classProp: new SubModel()),
                        false
                    },
                    new object[]
                    {
                        new Model(
                            listProp: new SubModel[] { new SubModel(intProp: 6), new SubModel() }),
                        new Model(
                            listProp: new SubModel[] { new SubModel(), new SubModel(intProp: 6) }),
                        false
                    },
                    new object[]
                    {
                        new Model(
                            listProp: new SubModel[] { new SubModel(enumProp: Enum.Second), new SubModel() }),
                        new Model(
                            listProp: new SubModel[] { new SubModel(enumProp: Enum.Third), new SubModel() }),
                        false
                    },
                    new object[]
                    {
                        new Model(
                            listProp: new SubModel[] { new SubModel(), new SubModel() }),
                        new Model(
                            listProp: new SubModel[] { new SubModel() }),
                        false
                    }
                };
            }
        }

        public static IEnumerable<object[]> EqualsWithSubModelsScenarios
        {
            get
            {
                return new object[][]
                {
                    new object[]
                    {
                        sampleSubModel,
                        sampleSubModel,
                        true
                    },
                    new object[]
                    {
                        new SubModel(),
                        new SubModel(),
                        true
                    },
                    new object[]
                    {
                        new SubModel(arrayProp: new int[] { }),
                        new SubModel(arrayProp: new int[] { }),
                        true
                    },
                    new object[]
                    {
                        new SubModel(
                            new DateTime(9876543210),
                            Enum.Third,
                            Guid.Empty,
                            999,
                            "SubModel string",
                            new int[] { 100, 200 }),
                        new SubModel(
                            new DateTime(9876543210),
                            Enum.Third,
                            Guid.Empty,
                            999,
                            "SubModel string",
                            new int[] { 100, 200 }),
                        true
                    },
                    new object[]
                    {
                        new SubModel(),
                        null,
                        false
                    },
                    new object[]
                    {
                        new SubModel(),
                        new SubModel(dateTimeProp: DateTime.Now),
                        false
                    },
                    new object[]
                    {
                        new SubModel(intProp: 10),
                        new SubModel(intProp: -10),
                        false
                    },
                    new object[]
                    {
                        new SubModel(arrayProp: new int[] { 10, 11, 12 }),
                        new SubModel(arrayProp: new int[] { 10, 11 }),
                        false
                    }
                };
            }
        }

        [Theory]
        [MemberData("EqualsWithEnumerableStringsScenarios")]
        public void EqualsWithEnumerableStringsReturnsExpectedResult(
            IEnumerable<string> x, IEnumerable<string> y, bool expected)
        {
            var sut = new GenericEqualityComparer<IEnumerable<string>>();

            Assert.Equal(expected, sut.Equals(x, y));
        }

        [Theory]
        [MemberData("EqualsWithEnumerableSubModelsScenarios")]
        public void EqualsWithEnumerableSubModelsReturnsExpectedResult(
            IEnumerable<SubModel> x, IEnumerable<SubModel> y, bool expected)
        {
            var sut = new GenericEqualityComparer<IEnumerable<SubModel>>();

            Assert.Equal(expected, sut.Equals(x, y));
        }

        [Theory]
        [InlineData(Enum.Second, Enum.Second, true)]
        [InlineData(Enum.Third, Enum.First, false)]
        public void EqualsWithEnumsReturnsExpectedResult(Enum x, Enum y, bool expected)
        {
            var sut = new GenericEqualityComparer<Enum>();

            Assert.Equal(expected, sut.Equals(x, y));
        }

        [Theory]
        [InlineData(3, 3, true)]
        [InlineData(0, 1, false)]
        public void EqualsWithIntsReturnsExpectedResult(int x, int y, bool expected)
        {
            var sut = new GenericEqualityComparer<int>();

            Assert.Equal(expected, sut.Equals(x, y));
        }

        [Theory]
        [MemberData("EqualsWithListsScenarios")]
        public void EqualsWithListsReturnsExpectedResult(List<int> x, List<int> y, bool expected)
        {
            var sut = new GenericEqualityComparer<List<int>>();

            Assert.Equal(expected, sut.Equals(x, y));
        }

        [Theory]
        [MemberData("EqualsWithModelsScenarios")]
        public void EqualsWithModelsReturnsExpectedResult(Model x, Model y, bool expected)
        {
            var sut = new GenericEqualityComparer<Model>();

            Assert.Equal(expected, sut.Equals(x, y));
        }

        [Theory]
        [InlineData("abc", "abc", true)]
        [InlineData("def", "DEF", false)]
        [InlineData("", null, false)]
        public void EqualsWithStringsReturnsExpectedResult(string x, string y, bool expected)
        {
            var sut = new GenericEqualityComparer<string>();

            Assert.Equal(expected, sut.Equals(x, y));
        }

        [Theory]
        [MemberData("EqualsWithSubModelsScenarios")]
        public void EqualsWithSubModelsReturnsExpectedResult(SubModel x, SubModel y, bool expected)
        {
            var sut = new GenericEqualityComparer<SubModel>();

            Assert.Equal(expected, sut.Equals(x, y));
        }

        [Fact]
        public void GetHashCodeForNullObjectReturnsZero()
        {
            var sut = new GenericEqualityComparer<Model>();

            Assert.Equal(0, sut.GetHashCode(null));
        }

        [Fact]
        public void GetHashCodeForValidObjectReturnsObjectHashCode()
        {
            var sut = new GenericEqualityComparer<Model>();
            var model = new Model();

            Assert.Equal(model.GetHashCode(), sut.GetHashCode(model));
        }

        public class Model
        {
            private List<SubModel> list = new List<SubModel>();

            public Model(
                DateTime? dateTimeProp = null,
                Enum enumProp = Enum.First,
                Guid guidProp = new Guid(),
                int intProp = 0,
                string stringProp = null,
                SubModel classProp = null,
                IEnumerable<SubModel> listProp = null)
            {
                this.DateTimeProp = dateTimeProp;
                this.EnumProp = enumProp;
                this.GuidProp = guidProp;
                this.IntProp = intProp;
                this.StringProp = stringProp;
                this.ClassProp = classProp;

                if (listProp != null)
                {
                    this.list.AddRange(listProp);
                }
            }

            public SubModel ClassProp { get; set; }

            public DateTime? DateTimeProp { get; private set; }

            public Enum EnumProp { get; set; }

            public Guid GuidProp { get; set; }

            public int IntProp { get; private set; }

            public IEnumerable<SubModel> ListProp
            {
                get { return this.list; }
            }

            public string StringProp { get; set; }
        }

        public class SubModel
        {
            public SubModel(
                DateTime dateTimeProp = new DateTime(),
                Enum? enumProp = null,
                Guid? guidProp = null,
                int? intProp = null,
                string stringProp = null,
                IEnumerable<int> arrayProp = null)
            {
                this.DateTimeProp = dateTimeProp;
                this.EnumProp = enumProp;
                this.GuidProp = guidProp;
                this.IntProp = intProp;
                this.StringProp = stringProp;
                this.ArrayProp = arrayProp;
            }

            public IEnumerable<int> ArrayProp { get; set; }

            public DateTime DateTimeProp { get; set; }

            public Enum? EnumProp { get; private set; }

            public Guid? GuidProp { get; private set; }

            public int? IntProp { get; set; }

            public string StringProp { get; private set; }
        }
    }
}