using System;
using System.Collections.Generic;
using System.IO;

namespace NPlaylist
{
    public interface IPlaylistItem
    {
        IDictionary<string, string> Tags { get; }
        string Path { get; }
    }   
}
