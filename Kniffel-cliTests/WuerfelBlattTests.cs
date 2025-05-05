using Knoeffel_cli;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knoeffel_cliTests
{
    [TestClass]
    public class WuerfelBlattTests
    {
        [TestMethod]
        public void Eintragung_EinsenSpeichern()
        {
            // Arrange
            WuerfelBlatt wb = new WuerfelBlatt("Thomas");
            WuerfelBlatt.WuerfelListe[0].Augenzahl = 1;
            WuerfelBlatt.WuerfelListe[1].Augenzahl = 1;
            WuerfelBlatt.WuerfelListe[2].Augenzahl = 2;
            WuerfelBlatt.WuerfelListe[3].Augenzahl = 3;
            WuerfelBlatt.WuerfelListe[4].Augenzahl = 4;

            // Act
            wb.NurEinsen = 69;

            // Assert
            Assert.AreEqual(wb.NurEinsen, 2);
        }

        [TestMethod]
        public void Eintragung_DreierpaschSpeichern()
        {
            // Arrange
            WuerfelBlatt wb = new WuerfelBlatt("Thomas");
            WuerfelBlatt.WuerfelListe[0].Augenzahl = 4;
            WuerfelBlatt.WuerfelListe[1].Augenzahl = 4;
            WuerfelBlatt.WuerfelListe[2].Augenzahl = 4;
            WuerfelBlatt.WuerfelListe[3].Augenzahl = 2;
            WuerfelBlatt.WuerfelListe[4].Augenzahl = 2;

            // Act
            wb.Dreierpasch = 69;

            // Assert
            Assert.AreEqual(wb.Dreierpasch, 16);
        }

        [TestMethod]
        public void Eintragung_FullHouseSpeichern()
        {
            // Arrange
            WuerfelBlatt wb = new WuerfelBlatt("Thomas");
            WuerfelBlatt.WuerfelListe[0].Augenzahl = 1;
            WuerfelBlatt.WuerfelListe[1].Augenzahl = 1;
            WuerfelBlatt.WuerfelListe[2].Augenzahl = 2;
            WuerfelBlatt.WuerfelListe[3].Augenzahl = 1;
            WuerfelBlatt.WuerfelListe[4].Augenzahl = 2;

            // Act
            wb.FullHouse = 69;

            // Assert
            Assert.AreEqual(25, wb.FullHouse);
        }

        [TestMethod]
        public void Eintragung_KleineStrasseSpeichern()
        {
            // Arrange
            WuerfelBlatt wb = new WuerfelBlatt("Thomas");
            WuerfelBlatt.WuerfelListe[0].Augenzahl = 1;
            WuerfelBlatt.WuerfelListe[1].Augenzahl = 2;
            WuerfelBlatt.WuerfelListe[2].Augenzahl = 3;
            WuerfelBlatt.WuerfelListe[3].Augenzahl = 4;
            WuerfelBlatt.WuerfelListe[4].Augenzahl = 6;

            // Act
            wb.KleineStrasse = 69;

            // Assert
            Assert.AreEqual(30, wb.KleineStrasse);
        }

        [TestMethod]
        public void Eintragung_KnuellerSpeichern()
        {
            // Arrange
            WuerfelBlatt wb = new WuerfelBlatt("Thomas");
            WuerfelBlatt.WuerfelListe[0].Augenzahl = 5;
            WuerfelBlatt.WuerfelListe[1].Augenzahl = 5;
            WuerfelBlatt.WuerfelListe[2].Augenzahl = 5;
            WuerfelBlatt.WuerfelListe[3].Augenzahl = 5;
            WuerfelBlatt.WuerfelListe[4].Augenzahl = 5;

            // Act
            wb.Knueller = 69;

            // Assert
            Assert.AreEqual(50, wb.Knueller);
        }

        [TestMethod]
        public void Eintragung_ChanceSpeichern()
        {
            // Arrange
            WuerfelBlatt wb = new WuerfelBlatt("Thomas");
            WuerfelBlatt.WuerfelListe[0].Augenzahl = 6;
            WuerfelBlatt.WuerfelListe[1].Augenzahl = 3;
            WuerfelBlatt.WuerfelListe[2].Augenzahl = 1;
            WuerfelBlatt.WuerfelListe[3].Augenzahl = 2;
            WuerfelBlatt.WuerfelListe[4].Augenzahl = 3;

            // Act
            wb.Chance = 69;

            // Assert
            Assert.AreEqual(15, wb.Chance);
        }
    }
}
