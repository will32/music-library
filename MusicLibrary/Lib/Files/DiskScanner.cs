using System.Collections.Generic;
using System.IO;
using MusicLibrary.Models;
using MusicLibrary.Enums;

namespace MusicLibrary.Lib
{
  public static class DiskScanner
  {
    // get file/directory name from path
    private static IEnumerable<string> GetNames(IEnumerable<string> paths)
    {
      List<string> names = new List<string>();
      foreach (string path in paths)
      {
        names.Add(Path.GetFileName(path));
      }

      return names;
    }

    // get list of files in format of path
    private static IEnumerable<string> GetFileNames(string path)
    {
      string[] filePaths = Directory.GetFiles(path);
      return GetNames(filePaths);
    }

    // get list of dirs in format of path
    private static IEnumerable<string> GetDirNames(string path)
    {
      string[] dirPaths = Directory.GetDirectories(path);
      return GetNames(dirPaths);
    }

    public static IEnumerable<Models.File> Scan(string path)
    {
      IEnumerable<string> fileNames = GetFileNames(path);
      IEnumerable<string> dirNames = GetDirNames(path);

      List<Models.File> files = new List<Models.File>();

      foreach (string fileName in fileNames)
      {
        files.Add(new Models.File(fileName, FileType.File));
      }
      foreach (string dirName in dirNames)
      {
        files.Add(new Models.File(dirName, FileType.Folder));
      }

      return files;
    }
  }
}