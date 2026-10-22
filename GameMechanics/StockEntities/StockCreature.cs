namespace TheWorld.GameMechanics.StockEntities;

public static class StockCreatures
{
    public static Creature Goblin =>
        CreatureBuilder.FromName("Goblin")
            .WithHealthPoints(HealthPoints.Create(7))
            .WithAbilities(AbilityScore.Create(8, 14, 10, 10, 8, 8)!)
            .WithExperienceReward(50)
            .Build();
    
    public static Creature Dragon =>
        CreatureBuilder.FromName("Dragon")
            .WithHealthPoints(HealthPoints.Create(100))
            .WithAbilities(AbilityScore.Create(16, 12, 18, 11, 10, 17)!)
            .WithExperienceReward(200)
            .Build();
    
    public static Creature Skeleton =>
        CreatureBuilder.FromName("Skeleton")
            .WithHealthPoints(HealthPoints.Create(80))
            .WithAbilities(AbilityScore.Create(10, 8, 9, 10, 9, 10)!)
            .WithExperienceReward(70)
            .Build();
}