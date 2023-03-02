using Aqua;
using NUnit.Framework;
using System;

namespace AquaTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FishConstructorShouldInicializeCorrectly()
        {
            Fish fish = new Fish("Gold", 7);

            Assert.AreEqual("Gold", fish.Type);
            Assert.AreEqual(7, fish.Price);
        }
        [Test]
        public void AquariumConstructorShouldInicializeCorrectly()
        {
            Aquarium aquarium = new Aquarium("Ball",100);

            Assert.AreEqual(100, aquarium.Capacity);
            Assert.AreEqual("Ball", aquarium.Shape);
        }
        [Test]
        public void AddMethodShoudReduceAquariumCapacity()
        {
            Aquarium aquarium = new Aquarium("Ball", 100);
            Fish fish = new Fish("Gold", 7);

            aquarium.AddFish(fish);

            Assert.AreEqual(99, aquarium.Capacity);
        }
        [Test]
        public void AddMethodShoudAddFish()
        {
            Aquarium aquarium = new Aquarium("Ball", 100);
            Fish fish = new Fish("Gold", 7);

            aquarium.AddFish(fish);

            Assert.AreEqual(1, aquarium.Fishes.Count);
        }
        [Test]
        public void AddMethodShoudAddExactliOneFish()
        {
            Aquarium aquarium = new Aquarium("Ball", 100);
            Fish fish = new Fish("Gold", 7);
            Fish fish1 = new Fish("Silver", 6);
            aquarium.AddFish(fish1);
            aquarium.AddFish(fish);

            Assert.AreEqual(2, aquarium.Fishes.Count);
        }
        [Test]
        public void AddMethodShoudThrowInvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("Ball", 0);
            Fish fish = new Fish("Gold", 7);

            Assert.Throws<InvalidOperationException>(() => aquarium.AddFish(fish));
        }
        [Test]
        public void AddMethodShoudThrowExactMessageException()
        {
            Aquarium aquarium = new Aquarium("Ball", 0);
            Fish fish = new Fish("Gold", 7);

            var ex =Assert.Throws<InvalidOperationException>(() => aquarium.AddFish(fish));

            Assert.AreEqual("Invalid operation", ex.Message);
        }
        [Test]
        public void ReportAddFishShoudPrintExactSuccessfulMessage()
        {
            Aquarium aquarium = new Aquarium("Ball", 100);
            Fish fish = new Fish("Gold", 7);

            aquarium.AddFish(fish);

            
            Assert.AreEqual("You successfully add a fish!", aquarium.ReportAddFish());
        }
        [Test]
        public void EmptyMethodShoudWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("Ball", 100);
            Fish fish = new Fish("Gold", 7);

            aquarium.AddFish(fish);
            aquarium.Empty();

            Assert.AreEqual(100, aquarium.Capacity);
        }
        [Test]
        public void EmptyMethodShoudThrowEx()
        {
            Aquarium aquarium = new Aquarium("Ball", 100);

            Assert.Throws<InvalidOperationException>(() => aquarium.Empty());
        }
        [Test]
        public void EmptyMethodShoudThrowExactEx()
        {
            Aquarium aquarium = new Aquarium("Ball", 100);

            var ex = Assert.Throws<InvalidOperationException>(() => aquarium.Empty());
            Assert.AreEqual("Aquarium is empty!", ex.Message);
        }
    }
}