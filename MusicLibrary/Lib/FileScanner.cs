using System.Collections.Generic;
using System.IO.Abstractions;
using MusicLibrary.Enums;

namespace MusicLibrary.Lib
{
  public class FileScanner
  {
    private readonly IFileSystem _fileSystem;

    public FileScanner(IFileSystem fileSystem)
    {
      _fileSystem = fileSystem;
    }

    public FileScanner()
      : this(new FileSystem())
    {
    }

    // get file/directory name from path
    private string GetName(string path)
    {
      return _fileSystem.Path.GetFileName(path);
    }
    private IEnumerable<string> GetNames(IEnumerable<string> paths)
    {
      List<string> names = new List<string>();
      foreach (string path in paths)
      {
        names.Add(GetName(path));
      }

      return names;
    }

    // get list of files in format of path
    private IEnumerable<string> GetFileNames(string path)
    {
      string[] filePaths = _fileSystem.Directory.GetFiles(path);
      return GetNames(filePaths);
    }

    // get list of dirs in format of path
    private IEnumerable<string> GetDirNames(string path)
    {
      string[] dirPaths = _fileSystem.Directory.GetDirectories(path);
      return GetNames(dirPaths);
    }

    
    public Models.File Scan(string path)
    {
      if (System.IO.File.Exists(path))
      {
        return new Models.File(GetName(path), FileType.File, path);
      }

      Models.File rootFile = new Models.File(GetName(path), FileType.Folder, path);
      return Scan(rootFile);
    }

    public Models.File Scan(Models.File parent)
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