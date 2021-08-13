using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// N = 0;
    /// E = 1;
    /// S = 2;
    /// W = 3;
    /// </summary>
    public enum CardinalCompassPoints
    {
        N,
        E,
        S,
        W,
    }

    /// <summary>
    /// Contains global information about rovers.
    /// For example, List of all rovers.
    /// </summary>
    public class RoverInfo
    {
        public static List<Rover> ListOfAllRovers = new();
    }

}
