namespace TheWorld.GameMechanics;

/// <summary>
/// Builds a <see cref="Player"/> one part at a time.
///
/// Each part gets its own With... method, and Build() puts the finished
/// player together.
/// </summary>
public record PlayerBuilder
{
    
    // Default Parameters for a Character ONE WAY (not necessarily a GOOD way)
    // To guarantee that a valid Character is always created...
    // TODO:  Find a better way!
    private string _name = "Frank";
    private PlayerLevel _level = PlayerLevel.Level1;
    private HealthPoints _healthPoints = HealthPoints.Create(20);
    private AbilityScore _abilities = AbilityScore.Create(10, 10, 10, 10, 10, 10)!;
    private Money _wallet = Money.Default;

    /// <summary>
    /// Does Nothing except forces the user to use the provided Factory Methods
    /// </summary>
    private PlayerBuilder() { }

    /// <summary>
    /// Start with a FROM method. The first natural place is the player's name.
    /// </summary>
    /// <param name="name">Will be Validated by the built in Validation method.</param>
    /// <returns></returns>
    public static PlayerBuilder FromName(string name) => new PlayerBuilder { _name = ValidateName(name) };

    //------------------------------------------------------------------------------------
    // With methods are how we "Build" the Player from its constituent parts.
    // Blindly handing the values to the class is the most basic way to do this and is 
    // Indistinguishable from the Factory method we wrote previously.  
    // This means, we can do better!
    //------------------------------------------------------------------------------------
    
    public PlayerBuilder WithLevel(PlayerLevel level) => this with { _level = level };
    public PlayerBuilder WithHealthPoints(HealthPoints hp) => this with { _healthPoints = hp };
    public PlayerBuilder WithAbilities(AbilityScore abilities) => this with { _abilities = abilities };
    public PlayerBuilder WithWallet(Money wallet) => this with { _wallet = wallet };
    
    /// <summary>
    /// Puts the player together from whatever parts have been set.
    /// </summary>
    public Player Build() => 
        Player.Create(_name, _level, _healthPoints, _abilities, _wallet);
    
    #region Future Projects!
    /// <summary>
    /// TODO:  Research:  JSON Serialization of Objects.  
    /// </summary>
    /// <param name="jsonString"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static PlayerBuilder FromJson(string jsonString) => throw new NotImplementedException("Not yet implemented");
    
    /// <summary>
    /// Use Pattern Matching to make sure the chosen name is Valid
    /// The `.Trim()` method used here gets rid of any leading or trailing White-Space characters.
    /// So, this handles the invalid name case of `null` as well as "                 ".
    /// TODO:  Add more cases to this switch statement to catch other possible invalid names.
    /// TODO:  Research:  Use "Regular Expressions" to validate a player name can ONLY be made up of
    /// Alphabet characters and valid punctuation inside of the name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static string ValidateName(string name) =>
        name.Trim() switch
        {
            null or "" => "Frank",
            _ => name.Trim()
        };
    #endregion
}
