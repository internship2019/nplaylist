using System.IO;

namespace NPlaylist.Models
{
    public interface ISerializator<T>
    {
        string Serialize(T playlist);
        T Deserialize(Stream stream);
    }
}
