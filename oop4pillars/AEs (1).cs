using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_GAME__OOP_FINALS_.Characters;


namespace RPG_GAME__OOP_FINALS_.Characters
{
    public abstract class AEs
    {
        public string AEtype { get; protected set; }
        public int Level { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }

        public AEs (int health, int damage, int armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        Random random = new Random();
        public int TakeDamage(int damage)
        {
            double randomMultiplier = (1.2f - 0.8f) * random.NextDouble() + 0.8f;
            int finalDamage = (int)((damage * randomMultiplier) / Armor);

            if (finalDamage <= 0)
                finalDamage = 1;

            Health -= damage;

            return damage;
        }

        public void gainHP(int health)
        {
            Health += health;
        }

        public abstract int Skill(Enemies enemy);
    }

    public class RocketPuncher : AEs
    {
        public RocketPuncher(int health, int damage, int armor) : base (health, damage, armor)
        {
            AEtype = "RocketPuncher";
        }

        public override int Skill(Enemies enemy)
        {
            //GamePlay.gamePlay.TypeText(new string[] {"Sonic Disruptor"}, true, true);
            return enemy.TakeDamage((int)(enemy.Health * 0.3f));
        }
    }

    public class Armamenter : AEs
    {
        public Armamenter(int health, int damage, int armor) : base(health, damage, armor)
        {
            AEtype = "Armamenter";
        }

        public override int Skill(Enemies enemy)
        {
            //Console.WriteLine("Elemental Disruptor");
            return enemy.TakeDamage((int)(enemy.Health * 0.3f));
        }
    }

    public class Xenoglossy : AEs
    {
        public Xenoglossy(int health, int damage, int armor) : base(health, damage, armor)
        {
            AEtype = "Xenoglossy";
        }

        public override int Skill(Enemies enemy)
        {
            //Console.WriteLine("Cipher Unraveler");
            return enemy.TakeDamage((int)(enemy.Health * 0.3f));
        }
    }

    public class ED_hacker : AEs
    {
        public ED_hacker(int health, int damage, int armor) : base(health, damage, armor)
        {
            AEtype = "E.D Hacker";
        }

        public override int Skill(Enemies enemy)
        {
            //Console.WriteLine("Binary Breaker");
            return enemy.TakeDamage((int)(enemy.Health * 0.3f));
        }
    }
}
