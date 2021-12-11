using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CellsInVaultShouldBeExactly12()
        {
            BankVault vault = new BankVault();

            Assert.AreEqual(12, vault.VaultCells.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCellDoesntExist()
        {
            BankVault vault = new BankVault();

            Assert.Throws<ArgumentException>(() => vault.AddItem("k5", new Item("Ivan", "12")));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTheCellIsAlreadyTaken()
        {
            BankVault vault = new BankVault();
            vault.AddItem("A2", new Item("Nikola", "19"));

            Assert.Throws<ArgumentException>(() => vault.AddItem("A2", new Item("Petko", "25")));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTheItemIsAlreadyPlacedInTheSameCell()
        {
            BankVault vault = new BankVault();

            Item item1 = new Item("Niko", "15");
            Item item2 = new Item("Petko", "15");

            
            Assert.AreEqual(item1.ItemId, item2.ItemId);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfTheCellDoesntExist()
        {
            BankVault vault = new BankVault();

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("Q5", new Item("Vasko", "15")));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfTheItemDoesntExistInTheCell()
        {
            BankVault vault = new BankVault();
            vault.AddItem("B4", new Item("Petko", "20"));
            var item = new Item("name", "10");

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("B4", item));
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            BankVault vault = new BankVault();
            var item = new Item("Niki", "15");

            vault.AddItem("B1", new Item("Stoyan", "10"));
            vault.AddItem("C1", item);
            vault.AddItem("A1", new Item("Svilen", "20"));

            vault.RemoveItem("C1", item);

            Assert.IsNull(vault.VaultCells["C1"]);
        }
    }
}