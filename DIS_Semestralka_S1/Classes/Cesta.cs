using DIS_Semestralka_S1.Enums;
using DIS_Semestralka_S1.Generators;
using DIS_Semestralka_S1.Generators.Components;
using DIS_Semestralka_S1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes
{
    internal class Cesta : ICesta
    {
        private int dlzka;
        private FarbaCesty farba;
        private double rychlost;
        private bool k;
        private bool kvychod;
        private RozdelenieDiskretne cervenaCesta;
        private RozdelenieSpojite zelenaCesta;
        private SpojityEmpirickyGenerator ciernaCesta;
        private DiskretnyEmpirickyGenerator modraCesta;
        private RozdelenieSpojite spomalenieK;
        public int Dlzka => dlzka;

        public FarbaCesty Farba => farba;

        public double Rychlost => rychlost;

        public bool K => k;
        public bool Kvychod => kvychod;
        bool ICesta.Kvychod { get => Kvychod; set => kvychod = value; }

        public Cesta(int dlzka, FarbaCesty farba ,bool k, bool kvychod, Random generatorGeneratorov)
        {
            this.dlzka = dlzka;
            this.farba = farba;
            this.k = k;
            this.kvychod = kvychod;
            int cervenaMin = 55;
            int cervenaMax = 75;
            cervenaCesta = new RozdelenieDiskretne(generatorGeneratorov, cervenaMin, cervenaMax + 1);
            double zelenaMin = 50;
            double zelenaMax = 80;
            zelenaCesta = new RozdelenieSpojite(generatorGeneratorov, zelenaMin, zelenaMax);
            List<double> ciernyMin = new List<double>{ 10, 20, 32, 45, 75 };
            List<double> ciernyMax = new List<double>{ 20, 32, 45, 75, 85 };
            List<double> ciernyPravdepodobnosti = new List<double>{ 0.1, 0.5, 0.2, 0.15, 0.05 };
            ciernaCesta = new SpojityEmpirickyGenerator(generatorGeneratorov, ciernyMin, ciernyMax, ciernyPravdepodobnosti);
            List<int> modryMin = new List<int>{ 15, 29, 45 };
            List<int> modryMax = new List<int>{ 29, 45, 65 };
            List<double> modryPravdepodobnosti = new List<double>{ 0.2, 0.4, 0.4 };
            modraCesta = new DiskretnyEmpirickyGenerator(generatorGeneratorov, modryMin, modryMax, modryPravdepodobnosti);
            double spomalenieKMin = 10;
            double spomalenieKMax = 25;
            spomalenieK = new RozdelenieSpojite(generatorGeneratorov, spomalenieKMin, spomalenieKMax);
        }

        public double DajCasPrejazdu()
        {
            double rychlost = this.rychlost;
            if(k && kvychod)
            {
                double spomalenie = spomalenieK.Generate();
                rychlost = rychlost * ((100-spomalenie)/100);
            }
            double cas = dlzka / rychlost * 60;
            return cas;
        }

        public void GenerujRychlost()
        {
            switch (Farba)
            {
                case FarbaCesty.CERVENA:
                    rychlost = cervenaCesta.Generate();
                    break;
                case FarbaCesty.ZELENA:
                    rychlost = zelenaCesta.Generate();
                    break;
                case FarbaCesty.CIERNA:
                    rychlost = ciernaCesta.Generate();
                    break;
                case FarbaCesty.MODRA:
                    rychlost = modraCesta.Generate();
                    break;
            }
        }
    }
}
