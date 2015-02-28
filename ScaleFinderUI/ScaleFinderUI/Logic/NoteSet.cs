using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleFinderConsole
{
    abstract class NoteSet
    {
        private readonly String _pattern;
        private Note _key;
        public Note Key
        {
            get
            { 
                return _key; 
            }
            set
            {
                _key = value;
                Notes = GetNotesFromPattern(_pattern);
            }
        }
        public List<Note> Notes { get; protected set; }
        public String Name { get; private set; }

        protected NoteSet(String pattern, String name)
        {
            _pattern = pattern;
            Notes = GetNotesFromPattern(pattern);
            Name = name;
        }

        protected List<Note> GetNotesFromPattern(string pattern)
        {
            int i = (int)_key;
            List<Note> notes = new List<Note>();
            foreach (char c in pattern)
            {
                if (c.Equals('1'))
                {
                    Note x;
                    Enum.TryParse(i.ToString(), out x);
                    notes.Add(x);
                }
                else if (c.Equals('0'))
                { }

                i++;

                if (i > 11)
                {
                    i = 0;
                }
            }

            return notes;
        }
    }
}
