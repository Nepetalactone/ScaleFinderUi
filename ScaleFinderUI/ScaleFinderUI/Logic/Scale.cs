using System;
using System.Linq;

namespace ScaleFinderUI.Logic
{
    class Scale : NoteSet
    {
        public Scale(String pattern, String name):base(pattern, name)
        {
        }
        public bool IsChordInScale(Chord chord)
        {
            return chord.Notes.All(x => Notes.Contains(x));
        }
    }
}
