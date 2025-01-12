using FluentAssertions;
using LegacyFighter.Dietary.Models;
using LegacyFighter.Dietary.Models.NewProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LegacyFighter.Dietary.Tests
{
    public class OldProductTests
    {
        public OldProductTests()
        {

        }

        [Fact]
        public async Task OldProduct_ShouldHaveProperties_WhenConstructed()
        {
            // arrange


            // act
            var product = new OldProduct(10.0m, "krótki opis","długi opis", 10);

            // assert
            product.Price.Should().HaveValue();
            product.Desc.Should().NotBeNullOrWhiteSpace();
            product.LongDesc.Should().NotBeNullOrWhiteSpace();
            product.Counter.Should().HaveValue();
        }

        [Fact]
        public async Task OldProduct_ShouldReturnDescriptions()
        {
            // arrange


            // act
            var product = new OldProduct(10.0m, "krótki opis", "długi opis", 10);

            // assert
            product.FormatDesc().Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task OldProduct_ShouldReplaceCharInDescriptions()
        {
            // arrange
            var product = new OldProduct(10.0m, "krótki opis", "długi opis", 10);

            // act
            product.ReplaceCharFromDesc("i","Ź");

            // assert
            product.FormatDesc().Should().Be("krótkŹ opŹs" + " *** " + "długŹ opŹs");
        }

        [Fact]
        public async Task OldProduct_ShouldIncrementCounter()
        {
            // arrange
            var product = new OldProduct(10.0m, "krótki opis", "długi opis", 10);

            // act
            product.IncrementCounter();

            // assert
            product.Counter.Should().Be(11);
        }

        [Fact]
        public async Task OldProduct_ShouldDecrementCounter()
        {
            // arrange
            var product = new OldProduct(10.0m, "krótki opis", "długi opis", 10);

            // act
            product.DecrementCounter();

            // assert
            product.Counter.Should().Be(9);
        }
    }
}
