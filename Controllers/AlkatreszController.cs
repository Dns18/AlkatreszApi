using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlkatreszController : ControllerBase
{
    private static List<Alkatresz> alkatreszek = new List<Alkatresz>
    {
        new Alkatresz { Id = 1, Nev = "Motor", Ar = 1000, Keszlet = 10 },
        new Alkatresz { Id = 2, Nev = "AblakUveg", Ar = 500, Keszlet = 5 },
        new Alkatresz { Id = 3, Nev = "Kerek", Ar = 200, Keszlet = 20 }
    };

    [HttpGet]
    public ActionResult<List<Alkatresz>> GetAll()
    {
        return Ok(alkatreszek);
    }

    
    [HttpGet("{id}")]
    public ActionResult<Alkatresz> GetById(int id)
    {
        var alkatresz = alkatreszek.FirstOrDefault(a => a.Id == id);
        if(alkatresz == null)
        {
            return NotFound();
        }
        return Ok(alkatresz);
    }

    [HttpPost]
    public ActionResult<Alkatresz> Create(Alkatresz uj)
    {
        if(alkatreszek.Count == 0)
        {
            uj.Id = 1;
        }
        else
        {
            uj.Id = alkatreszek.Max(a => a.Id) + 1;
        }
        //uj.Id = alkatreszek.Count == 0 ? 1 : alkatreszek.Max(a => a.Id) + 1; Rövdebb változat.
        alkatreszek.Add(uj);
        return CreatedAtAction(nameof(GetById), new { id = uj.Id}, uj);
    }
}