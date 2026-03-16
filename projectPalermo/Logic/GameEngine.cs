namespace projectPalermo.Models; 
namespace projectPalermo.Logic;

public void PlayNightPhase(List<Player> players)
{
    foreach (var player in players.Where(p => p.IsAlive))
    {
        // Μόνο οι ρόλοι με ειδικές ικανότητες δρουν τη νύχτα
        if (player.Role == RoleType.Citizen) continue;

        Console.Clear();
        Console.WriteLine($"Παρακαλώ να μείνει στην οθόνη μόνο ο/η: {player.Name}");
        Console.WriteLine("Πατήστε Enter όταν είστε έτοιμοι...");
        Console.ReadLine();

        switch (player.Role)
        {
            case RoleType.Mafia:
            case RoleType.Godfather:
                HandleMurderAction(player, players);
                break;
            case RoleType.Police:
                HandleInvestigation(player, players);
                break;
            // Πρόσθεσε εδώ Doctor κλπ.
        }

        Console.WriteLine("Η ενέργειά σας καταγράφηκε. Πατήστε Enter για να σβήσει η οθόνη.");
        Console.ReadLine();
        Console.Clear();
    }
    
    // Logic/GameEngine.cs

    private void HandlePoliceAction(Player police, List<Player> allPlayers)
    {
        Console.WriteLine("Αστυνόμε, ποιον παίκτη θέλεις να ελέγξεις;");
        string targetName = Console.ReadLine();
    
        var target = allPlayers.FirstOrDefault(p => p.Name == targetName && p.IsAlive);

        if (target != null)
        {
            // ΕΔΩ ΕΙΝΑΙ Η ΔΙΑΧΕΙΡΙΣΗ ΤΗΣ ΚΡΥΦΗΣ ΠΛΗΡΟΦΟΡΙΑΣ:
            // Αν ο target είναι Godfather, το AppearsAsInnocent είναι true
            if (target.AppearsAsInnocent) 
            {
                Console.WriteLine($"Ο/Η {target.Name} είναι: ΑΘΩΟΣ");
            }
            else 
            {
                Console.WriteLine($"Ο/Η {target.Name} είναι: ΕΝΟΧΟΣ");
            }
        }
    }
    
    // Logic/GameEngine.cs

    public void ShowMafiaTeammates(Player currentMafia, List<Player> allPlayers)
    {
        // Φιλτράρουμε όσους είναι ορατοί στη μαφία (π.χ. Godfather, Mafia)
        var teammates = allPlayers.Where(p => p.IsVisibleToMafia && p.Name != currentMafia.Name);
    
        Console.WriteLine("Οι συνεργάτες σου είναι:");
        foreach (var mate in teammates)
        {
            Console.WriteLine("- " + mate.Name);
        }
    }
    
    
}