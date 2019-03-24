using System;

namespace NPlaylist.Asx
{
    public class InvalidAsxFormatException : Exception
    {
        public override string Message => "Invalid Asx Format";
    }
}
