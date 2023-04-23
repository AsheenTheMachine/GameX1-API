using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameX1API.Controllers { }

public class BaseController : ControllerBase
{
    [NonAction]
    public string GetErrors()
    {
        return string.Join("; ", ModelState.Values
                               .SelectMany(x => x.Errors)
                               .Select(x => x.ErrorMessage));
    }
}

