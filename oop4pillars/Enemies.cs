using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_GAME__OOP_FINALS_.Characters;


namespace RPG_GAME__OOP_FINALS_.Characters
{
    public class Enemies
    {
        public int VirusRank { get; set; } = 1;

        public string EnemyType { get; protected set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }

        public Enemies(int health, int damage, int armor)
        {
            Health = health* VirusRank;
            Damage = damage * VirusRank;
            Armor = armor * VirusRank;
        }


        Random random = new Random();
        public int TakeDamage(int damage)
        {
            // Approach 1
            double randomMultiplier = (1.2f - 0.8f) * random.NextDouble() + 0.8f;
            int finalDamage = (int)((damage * randomMultiplier) / Armor);

            if (finalDamage <= 0)
             finalDamage = 1;

            // Approach 2
            Health -= damage;

            return damage;

        }
        

        public virtual string SkillInfo()
        {
            return " Skill Unknown!";
        }
    }

    public class Binary_Specter : Enemies
    {
        public Binary_Specter(int health, int damage, int armor) : base(health, damage, armor)
        {
            VirusRank = 2 ;
  
            EnemyType = " Binary Specter ";
        }

        public override string SkillInfo()
        {
            return "A phantom entity that manipulates binary code to disrupt the SYNC and drain avatars' data.";
        }
    }

    public class Elemental_Warden : Enemies
    {
        public Elemental_Warden(int health, int damage, int armor) : base(health, damage, armor)
        {
            VirusRank = 3 ;

            EnemyType = " Elemental Warden ";
        }

        public override string SkillInfo()
        {
            return "An armored guardian with the ability to control and resist elemental attacks, disrupting the harmony of the Virtual World.";
        }
    }

    public class Cipher_Illusionist : Enemies
    {
        public Cipher_Illusionist(int health, int damage, int armor) : base(health, damage, armor)
        {
            VirusRank = 2 ;

            EnemyType = " Cipher Illusionist ";
        }

        public override string SkillInfo()
        {
            return "A digital illusionist that creates intricate ciphers, confusing avatars and disrupting combat strategies.";
        }
    }

    public class Stealth_Dynamo : Enemies
    {
        public Stealth_Dynamo(int health, int damage, int armor) : base(health, damage, armor)
        {
            VirusRank = 3 ;
            EnemyType = " Stealth Dynamo ";
        }

        public override string SkillInfo()
        {
            return "A stealthy adversary capable of infiltrating data streams, disrupting the flow of combat.";
        }
    }

    public class Black_Mamba : Enemies
    {
        public Black_Mamba (int health, int damage, int armor) : base(health, damage, armor)
        {
            VirusRank = 5;

            EnemyType = " Black Mamba ";
        }

        public override string SkillInfo()
        {
            return "A stealthy adversary capable of infiltrating data streams, disrupting the flow of combat.";
        }
    }
}
