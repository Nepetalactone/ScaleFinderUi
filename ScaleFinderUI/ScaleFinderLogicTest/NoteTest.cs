using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScaleFinderUI.Logic;

namespace ScaleFinderTest
{
    [TestClass]
    public class NoteTest
    {
        [TestMethod]
        public void ToStringManualTest()
        {
            String[] stringNotes = {"A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"};
            Note[] notes ={Note.A, Note.ASharp, Note.B, Note.C, Note.CSharp, Note.D, Note.DSharp, Note.E, Note.F, Note.FSharp, Note.G, Note.GSharp};

            for (int i = 0; i < stringNotes.Length; i++)
            {
                Assert.AreEqual(stringNotes[i], notes[i].ToStringManual());
            }
        }
    }
}
