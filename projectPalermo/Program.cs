using System;
using System.Collections.Generic;
using projectPalermo.Models;
using projectPalermo.Logic;

Console.WriteLine("Καλώς ήρθατε στο Παλέρμο!");

// 1. Δημιουργία δοκιμαστικών παικτών
List<Player> players = new List<Player>
{
    new Player("Γιάννης", RoleType.Godfather), // Κρυφός δολοφόνος
    new Player("Μαρία", RoleType.Police),      // Αστυνόμος
    new Player("Κώστας", RoleType.Citizen),   
    new Player("Βασίλης", RoleType.Citizen),    // Απλός πολίτης
    new Player("Γίωργος", RoleType.Citizen),    // Απλός πολίτης// Απλός πολίτης
    new Player("Ελένη", RoleType.Mafia)        // Απλός Μαφιόζος
};

// 2. Δημιουργία της μηχανής του παιχνιδιού
GameEngine engine = new GameEngine();

// 3. Ξεκινάμε τη φάση της νύχτας!
engine.PlayNightPhase(players);

Console.WriteLine("Η νύχτα τελείωσε. Το χωριό ξυπνάει...");