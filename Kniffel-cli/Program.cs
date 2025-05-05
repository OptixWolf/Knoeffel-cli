using Knoeffel_cli;

namespace Knoeffel_cli
{
    internal class Program
    {
        public static List<WuerfelBlatt> wuerfelBlattListe = new List<WuerfelBlatt>();
        public static int spielerAnzahl;
        public static int aktuellerSpieler = 0;
        public static int aktuellerZug = 0;
        public static int aktuelleRunde = 1;

        private static void Main(string[] args)
        {
            Console.Title = "Knöffel-cli von OptixWolf";

            bool loop = true;
            bool error;

            do
            {
                Console.Clear();
                error = false;

                for (int i = 0; i < 5; i++)
                {
                    WuerfelBlatt.WuerfelListe.Add(new Wuerfel(1, 6));
                }

                Console.WriteLine("Knöffel-cli");
                Console.Write("Bitte gebe an wieviele Spieler es geben soll (1-6): ");

                try
                {
                    spielerAnzahl = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    error = true;
                }

                if (!error && spielerAnzahl >= 1 && spielerAnzahl <= 6)
                {
                    loop = false;

                    for (int i = 0; i < spielerAnzahl; i++)
                    {
                        Console.Write($"\nBitte gebe den Namen für Spieler {i + 1} ein: ");
                        wuerfelBlattListe.Add(new WuerfelBlatt(Console.ReadLine()));
                    }
                }
            } while (loop);

            loop = true;

            do
            {
                Console.Clear();
                error = false;

                int spielerAnzahl = wuerfelBlattListe.Count;
                int spaltenBreite = 14;
                int werteNameBreite = 17;
                int gesamtBreite = werteNameBreite + 3 + (spielerAnzahl * (spaltenBreite + 3)); // +3 für " | "

                string linie = new string('─', gesamtBreite);
                Console.WriteLine(linie);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("{0,-" + werteNameBreite + "} | ", "Knöffel");
                Console.ResetColor();
                foreach (var blatt in wuerfelBlattListe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("{0,-" + spaltenBreite + "} | ", blatt.Playername);
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine(linie);

                void Zeile(string name, Func<WuerfelBlatt, int> selector)
                {
                    Console.Write("{0,-" + werteNameBreite + "} | ", name);
                    foreach (var blatt in wuerfelBlattListe)
                    {
                        Console.Write("{0,-" + spaltenBreite + "} | ", selector(blatt));
                    }
                    Console.WriteLine();
                }

                Zeile("Nur Einsen", w => w.NurEinsen);
                Zeile("Nur Zweien", w => w.NurZweien);
                Zeile("Nur Dreien", w => w.NurDreien);
                Zeile("Nur Vieren", w => w.NurVieren);
                Zeile("Nur Fünfen", w => w.NurFuenfen);
                Zeile("Nur Sechsen", w => w.NurSechsen);
                Console.WriteLine(linie);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Zeile("+35 bei 63 Pkt.", w => w.BonusBei63);
                Zeile("Gesamtpkt. Oben", w => w.PunktzahlOben);
                Console.ResetColor();
                Console.WriteLine(linie);
                Zeile("Dreierpasch", w => w.Dreierpasch);
                Zeile("Viererpasch", w => w.Viererpasch);
                Zeile("Full House", w => w.FullHouse);
                Zeile("Kleine Strasse", w => w.KleineStrasse);
                Zeile("Grosse Strasse", w => w.GrosseStrasse);
                Zeile("Knüller", w => w.Knueller);
                Zeile("Chance", w => w.Chance);
                Console.WriteLine(linie);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Zeile("Gesamtpkt. Unten", w => w.PunktzahlUnten);
                Zeile("Gesamtpunkte", w => w.Punktzahl);
                Console.ResetColor();

                Console.WriteLine(linie);
                Console.WriteLine();

                if(aktuelleRunde == 14)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Das Spiel ist vorbei");
                    Console.WriteLine("Zum Beenden Enter drücken");

                    Console.ResetColor();
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Aktuelle Runde: {aktuelleRunde}/13");
                    Console.Write($"Aktuelle Spieler: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(wuerfelBlattListe[aktuellerSpieler].Playername);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Anzahl Würfe: {aktuellerZug}/3");
                    Console.WriteLine();
                    Console.ResetColor();

                    for (int i = 0; i < 5; i++)
                    {
                        if (WuerfelBlatt.WuerfelListe[i].Ausgewaehlt == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        Console.Write($"Würfel-{i + 1}: {WuerfelBlatt.WuerfelListe[i].Augenzahl}\t");

                        Console.ResetColor();
                    }

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("1. 1. Würfel behalten (toggle)");
                    Console.WriteLine("2. 2. Würfel behalten (toggle)");
                    Console.WriteLine("3. 3. Würfel behalten (toggle)");
                    Console.WriteLine("4. 4. Würfel behalten (toggle)");
                    Console.WriteLine("5. 5. Würfel behalten (toggle)");
                    Console.WriteLine("10. Würfeln");
                    Console.WriteLine("11. Einser Eintragen");
                    Console.WriteLine("12. Zweier Eintragen");
                    Console.WriteLine("13. Dreier Eintragen");
                    Console.WriteLine("14. Vierer Eintragen");
                    Console.WriteLine("15. Fünfer Eintragen");
                    Console.WriteLine("16. Sechser Eintragen");
                    Console.WriteLine("17. Dreierpasch Eintragen");
                    Console.WriteLine("18. Viererpasch Eintragen");
                    Console.WriteLine("19. Full House Eintragen");
                    Console.WriteLine("20. Kleine Straße Eintragen");
                    Console.WriteLine("21. Große Straße Eintragen");
                    Console.WriteLine("22. Knüller Eintragen");
                    Console.WriteLine("23. Chance Eintragen");

                    int output = 0;

                    try
                    {
                        output = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        error = true;
                    }

                    if (!error)
                    {
                        if (output >= 1 && output <= 5)
                        {
                            WuerfelBlatt.WuerfelListe[output - 1].Ausgewaehlt = !WuerfelBlatt.WuerfelListe[output - 1].Ausgewaehlt;
                        }

                        if (output == 10 && aktuellerZug != 3)
                        {
                            foreach (Wuerfel wuerfel in WuerfelBlatt.WuerfelListe)
                            {
                                wuerfel.Wuerfeln();
                            }
                            aktuellerZug++;
                        }

                        if (output >= 11 && output <= 23)
                        {
                            if (WuerfelBlatt.WuerfelListe[0].Augenzahl != 0 && WuerfelBlatt.WuerfelListe[1].Augenzahl != 0 && WuerfelBlatt.WuerfelListe[2].Augenzahl != 0 && WuerfelBlatt.WuerfelListe[3].Augenzahl != 0 && WuerfelBlatt.WuerfelListe[4].Augenzahl != 0)
                            {

                                WuerfelBlattEintrag(output - 11);

                                foreach (Wuerfel w in WuerfelBlatt.WuerfelListe)
                                {
                                    w.ResetWuerfel();
                                }

                                aktuellerZug = 0;

                                if (aktuellerSpieler + 1 == spielerAnzahl)
                                {
                                    aktuellerSpieler = 0;
                                    aktuelleRunde++;
                                }
                                else
                                {
                                    aktuellerSpieler++;
                                }
                            }
                        }
                    }
                }
            } while (loop);
        }

        private static bool WuerfelBlattEintrag(int fieldID)
        {
            switch (fieldID)
            {
                case 0:
                    if (wuerfelBlattListe[aktuellerSpieler].NurEinsen != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].NurEinsen = 69;
                    return true;

                case 1:
                    if (wuerfelBlattListe[aktuellerSpieler].NurZweien != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].NurZweien = 69;
                    return true;

                case 2:
                    if (wuerfelBlattListe[aktuellerSpieler].NurDreien != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].NurDreien = 69;
                    return true;

                case 3:
                    if (wuerfelBlattListe[aktuellerSpieler].NurVieren != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].NurVieren = 69;
                    return true;

                case 4:
                    if (wuerfelBlattListe[aktuellerSpieler].NurFuenfen != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].NurFuenfen = 69;
                    return true;

                case 5:
                    if (wuerfelBlattListe[aktuellerSpieler].NurSechsen != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].NurSechsen = 69;
                    return true;

                case 6:
                    if (wuerfelBlattListe[aktuellerSpieler].Dreierpasch != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].Dreierpasch = 69;
                    return true;

                case 7:
                    if (wuerfelBlattListe[aktuellerSpieler].Viererpasch != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].Viererpasch = 69;
                    return true;

                case 8:
                    if (wuerfelBlattListe[aktuellerSpieler].FullHouse != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].FullHouse = 69;
                    return true;

                case 9:
                    if (wuerfelBlattListe[aktuellerSpieler].KleineStrasse != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].KleineStrasse = 69;
                    return true;

                case 10:
                    if (wuerfelBlattListe[aktuellerSpieler].GrosseStrasse != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].GrosseStrasse = 69;
                    return true;

                case 11:
                    if (wuerfelBlattListe[aktuellerSpieler].Knueller != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].Knueller = 69;
                    return true;

                case 12:
                    if (wuerfelBlattListe[aktuellerSpieler].Chance != 0)
                    {
                        return false;
                    }
                    wuerfelBlattListe[aktuellerSpieler].Chance = 69;
                    return true;
                default:
                    return false;
            }

        }
    }
}