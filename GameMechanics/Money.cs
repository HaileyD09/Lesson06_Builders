namespace TheWorld.GameMechanics;

public record Money
{
    public static Money Default => new(0);
    public static Money Create(int gold) => new(gold);

    public static Money Roll(Random rng, Dice hitDice, DiceRollStrategy rollStrategy) =>
        new(rollStrategy(rng, hitDice));

    /// <summary>
    /// TODO:  This is so much more complicated!
    /// </summary>
    public int Gold { get; }

    private Money(int gold) 
    {
        Gold = gold;
    }
}