namespace TheWorld.GameMechanics;

/// <summary>
/// Anything the players fight.  A goblin, a wolf, a dragon.
///
/// Still built the Lesson 5 way:  a private constructor, and one door in that
/// checks every number.  <see cref="Player"/> has moved on to a builder.
/// Creature is next.
/// </summary>
public record Creature
{
    public string Name { get; }

    public HealthPoints HealthPoints { get; } 
    
    public AbilityScore Abilities { get; }

    /// <summary>TODO: This is probably an object in its own rite. Experience the party earns for defeating it.</summary>
    public int ExperienceReward { get; }

    private Creature(string name,
        HealthPoints healthPoints,
        AbilityScore abilityScore,
        int experienceReward)
    {
        Name = name;
        HealthPoints = healthPoints;
        Abilities = abilityScore;
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

        var healthPoints = TheWorld.GameMechanics.HealthPoints.Create(maxHealth);

        var creatureStats =
            TheWorld.GameMechanics.AbilityScore.Create(strength, dexterity, constitution, intelligence, wisdom, charisma)
            ?? TheWorld.GameMechanics.AbilityScore.Create(10, 10, 10, 10, 10, 10)!;
        
        if (experienceReward < 0)
            throw new ArgumentOutOfRangeException(
                nameof(experienceReward), experienceReward,
                "Experience reward can't be negative.");

        return new Creature(name,
            healthPoints,
            creatureStats,
            experienceReward);
    }
    
    internal static Creature Create(string name, HealthPoints healthPoints,
        AbilityScore abilityScore, int experienceReward) => new(name, healthPoints, abilityScore, experienceReward);
    
}
