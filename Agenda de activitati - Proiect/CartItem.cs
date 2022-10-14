using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda_de_activitati___Proiect
{
    public class CartItem
    {
        public int ID { get; set; }
        public string Nume { get; set; }

        public string Imagine { get; set; }

        public string Descriere { get; set; }

        public Double Pret{ get; set; }

        public int Cantitate { get; set; }

        public CartItem ()
        {

        }

        public CartItem(int ID, string nume, string img, string descriere, Double pret, int cant)
        {
            this.ID = ID;
            this.Nume = nume;
            this.Imagine = img;
            this.Descriere = descriere;
            this.Pret = pret;
            this.Cantitate = cant;
        }
    }
}