namespace MusicLibrary.Models
{
  using System.Collections.Generic;

  public abstract class TreeStruc<TTree>
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

    public TreeStruc()
    {
      _parent = default(TTree);
    }

    public TreeStruc(TTree parent)
    {
      _parent = parent;
    }

    public TreeStruc<TTree> AddChild(TTree child)
    {
      Children.Add(child);
      return this;
    }
  }
}