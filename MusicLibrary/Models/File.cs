using System.Collections.Generic;
using System.IO;
using MusicLibrary.Enums;

namespace MusicLibrary.Models
{
  public class File : TreeStruc<File>
  {
    public FileType FileType { get; set; }
    public string Name { get; set; }

    public File(string name, FileType fileType) : base()
    {
      FileType = fileType;
      Name = name;
    }

    public File(string name, FileType fileType, File parent) : base(parent)
    {
      FileType = fileType;
      Name = name;
    }

    public string GetPath()
    {
      List<string> paths = new List<string>();
      File pointer = this;
      do {
        paths.Add(pointer.Name);
        pointer = pointer.Parent;
      } while(pointer != default(File));

      paths.Reverse();
      return Path.Combine(paths.ToArray());
    }
  }
}