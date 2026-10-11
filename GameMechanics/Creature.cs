namespace TheWorld.GameMechanics;

/// <summary>
/// Anything the players fight.  A goblin, a wolf, a dragon.
///
/// Same rules as <see cref="Player"/>:  a private constructor, and one door in
/// that checks every number.
/// </summary>
public record Creature
{
    public string Name { get; }

    public int CurrentHealth { get; }
    public int MaxHealth { get; }

    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }

    /// <summary>Experience the party earns for defeating it.</summary>
    public int ExperienceReward { get; }

    private Creature(string name,
        int currentHealth, int maxHealth,
        int strength, int dexterity, int constitution,
        int intelligence, int wisdom, int charisma,
        int experienceReward)
    {
        Name = name;
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        ExperienceReward = experienceReward;
    }

    /// <summary>
    /// Builds a creature, or refuses to.  Every creature in the program comes
    /// through here.
    /// </summary>
    public static Creature Create(string name,
        int currentHealth, int maxHealth,
        int strength, int dexterity, int constitution,
        int intelligence, int wisdom, int charisma,
        int experienceReward)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A creature needs a name.", nameof(name));

        if (maxHealth < 1)
            throw new ArgumentOutOfRangeException(
                nameof(maxHealth), maxHealth, "Max health is at least 1.");

        if (currentHealth < 0 || currentHealth > maxHealth)
            throw new ArgumentOutOfRangeException(
                nameof(currentHealth), currentHealth,
                $"Current health runs from 0 to max health ({maxHealth}).");

        if (strength < 3 || strength > 18)
            throw new ArgumentOutOfRangeException(
                nameof(strength), strength, "Ability scores run from 3 to 18.");

        if (dexterity < 3 || dexterity > 18)
            throw new ArgumentOutOfRangeException(
                nameof(dexterity), dexterity, "Ability scores run from 3 to 18.");

        if (constitution < 3 || constitution > 18)
            throw new ArgumentOutOfRangeException(
                nameof(constitution), constitution, "Ability scores run from 3 to 18.");

        if (intelligence < 3 || intelligence > 18)
            throw new ArgumentOutOfRangeException(
                nameof(intelligence), intelligence, "Ability scores run from 3 to 18.");

        if (wisdom < 3 || wisdom > 18)
            throw new ArgumentOutOfRangeException(
                nameof(wisdom), wisdom, "Ability scores run from 3 to 18.");

        if (charisma < 3 || charisma > 18)
            throw new ArgumentOutOfRangeException(
                nameof(charisma), charisma, "Ability scores run from 3 to 18.");

        if (experienceReward < 0)
            throw new ArgumentOutOfRangeException(
                nameof(experienceReward), experienceReward,
                "Experience reward can't be negative.");

        return new Creature(name,
            currentHealth, maxHealth,
            strength, dexterity, constitution,
            intelligence, wisdom, charisma,
            experienceReward);
    }
}
