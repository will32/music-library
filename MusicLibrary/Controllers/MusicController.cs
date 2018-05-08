using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Lib;

namespace MusicLibrary.Controllers {
  public class MusicController : Controller {
    public string Index () {
      return "Hello world";
    }
  }
}