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
                new Unit(1, [
                    new VocabularyItem("تَماماً يا فَريد.", "Absolutely, Farid. ")
                    ])
                ])
        ]));
    }
}
