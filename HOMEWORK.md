# Homework - Refactor the Creature

*Twelve numbers, and which one is which.*

**About fifteen minutes.**  If you hit fifteen and you're still stuck, stop.
Write down the exact line that stopped you and bring it to class.  That note is
worth more than another hour of guessing.

## Getting the code

You forked the starter in class.  Keep working in that fork, because the
`AbilityScores` you built in class is what this homework uses.

If you haven't forked it yet, [fork the Lesson 5 starter](https://github.com/cox-programming-classes/Lesson05_Composition/fork),
then open your fork in GitHub Desktop with **Code > Open with GitHub Desktop**.
The starter doesn't have `AbilityScores` yet, so you'll need to build it first
(steps 3 to 5 in `README.md`).  Ask Sparky to walk you through it.

## What we did in class

Bree is the party's wizard, and her sheet came out with intelligence 12 and
wisdom 15.  Two numbers swapped in a twelve-argument call.  It compiled, it ran,
and every guard in `Player.Create` passed, because 12 and 15 are both legal
scores.

**A guard checks what a number is.  It can't check which number it was meant to
be.**

That's **primitive obsession** again, in a new shape:

| | Last time | This time |
|---|---|---|
| the symptom | **one** value with a rule, stored as a bare `int` | **six** values that only mean something together, stored as six bare `int`s |
| what goes wrong | an illegal value gets through | a legal value lands in the wrong place |
| the fix | a type that owns the rule | a type that names the group |

So we built a type that names the group.  `AbilityScores` holds the six scores,
and the 3-to-18 rule moved in with them.  Then `Player` got one:

```csharp
// before:  twelve parameters, six of them scores
Player.Create("Bree", 3, 900, 16, 16, 8, 14, 13, 15, 12, 10, 40);

// after:  the scores travel together, as one thing
var breeScores = AbilityScores.Create(8, 14, 13, 15, 12, 10);
Player.Create("Bree", 3, 900, 16, 16, breeScores, 40);
```

Building a type out of other types is **composition**.  A `Player` *has*
`AbilityScores`, the same way a `Card` has a `Suit`.

## The assignment

`Creature` has the same six `int`s and the same six guards that `Player` used
to have.  Give it the same treatment.

When you're done:

1. **`Creature` has an `AbilityScores`.**  The six score properties are gone,
   and one property holds all of them.
2. **`Creature.Create` takes an `AbilityScores`.**  The six score parameters are
   gone, and so are the six 3-to-18 guards.  The rule lives in one place now.
3. **The goblin's line in `Program.cs` builds its scores first**, the way Bree's
   does.
4. **The `Creature` halves of `CharacterSheet.cs` and `Combat.cs` compile.**
5. **The program prints exactly what it printed before.**  A refactor changes
   the shape of the code and leaves the behavior alone.

Use the `AbilityScores` you already have.  Don't make a second one for
creatures.  The whole point is that the second type to use it gets it for free.

### Your map is `Player.cs`

You already did this once, in class, to `Player`.  Open `Player.cs` and
`Creature.cs` side by side.  Every change you made to one is a change the other
needs.  If your class named things differently from this page -- `Scores` where
this page says `Abilities`, say -- use your names.

## Checking your work

**Expect a red build halfway through.**  The moment `Creature` loses its six
properties, every line that used them breaks.  That's normal.  The compiler's
list of errors is your to-do list.  Work down it.

The two errors you'll see most:

| Error | What it means here |
|---|---|
| **CS1061**, *'Creature' does not contain a definition for 'Strength'* | a caller still reaches for the old property.  It wants `creature.Abilities.Strength` now. |
| **CS1501**, *No overload for method 'Create' takes 10 arguments* | a call still passes six loose scores.  Build an `AbilityScores` first and pass that. |

When it builds, run it.  The goblin's part of the output should match this,
character for character:

```
== Goblin ==  worth 50 XP
   HP 7/7
   STR  8 (-1)   DEX 14 (+2)   CON 10 (+0)
   INT 10 (+0)   WIS  8 (-1)   CHA  8 (-1)
```

and so should the two combat lines at the bottom.  Then search the project for
`18`.  How many places say "3 to 18" now?

## Bonus level:  `Level` and `Experience`

Optional, and there's no wrong answer.  The battle against primitive obsession
isn't over.  `Player` still has two `int`s called `Level` and `Experience`, and
you already have every tool you'd need to start on them.  You don't need to
change any code.  Think about two questions:

1. **Is `Level` part of a character's stats, or something separate?**  It's a
   number on the character sheet, like strength.  Does it belong in the same
   box?  How often does each one change, and why?
2. **Are `Level` and `Experience` really independent?**  Bree is level 3 with
   900 XP.  Could she be level 3 with 0 XP?  Level 20 with 900?  If one of the
   two numbers can be worked out from the other, should the code store both?

Write a few sentences on either question, below your answer about `Creature`.
Bring your answer to class -- the room won't agree, and that's the point.

## What to turn in

**Push your repository to GitHub and submit the URL.**  In GitHub Desktop, type a
summary, **Commit to main**, then **Push origin**.  A commit you have yet to push
is still sitting on your laptop.

Then answer one question, in a comment at the top of `Creature.cs` or in the
submission box:

> **What mistake can't happen in `Creature` now that could happen before?**

One sentence is plenty.

## What good work looks like

| Stage | What it means |
|---|---|
| **Getting Started** | The build is red, or `Creature` still has its six score properties. |
| **Got It Working** | `Creature` has an `AbilityScores`, `Create` takes one, the build is green, and the output matches what it printed before. |
| **Made It Mine** | ...and the 3-to-18 rule lives only in `AbilityScores`, with no copy left in `Creature`, and your sentence names a real mistake that no longer compiles. |
| **Went Beyond** | ...and you found the next group.  Two more numbers in `Creature` always travel together.  Name them, say what type they want to be, and say what rule it would keep.  Don't build it yet.  Or take on the bonus level, and argue for an answer. |

**Made It Mine is the target.**

## Stuck?

Ask Sparky, the Flint helper for this lesson.  Sparky will help with syntax and
compiler errors all day.  It'll ask you questions about the design, because the
design is yours.
