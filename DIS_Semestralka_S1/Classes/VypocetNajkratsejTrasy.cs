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
        String[] trasy = new string[] { "Divinka - Rajec - Strecno", "Divinka - Strecno - Rajec", "Rajec - Divinka - Strecno", "Rajec - Strecno - Divinka", "Strecno - Rajec - Divinka", "Strecno - Divinka - Rajec" };
        Random random = new Random();
        Cesta ZilDivZelena;
        Cesta ZilDivCervena;
        Cesta ZilKCierna;
        Cesta KDivCervena;
        Cesta DivRajCierna;
        Cesta DivRajModra1;
        Cesta DivRajModra2;
        Cesta DivRajCervena1;
        Cesta DivRajCervena2;
        Cesta KRajZelena;
        Cesta ZilStrCervena1;
        Cesta ZilStrCervena2;
        Cesta ZilStrZelena;
        Cesta ZilStrCierna;
        Cesta KStrModra;
        Cesta RajStrModra1;
        Cesta RajStrModra2;
        Cesta RajStrCierna;

        Cesta[] cestyZilinaDivinka;
        Cesta[] cestyDivinkaRajTep;
        Cesta[] cestyRajTepStrecno;
        Cesta[] cestyZilinaStrecno;

        Cesta[] ZilinaDivinka1;
        Cesta[] ZilinaDivinka2;
        Cesta[] ZilinaDivinka3;

        Cesta[] DivinkaRajTep1;
        Cesta[] DivinkaRajTep2;
        Cesta[] DivinkaRajTep3;

        Cesta[] RajTepStrecno1;
        Cesta[] RajTepStrecno2;
        Cesta[] RajTepStrecno3;

        Cesta[] ZilinaStrecno1;
        Cesta[] ZilinaStrecno2;
        Cesta[] ZilinaStrecno3;

        Trasa trasaZilinaDivinka1;
        Trasa trasaZilinaDivinka2;
        Trasa trasaZilinaDivinka3;

        Trasa trasaDivinkaRajTep1;
        Trasa trasaDivinkaRajTep2;
        Trasa trasaDivinkaRajTep3;

        Trasa trasaRajTepStrecno1;
        Trasa trasaRajTepStrecno2;
        Trasa trasaRajTepStrecno3;

        Trasa trasaZilinaStrecno1;
        Trasa trasaZilinaStrecno2;
        Trasa trasaZilinaStrecno3;

        Kurier kurier;
        double priemernyCas;


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
        }

        protected override void AfterSimulation()
        {
            Console.WriteLine(360-priemernyCas);
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
            foreach (var cesta in cestyZilinaDivinka)
            {
                cesta.GenerujRychlost();
            }
            double[] casyZilinaDivinka = new double[3];
            casyZilinaDivinka[0] = trasaZilinaDivinka1.VypocitajCasPrejazdu(kurier);
            casyZilinaDivinka[1] = trasaZilinaDivinka2.VypocitajCasPrejazdu(kurier);
            casyZilinaDivinka[2] = trasaZilinaDivinka3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyZilinaDivinka.Min());
            foreach (var cesta in cestyDivinkaRajTep)
            {
                cesta.GenerujRychlost();
            }
            double[] casyDivinkaRajTep = new double[3];
            casyDivinkaRajTep[0] = trasaDivinkaRajTep1.VypocitajCasPrejazdu(kurier);
            casyDivinkaRajTep[1] = trasaDivinkaRajTep2.VypocitajCasPrejazdu(kurier);
            casyDivinkaRajTep[2] = trasaDivinkaRajTep3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyDivinkaRajTep.Min());
            foreach (var cesta in cestyRajTepStrecno)
            {
                cesta.GenerujRychlost();
            }
            double[] casyRajTepStrecno = new double[3];
            casyRajTepStrecno[0] = trasaRajTepStrecno1.VypocitajCasPrejazdu(kurier);
            casyRajTepStrecno[1] = trasaRajTepStrecno2.VypocitajCasPrejazdu(kurier);
            casyRajTepStrecno[2] = trasaRajTepStrecno3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyRajTepStrecno.Min());
            foreach (var cesta in cestyZilinaStrecno)
            {
                cesta.GenerujRychlost();
            }
            double[] casyZilinaStrecno = new double[3];
            casyZilinaStrecno[0] = trasaZilinaStrecno1.VypocitajCasPrejazdu(kurier);
            casyZilinaStrecno[1] = trasaZilinaStrecno2.VypocitajCasPrejazdu(kurier);
            casyZilinaStrecno[2] = trasaZilinaStrecno3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyZilinaStrecno.Min());
        }
    }
}
