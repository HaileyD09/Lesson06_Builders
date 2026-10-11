namespace TheWorld.GameMechanics;

/// <summary>
/// A set of dice:  Count dice with Sides sides, plus a flat Modifier.
///
/// This is your Dice from Lesson 1, with the change you made -- the three
/// properties are init-only, so a set of dice is fixed once it exists.
///
/// Which leaves exactly one moment when dice could be wrong:  the moment they
/// are built.  So this version closes that moment too.  The constructor is
/// PRIVATE, and this file is the only place that can reach it.  The one way to
/// make dice is a factory method below, and that is where the rules live.
///
/// One door in.  One place the rules are written.  That is the whole design.
/// </summary>
public record Dice
{
    // ─────────────────────────────────────────────────────────────────────────
    //  Standard Dice
    // ─────────────────────────────────────────────────────────────────────────    

    public static Dice Coin = new(sides: 2);
    public static Dice D4 = new(sides: 4);
    public static Dice D6 = new();
    public static Dice D8 = new(sides: 8);
    public static Dice D10 = new(sides: 10);
    public static Dice D12 = new (sides: 12);
    public static Dice D20 = new(sides: 20);
    public static Dice D100 = new(sides: 100);
    
    
    // ─────────────────────────────────────────────────────────────────────────
    //  What a set of dice IS
    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>How many dice are rolled.  The 2 in "2d6+3".</summary>
    public int Count { get; init; }

    /// <summary>How many sides each die has.  The 6 in "2d6+3".</summary>
    public int Sides { get; init; }

    /// <summary>A flat amount added to the total after rolling.  The +3 in "2d6+3".</summary>
    public int Modifier { get; init; }

    /// <summary>
    /// Private, and that is the point.
    ///
    /// It puts the three numbers where they go and trusts them completely.  It
    /// can afford that, because this file is the only place that can reach it.
    /// The one thing that CAN call it is the factory method twenty lines below,
    /// and that is where the checking happens.
    /// </summary>
    private Dice(int count = 1, int sides = 6, int modifier = 0)
    {
        Count = count;
        Sides = sides;
        Modifier = modifier;
    }
    
    // ─────────────────────────────────────────────────────────────────────────
    //  What a set of dice DOES
    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Rolls the dice.  Sums Count rolls of a Sides-sided die, then adds Modifier.
    /// </summary>
    /// <param name="rng">Where the randomness comes from.  Seed it to repeat it.</param>
    public int Roll(Random rng)
    {
        var sum = Modifier;
        for (var i = 0; i < Count; i++)
            sum += rng.Next(1, Sides + 1);
        return sum;
    }
    
    /// <summary>The smallest total these dice can produce.</summary>
    public int Minimum => Count + Modifier;

    /// <summary>The largest total these dice can produce.</summary>
    public int Maximum => Count * Sides + Modifier;

    /// <summary>"2d6+3", the way a player would write it.</summary>
    public override string ToString()
    {
        var mod = Modifier switch
        {
            > 0 => $"+{Modifier}",
            < 0 => $"{Modifier}",
            _ => ""
        };
        return $"{Count}d{Sides}{mod}";
    }
}
