using System;
using System.Collections.Generic;
using System.Linq;
using projectPalermo.Models; // Για να "βλέπει" τον Player και το RoleType

namespace projectPalermo.Logic;

public class GameEngine
{
    public void PlayNightPhase(List<Player> players)
    {
        foreach (var player in players.Where(p => p.IsAlive))
        {
            if (player.Role == RoleType.Citizen) continue;

            Console.Clear();
            Console.WriteLine($"Παρακαλώ να μείνει στην οθόνη μόνο ο/η: {player.Name}");
            Console.WriteLine("Πατήστε Enter όταν είστε έτοιμοι...");
            Console.ReadLine();

            switch (player.Role)
            {
                case RoleType.Mafia:
                case RoleType.Godfather:
                    // Το φτιάχνουμε παρακάτω
                    Console.WriteLine("Είστε η μαφία. Ποιον θέλετε να " + "σκοτώσετε" + ";"); 
                    Console.ReadLine();
                    break;
                case RoleType.Police:
                    HandlePoliceAction(player, players);
                    break;
            }

            Console.WriteLine("Η ενέργειά σας καταγράφηκε. Πατήστε Enter για να σβήσει η οθόνη.");
            Console.ReadLine();
            Console.Clear();
        }
    }

    private void HandlePoliceAction(Player police, List<Player> allPlayers)
    {
        Console.WriteLine("Αστυνόμε, ποιον παίκτη θέλεις να ελέγξεις;");
        string targetName = Console.ReadLine();
    
        var target = allPlayers.FirstOrDefault(p => p.Name == targetName && p.IsAlive);

        if (target != null)
        {
            if (target.AppearsAsInnocent) 
            {
                Console.WriteLine($"Ο/Η {target.Name} είναι: ΑΘΩΟΣ");
            }
            else 
            {
                Console.WriteLine($"Ο/Η {target.Name} είναι: ΕΝΟΧΟΣ");
            }
        }
        else
        {
            Console.WriteLine("Αυτός ο παίκτης δεν βρέθηκε.");
        }
    }

    public void ShowMafiaTeammates(Player currentMafia, List<Player> allPlayers)
    {
        var teammates = allPlayers.Where(p => p.IsVisibleToMafia && p.Name != currentMafia.Name);
    
        Console.WriteLine("Οι συνεργάτες σου είναι:");
        foreach (var mate in teammates)
        {
            Console.WriteLine("- " + mate.Name);
        }
    }
}