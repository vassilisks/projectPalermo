public class Player
{
    public string Name { get; set; }
    public RoleType Role { get; set; }
    public bool IsAlive { get; set; } = true;

    // Προσθέτουμε αυτά:
    public bool IsKiller { get; set; } // Μπορεί να σκοτώσει τη νύχτα;
    public bool AppearsAsInnocent { get; set; } // Αν τον ελέγξει η αστυνομία, φαίνεται αθώος;
    public bool IsVisibleToMafia { get; set; } // Τον ξέρουν οι άλλοι μαφιόζοι;

    public Player(string name, RoleType role)
    {
        Name = name;
        Role = role;
        SetupRoleAttributes();
    }

    private void SetupRoleAttributes()
    {
        switch (Role)
        {
            case RoleType.Mafia: // Ο κλασικός δολοφόνος
                IsKiller = true;
                AppearsAsInnocent = false;
                IsVisibleToMafia = true;
                break;
            case RoleType.Godfather: // Ο αρχηγός (Κρυφός)
                IsKiller = true;
                AppearsAsInnocent = true; // Η αστυνομία τον βλέπει ως πολίτη!
                IsVisibleToMafia = true;
                break;
            case RoleType.SerialKiller: // Ο μοναχικός δολοφόνος (Φανερός αλλά εχθρός όλων)
                IsKiller = true;
                AppearsAsInnocent = false;
                IsVisibleToMafia = false; // Η μαφία δεν τον ξέρει
                break;
        }
    }
}