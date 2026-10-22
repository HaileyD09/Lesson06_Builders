using TheWorld.Display;
using TheWorld.GameMechanics.StockEntities;
using TheWorld.Rules;
using TheWorld.GameMechanics;

using static TheWorld.Rules.DiceRollStrategies;

// This is the one Random Number Generator for the whole program.  We inject it everywhere a roll happens.
Random rng = new();

// The party.  Bree is the wizard;  Tamsin is the fighter.
var bree = StockPlayers.Bree;
var tamsin = StockPlayers.Tamsin;

// What they're up against.
var goblin = StockCreatures.Goblin;

var dragon = StockCreatures.Dragon;

var skeleton = StockCreatures.Skeleton;

var start = PlayerBuilder.FromName("Hero");
var rookie = start.Build();
var veteran = start.WithLevel(PlayerLevel.FromExperience(500)).Build();

Console.WriteLine($"Tamsin swings at the goblin:  {tamsin.AttackBonus:+0;-0;+0} to hit, against AC {goblin.ArmorClass}.");
Console.WriteLine($"The goblin swings back:  {goblin.AttackBonus:+0;-0;+0} to hit, against AC {tamsin.ArmorClass}.");

Console.WriteLine(rookie.Level.Level);
Console.WriteLine(veteran.Level.Level);

PlayerBuilder.FromName("Hardcore").WithAbilities(rng).Build().ShowSheet();
PlayerBuilder.FromName("Lucky")
    .WithAbilities(rng, Dice.D6 with { Count = 3 }, HighestOfThreeRolls)
    .Build().ShowSheet();
PlayerBuilder.FromName("LuckyWeak")
    .WithAbilities(rng, Dice.Coin, Disadvantage)
    .Build().ShowSheet();
    
var player = PlayerBuilder
    .FromName("Kyroki")
    .WithHealthPoints(rng, Dice.D6 with { Count = 2, Modifier = 1 })
    .WithAbilities(rng, Dice.D20, ClampRoll(strategy: Advantage))
    .WithWallet(Money.Roll(rng, Dice.D100, Default))
    .Build();

//for (int i = 0; i < 20; i++)
//{
    //Console.WriteLine(ClampRoll(strategy: Advantage)(rng, Dice.D20));
//}

bree.ShowSheet();
tamsin.ShowSheet();
goblin.ShowSheet();
player.ShowSheet();
dragon.ShowSheet();
skeleton.ShowSheet();