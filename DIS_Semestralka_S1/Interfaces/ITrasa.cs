using DIS_Semestralka_S1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Interfaces
{
    internal interface ITrasa
    {
        ICesta[] Cesty { get; }
        double VypocitajCasPrejazdu(Kurier kurier);
    }
}
