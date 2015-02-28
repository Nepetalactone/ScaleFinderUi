using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleFinderConsole
{
    class Scale : NoteSet
    {
        public Scale(String pattern, String name):base(pattern, name)
        {
        }
        public bool IsChordInScale(Chord chord)
        {
            foreach (Note note in chord.Notes)
            {
                if (!Notes.Contains(note))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
