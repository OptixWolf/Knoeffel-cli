using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kniffel_cli;

namespace Kniffel_cli
{
    public class WuerfelBlatt
    {
        private string playername;

        private int nurEinsen;
        private int nurZweien;
        private int nurDreien;
        private int nurVieren;
        private int nurFuenfen;
        private int nurSechsen;
        private int dreierpasch;
        private int viererpasch;
        private int fullHouse;
        private int kleineStrasse;
        private int grosseStrasse;
        private int knueller;
        private int chance;

        public static List<Wuerfel> WuerfelListe = new List<Wuerfel>();

        public WuerfelBlatt(string playername)
        {
            this.playername = playername;

            if(WuerfelListe.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    WuerfelListe.Add(new Wuerfel(1, 6));
                }
            }
        }

        public int Punktzahl
        {
            get
            {
                return (PunktzahlOben + PunktzahlUnten);
            }
        }

        public int PunktzahlOben
        {
            get { return (nurEinsen + nurZweien + nurDreien + nurVieren + nurFuenfen + nurSechsen + BonusBei63); }
        }

        public int PunktzahlUnten
        {
            get { return (dreierpasch + viererpasch + fullHouse + kleineStrasse + grosseStrasse + knueller + chance); }
        }

        public int BonusBei63
        {
            get
            {
                int obereSumme = nurEinsen + nurZweien + nurDreien + nurVieren + nurFuenfen + nurSechsen;

                if(obereSumme >= 63)
                {
                    return 35;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string Playername
        {
            get { return playername; }
        }

        public int NurEinsen
        {
            get { return nurEinsen; }
            set
            {
                nurEinsen = ZaehleAugen(1);
            }
        }

        public int NurZweien
        {
            get { return nurZweien; }
            set
            {
                nurZweien = ZaehleAugen(2);
            }
        }

        public int NurDreien
        {
            get { return nurDreien; }
            set
            {
                nurDreien = ZaehleAugen(3);
            }
        }

        public int NurVieren
        {
            get { return nurVieren; }
            set
            {
                nurVieren = ZaehleAugen(4);
            }
        }

        public int NurFuenfen
        {
            get { return nurFuenfen; }
            set
            {
                nurFuenfen = ZaehleAugen(5);
            }
        }

        public int NurSechsen
        {
            get { return nurSechsen; }
            set
            {
                nurSechsen = ZaehleAugen(6);
            }
        }

        public int Dreierpasch
        {
            get { return dreierpasch; }
            set
            {
                dreierpasch = ZaehlePasch(3);
            }
        }

        public int Viererpasch
        {
            get { return viererpasch; }
            set
            {
                viererpasch = ZaehlePasch(4);
            }
        }

        public int FullHouse
        {
            get { return fullHouse; }
            set
            {
                var haeufigkeiten = WuerfelListe
                    .GroupBy(w => w.Augenzahl)
                    .Select(g => g.Count())
                    .OrderByDescending(c => c)
                    .ToList();

                if (haeufigkeiten.SequenceEqual(new List<int> { 3, 2 }))
                {
                    fullHouse = 25;
                }
                else
                {
                    fullHouse = 0;
                }
            }
        }

        public int KleineStrasse
        {
            get { return kleineStrasse; }
            set
            {
                var werte = WuerfelListe.Select(w => w.Augenzahl).Distinct().OrderBy(n => n).ToList();

                var sequenzen = new List<List<int>> {
                    new List<int> {1,2,3,4},
                    new List<int> {2,3,4,5},
                    new List<int> {3,4,5,6}
                };

                kleineStrasse = 0;

                foreach (var seq in sequenzen)
                {
                    if (seq.All(x => werte.Contains(x)))
                        kleineStrasse = 30;
                }
            }
        }

        public int GrosseStrasse
        {
            get { return grosseStrasse; }
            set
            {
                var werte = WuerfelListe.Select(w => w.Augenzahl).Distinct().OrderBy(n => n).ToList();

                var sequenzen = new List<List<int>> {
                    new List<int> {1,2,3,4,5},
                    new List<int> {2,3,4,5,6}
                };

                grosseStrasse = 0;

                foreach (var seq in sequenzen)
                {
                    if (seq.All(x => werte.Contains(x)))
                        grosseStrasse = 40;
                }
            }
        }

        public int Knueller
        {
            get { return knueller; }
            set
            {
                bool alleGleich = true;
                int ersteZahl = WuerfelListe.First().Augenzahl;

                foreach(Wuerfel w in WuerfelListe)
                {
                    if(w.Augenzahl != ersteZahl)
                    {
                        alleGleich = false;
                    }
                }

                if(alleGleich)
                {
                    knueller = 50;
                }
                else
                {
                    knueller = 0;
                }
            }
        }

        public int Chance
        {
            get { return chance; }
            set
            {
                chance = Summe();
            }
        }

        public int ZaehleAugen(int number)
        {
            int augenSumme = 0;

            foreach(Wuerfel w in WuerfelListe)
            {
                if(w.Augenzahl == number)
                {
                    augenSumme += w.Augenzahl;
                }
            }

            return augenSumme;
        }

        public int ZaehlePasch(int number)
        {
            var sortierteListe = WuerfelListe
                    .GroupBy(w => w.Augenzahl)
                    .Select(g => g.Count());

            bool istDreierpasch = sortierteListe.Any(count => count >= 3);
            bool istViererpasch = sortierteListe.Any(count => count >= 4);

            if (number == 3 && istDreierpasch)
            {
                return Summe();
            }
            else if (number == 4 && istViererpasch)
            {
                return Summe();
            }
            else
            {
                return 0;
            }
        }

        public int Summe()
        {
            int summe = 0;

            foreach(Wuerfel w in WuerfelListe)
            {
                summe += w.Augenzahl;
            }

            return summe;
        }
    }
}
