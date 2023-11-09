using System;

namespace Esercizio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cittadino ct1 = new Militare("C", "D", 60, 3, true, 3, "Alfa");
            Comune c1 = new Comune();
            c1.CalcoloRdC(ct1);
            ct1.GetInfo();
        }

        public abstract class Persona
        {
            string _name;
            string _surname;
            int _age;

            public Persona(string name, string surname, int age)
            {
                _name = name;
                _surname = surname;
                _age = age;
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public string Surname
            {
                get { return _surname; }
                set { _surname = value; }
            }

            public int Age
            {
                get { return _age; }
                set { _age = value; }
            }

            public abstract void GetInfo();
        }
        public class Cittadino : Persona
        {
            int _figliACarico;
            bool _haDebiti;
            int _punteggioPerRdC;

            public Cittadino(string name, string surname, int age,
                int figliACarico, bool haDebiti) : base(name, surname, age)
            {
                _figliACarico = figliACarico;
                _haDebiti = haDebiti;
                _punteggioPerRdC = 0;
            }
            public int FigliACarico
            {
                get { return _figliACarico; }
                set { _figliACarico = value; }
            }
            public bool HaDebiti
            {
                get { return _haDebiti; }
                set { _haDebiti = value; }
            }
            public int PunteggioPerRdC
            {
                get { return _punteggioPerRdC; }
                set { _punteggioPerRdC = value; }
            }

            public override void GetInfo()
            {
                Console.WriteLine($"Info: {Name}\n{Surname}" +
                    $"\n{Age}\n{HaDebiti}\n{FigliACarico}");
            }
        }

        public class Studente : Cittadino
        {
            int _votoMaturità;
            int _mediaUniversitaria;

            public Studente(string name, string surname, int age, int figliACarico, bool haDebiti, int votoMaturità, int mediaUniversitaria)
                : base(name, surname, age, figliACarico, haDebiti)
            {
                _votoMaturità = votoMaturità;
                _mediaUniversitaria = mediaUniversitaria;
            }

            public int VotoMaturità
            {
                get { return _votoMaturità; }
                set { _votoMaturità = value; }
            }

            public int MediaUniversitaria
            {
                get { return _mediaUniversitaria; }
                set { _mediaUniversitaria = value; }
            }

            public override void GetInfo()
            {
                Console.WriteLine($"Info;\nNome: {Name}\nCongnome: {Surname}\nMaturità: {VotoMaturità}\nMedia voti università:{MediaUniversitaria}");
            }

        }

        public class Militare : Cittadino
        {
            int _anniDiServizio;
            string _luogoDiServizio;
            public Militare(string name, string surname, int age, int figliACarico, bool haDebiti, int anniDiServizio, string luogoDiServizio)
                : base(name, surname, age, figliACarico, haDebiti)
            {
                _anniDiServizio = anniDiServizio;
                _luogoDiServizio = luogoDiServizio;
            }
            public int AnniDiservizio
            {
                get { return _anniDiServizio; }
                set { _anniDiServizio = value; }
            }
            public string LuogoDiServizio
            {
                get { return _luogoDiServizio; }
                set { LuogoDiServizio = value; }
            }

            public override void GetInfo()
            {
                Console.WriteLine($"Info;\nNome: {Name}\nCongnome: {Surname}\nAnni di servzizio: {AnniDiservizio}\nLuogo di Servizio:{LuogoDiServizio}");
            }
        }

        public abstract class EntePubblico
        {
            string _nome;
            public abstract void CalcoloRdC(Cittadino cittadino);

        }

        public class Comune : EntePubblico
        {
            decimal _pillComune;
            string _nomeComune;

            public override void CalcoloRdC(Cittadino cittadino)
            {
                if (cittadino is Militare)
                {
                    cittadino.PunteggioPerRdC += 3;
                }
                if (cittadino is Militare && ((Militare)cittadino).AnniDiservizio > 5)
                {
                    cittadino.PunteggioPerRdC += 10;
                }
                if (cittadino is Studente && ((Studente)cittadino).VotoMaturità > 90)
                {
                    cittadino.PunteggioPerRdC += 2;
                }
                if (cittadino is Studente && ((Studente)cittadino).MediaUniversitaria > 28)
                {
                    cittadino.PunteggioPerRdC += 3;
                }
                if ((cittadino.Age >= 18 && cittadino.Age <= 25) || cittadino.Age >= 60)
                {
                    cittadino.PunteggioPerRdC = +3;
                }
                if (cittadino.Age >= 60 && cittadino.HaDebiti)
                {
                    cittadino.PunteggioPerRdC += 4;
                }
                if (cittadino.HaDebiti)
                {
                    cittadino.PunteggioPerRdC += 5;
                }
                if (cittadino.PunteggioPerRdC >= 25)
                {
                    Console.WriteLine("Il cittadino ha diritto Al RdC");
                }
                else
                {
                    Console.WriteLine("Il Cittadino non ha diritto al RdC");
                }
            }
        }
    }
}
