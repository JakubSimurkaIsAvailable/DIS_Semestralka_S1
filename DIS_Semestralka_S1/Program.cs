//string[] mesta = {"Zilina", "Strecno", "Rajecke Teplice", "Divinka"};
using DIS_Semestralka_S1;
using DIS_Semestralka_S1.Classes;
using DIS_Semestralka_S1.Classes.JednotliveCesty;

//Tester tester = new Tester();
//tester.RunSimulation(1000000);
int pocetReplikacii = 100_000;
DivinkaRajecStrecno divinkaRajecStrecno = new DivinkaRajecStrecno();
divinkaRajecStrecno.RunSimulation(pocetReplikacii);
DivinkaStrecnoRajec divinkaStrecnoRajec = new DivinkaStrecnoRajec();
divinkaStrecnoRajec.RunSimulation(pocetReplikacii);
RajecDivinkaStrecno rajecDivinkaStrecno = new RajecDivinkaStrecno();
rajecDivinkaStrecno.RunSimulation(pocetReplikacii);
RajecStrecnoDivinka rajecStrecnoDivinka = new RajecStrecnoDivinka();
rajecStrecnoDivinka.RunSimulation(pocetReplikacii);
StrecnoDivinkaRajec strecnoDivinkaRajec = new StrecnoDivinkaRajec();
strecnoDivinkaRajec.RunSimulation(pocetReplikacii);
StrecnoRajecDivinka strecnoRajecDivinka = new StrecnoRajecDivinka();
strecnoRajecDivinka.RunSimulation(pocetReplikacii);

