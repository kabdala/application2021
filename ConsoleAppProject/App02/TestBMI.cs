using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App02;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class TestBMIOutput
    {
        [TestMethod]
        public void TestLowUnderweightMetric()
        {
            //TODO: Find out how to round values
            //Thanks to StackOverflow https://stackoverflow.com/questions/35409965/c-sharp-rounding-down-to-nearest-integer
            //IT WORKS! :)

            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 45.5;
            bmi.Metres = 1.93;
            bmi.CalculateMetricBMI();

            double expectedBMI = 12;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowUnderweightImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 100;
            bmi.Feet = 6;
            bmi.Inches = 4;
            bmi.CalculateImperialBMI();

            double expectedBMI = 12;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighUnderweightMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 68.2;
            bmi.Metres = 1.93;
            bmi.CalculateMetricBMI();

            double expectedBMI = 18;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighUnderweightImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 150;
            bmi.Feet = 6;
            bmi.Inches = 4;
            bmi.CalculateImperialBMI();

            double expectedBMI = 18;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowNormalMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 45.5;
            bmi.Metres = 1.524;
            bmi.CalculateMetricBMI();

            double expectedBMI = 19;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowNormalImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 100;
            bmi.Feet = 5;
            bmi.Inches = 0;
            bmi.CalculateImperialBMI();

            double expectedBMI = 19;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighNormalMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 90.9;
            bmi.Metres = 1.93;
            bmi.CalculateMetricBMI();

            double expectedBMI = 24;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighNormalImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 200;
            bmi.Feet = 6;
            bmi.Inches = 4;
            bmi.CalculateImperialBMI();

            double expectedBMI = 24;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowOverweightMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 59.1;
            bmi.Metres = 1.524;
            bmi.CalculateMetricBMI();

            double expectedBMI = 25;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowOverweightImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 130;
            bmi.Feet = 5;
            bmi.Inches = 0;
            bmi.CalculateImperialBMI();

            double expectedBMI = 25;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighOverweightMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 97.7;
            bmi.Metres = 1.93;
            bmi.CalculateMetricBMI();

            double expectedBMI = 26;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighOverweightImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 215;
            bmi.Feet = 6;
            bmi.Inches = 4;
            bmi.CalculateImperialBMI();

            double expectedBMI = 26;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowObeseClassOneMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 70.5;
            bmi.Metres = 1.524;
            bmi.CalculateMetricBMI();

            double expectedBMI = 30;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowObeseClassOneImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 155;
            bmi.Feet = 5;
            bmi.Inches = 0;
            bmi.CalculateImperialBMI();

            double expectedBMI = 30;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighObeseClassOneMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 70.5;
            bmi.Metres = 1.524;
            bmi.CalculateMetricBMI();

            double expectedBMI = 34;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighObeseClassOneImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 155;
            bmi.Feet = 5;
            bmi.Inches = 0;
            bmi.CalculateImperialBMI();

            double expectedBMI = 34;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowObeseClassTwoMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 0;
            bmi.Metres = 0;
            bmi.CalculateMetricBMI();

            double expectedBMI = 0;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowObeseClassTwoImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 0;
            bmi.Feet = 0;
            bmi.Inches = 0;
            bmi.CalculateImperialBMI();

            double expectedBMI = 0;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighObeseClassTwoMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 0;
            bmi.Metres = 0;
            bmi.CalculateMetricBMI();

            double expectedBMI = 0;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighObeseClassTwoImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 0;
            bmi.Feet = 0;
            bmi.Inches = 0;
            bmi.CalculateImperialBMI();

            double expectedBMI = 0;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowObeseClassThreeMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 0;
            bmi.Metres = 0;
            bmi.CalculateMetricBMI();

            double expectedBMI = 0;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestLowObeseClassThreeImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 0;
            bmi.Feet = 0;
            bmi.Inches = 0;
            bmi.CalculateImperialBMI();

            double expectedBMI = 0;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighObeseClassThreeMetric()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Kilos = 0;
            bmi.Metres = 0;
            bmi.CalculateMetricBMI();

            double expectedBMI = 0;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

        [TestMethod]
        public void TestHighObeseClassThreeImperial()
        {
            // 1. Arrange
            BMI bmi = new BMI();

            // 2. Act
            bmi.Pounds = 0;
            bmi.Feet = 0;
            bmi.Inches = 0;
            bmi.CalculateImperialBMI();

            double expectedBMI = 0;

            // 3. Assert
            Assert.AreEqual(expectedBMI, Math.Floor(bmi.BMIValue));
        }

    }
}
