using System.Security.Cryptography;
using TheWorld.GameMechanics;

namespace TheWorld.Rules;


public static class DiceRollStrategies
{
    /// <summary>
    /// Just roll the damn thing.
    /// </summary>
    public static int Default(Random rng, Dice dice) => dice.Roll(rng);
    
    // <summary>
    /// Roll twice and keep the Higher.
    /// </summary>
    public static int Advantage(Random rng, Dice dice) =>
        Enumerable.Range(0, 2)
            .Select(_ => dice.Roll(rng))
            .Max();
    
    /// <summary>
    /// Rolls three times and keeps the highest.
    /// </summary>
    public static int HighestOfThreeRolls(Random rng, Dice dice) =>
        Enumerable.Range(0, 3)
            .Select(_ => dice.Roll(rng))
            .Max();
    
    /// <summary>
    /// Rolls twice and keeps the lower.
    /// </summary>
    public static int Disadvantage(Random rng, Dice dice) =>
        Enumerable.Range(0, 2)
            .Select(_ => dice.Roll(rng))
            .Min(); 
    /// <summary>
    /// Strategies can also be Composed in fun ways!
    /// Hoo boy but it can get Dangerous!~
    /// TODO:  Spot the Monster hiding in this Strategy!
    /// </summary>
    public static DiceRollStrategy ClampRoll(int minRoll = 8, int maxRoll = 18, DiceRollStrategy? strategy = null) =>
        (rng, dice) =>
            dice.Roll(rng, strategy ?? HighestOfThreeRolls) switch
            {
                var roll when roll < minRoll =>
                    ClampRoll(minRoll, maxRoll, strategy)(rng, dice),
                var roll when roll > maxRoll =>
                    ClampRoll(minRoll, maxRoll, strategy)(rng, dice),
                var roll => roll
            };

    /// <summary>
    /// TODO:  A Critical Roll returns double the roll on the dice.
    /// </summary>
    public static int CriticalRoll(Random rng, Dice dice) =>
        dice.Roll(rng) * 2;

    /// <summary>
    /// TODO:  A Fumbled Roll returns half the roll on the dice.
    /// </summary>
    public static int Fumble(Random rng, Dice dice) =>
        dice.Roll(rng) / 2;
}
    
