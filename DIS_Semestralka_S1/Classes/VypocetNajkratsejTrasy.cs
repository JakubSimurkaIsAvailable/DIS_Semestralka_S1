using DIS_Semestralka_S1.Enums;
using DIS_Semestralka_S1.Simulation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes
{
    internal class VypocetNajkratsejTrasy : MonteCarlo_Core
    {
        protected string[] trasy = new string[] { "Divinka - Rajec - Strecno", "Divinka - Strecno - Rajec", "Rajec - Divinka - Strecno", "Rajec - Strecno - Divinka", "Strecno - Divinka - Rajec", "Strecno - Rajec - Divinka" };
        protected string aktualnaTrasa;
        protected Random random = new Random();
        protected Cesta ZilDivZelena;
        protected Cesta ZilDivCervena;
        protected Cesta ZilKCierna;
        protected Cesta KDivCervena;
        protected Cesta DivRajCierna;
        protected Cesta DivRajModra1;
        protected Cesta DivRajModra2;
        protected Cesta DivRajCervena1;
        protected Cesta DivRajCervena2;
        protected Cesta KRajZelena;
        protected Cesta ZilStrCervena1;
        protected Cesta ZilStrCervena2;
        protected Cesta ZilStrZelena;
        protected Cesta ZilStrCierna;
        protected Cesta KStrModra;
        protected Cesta RajStrModra1;
        protected Cesta RajStrModra2;
        protected Cesta RajStrCierna;

        protected Cesta[] cestyZilinaDivinka;
        protected Cesta[] cestyDivinkaRajTep;
        protected Cesta[] cestyRajTepStrecno;
        protected Cesta[] cestyZilinaStrecno;

        protected Cesta[] cestyDivinkaStrecno;
        protected Cesta[] cestyZilinaRajTep;

        protected Cesta[] ZilinaDivinka1;
        protected Cesta[] ZilinaDivinka2;
        protected Cesta[] ZilinaDivinka3;

        protected Cesta[] DivinkaRajTep1;
        protected Cesta[] DivinkaRajTep2;
        protected Cesta[] DivinkaRajTep3;

        protected Cesta[] RajTepStrecno1;
        protected Cesta[] RajTepStrecno2;
        protected Cesta[] RajTepStrecno3;

        protected Cesta[] ZilinaStrecno1;
        protected Cesta[] ZilinaStrecno2;
        protected Cesta[] ZilinaStrecno3;

        protected Trasa trasaZilinaDivinka1;
        protected Trasa trasaZilinaDivinka2;
        protected Trasa trasaZilinaDivinka3;

        protected Trasa trasaDivinkaRajTep1;
        protected Trasa trasaDivinkaRajTep2;
        protected Trasa trasaDivinkaRajTep3;

        protected Trasa trasaRajTepStrecno1;
        protected Trasa trasaRajTepStrecno2;
        protected Trasa trasaRajTepStrecno3;

        protected Trasa trasaZilinaStrecno1;
        protected Trasa trasaZilinaStrecno2;
        protected Trasa trasaZilinaStrecno3;

        protected Trasa trasaDivinkaStrecno;
        protected Trasa trasaZilinaRajTep;

        protected Kurier kurier;
        protected double priemernyCas;


        public VypocetNajkratsejTrasy()
        {
            kurier = new Kurier();
            ZilDivZelena = new Cesta(4, FarbaCesty.ZELENA, false, false, random);
            ZilDivCervena = new Cesta(4, FarbaCesty.CERVENA, false, false, random);

            ZilKCierna = new Cesta(2, FarbaCesty.CIERNA, true, false, random);
            KDivCervena = new Cesta(2, FarbaCesty.CERVENA, true, false, random);

            DivRajCierna = new Cesta(1, FarbaCesty.CIERNA, false, false, random);
            DivRajModra1 = new Cesta(1, FarbaCesty.MODRA, false, false, random);
            DivRajCervena1 = new Cesta(2, FarbaCesty.CERVENA, false, false, random);
            DivRajCervena2 = new Cesta(3, FarbaCesty.CERVENA, false, false, random);
            DivRajModra2 = new Cesta(1, FarbaCesty.MODRA, false, false, random);

            KRajZelena = new Cesta(2, FarbaCesty.ZELENA, true, false, random);

            ZilStrCervena1 = new Cesta(3, FarbaCesty.CERVENA, false, false, random);
            ZilStrCervena2 = new Cesta(4, FarbaCesty.CERVENA, false, false, random);
            ZilStrZelena = new Cesta(4, FarbaCesty.ZELENA, false, false, random);
            ZilStrCierna = new Cesta(3, FarbaCesty.CIERNA, false, false, random);

            KStrModra = new Cesta(4, FarbaCesty.MODRA, true, false, random);

            RajStrModra1 = new Cesta(8, FarbaCesty.MODRA, false, false, random);
            RajStrModra2 = new Cesta(5, FarbaCesty.MODRA, false, false, random);
            RajStrCierna = new Cesta(5, FarbaCesty.CIERNA, false, false, random);

            cestyZilinaDivinka = new Cesta[] {ZilDivZelena, ZilDivCervena, ZilKCierna, KDivCervena };
            cestyDivinkaRajTep = new Cesta[] { DivRajCierna, DivRajModra1, DivRajCervena1, DivRajCervena2, DivRajModra2, KDivCervena, KRajZelena };
            cestyRajTepStrecno = new Cesta[] { RajStrModra1, RajStrModra2, RajStrCierna, KRajZelena, KStrModra };
            cestyZilinaStrecno = new Cesta[] { ZilStrCervena1, ZilStrCervena2, ZilStrZelena, ZilStrCierna, KStrModra, ZilKCierna };

            cestyDivinkaStrecno = new Cesta[] { KDivCervena, KStrModra };
            cestyZilinaRajTep = new Cesta[] { ZilKCierna, KRajZelena };

            ZilinaDivinka1 = new Cesta[] { ZilDivZelena };
            ZilinaDivinka2 = new Cesta[] { ZilDivCervena };
            ZilinaDivinka3 = new Cesta[] { ZilKCierna, KDivCervena };

            DivinkaRajTep1 = new Cesta[] { DivRajCierna, DivRajCervena2, DivRajModra2 };
            DivinkaRajTep2 = new Cesta[] { DivRajCierna, DivRajModra1, DivRajCervena1, DivRajModra2};
            DivinkaRajTep3 = new Cesta[] { KDivCervena, KRajZelena };

            RajTepStrecno1 = new Cesta[] { RajStrModra1, RajStrModra2 };
            RajTepStrecno2 = new Cesta[] { RajStrModra1, RajStrCierna };
            RajTepStrecno3 = new Cesta[] { KRajZelena, KStrModra };

            ZilinaStrecno1 = new Cesta[] { ZilStrCervena1, ZilStrCervena2 };
            ZilinaStrecno2 = new Cesta[] { ZilStrZelena, ZilStrCierna };
            ZilinaStrecno3 = new Cesta[] { ZilKCierna, KStrModra };

            trasaZilinaDivinka1 = new Trasa(ZilinaDivinka1, "Zilina", "Divinka");
            trasaZilinaDivinka2 = new Trasa(ZilinaDivinka2, "Zilina", "Divinka");
            trasaZilinaDivinka3 = new Trasa(ZilinaDivinka3, "Zilina", "Divinka");

            trasaDivinkaRajTep1 = new Trasa(DivinkaRajTep1, "Divinka", "Rajec Teplice");
            trasaDivinkaRajTep2 = new Trasa(DivinkaRajTep2, "Divinka", "Rajec Teplice");
            trasaDivinkaRajTep3 = new Trasa(DivinkaRajTep3, "Divinka", "Rajec Teplice");

            trasaRajTepStrecno1 = new Trasa(RajTepStrecno1, "Rajec Teplice", "Strecno");
            trasaRajTepStrecno2 = new Trasa(RajTepStrecno2, "Rajec Teplice", "Strecno");
            trasaRajTepStrecno3 = new Trasa(RajTepStrecno3, "Rajec Teplice", "Strecno");

            trasaZilinaStrecno1 = new Trasa(ZilinaStrecno1, "Zilina", "Strecno");
            trasaZilinaStrecno2 = new Trasa(ZilinaStrecno2, "Zilina", "Strecno");
            trasaZilinaStrecno3 = new Trasa(ZilinaStrecno3, "Zilina", "Strecno");

            trasaDivinkaStrecno = new Trasa(cestyDivinkaStrecno, "Divinka", "Strecno");
            trasaZilinaRajTep = new Trasa(cestyZilinaRajTep, "Zilina", "Rajec Teplice");
            aktualnaTrasa = trasy[0];
        }
        //implementacia zatial iba Zilina-Divinka-Rajec Teplice-Strecno ostatne variacie pridam potom
        protected override void AfterReplication()
        {
            //po kazdej replikacii sa vypocita celkovy priemerny cas
            double cas = priemernyCas * (CurrentReplication - 1) + kurier.AkutalnyCas;
            if (cas > 0)
            {
                cas = cas / CurrentReplication;
            }
            priemernyCas = cas;

            replicationResults.Add(priemernyCas);
            ReplicationCompleted?.Invoke(this, new ReplicationEventArgs(CurrentReplication, priemernyCas, aktualnaTrasa));
        }

        protected override void AfterSimulation()
        {
            Console.WriteLine(aktualnaTrasa);
            Console.WriteLine(priemernyCas);
            Console.WriteLine();
        }

        protected override void BeforeReplication()
        {
            kurier.Vynuluj();
        }

        protected override void BeforeSimulation()
        {
            return;
        }

        protected override void DoReplication()
        {

        }
    }

    public class ReplicationEventArgs : EventArgs
    {
        public int ReplicationNumber { get; }
        public double AverageTime { get; }
        public string Route { get; }

        public ReplicationEventArgs(int replicationNumber, double averageTime, string route)
        {
            ReplicationNumber = replicationNumber;
            AverageTime = averageTime;
            Route = route;
        }
    }
}
