using DIS_Semestralka_S1.Generators;
using DIS_Semestralka_S1.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1
{
    internal class Tester : MonteCarlo_Core
    {
        Random random;
        List<double> minimaSpojite;
        List<double> maximaSpojite;
        List<double> pravdepodobnostiSpojite;
        List<int> minimaDiskretne;
        List<int> maximaDiskretne;
        List<double> pravdepodobnostiDiskretne;
        int[] poctySpojite;
        SpojityEmpirickyGenerator spojityEmpirickyGenerator;
        int[] poctyDiskretne;
        DiskretnyEmpirickyGenerator diskretnyEmpirickyGenerator;
        List<int> minimaDiskretneRovnomerne;
        List<int> maximaDiskretneRovnomerne;
        List<double> pravdepodobnostiDiskretneRovnomerne;
        int[] poctyDiskretneRovnomerne;
        DiskretnyEmpirickyGenerator diskretnyRovnomernyEmpirickyGenerator;
        List<double> minimaSpojiteRovnomerne;
        List<double> maximaSpojiteRovnomerne;
        List<double> pravdepodobnostiSpojiteRovnomerne;
        int[] poctySpojiteRovnomerne;
        SpojityEmpirickyGenerator spojityRovnomernyEmpirickyGenerator;
        StringBuilder csvIndividualneSpojite;
        StringBuilder csvIndividualneDiskretne;
        StringBuilder csvIndividualneRovnomerne;
        StringBuilder csvIndividualneRovnomerneSpojite;

        public Tester() 
        {
            random = new Random();
            minimaSpojite = new List<double> { 10, 20, 32, 45, 75 };
            maximaSpojite = new List<double> { 20, 32, 45, 75, 85 };
            pravdepodobnostiSpojite = new List<double> { 0.1, 0.5, 0.2, 0.15, 0.05 };
            poctySpojite = new int[minimaSpojite.Count];
            spojityEmpirickyGenerator = new SpojityEmpirickyGenerator(random, minimaSpojite, maximaSpojite, pravdepodobnostiSpojite);
            minimaDiskretne = new List<int> { 15, 29, 45 };
            maximaDiskretne = new List<int> { 29, 45, 65 };
            pravdepodobnostiDiskretne = new List<double> { 0.2, 0.4, 0.4 };
            poctyDiskretne = new int[minimaDiskretne.Count];
            diskretnyEmpirickyGenerator = new Generators.DiskretnyEmpirickyGenerator(random, minimaDiskretne, maximaDiskretne, pravdepodobnostiDiskretne);
            minimaDiskretneRovnomerne = new List<int> { 0, 10, 20, 30, 40 }; 
            maximaDiskretneRovnomerne = new List<int> { 10, 20, 30, 40, 50 };
            pravdepodobnostiDiskretneRovnomerne = new List<double> { 0.2, 0.2, 0.2, 0.2, 0.2 };
            poctyDiskretneRovnomerne = new int[minimaDiskretneRovnomerne.Count];
            diskretnyRovnomernyEmpirickyGenerator = new Generators.DiskretnyEmpirickyGenerator(random, minimaDiskretneRovnomerne, maximaDiskretneRovnomerne, pravdepodobnostiDiskretneRovnomerne);
            minimaSpojiteRovnomerne = new List<double> { 0, 10, 20, 30, 40 };
            maximaSpojiteRovnomerne = new List<double> { 10, 20, 30, 40, 50 };
            pravdepodobnostiSpojiteRovnomerne = new List<double> { 0.2, 0.2, 0.2, 0.2, 0.2 };
            poctySpojiteRovnomerne = new int[minimaSpojiteRovnomerne.Count];
            spojityRovnomernyEmpirickyGenerator = new Generators.SpojityEmpirickyGenerator(random, minimaSpojiteRovnomerne, maximaSpojiteRovnomerne, pravdepodobnostiSpojiteRovnomerne);

            csvIndividualneSpojite = new StringBuilder();
            csvIndividualneDiskretne = new StringBuilder();
            csvIndividualneRovnomerne = new StringBuilder();
            csvIndividualneRovnomerneSpojite = new StringBuilder();
        }

        protected override void AfterReplication()
        {
            return;
        }

        protected override void AfterSimulation()
        {
            File.WriteAllText("individualne_spojite.csv", csvIndividualneSpojite.ToString());
            File.WriteAllText("individualne_diskretne.csv", csvIndividualneDiskretne.ToString());
            File.WriteAllText("individualne_rovnomerne.csv", csvIndividualneRovnomerne.ToString());
            File.WriteAllText("individualne_rovnomerne_spojite.csv", csvIndividualneRovnomerneSpojite.ToString());

            //uloz do csv

            StringBuilder csvSpojite = new StringBuilder();
            csvSpojite.AppendLine("Typ,Min,Max,Pravdepodobnost,Pocet");
            for (int i = 0; i < minimaSpojite.Count; i++)
            {
                csvSpojite.AppendLine($"Spojity,{minimaSpojite[i]},{maximaSpojite[i]},{pravdepodobnostiSpojite[i]},{poctySpojite[i]}");
            }
            StringBuilder csvDiskretne = new StringBuilder();
            csvDiskretne.AppendLine("Typ,Min,Max,Pravdepodobnost,Pocet");
            for (int i = 0; i < minimaDiskretne.Count; i++)
            {
                csvDiskretne.AppendLine($"Diskretny,{minimaDiskretne[i]},{maximaDiskretne[i]},{pravdepodobnostiDiskretne[i]},{poctyDiskretne[i]}");
            }
            StringBuilder csvDiskretneRovnomerne = new StringBuilder();
            csvDiskretneRovnomerne.AppendLine("Typ,Min,Max,Pravdepodobnost,Pocet");
            for (int i = 0; i < minimaDiskretneRovnomerne.Count; i++)
            {
                csvDiskretneRovnomerne.AppendLine($"DiskretnyRovnomerny,{minimaDiskretneRovnomerne[i]},{maximaDiskretneRovnomerne[i]},{pravdepodobnostiDiskretneRovnomerne[i]},{poctyDiskretneRovnomerne[i]}");
            }

            File.WriteAllText("spojite.csv", csvSpojite.ToString());
            File.WriteAllText("diskretne.csv", csvDiskretne.ToString());
            File.WriteAllText("diskretne_rovnomerne.csv", csvDiskretneRovnomerne.ToString());
        }

        protected override void BeforeReplication()
        {
            return;
        }

        protected override void BeforeSimulation()
        {
            csvIndividualneSpojite.AppendLine("Vysledok");
            csvIndividualneDiskretne.AppendLine("Vysledok");
            csvIndividualneRovnomerne.AppendLine("Vysledok");
            csvIndividualneRovnomerneSpojite.AppendLine("Vysledok");
        }

        protected override void DoReplication()
        {
            double spojityVysledok = spojityEmpirickyGenerator.Generate();
            int diskretnyVysledok = diskretnyEmpirickyGenerator.Generate();
            int diskretnyRovnomernyVysledok = diskretnyRovnomernyEmpirickyGenerator.Generate();
            double spojityRovnomernyVysledok = spojityRovnomernyEmpirickyGenerator.Generate();
            csvIndividualneSpojite.AppendLine($"{spojityVysledok}");
            csvIndividualneDiskretne.AppendLine($"{diskretnyVysledok}");
            csvIndividualneRovnomerne.AppendLine($"{diskretnyRovnomernyVysledok}");
            csvIndividualneRovnomerneSpojite.AppendLine($"{spojityRovnomernyVysledok}");
            for (int j = 0; j < minimaSpojite.Count; j++)
            {
                if (spojityVysledok >= minimaSpojite[j] && spojityVysledok < maximaSpojite[j])
                {
                    poctySpojite[j]++;
                }
            }
            for (int j = 0; j < minimaDiskretne.Count; j++)
            {
                if (diskretnyVysledok >= minimaDiskretne[j] && diskretnyVysledok < maximaDiskretne[j])
                {
                    poctyDiskretne[j]++;
                }
            }
            for (int j = 0; j < minimaDiskretneRovnomerne.Count; j++)
            {
                if (diskretnyRovnomernyVysledok >= minimaDiskretneRovnomerne[j] && diskretnyRovnomernyVysledok < maximaDiskretneRovnomerne[j])
                {
                    poctyDiskretneRovnomerne[j]++;
                }
            }
            for (int j = 0; j < minimaSpojiteRovnomerne.Count; j++)
            {
                if (spojityRovnomernyVysledok >= minimaSpojiteRovnomerne[j] && spojityRovnomernyVysledok < maximaSpojiteRovnomerne[j])
                {
                    poctySpojiteRovnomerne[j]++;
                }
            }
        }
    }
}
