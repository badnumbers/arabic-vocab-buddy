namespace ArabicVocabBuddy.Models;
public record Unit(
    int Number,
    IEnumerable<VocabularyItem> Vocabulary
);
