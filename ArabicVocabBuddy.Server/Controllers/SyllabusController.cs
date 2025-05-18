using ArabicVocabBuddy.Server.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SyllabusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new Syllabus([
            new Section(1, [
                new Unit(10, [
                    new VocabularyItem("تَماماً يا فَريد.", "Absolutely, Farid."),
                    new VocabularyItem("أَهْلاً يا مَها.", "Hello, Maha."),
                    new VocabularyItem("أَنا مِن فَرَنْسا.", "I am from France."),
                    ])
                ]),
                new Section(2, [
                new Unit(4, [
                    new VocabularyItem("اَلْمَدينة هُناك", "The city is there."),
                    new VocabularyItem("هُناك مَحْفَظة في شَنْطَتي", "There is a wallet in my bag."),
                    new VocabularyItem("هُناك كِتاب جَديد", "There is a new book."),
                    ])
                ]),
                new Section(2, [
                new Unit(5, [
                    new VocabularyItem("حاسوب", "computer"),
                    new VocabularyItem("كُرْسي", "chair"),
                    new VocabularyItem("هٰذا كُرْسي.", "This is a chair.")
                    ])
                ]),new Section(2, [
                new Unit(6, [
                    new VocabularyItem("موزة", "banana"),
                    new VocabularyItem("هٰذِهِ موزة.", "This is a banana."),
                    new VocabularyItem("حَليب", "milk")
                    ])
                ]),
                new Section(2, [
                new Unit(7, [
                    new VocabularyItem("صَديقهُ بوب", "his friend Bob"),
                    new VocabularyItem("أَبي وَصَديقهُ عُمَر", "my father and his friend Omar"),
                    new VocabularyItem("صَديقها جورْج", "her friend George"),
                    ])
                ])
        ]));
    }
}
