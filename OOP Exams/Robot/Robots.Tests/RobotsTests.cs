using System;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace Robots.Tests
{
    [TestFixture]
    public class RobotsTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void CapacityShouldNotBeLessThanZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        public void CountOfRobotsShouldBeCorrect()
        {
            RobotManager robots = new RobotManager(2);
            robots.Add(new Robot("Ivan", 10));
            robots.Add(new Robot("Petkan", 15));

            Assert.AreEqual(2, robots.Count);
        }

        [Test]
        [TestCase("Ivan", 10)]
        [TestCase("Petkan", 20)]
        [TestCase("Dragan", 30)]
        public void AddMethodShouldThrowExceptionIfTheRobotsNameAlreadyExist(string name, int maxBattery)
        {
            RobotManager robots = new RobotManager(3);

            Robot robot = new Robot(name, maxBattery);
            robots.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robots.Add(robot));
        }

        [Test]
        public void AddMethodShouldAddRobotsUntilCountIsEqualToCapacity()
        {
            RobotManager robots = new RobotManager(2);
            robots.Add(new Robot("Ivancho", 5));
            robots.Add(new Robot("Petkancho", 10));

            Assert.AreEqual(2, robots.Count);

            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("Stoyan", 100)));

        }

        [Test]
        [TestCase(null)]
        [TestCase("Petkan")]
        [TestCase("Ivan")]
        public void RemoveMethodShouldThrowExceptionIfNameDoesntExist(string name)
        {
            RobotManager robots = new RobotManager(3);
            robots.Add(new Robot("John", 10));
            robots.Add(new Robot("Jack", 10));
            robots.Add(new Robot("Nicolas", 10));

            Assert.Throws<InvalidOperationException>(() => robots.Remove(name));
        }

        [Test]
        public void RemoveMethodShouldRemoveRobotsSuccessful()
        {
            RobotManager robots = new RobotManager(2);
            robots.Add(new Robot("Ivan", 10));
            robots.Add(new Robot("Petkan", 20));

            robots.Remove("Ivan");
            Assert.AreEqual(1, robots.Count);
        }

        [Test]
        public void WorkMethodShuldThrowExceptionWhenRobotDoesntExist()
        {
            RobotManager robots = new RobotManager(1);
            robots.Add(new Robot("name", 50));

            Assert.Throws<InvalidOperationException>(() =>
                robots.Work("Pesho", "Driving", 20));
        }

        [Test]
        [TestCase(21)]
        [TestCase(25)]
        [TestCase(50)]
        public void WorkMethodShouldThrowExceptionWhenBatteryUsageIsMoreThanRobotsBattery(int batteryUsage)
        {
            RobotManager robots = new RobotManager(1);
            robots.Add(new Robot("name", 20));

            Assert.Throws<InvalidOperationException>(() =>
                robots.Work("name", "Driving", batteryUsage));
        }

        [Test]
        public void WorkMethodShouldReduceRobotsBattery()
        {
            RobotManager robots = new RobotManager(1);
            Robot robot = new Robot("name", 100);
            robots.Add(robot);

            robots.Work(robot.Name, "cooking", 20);
            Assert.AreEqual(80, robot.Battery);
        }

        [Test]
        [TestCase(null)]
        [TestCase("Valko")]
        public void ChargeMethodShouldThrowExceptionIfNameDoesntExist(string name)
        {
            RobotManager robots = new RobotManager(2);
            robots.Add(new Robot("Ime", 20));

            Assert.Throws<InvalidOperationException>(() => robots.Charge(name));
        }

        [Test]
        public void ChargeMethodShouldWorkCorrectly()
        {
            RobotManager robots = new RobotManager(1);
            Robot robot = new Robot("name", 20);
            robots.Add(robot);
            robots.Work(robot.Name, "Driving", 10);

            Assert.True(robot.Battery == 10);
            robots.Charge(robot.Name);
            Assert.AreEqual(robot.MaximumBattery, robot.Battery);
        }
    }
}
