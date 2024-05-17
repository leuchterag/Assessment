using Microsoft.AspNetCore.Mvc;
using Assessment.Models;

namespace Assessment.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TimelogTypesController : ControllerBase
    {
        private static List<TimelogTypeResponse> _timelogTypes = new List<TimelogTypeResponse>
        {
            new TimelogTypeResponse { timelogTypeId = 1, timelogType = "Entwicklung", budget = 120 },
            new TimelogTypeResponse { timelogTypeId = 2, timelogType = "Design", budget = 100 },
            new TimelogTypeResponse { timelogTypeId = 3, timelogType = "Projektmanagement", budget = 90.5 },
            new TimelogTypeResponse { timelogTypeId = 4, timelogType = "Ferien", budget = 111 },
            new TimelogTypeResponse { timelogTypeId = 5, timelogType = "Umzug", budget = 230 }
        };

        /// <summary>
        /// Gibt alle Zeittypen zurück.
        /// </summary>
        /// <returns>Liste der Zeittypen.</returns>
        [HttpGet]
        public ActionResult<List<TimelogTypeResponse>> GetTimelogTypes()
        {
            return _timelogTypes;
        }

        /// <summary>
        /// Erstellt einen neuen Zeittyp.
        /// </summary>
        /// <param name="request">Das Anforderungsobjekt mit Details zum neuen Zeittyp.</param>
        /// <returns>Der erstellte Zeittyp.</returns>
        [HttpPut]
        public IActionResult CreateTimelogType([FromBody] TimelogTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTimelogType = new TimelogTypeResponse
            {
                timelogTypeId = request.timelogTypeId,
                timelogType = request.timelogType,
                budget = request.budget
            };

            _timelogTypes.Add(newTimelogType);
            return Ok(newTimelogType);
        }

        /// <summary>
        /// Ruft einen spezifischen Zeittyp anhand seiner ID ab.
        /// </summary>
        /// <param name="timelogTypeId">Die ID des abzurufenden Zeittyps.</param>
        /// <returns>Der Zeittyp mit der angegebenen ID.</returns>
        [HttpGet("{timelogTypeId}")]
        public ActionResult<TimelogTypeResponse> GetTimelogType(int timelogTypeId)
        {
            var timelogType = _timelogTypes.FirstOrDefault(t => t.timelogTypeId == timelogTypeId);
            if (timelogType == null)
            {
                return NotFound();
            }
            return timelogType;
        }
    }
}
