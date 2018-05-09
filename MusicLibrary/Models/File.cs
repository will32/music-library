using System.Collections.Generic;
using System.IO;
using MusicLibrary.Enums;

namespace MusicLibrary.Models
{
  public class File : TreeStruct<File>
  {
    public FileType FileType { get; set; }
    public string Name { get; set; }

    private string RootPath { get; }

    public File(string name, FileType fileType, string rootPath) : base()
    {
      FileType = fileType;
      Name = name;
      RootPath = rootPath;
    }

    public File(string name, FileType fileType, File parent) : base(parent)
    {
      FileType = fileType;
      Name = name;
      Parent = parent;
      parent.Children.Add(this);
    }

    //trace the path until it get to the root
    public string GetPath()
    {
      List<string> paths = new List<string>();
      File pointer = this;

      while (pointer.Parent != default(File))
      {
        paths.Add(pointer.Name);
        pointer = pointer.Parent;
      }

      paths.Add(pointer.RootPath);

      paths.Reverse();
      return Path.Combine(paths.ToArray());
    }
  }
}