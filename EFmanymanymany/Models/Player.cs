using System.Collections.Generic;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Position> Positions { get; set; }
}
