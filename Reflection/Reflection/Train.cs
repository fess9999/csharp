namespace Reflection
{
    public abstract class Entity
    {

    }

    public abstract class Train : Entity
    {
        [NonDefault]
        [MaxValue(MaxValue = 100)]
        public int CarCount { get; set; }

        [MaxValue(100)]
        public string Description { get; set; }

        public int Power { get; set; }
    }
}