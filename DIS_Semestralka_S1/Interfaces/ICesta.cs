using DIS_Semestralka_S1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Interfaces
{
    internal interface ICesta
    {
        int Dlzka { get; }
        FarbaCesty Farba { get; }
        double Rychlost { get; }
        bool K { get; }
        bool Kvychod { get; set; }

        double DajCasPrejazdu();
        void GenerujRychlost();
    }
}
