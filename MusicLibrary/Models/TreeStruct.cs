namespace MusicLibrary.Models
{
  using System.Collections.Generic;

  public abstract class TreeStruct<TTree>
  {

    public List<TTree> Children { get; set; }
    public TTree Parent { get; internal set; }

    public bool HasChild
    {
      get
      {
        return Children.Count > 0;
      }
    }

    public bool IsRoot
    {
      get
      {
        return EqualityComparer<TTree>.Default.Equals(Parent);
      }
    }

    public TreeStruct()
    {
      Parent = default(TTree);
      Children = new List<TTree>();
    }

    public TreeStruct(TTree parent)
    {
      Parent = parent;
      Children = new List<TTree>();
    }
  }
}