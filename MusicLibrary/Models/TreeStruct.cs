namespace MusicLibrary.Models
{
  using System.Collections.Generic;

  public abstract class TreeStruct<TTree>
  {
    private TTree _parent;

    public List<TTree> Children { get; set; }
    public TTree Parent
    {
      get
      {
        return _parent;
      }
    }

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
        return _parent == null;
      }
    }

    public TreeStruct()
    {
      _parent = default(TTree);
    }

    public TreeStruct(TTree parent)
    {
      _parent = parent;
    }
  }
}