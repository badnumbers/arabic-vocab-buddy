namespace ArabicVocabBuddy.Server.Models;
public record Section(
    int Number,
    IEnumerable<Unit> Units
);
