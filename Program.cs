using TheWorld.GameMechanics;
using TheWorld.Display;
using TheWorld.GameMechanics.StockEntities;
using TheWorld.Rules;

// The party.  Bree is the wizard;  Tamsin is the fighter.
var bree = StockPlayers.Bree;
var tamsin = StockPlayers.Tamsin;

// What they're up against.
var goblin = Creature.Create("Goblin", 7, 7, 8, 14, 10, 10, 8, 8, 50);

bree.ShowSheet();
tamsin.ShowSheet();
goblin.ShowSheet();

Console.WriteLine($"Tamsin swings at the goblin:  {tamsin.AttackBonus:+0;-0;+0} to hit, against AC {goblin.ArmorClass}.");
Console.WriteLine($"The goblin swings back:  {goblin.AttackBonus:+0;-0;+0} to hit, against AC {tamsin.ArmorClass}.");
