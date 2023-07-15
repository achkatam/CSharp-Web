namespace WebApiDemo.Controllers;

using Microsoft.AspNetCore.Mvc;

public class ValuesController : ApiController
{
    private readonly Dictionary<int, string> values = new()
        {
        { 1, "value1" },
        { 2, "value2" },
        { 3, "value3" },
        { 4, "value4" },
        { 5, "value5" },
    };

    [HttpGet]
    [Route("GetValues")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        if (values.ContainsKey(id))
        {
            return Ok(values[id]);
        }

        return NotFound();
    }
}