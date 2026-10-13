# Lesson 6 - Builders

*One part at a time, and somebody else decides how.*

```
dotnet run
```

It builds the party and prints their sheets, same as last time.  Then open
`Program.cs`.  The party is two lines long now.  Follow them to
`StockPlayers.cs` and read how Bree gets made.  Then ask the question this
lesson is built on:

> **Every `With...` method takes whatever it's handed.  So what has the builder
> bought us?**

| File | What it is |
|---|---|
| `GameMechanics/PlayerBuilder.cs` | **Today's file.**  Builds a `Player` one part at a time, starting from a name. |
| `GameMechanics/StockEntities/StockPlayers.cs` | Bree and Tamsin, put together with the builder. |
| `GameMechanics/Player.cs` | A player, made of parts since Lesson 5.  It has two doors now.  Find both. |
| `GameMechanics/Dice.cs` | Back from Lesson 2, with a few changes.  Read the factory again before you use it. |
| `GameMechanics/Creature.cs` | Made of parts now, the way we left it at the end of Lesson 5.  Still one door in. |
| `Display/CharacterSheet.cs` | Prints a sheet. |
| `Program.cs` | Builds the party and the goblin.  Keep it short. |

## A new address

The project has a name now.  Its root namespace is `TheWorld`, and the types a
game is made of live in `TheWorld.GameMechanics`:  dice, players, creatures,
and the parts they're built from.  Ready-made characters get their own corner,
`TheWorld.GameMechanics.StockEntities`.  Every folder has the same name as
its namespace, so the file tree and the code agree about where things are.

That's why `Program.cs` opens with three `using` lines.  When the compiler
can't find a type you know exists, check those first.

## The one new idea

**A builder puts an object together one part at a time, and hands it over
finished.**

Start with the cost, because the code says it out loud.  Read the comment above
the `With...` methods.  Handing values straight through is the plainest way to
build a player, and it checks exactly as much as Lesson 5's factory did.  A
builder is also a whole second class whose only job is making the first one.
So far it has bought us readable lines and little else.

The readable lines matter.  Put `StockPlayers.cs` beside Lesson 5's
twelve-argument call and read both out loud.  Every part of Bree is named where
it's set, so a swap shows up when you read it.  Skip a part and it gets a
default.  And `Build()` is the one door into `Player`, the way `Create` was in
Lesson 2.

**Today's goal is `With...` methods that earn their keep.**

## And the second half:  strategies, again

Lesson 4 handed `Shuffle` a decision from outside.  The deck kept its rules,
and the caller chose the shuffle.

Ability scores are the same kind of decision.  One table rolls 4d6 and drops
the lowest.  Another rolls 3d6 straight down the sheet, and a third hands
everybody the same six numbers to place.  `Player` has no business knowing
which table it's sitting at.

So a `With...` method can take a part, or it can take **the way to make the
part**.  The second kind is a strategy, and it's why `Dice` came back.

## Things to notice before you change anything

Everything here works exactly the way it was written.  Your job for now is to
explain it.

1. **Find both doors.**  `Player` has two methods called `Create`.  Which one
   does `Build()` use?  Who else can call it?  Look up what `internal` means.
2. **Follow one `With`.**  `PlayerBuilder` is a `record`, and every `With...`
   ends in `this with { ... }`.  What comes back?  What happens to the builder
   you called it on?
3. **Start somewhere.**  Try `new PlayerBuilder()`.  Why is the compiler
   unhappy, and what does it want from you first?
4. **Leave out the name.**  Build a player from `"   "`.  Who did you get?
5. **Break a score.**  Give Bree a strength of 25 in `StockPlayers.cs` and run
   it.  Where does the program crash?  Where was the actual mistake?  What
   does the `!` on that line do?

## Today's steps

1. **List what each `With...` trusts.**  For every one, write down something a
   caller could hand it that's wrong, and say where the program finds out.
2. **The first strategy.**  Write a `With...` that takes a way to make ability
   scores in place of the scores themselves.  Then write a strategy that rolls
   them with `Dice`.  Seed the `Random` so two runs agree.
3. **A second strategy.**  Build the same player with each one, and print both
   sheets.
4. **Put the party on the new methods.**  Rebuild Bree and Tamsin in
   `StockPlayers.cs`, and delete every `!`.  Which crash from the notice list
   can't happen anymore?
5. **Pick the next part.**  Health, level, or the wallet.  Decide whether it
   wants a strategy too, and defend the answer either way.
6. **`CreatureBuilder`, on your own.**  Same idea, second time.  Which of your
   `With...` methods carry over, and which belong to players alone?

## Went beyond?

- **Frank.**  A blank name quietly turns into somebody else.  Refuse it or
  repair it?  Lesson 2 gave you the argument.  Make the call and change
  `ValidateName` to match.
- **Names with rules.**  Look up regular expressions, and make a name allow
  letters and sensible punctuation alone.  Which names did you just make
  illegal by accident?
- **A player from a file.**  `FromJson` is waiting at the bottom of
  `PlayerBuilder.cs`.  Look up JSON serialization in C#, and decide which of
  the builder's checks a file should have to pass.

## Done for today?

> Name one `With...` method you changed, the mistake it can catch now, and the
> strategy you handed it.  Say why that decision belongs outside `Player`.
