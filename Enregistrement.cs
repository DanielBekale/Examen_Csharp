using System;
using static Gestion_Pharmacie.ControlSaisie;

namespace Gestion_Pharmacie
{
    public class Enregistrement
    {
        private InventaireMedicament inventaire;
        private Client client;

        public Enregistrement()
        {
            inventaire = new InventaireMedicament();
            client = null;
        }

        public void AjouterMedicament()
        {
            Console.Write("Nom du médicament : ");
            string nom = Console.ReadLine();

            Console.Write("Quantité : ");
            int quantite = int.Parse(Console.ReadLine());

            Console.Write("Date d'expiration (jj/mm/aaaa) : ");
            DateTime dateExpiration = DateTime.Parse(Console.ReadLine());

            Medicament medicament = new Medicament(nom, quantite, dateExpiration);
            inventaire.AjouterMedicament(medicament);
        }

        public void SaisirInformationsClient()
        {
            string nom = String.Empty;
            string prenom = String.Empty;
            DateOnly dateNaissance; 

            do
            {
                Console.Write("ENTRER LE NOM DE L'EMPLOYE  : ");
                nom = Console.ReadLine();

                if (!controleSaisie(nom))
                {
                    Console.WriteLine("VEUILLEZ ENTRER UN NOM VALIDE SVP");
                }

            } while (!controleSaisie(nom) || String.IsNullOrEmpty(nom));

            do
            {
                Console.Write("ENTRER LE PRENOM DE L'EMPLOYE: ");

                prenom = Console.ReadLine();

                if (!controleSaisie(prenom))
                {
                    Console.WriteLine("VEUILLEZ ENTRER UN PRENOM VALIDE SVP !");

                }

            } while (!controleSaisie(prenom) || String.IsNullOrEmpty(prenom));

            do
            {
                Console.Write("ENTRER LA DATE DE NAISSANCE DE L'EMPLOYE (FORMAT JJ/MM/AAAA) : ");
                Console.WriteLine("L'EMPLOYE DOIT AVOIR PLUS DE 18 ANS ");
                try
                {
                    dateNaissance = DateOnly.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("ENTRER UNE DATE VALIDE !");
                }
            }
            while (DateOnly.FromDateTime(DateTime.Now).Year - dateNaissance.Year < 18);

            client = new Client(nom, prenom, dateNaissance);
        }

        public void PasserCommande()
        {
            if (client == null)
            {
                Console.WriteLine("Veuillez d'abord saisir les informations du client.");
                return;
            }

            Console.Write("Nom du médicament : ");
            string nomMedicament = Console.ReadLine();

            Console.Write("Quantité : ");
            int quantite = int.Parse(Console.ReadLine());

            Medicament medicament = new Medicament(nomMedicament, quantite, DateTime.Now);

            bool stockDisponible = inventaire.VerifierStock(nomMedicament, quantite);

            if (stockDisponible)
            {
                client.PasserCommande(medicament);
                inventaire.VendreMedicament(nomMedicament, quantite);
                Console.WriteLine("Commande passée avec succès !");
            }
            else
            {
                Console.WriteLine("Le médicament est en rupture de stock.");
            }
        }

        public void AfficherCommandesClient()
        {
            if (client == null)
            {
                Console.WriteLine("Aucun client enregistré.");
                return;
            }

            client.AfficherCommandes();
        }

        public void AfficherInventaire()
        {
            Console.WriteLine("Inventaire de la pharmacie :");
            foreach (Medicament medicament in inventaire.GetInventaire())
            {
                Console.WriteLine("Nom : " + medicament.Nom);
                Console.WriteLine("Quantité : " + medicament.Quantite);
                Console.WriteLine("Date d'expiration : " + medicament.DateExpiration.ToShortDateString());
                Console.WriteLine("--------------------");
            }
        }
    }
}
