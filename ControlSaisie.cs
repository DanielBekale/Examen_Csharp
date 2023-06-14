using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pharmacie
{
    public class ControlSaisie
    {
        public static bool controleSaisie(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c) || char.IsWhiteSpace(c))
                {
                    return false; // Chiffre ou espace trouvé
                }
            }

            return true; // Aucun chiffre ou espace trouvé
        }
    }
}
