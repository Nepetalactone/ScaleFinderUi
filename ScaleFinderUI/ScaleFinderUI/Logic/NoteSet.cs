using System;
using System.Collections.Generic;
using System.Globalization;

namespace ScaleFinderUI.Logic
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
                    notes.Add((Note)Enum.Parse(typeof(Note), i.ToString(CultureInfo.CurrentCulture)));
                }
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
