using System;

namespace Gestion_Pharmacie
{
    public class Medicament
    {
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public DateTime DateExpiration { get; set; }

        public Medicament(string nom, int quantite, DateTime dateExpiration)
        {
            Nom = nom;
            Quantite = quantite;
            DateExpiration = dateExpiration;
        }
    }
}
