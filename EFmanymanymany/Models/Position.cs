public class Position
{
    public int Id { get; set; }
    public int Pos { get; set; }

    public virtual Game Game { get; set; }
    public virtual Player Player { get; set; }

}