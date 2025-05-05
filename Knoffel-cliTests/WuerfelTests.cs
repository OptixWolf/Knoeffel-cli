using Knoeffel_cli;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Knoeffel_cliTests;

[TestClass]
public class WuerfelTests
{
    [TestMethod]
    public void Wuerfel_HatEinenFunktionierendenKonstruktor()
    {
        // Arrange
        int minAugenzahl = 1;
        int maxAugenzahl = 6;

        // Act
        Wuerfel wuerfel = new Wuerfel(minAugenzahl, maxAugenzahl);

        // Arrange
        Assert.AreEqual(minAugenzahl, wuerfel.MinAugenzahl);
        Assert.AreEqual(maxAugenzahl, wuerfel.MaxAugenzahl);
    }

    [TestMethod]
    public void Wurf_GeneriertZufallszahl()
    {
        // Arrange
        Wuerfel wuerfel = new Wuerfel(1, 6);
        int[] wuerfe = new int[10];
        
        // Act
        for (int i = 0; i < 10; i++)
        {
            wuerfel.Wuerfeln();
            wuerfe[i] = wuerfel.Augenzahl;
        }

        int ersteZahl = wuerfe[0];
        bool alleGleich = true;
        
        for (int i = 0; i < 10; i++)
        {
            if (wuerfe[i] != ersteZahl)
            {
                alleGleich = false;
            }
        }

        // Assert
        Assert.IsFalse(alleGleich);
    }

    [TestMethod]
    public void Wuerfe_GenerierenKorrekteZahlen()
    {
        // Arrange
        Wuerfel wuerfel = new Wuerfel(1, 6);
        int[] wuerfe = new int[100];
        int minAugenzahl = 1;
        int maxAugenzahl = 6;

        // Act
        for (int i = 0; i < 100; i++)
        {
            wuerfel.Wuerfeln();
            wuerfe[i] = wuerfel.Augenzahl;
        }

        bool inkorrekteZahlGefunden = false;

        for (int i = 0; i < 100; i++)
        {
            if (wuerfe[i] < minAugenzahl || wuerfe[i] > maxAugenzahl)
            {
                inkorrekteZahlGefunden = true;
            }
        }

        // Assert
        Assert.IsFalse(inkorrekteZahlGefunden);
    }
}