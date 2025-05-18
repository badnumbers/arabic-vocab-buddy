namespace ArabicVocabBuddy.Models;
public record Section(
    int Number,
    IEnumerable<Unit> Units
);
