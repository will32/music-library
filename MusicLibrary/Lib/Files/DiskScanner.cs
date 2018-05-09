using System.Collections.Generic;
using System.IO;
using MusicLibrary.Models;
using MusicLibrary.Enums;

namespace MusicLibrary.Lib
{
  public static class DiskScanner
  {
    // get file/directory name from path
    private static string GetName(string path)
    {
      return Path.GetFileName(path);
    }
    private static IEnumerable<string> GetNames(IEnumerable<string> paths)
    {
      List<string> names = new List<string>();
      foreach (string path in paths)
      {
        names.Add(GetName(path));
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

    public static Models.File Scan(string path)
    {
      if (System.IO.File.Exists(path))
      {
        return new Models.File(GetName(path), FileType.File, path);
      }

      Models.File rootFile = new Models.File(GetName(path), FileType.Folder, path);
      return Scan(rootFile);
    }

    public static Models.File Scan(Models.File parent)
    {
      if (parent.FileType != FileType.Folder)
      {
        return parent;
      }
      string path = parent.GetPath();
      
      IEnumerable<string> dirNames = GetDirNames(path);
      foreach(string dirName in dirNames)
      {
        Models.File file = new Models.File(dirName, FileType.Folder, parent);
        Scan(file);
      }

      IEnumerable<string> fileNames = GetFileNames(path);
      foreach(string fileName in fileNames)
      {
        Models.File file = new Models.File(fileName, FileType.File, parent);
      }

      return parent;
    }
  }
}