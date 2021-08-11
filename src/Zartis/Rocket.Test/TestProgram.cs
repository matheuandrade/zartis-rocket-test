using Rocket.Library;
using Rocket.Library.Models;
using System;
using Xunit;

namespace Rocket.Test
{
    public class TestProgram
    {
        [Fact]
        public void TestOkForLanding()
        {
            //Arrange
            var landindArea = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 100
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 100
                }
            };

            var platform = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 10
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 10
                }
            };

            var program = new Program(landindArea, platform);

            //Act
            var reponse = program.RocketCanLand(5, 5);

            //Assert
            Assert.Equal("ok for landing", reponse);
        }

        [Fact]
        public void TestNotOkForLanding()
        {
            //Arrange
            var landindArea = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 100
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 100
                }
            };

            var platform = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 10
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 10
                }
            };

            var program = new Program(landindArea, platform);

            //Act
            var reponse = program.RocketCanLand(16, 15);

            //Assert
            Assert.Equal("out of platform", reponse);
        }

        [Fact]
        public void TestPositionPreviouslyChecked()
        {
            //Arrange
            var landindArea = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 100
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 100
                }
            };

            var platform = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 10
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 10
                }
            };

            var program = new Program(landindArea, platform);

            //Act
            var firstReponse = program.RocketCanLand(5, 5);
            var secondReponse = program.RocketCanLand(5, 5);

            //Assert
            Assert.Equal("ok for landing", firstReponse);
            Assert.Equal("clash", secondReponse);
        }

        [Fact]
        public void TestBounderyLand()
        {
            //Arrange
            var landindArea = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 100
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 100
                }
            };

            var platform = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 10
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 10
                }
            };

            var program = new Program(landindArea, platform);

            //Act
            var firstReponse = program.RocketCanLand(3, 3);
            var secondReponse = program.RocketCanLand(2, 3);
            var thirdReponse = program.RocketCanLand(4, 3);
            var fourthReponse = program.RocketCanLand(5, 3);
            var fifthReponse = program.RocketCanLand(3, 4);
            var sixthReponse = program.RocketCanLand(2, 3);

            //Assert
            Assert.Equal("ok for landing", firstReponse);
            Assert.Equal("clash", secondReponse);
            Assert.Equal("clash", thirdReponse);
            Assert.Equal("ok for landing", fourthReponse);
            Assert.Equal("clash", fifthReponse);
            Assert.Equal("clash", sixthReponse);
        }

        [Fact]
        public void TestSimiliarPreviouslyCheckedPosition()
        {
            //Arrange
            var landindArea = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 100
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 100
                }
            };

            var platform = new Area()
            {
                CoordinateX = new Coordinate
                {
                    X = 0,
                    Y = 10
                },
                CoordinateY = new Coordinate
                {
                    X = 0,
                    Y = 10
                }
            };

            var program = new Program(landindArea, platform);

            //Act
            var firstReponse = program.RocketCanLand(7, 7);
            var secondReponse = program.RocketCanLand(7, 8);
            var thirdReponse = program.RocketCanLand(6, 7);
            var fourthReponse = program.RocketCanLand(6, 6);

            //Assert
            Assert.Equal("ok for landing", firstReponse);
            Assert.Equal("clash", secondReponse);
            Assert.Equal("clash", thirdReponse);
            Assert.Equal("clash", fourthReponse);
        }
    }
}
