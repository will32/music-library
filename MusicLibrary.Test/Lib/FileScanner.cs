using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using MusicLibrary.Lib;
using Xunit;

namespace MusicLibrary.Test
{
  public class FileScanner_Should
  {
    [Fact]
    public void ScanFileSystem()
    {
      var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
      {
          { @"c:\myFile.txt", new MockFileData("Testing is meh.") },
          { @"c:\demo\jQuery.js", new MockFileData("some js") },
          { @"c:\demo\image.gif", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }) }
      });

      var fileScanner = new FileScanner(fileSystem);
      var t = fileScanner.Scan(@"c:\demo");
      Assert.Equal("jQuery.js", t.Children[0].Name);
    }
  }
}
