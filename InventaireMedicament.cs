using System;
using System.Collections.Generic;

namespace Gestion_Pharmacie
{
    public class InventaireMedicament
    {
        private List<Medicament> inventaire;

        public InventaireMedicament()
        {
            inventaire = new List<Medicament>();
        }

        public void AjouterMedicament(Medicament medicament)
        {
            inventaire.Add(medicament);
        }

        public bool VerifierStock(string nom, int quantite)
        {
            Medicament medicament = inventaire.Find(m => m.Nom == nom);

            if (medicament != null && medicament.Quantite >= quantite)
            {
                return true; // Stock disponible
            }
            else
            {
                return false; // Stock insuffisant ou médicament non disponible
            }
        }

        public void VendreMedicament(string nom, int quantite)
        {
            Medicament medicament = inventaire.Find(m => m.Nom == nom);

            if (medicament != null && medicament.Quantite >= quantite)
            {
                medicament.Quantite -= quantite;
                Console.WriteLine(quantite + " " + medicament.Nom + "(s) vendu(s) !");
            }
            else
            {
                Console.WriteLine("Le médicament n'est pas disponible en quantité suffisante.");
            }
        }

        public List<Medicament> GetInventaire()
        {
            return inventaire;
        }
    }
}
