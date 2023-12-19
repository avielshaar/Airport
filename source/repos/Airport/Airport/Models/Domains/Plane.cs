namespace Airport.Models.Domains
{
    public class Plane
    {
        public int Id { get; set; }
        public bool Type { get; set; } // false for arrivel, true for departure

        public Plane(int planeId, bool type)
        {
            Id = planeId;
            Type = type;
        }
    }
}
