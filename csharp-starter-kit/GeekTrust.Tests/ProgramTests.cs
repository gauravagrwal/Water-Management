using Xunit;

namespace GeekTrust.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test_CalculateTotalWaterConsumed()
        {
            // Arrange
            int amountOfCorporationWater = 270;
            int amountOfBorewellWater = 630;
            int amountOfTankerWater = 1500;
            // Act
            int actualWaterConsumed = Program.CalculateTotalWaterConsumed(amountOfCorporationWater, amountOfBorewellWater, amountOfTankerWater);
            // Assert
            int expectedWaterConsumed = 2400;
            Assert.Equal(actualWaterConsumed, expectedWaterConsumed);
        }

        [Fact]
        public void Test_CalculateCostForTankerWater()
        {
            // Arrange
            int amountOfTankerWater = 1500;
            // Act
            int actualCost = Program.CalculateCostForTankerWater(amountOfTankerWater);
            // Assert
            int expectedCost = 4000;
            Assert.Equal(actualCost, expectedCost);
        }

        [Fact]
        public void Test_CalculateCost()
        {
            // Arrange
            int amountOfCorporationWater = 270;
            int amountOfBorewellWater = 630;
            int amountOfTankerWater = 1500;
            // Act
            int actualTotalCost = Program.CalculateTotalCost(amountOfCorporationWater, amountOfBorewellWater, amountOfTankerWater);
            // Assert
            int expectedTotalCost = 5215;
            Assert.Equal(actualTotalCost, expectedTotalCost);
        }
    }
}
