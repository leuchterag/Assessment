using Microsoft.AspNetCore.Mvc;
using Assessment.Models;

namespace Assessment.Controllers
{
  // Controller für die Verwaltung von TimelogType.
  [Route("/timelogtypes")]
  [ApiController]
  public class TimelogTypesController : ControllerBase
  {
    private static readonly List<TimelogTypeAPI> TimelogTypes = new List<TimelogTypeAPI>
        {
            // Statische Liste von TimelogType als Beispieldaten.
            new TimelogTypeAPI { TimelogTypeId = 1, TimelogType = "Hausaufgaben", Budget = 60 },
            new TimelogTypeAPI { TimelogTypeId = 2, TimelogType = "Lernen", Budget = 120 },
            new TimelogTypeAPI { TimelogTypeId = 3, TimelogType = "Pause", Budget = 30 }
        };

    // Ruft alle TimelogTypes ab.
    [HttpGet]
    public IEnumerable<TimelogTypeAPI> GetTimelogTypes()
    {
      return TimelogTypes;
    }

    // Ruft einen spezifischen TimelogType anhand seiner ID ab.
    [HttpGet("{timelogTypeId}")]
    public ActionResult<TimelogTypeAPI> GetTimelogType(int timelogTypeId)
    {
      var timelogType = TimelogTypes.FirstOrDefault(t => t.TimelogTypeId == timelogTypeId);
      if (timelogType == null)
      {
        return NotFound();
      }
      return timelogType;
    }

    // Erstellt einen neuen TimelogType.
    [HttpPut]
    public ActionResult<TimelogTypeAPI> CreateTimelogType([FromBody] TimelogTypeAPI newTimelogType)
    {
      if (newTimelogType == null)
      {
        return BadRequest();
      }

      // Setze eine neue ID für den TimelogType.
      int newId = TimelogTypes.Any() ? TimelogTypes.Max(t => t.TimelogTypeId) + 1 : 1;
      newTimelogType.TimelogTypeId = newId;

      TimelogTypes.Add(newTimelogType);
      return CreatedAtAction(nameof(GetTimelogType), new { timelogTypeId = newTimelogType.TimelogTypeId }, newTimelogType);
    }
  }
}

