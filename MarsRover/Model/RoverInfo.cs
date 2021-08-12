using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// N = 0
    /// E = 1
    /// S = 2
    /// W = 3
    /// </summary>
    public enum CardinalCompassPoints
    {
        N,
        E,
        S,
        W,
    }

    public class RoverInfo
    {
        public static List<Rover> listOfAllRovers = new();
    }

}
