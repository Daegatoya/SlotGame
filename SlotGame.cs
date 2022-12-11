namespace SlotGame
{

    // Différentes librairies utilisées
    using System;
    using System.Text.RegularExpressions;

    // Classe MainClass
    public static class MainClass
    {

        // Fonction Main() en valeur de retour "void"
        public static void Main()
        {

            // Déclaration des variables
            string[] resultats = { "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Pêche", "Cerise", "Cerise", "Cerise", "Cerise", "Cerise", "Cerise", "Cerise", "Cerise", "Cerise", "Cerise", "Cerise", "Fraise", "Fraise", "Fraise", "Fraise", "Fraise", "Fraise", "Fraise", "Pomme", "Pomme", "Pomme", "Pomme", "Pomme", "Pomme", "Pomme", "Pomme", "Ananas", "Ananas", "Ananas", "7", "7", "7", "7", "77", "77", "77", "777", "777" };
            string[] resultats_Finaux = new string[3];
            decimal wallet = 1000;
            decimal? mise;

            // Boucle "Faire... Tant Que..."
            do
            {

                // Écriture des données et des informations
                Console.WriteLine($"\n\nVotre solde : {wallet:F2}$");
                Console.Write("\nCombien voulez-vous miser? (Maximum 25000, 0 pour arrêter) : ");

                // Appel  et assignation à la variable "mise" de la fonction Mise() avec le paramètre "wallet"
                mise = Mise(wallet);
                wallet -= (decimal)mise;

                // Appel  et assignation à la variable "resultats_Finaux[]" de la fonction Spin() avec le paramètre "resultats[]"
                resultats_Finaux = Spin(resultats);

                // Appel et assignation à la variable "wallet" de la fonction Resultat() avec les paramètre "resultats_Finaux[]", "wallet" et "mise"
                wallet = Resultat(resultats_Finaux, wallet, mise);

                // Observation de la variable "wallet"
                if (wallet < 0.01m)
                {

                    // Sortie du programme si la valeur de "wallet" est infèrieur à 0.01$
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\n\tVous n'avez plus d'argent. Au revoir!");
                    Console.ResetColor();
                    Environment.Exit(0x1);
                }

                // Affichage des résultats et attente d'une entrée de l'utilisateur pour poursuivre
                Console.WriteLine("\n\n\tAppuyer sur ENTER pour poursuivre");
                Console.ReadKey();
                Console.Clear();
            } 
            
            // Reproduire le tout tant que la mise n'est pas de 0
            while (mise != 0);

            // Quitter si c'est le cas
            Environment.Exit(0x1);
        }

        // Fonction Mise() en valeur de retour "decimal?"
        public static decimal? Mise(decimal wallet)
        {

            // Déclaration des variables
            decimal? montant;
            decimal output;

            // Lecture d'entrée et assignation à la variable "montant"
            montant = decimal.TryParse(Console.ReadLine(), out output) ? output : null;

            // Boucle "Faire... Tant Que..."
            do
            {

                // Début d'une ligne mutli-conditionnelle avec la variable "montant"
                switch (montant)
                {

                    // Si null...
                    case null:

                        // Afficher une erreur et reprendre l'entrée utilisateur
                            Console.Write("Le montant est invalide. Réessayer : ");
                            montant = decimal.TryParse(Console.ReadLine(), out output) ? output : null;
                        break;

                    // Sinon...
                    default:

                        // Si montant > wallet...
                        if ((decimal)montant > wallet)
                        {

                            // Afficher une erreur et reprendre l'entrée utilisateur
                                Console.Write("Le montant est trop élevé. Réessayer : ");
                                montant = decimal.TryParse(Console.ReadLine(), out output) ? output : null;
                        }

                        // Si montant > 25000...
                        else if (montant > 25000)
                        {

                            // Afficher une erreur et reprendre l'entrée utilisateur
                                Console.Write("Le montant est trop élevé. Réessayer : ");
                                montant = decimal.TryParse(Console.ReadLine(), out output) ? output : null;
                        }

                        // Si montant = 0...
                        else if(montant == 0)
                        {
                           
                            // Quitter le programme
                            Environment.Exit(0x1);
                        }

                        // Sinon...
                        else
                        {

                            // Retour de la valeur "montant" en "decimal?"
                            return montant;
                        }
                        break;
                }
            } 
            
            // Refaire tant que la variable "montant" = null ou > wallet ou > 25000
            while(montant == null || montant > wallet || montant > 25000);

            // Retour de la valeur "montant" en "decimal?"
            return montant;
            }

        // Fonction Spin() en valeur de retour "string[]"
        public static string[] Spin(string[] résultats)
        {

            // Déclaration des variables
            string[] output = new string[3];
            Random random = new Random();

            Console.WriteLine();

            // Boucle "Pour..." avec la longueur "output.Length"
            for(int i = 0; i < output.Length; i++)
            {

                // Tirage au hasard d'un élément du tableau "résultats" et assignation à l'élément du tableau "output" i
                output[i] = résultats[random.Next(0, résultats.Length)];
            }

            // Boucle "Pour..." avec la longueur "11"
            for (int j = 0; j < 11; j++) 
            {

                // Affichage de différents couleurs
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(" ");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine();

            // Boucle "Pour Chaque..." avec un paramètre "string" dans le tableau "output"
            foreach (string nb in output)
            {

                // Observation du résultat par élément et assignation de couleur
                if(nb == "Pêche")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(nb + "  ");
                }
                else if (nb == "Cerise")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(nb + "  ");
                }
                else if (nb == "Fraise")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(nb + "  ");
                }
                else if (nb == "Pomme")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(nb + "  ");
                }
                else if (nb == "Ananas")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(nb + "  ");
                }
                else if (nb == "7")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(nb + "  ");
                }
                else if (nb == "77")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(nb + "  ");
                }
                else if (nb == "777")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(nb + "  ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();


            // Boucle "Pour..." avec la longueur "11"
            for (int k = 0; k < 11; k++)
            {

                // Affichage de différents couleurs
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(" ");
                Console.ResetColor();
            }

            // Retour de la valeur "output" en "string[]"
            return output;
        }

        // Fonction Resultat() en valeur de retour "decimal"
        public static decimal Resultat(string[] resultats_Finaux, decimal wallet, decimal? mise)
        {

            // Déclaration des variables
            string pattern = @"[7-77-777]";
            Regex regex = new Regex(pattern);

            // Observation des résultats dans le tableau "resultats_Finaux" et assignation de différents multiplicateurs de mise selon les résultats obtenus
             if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Pêche")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 1.2m:F2}$");
                wallet += ((decimal)mise * 1.2m);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == "Pêche" || resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Pêche" || resultats_Finaux[0] == resultats_Finaux[2] && resultats_Finaux[2] == "Pêche" && !(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Pêche"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 1:F2}$");
                wallet += ((decimal)mise * 1);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Pêche")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 1.2m:F2}$");
                wallet += ((decimal)mise * 1.2m);
                Console.ResetColor();
            }
            else if(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == "Cerise" || resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Cerise" || resultats_Finaux[0] == resultats_Finaux[2] && resultats_Finaux[2] == "Cerise" && !(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Cerise"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 1.1m:F2}$");
                wallet += ((decimal)mise * 1.1m);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Fraise")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 2m:F2}$");
                wallet += ((decimal)mise * 2m);
                Console.ResetColor();
            }
            else if(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == "Fraise" || resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Fraise" || resultats_Finaux[0] == resultats_Finaux[2] && resultats_Finaux[2] == "Fraise" && !(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Fraise"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 1.3m:F2}$");
                wallet += ((decimal)mise * 1.3m);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Pomme")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 4m:F2}$");
                wallet += ((decimal)mise * 4m);
                Console.ResetColor();
            }
            else if(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == "Pomme" || resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Pomme" || resultats_Finaux[0] == resultats_Finaux[2] && resultats_Finaux[2] == "Pomme" && !(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Pomme"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 1.5m:F2}$");
                wallet += ((decimal)mise * 1.5m);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Ananas")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 6m:F2}$");
                wallet += ((decimal)mise * 6m);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == "Ananas" || resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Ananas" || resultats_Finaux[0] == resultats_Finaux[2] && resultats_Finaux[2] == "Ananas" && !(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "Ananas"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\n\tVous gagnez {mise * 2m:F2}$");
                wallet += ((decimal)mise * 2m);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "7")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\tTu gagnes le Big-Jackpot!");
                Console.WriteLine($"\n\tVous gagnez {mise * 15m:F2}$");
                wallet += ((decimal)mise * 15m);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "77")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\tTu gagnes le Mega-Jackpot!");
                Console.WriteLine($"\n\tVous gagnez {mise * 25m:F2}$");
                wallet += ((decimal)mise * 25m);
                Console.ResetColor();
            }
            else if (resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && resultats_Finaux[1] == "777")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\tTu gagnes le Giant-Jackpot!");
                Console.WriteLine($"\n\tVous gagnez {mise * 50m:F2}$");
                wallet += ((decimal)mise * 50m);
                Console.ResetColor();
            }
            else if (regex.IsMatch(resultats_Finaux[0]) && regex.IsMatch(resultats_Finaux[1]) && regex.IsMatch(resultats_Finaux[2]) && !(resultats_Finaux[0] == resultats_Finaux[1] && resultats_Finaux[1] == resultats_Finaux[2] && (resultats_Finaux[1] == "7" || resultats_Finaux[1] == "77" || resultats_Finaux[1] == "777")))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\tTu gagnes le Mini-Jackpot!");
                Console.WriteLine($"\n\tVous gagnez {mise * 10m:F2}$");
                wallet += ((decimal)mise * 10m);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\n\tVous n'avez rien gagné");
                Console.ResetColor();
            }

             // Retour de la valeur "wallet" en "decimal"
            return wallet;
        }
    }
}
