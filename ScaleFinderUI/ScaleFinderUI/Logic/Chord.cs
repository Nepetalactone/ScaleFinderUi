using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleFinderConsole
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
