using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleFinderConsole
{
    public enum Note
    {
        A = 0,
        ASharp = 1,
        B = 2,
        C = 3, 
        CSharp = 4, 
        D = 5, 
        DSharp = 6, 
        E = 7, 
        F = 8, 
        FSharp = 9, 
        G = 10,
        GSharp = 11, 
    }

    public static class Extensions
    {
        public static String ToStringManual(this Note note)
        {
            switch (note)
            {
                case Note.A:
                    return "A";
                case Note.ASharp:
                    return "A#";
                case Note.B:
                    return "B";
                case Note.C:
                    return "C";
                case Note.CSharp:
                    return "C#";
                case Note.D:
                    return "D";
                case Note.DSharp:
                    return "D#";
                case Note.E:
                    return "E";
                case Note.F:
                    return "F";
                case Note.FSharp:
                    return "F#";
                case Note.G:
                    return "G";
                case Note.GSharp:
                    return "G#";
                default:
                    return "ERROR";
            }
        }
    }
}
