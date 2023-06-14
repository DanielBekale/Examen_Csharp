using System;

namespace Gestion_Pharmacie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Enregistrement enregistrement = new Enregistrement();

            while (true)
            {
                Console.WriteLine("------ Menu ------");
                Console.WriteLine("1. Ajouter un médicament");
                Console.WriteLine("2. Saisir les informations du client");
                Console.WriteLine("3. Passer une commande");
                Console.WriteLine("4. Afficher les commandes d'un client");
                Console.WriteLine("5. Afficher l'inventaire");
                Console.WriteLine("0. Quitter");
                Console.WriteLine("------------------");
                Console.Write("Choix : ");
                int choix = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (choix)
                {
                    case 1:
                        enregistrement.AjouterMedicament();
                        break;
                    case 2:
                        enregistrement.SaisirInformationsClient();
                        break;
                    case 3:
                        enregistrement.PasserCommande();
                        break;
                    case 4:
                        enregistrement.AfficherCommandesClient();
                        break;
                    case 5:
                        enregistrement.AfficherInventaire();
                        break;
                    case 0:
                        Console.WriteLine("Au revoir !");
                        return;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
