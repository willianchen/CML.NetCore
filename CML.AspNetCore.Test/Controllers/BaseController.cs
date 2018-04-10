using CML.AspNetCore.Authorization;
using CML.AspNetCore.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CML.AspNetCore.Test.Controllers
{
    [ApiAuthorize]
    [ExceptionHandler]
    public class BaseController : Controller
    {
    }
}