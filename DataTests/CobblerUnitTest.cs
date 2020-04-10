using System;
using ExamTwoCodeQuestions.Data;
using Xunit;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        /// <summary>
        /// Exam 2
        /// </summary>
        [Fact]
        public void CobblerShouldImplementINotifyPropertyChanged()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cobbler);
        }
        /// <summary>
        /// Exam 2
        /// </summary>
        /// <param name="filling"></param>
        [Theory]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Peach)]
        public void ChangingFruitShouldInvokePropertyChangedForFruit(FruitFilling filling)
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Fruit", () =>
            {
                cobbler.Fruit = filling;
            });
        }
        /// <summary>
        /// Exam 2
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForWithIceCream()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "WithIceCream", () =>
            {
                cobbler.WithIceCream = false;
            });
        }
        /// <summary>
        /// Exam 2
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForSpeacialInstructions()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () =>
            {
                cobbler.WithIceCream = true;
            });
        }
        /// <summary>
        /// Exam 2
        /// </summary>
        [Fact]
        public void ChangingWithIceaCreamShouldInbokePropertyChangedForPrice()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Price", () =>
            {
                cobbler.WithIceCream = true;
            });
        }
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }
    }
}
