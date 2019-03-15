using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.Models
{
    public class BasePlaylist<T>
    {
        public List<T> Entries { get; set; }

        public BasePlaylist()
        {
                Entries  = new List<T>();
        }
    }
}
