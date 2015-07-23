using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScaleFinderUI.Logic;

namespace ScaleFinderTest
{
    [TestClass]
    public class ScaleFinderLogicTest
    {
        private ScaleFinderController _scaleFinderController;

        [TestInitialize]
        public void Initialize()
        {
            _scaleFinderController = new ScaleFinderController();
        }

        [TestMethod]
        public void GetChordNotesBMin()
        {
            String[] chord = _scaleFinderController.GetChordNotes("B", "min");
            String[] testChord = {"B", "D", "F#"};

            if (chord.Length != testChord.Length)
            {
                Assert.Fail();
            }

            for (int i = 0; i < chord.Length; i++)
            {
                if (chord[i] != testChord[i])
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetChordNotesCSharpDim()
        {
            String[] chord = _scaleFinderController.GetChordNotes("C#", "dim");
            String[] testChord = {"C#", "E", "G"};

            if (chord.Length != testChord.Length)
            {
                Assert.Fail();
            }

            for (int i = 0; i < chord.Length; i++)
            {
                if (chord[i] != testChord[i])
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void GetPossibleChordsInScaleAeolinB()
        {
            List<String>[] chords = _scaleFinderController.GetPossibleChordsInScale("Aeolian", "B");
            List<String>[] testChords =
            {
                new List<string>{"Bmin", "Bsus2", "Bsus4", "Bmin7", "B7sus4", "B7sus4#5"},
                new List<string>{"C#dim", "C#min7b5", "C#7sus4#5"},
                new List<string>{"Dmaj", "Dsus2", "Dsus4", "Dmaj6", "Dmaj7"},
                new List<string>{"Emin", "Esus2", "Esus4", "Emin6", "Emin7", "E7sus4"},
                new List<string>{"F#min", "F#sus4", "F#min7", "F#7sus4", "F#7sus4#5"},
                new List<string>{"Gmaj", "Gsus2", "Gmaj6", "Gmaj7", "Gmaj7b5"},
                new List<string>{"Amaj", "Asus2", "Asus4", "Amaj6", "A7", "A7sus4"} 
            };

            if (chords.Length != testChords.Length)
            {
                Assert.Fail();
            }

            for (int i = 0; i < chords.Length; i++)
            {
                for (int j = 0; j < chords[i].Count; j ++)
                {
                    if (!testChords[i][j].Equals(chords[i][j]))
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void GetScaleNotes()
        {
            String[] testNotes = { "A", "B", "C#", "D", "E", "F#", "G#" };
            var notes = _scaleFinderController.GetScaleNotes("Ionian", "A");

            if (testNotes.Length != notes.Length)
            {
                Assert.Fail();
            }

            for (int i = 0; i < testNotes.Length; i++)
            {
                if (testNotes[i] != notes[i])
                {
                    Assert.Fail();
                }
            }
        }
    }
}
