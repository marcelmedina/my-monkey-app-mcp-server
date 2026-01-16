using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Manage Monkey data and operations.
/// </summary>
public static class MonkeyHelper
{
    
    /// <summary>
    /// Seeds monkeys
    /// </summary>
    private static readonly IReadOnlyList<Monkey> SeededMonkeys = new List<Monkey>
    {
        new Monkey
        {
            Name = "Caesar",
            Location = "Congo",
            Details = "Caesar is the leader of the monkey troop in the Congo rainforest. " +
                      "He is known for his intelligence and strategic thinking.",
            AsciiArt = @"
　　　　　　　   ',
            .-`-,\__
              .""`   `,
            .'_.  ._  `;.
        __ / `      `  `.\ .--.
       /--,| 0)   0)     )`_.-,)
      |    ;.-----.__ _-');   /
       '--./         `.`/  `""`
          :   '`      |.
          | \     /  //
           \ '---'  /'
            `------' \
             _/       `--...
            "
        },
        new Monkey
        {
            Name = "Luna",
            Location = "Amazon",
            Details = "Luna is a playful monkey who loves to swing from tree to tree in the Amazon jungle. " +
                      "She is curious and adventurous.",
            AsciiArt = @"
               __------__
              /~          ~\
             |    //^\\//^\|
           /~~\  ||  o| |o|:~\
          | |6   ||___|_|_||:|
           \__.  /      o  \/'
            |   (       O   )
   /~~~~\    `\  \         /
  | |~~\ |     )  ~------~`\
 /' |  | |   /     ____ /~~~)\
(_/'   | | |     /'    |    ( |
       | | |     \    /   __)/ \
       \  \ \      \/    /' \   `\
         \  \|\        /   | |\___|
           \ |  \____/     | |
           /^~>  \        _/ <
          |  |         \       \
          |  | \        \        \
          -^-\  \       |        )
               `\_______/^\______/
            "
        },
        new Monkey
        {
            Name = "Milo",
            Location = "Borneo",
            Details = "Milo is a shy monkey who prefers to stay hidden in the dense forests of Borneo. " +
                      "He is gentle and kind-hearted.",
            AsciiArt = @"
           .""`"".
       .-./ _=_ \.-.
      {  (,(oYo),) }}
      {{ |   ""   |} }
      { { \(---)/  }}
      {{  }'-=-'{ } }
      { { }._:_.{  }}
      {{  } -:- { } }
      {_{ }`===`{  _}
     ((((\)     (/))))
            "
        }
    };

    /// <summary>
    /// Gets the seeded monkey data.
    /// </summary>
    /// <returns>A read-only list of seeded monkeys.</returns>
    public static IReadOnlyList<Monkey> GetMonkeys() => SeededMonkeys;

    /// <summary>
    /// Finds a seeded monkey by name.
    /// </summary>
    /// <param name="name">The monkey name to search for.</param>
    /// <returns>The matching monkey, or <see langword="null"/> if not found.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        name = name.Trim();
        return GetMonkeys().FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Picks a random monkey from the seeded list.
    /// </summary>
    /// <returns>A random monkey, or <see langword="null"/> if no monkeys are available.</returns>
    public static Monkey? GetRandomMonkey()
    {
        var monkeys = GetMonkeys();
        if (monkeys.Count == 0)
            return null;

        var index = Random.Shared.Next(monkeys.Count);
        return monkeys[index];
    }
}