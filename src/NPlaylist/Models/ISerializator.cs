using System.IO;

namespace NPlaylist.Models
{
    public interface ISerializator<T>
    {
        void Serialize(T playlist, Stream stream);
        T Deserialize(Stream stream);
    }
}
