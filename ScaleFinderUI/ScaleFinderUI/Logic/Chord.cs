using System;

namespace ScaleFinderUI.Logic
{
    class Chord : NoteSet
    {
        public String ShortName { get; private set; }
        public Chord(String pattern, String name, String shortName):base(pattern, name)
        {
            ShortName = shortName;
        }
    }
}
