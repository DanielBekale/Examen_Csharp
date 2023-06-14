using System;
using System.Collections.Generic;

namespace Gestion_Pharmacie
{
    public class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public List<Medicament> Commandes { get; set; }
        public DateOnly DateNaissance1 { get; }

        public Client(string nom, string prenom, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Commandes = new List<Medicament>();
        }

        public Client(string nom, string prenom, DateOnly dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance1 = dateNaissance;
        }

        public void PasserCommande(Medicament medicament)
        {
            Commandes.Add(medicament);
        }

        public void AfficherCommandes()
        {
            Console.WriteLine("Commandes de " + Nom + " " + Prenom + " :");
            foreach (Medicament medicament in Commandes)
            {
                Console.WriteLine("- " + medicament.Nom);
            }
        }
    }
}
