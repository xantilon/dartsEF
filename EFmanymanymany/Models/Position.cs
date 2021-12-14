using System.ComponentModel.DataAnnotations.Schema;

public class Position
{

    [Index("IX_PositionIdAndPlayAndGame", 3)] 
    public int Id { get; set; }
    public int Pos { get; set; }


    [Index("IX_PositionIdAndPlayAndGame", IsUnique = true, Order = 1)]
    public int GameId { get; set; }
    [Index("IX_PositionIdAndPlayAndGame", IsUnique = true, Order = 2)]
    public int PlayerId { get; set; }

    public virtual Game Game { get; set; }
    public virtual Player Player { get; set; }

}