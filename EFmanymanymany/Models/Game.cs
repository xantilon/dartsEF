using System.Collections.Generic;

public class Game
{
    public int Id { get; set; }

    public virtual List<Position> Positions { get; set; }
}
