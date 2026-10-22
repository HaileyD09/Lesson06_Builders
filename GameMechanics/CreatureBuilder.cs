//A creature comes from an archetype whose numbers are already decided, so there's no "how"
// to choose -- strategies are for rolling, and a creature doesn't roll.

namespace TheWorld.GameMechanics;

public record CreatureBuilder
{
    private string _name = "Bob";
    private HealthPoints _healthPoints = HealthPoints.Create(20);
    private AbilityScore _abilities = AbilityScore.Create(10, 10, 10, 10, 10, 10)!;
    private int _experienceReward = 10;

    private CreatureBuilder() { }
    
    public static CreatureBuilder FromName(string name) => new() { _name = name };
    public CreatureBuilder WithHealthPoints(HealthPoints hp) => this with { _healthPoints = hp };
    public CreatureBuilder WithAbilities(AbilityScore abilities) => this with { _abilities = abilities };
    public CreatureBuilder WithExperienceReward(int experienceReward) => this with { _experienceReward = experienceReward };
    public Creature Build() => Creature.Create(_name, _healthPoints, _abilities, _experienceReward);
}