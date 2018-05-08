using Microsoft.AspNetCore.Mvc;

namespace MusicLibrary.Controllers {
  public class HomeController : Controller {
    public string Index () {
      return "Hello world";
    }
  }
}