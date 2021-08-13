namespace Model
{
    /// <summary>
    /// Plateau where the rovers are placed.
    /// UpperRightCoordinates -> upper limit of the plateau e.g 3,7 (x=3,y=7).
    /// LowerLeftCoordinates -> lower limit of the plateau e.g 0,0 (x=0,y=0)
    /// </summary>
    public class Plateau
    {
        public static int[,] UpperRightCoordinates { get; set; }
        public static readonly int[,] LowerLeftCoordinates = new int[,] { { 0, 0 } };
    }
}
