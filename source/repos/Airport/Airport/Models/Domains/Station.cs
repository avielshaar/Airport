namespace Airport.Models.Domains
{
    public class Station
    {
        public int Id { get; set; }
        public Plane? Plane { get; set; }
        public bool IsOccupied { get { return Plane != null; } }

        public Station(int id, Plane? plane)
        {
            Id = id;
            Plane = plane;
        }
    }
}
