using System;
using System.Collections.Generic;
using System.Linq;

public class GameEngine
{
    private Random _random = new Random();

    public List<Player> AssignRoles(List<string> playerNames)
    {
        int totalPlayers = playerNames.Count;
        
        // 1. Δημιουργία της λίστας με τους ρόλους που θα υπάρχουν στο παιχνίδι
        // Παράδειγμα κανόνα: 1 Μαφιόζος ανά 4 παίκτες
        List<RoleType> rolesPool = new List<RoleType>();
        
        int mafiaCount = totalPlayers / 4; 
        if (mafiaCount == 0) mafiaCount = 1; // Τουλάχιστον ένας

        for (int i = 0; i < mafiaCount; i++) rolesPool.Add(RoleType.Mafia);
        rolesPool.Add(RoleType.Police);
        rolesPool.Add(RoleType.Doctor);

        // Οι υπόλοιποι είναι πολίτες
        while (rolesPool.Count < totalPlayers)
        {
            rolesPool.Add(RoleType.Citizen);
        }

        // 2. Ανακάτεμα της λίστας των ρόλων (Fisher-Yates Shuffle)
        for (int i = rolesPool.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            RoleType temp = rolesPool[i];
            rolesPool[i] = rolesPool[j];
            rolesPool[j] = temp;
        }

        // 3. Ανάθεση των ανακατεμένων ρόλων στους παίκτες
        List<Player> players = new List<Player>();
        for (int i = 0; i < totalPlayers; i++)
        {
            players.Add(new Player(playerNames[i], rolesPool[i]));
        }

        return players;
    }
}