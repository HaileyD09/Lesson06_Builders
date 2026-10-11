# Homework - Build the Creature

*Players get rolled.  Creatures come from a recipe.*

**About thirty minutes.**  If you hit thirty and you're still stuck, stop.
Write down the exact line that stopped you and bring it to class.  That note is
worth more than another hour of guessing.

## Getting the code

[Fork the Lesson 6 starter](https://github.com/cox-programming-classes/Lesson06_Builders/fork),
then open your fork in GitHub Desktop with **Code > Open with GitHub Desktop**.

You'll also need your Lesson 5 fork open beside it, because the `Creature` you
refactored there is coming with you.  If your Lesson 5
homework isn't finished, ask Sparky to walk you through it first.  It's step 1
below either way.

## What we did in class

`Player.Create` could only make one kind of player:  level 1, 20 hit points, an
empty purse.  Giving it a parameter for every part would have put us right back
at the twelve-argument line that swapped Bree's scores.

So we built a `PlayerBuilder`.  It starts from a name, takes one part at a
time, and `Build()` hands over the finished player:

```csharp
PlayerBuilder.FromName("Bree")
    .WithLevel(PlayerLevel.FromExperience(200))
    .WithHealthPoints(HealthPoints.Create(16))
    .WithAbilities(AbilityScore.Create(8, 14, 13, 12, 15, 10)!)
    .WithWallet(Money.Create(40))
    .Build();
```

Every part is named where it's set.  Any part you skip gets a default.  And
because `PlayerBuilder` is a `record`, each `With...` hands back a new builder
and leaves the old one alone.

Then we gave the builder **strategies**.  A `With...` method can take a part,
or it can take the way to make the part:

```csharp
PlayerBuilder.FromName("Kyroki")
    .WithAbilities(rng, Dice.D20, ClampRoll(strategy: Advantage))
    .Build();
```

## The assignment

Give `Creature` a builder of its own.

This one is smaller than `PlayerBuilder`, and that's on purpose.  A player is
one of a kind, so their numbers get rolled.  A creature comes from an
**archetype**.  Every goblin is built from the same goblin recipe, so a
creature's numbers get set directly, and the strategies can wait.

When you're done:

1. **Your Lesson 5 `Creature` lives in this project.**  It already has an
   `AbilityScore` and a `HealthPoints`.  Copy your `Creature.cs` over the one
   in `GameMechanics/`.  Change its first line to
   `namespace TheWorld.GameMechanics;`.  If your class used different names,
   switch to this project's.  `AbilityScores` becomes `AbilityScore`, for
   one.
2. **`Creature` has an `internal` `Create` that takes its parts**, the way
   `Player` does.  That's the door your builder uses.
3. **`CreatureBuilder` exists, in `GameMechanics/`.**  It starts with
   `FromName`, and it has `WithAbilities` and `WithHealthPoints`, each taking
   the part directly.  `Build()` puts the creature together.
4. **`StockCreatures` exists, in `GameMechanics/StockEntities/`.**  The goblin
   moves in first, with the same numbers it has now.  Then add at least two
   more creatures of your own.
5. **`Program.cs` gets its goblin from `StockCreatures`.**

Your map is `PlayerBuilder.cs` and `StockPlayers.cs`.  Open each one beside the
file you're writing.  Most of what you need is already there, once.

## Checking your work

**Expect a red build after step 1.**  This project's `CharacterSheet.cs` and
`Combat.cs` were written for the flat `Creature`, so their creature halves still
reach for the old properties.  The compiler's list of errors is your to-do
list.  Work down it.

The errors you'll see most:

| Error | What it means here |
|---|---|
| **CS0246**, *The type or namespace name 'AbilityScores' could not be found* | your class used a different name.  Use `AbilityScore`. |
| **CS1061**, *'Creature' does not contain a definition for 'CurrentHealth'* | a caller still reaches for the old property.  It wants `creature.HealthPoints.CurrentHealth` now. |
| **CS0122**, *'Creature.Creature(...)' is inaccessible due to its protection level* | your builder is calling the constructor.  Call the `internal` `Create` instead. |

When it builds, run it.  The goblin's part of the output should match this,
character for character:

```
== Goblin ==  worth 50 XP
   HP 7/7
   STR  8 (-1)   DEX 14 (+2)   CON 10 (+0)
   INT 10 (+0)   WIS  8 (-1)   CHA  8 (-1)
```

## What to turn in

**Push your repository to GitHub and submit the URL.**  In GitHub Desktop, type
a summary, **Commit to main**, then **Push origin**.  A commit you have yet to
push is still sitting on your laptop.

Then answer one question, in a comment at the top of `CreatureBuilder.cs` or
in the submission box:

> **`PlayerBuilder` has strategies and `CreatureBuilder` doesn't.  Why does
> that fit what a creature is?**

A sentence or two is plenty.

## What good work looks like

| Stage | What it means |
|---|---|
| **Getting Started** | The build is red, or `Creature` still has its loose health and score properties. |
| **Got It Working** | `Creature` has an `AbilityScore` and a `HealthPoints`, `CreatureBuilder` builds the goblin, the build is green, and the goblin prints exactly what it printed before. |
| **Made It Mine** | ...and `StockCreatures` has at least three creatures that really are different from each other, and your answer says something true about the difference between a player and a creature. |
| **Went Beyond** | ...and you gave one archetype some variety.  Every goblin from the same recipe, each one a little different:  a `With...` that rolls its hit points from `Dice`.  Or decide where `ExperienceReward` belongs in the builder, and defend it. |

**Made It Mine is the target.**

## Stuck?

Ask Sparky, the Flint helper for this lesson.  Sparky will help with syntax,
compiler errors, and bringing your Lesson 5 `Creature` across, all day.  It'll
ask you questions about the design, because the design is yours.
