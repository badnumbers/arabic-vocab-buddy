namespace ArabicVocabBuddy.Server.Models;
public record Unit(
    int Number,
    IEnumerable<VocabularyItem> Vocabulary
);
