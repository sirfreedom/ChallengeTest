
namespace WinFormDisegnPattern.Prototype
{
    public class Warrior : IPrototype<Warrior>
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public Warrior(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Health:{Health}, AttackPower: {AttackPower}";
        }

        public Warrior Clone()
        {
            return (Warrior)MemberwiseClone();
        }



    }
}
