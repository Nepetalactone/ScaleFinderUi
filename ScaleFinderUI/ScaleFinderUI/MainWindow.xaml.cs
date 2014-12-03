using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScaleFinderConsole;

namespace ScaleFinderUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ScaleFinderController _controller;
        public MainWindow()
        {
            _controller = new ScaleFinderController();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (String note in _controller.GetNotes())
            {
                this.KeyBox.Items.Add(note);
            }

            foreach (String scale in _controller.GetScaleNames())
            {
                this.ScaleBox.Items.Add(scale);
            }

            this.KeyBox.SelectedValue = this.KeyBox.Items[0];
            this.ScaleBox.SelectedValue = this.ScaleBox.Items[0];
        }

        private void KeyBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((this.ScaleBox.SelectedValue != null) && (this.KeyBox.SelectedValue != null))
            {
                UpdateChords();
                FillStackPanel();
            }
        }

        private void ScaleBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((this.ScaleBox.SelectedValue != null) && (this.KeyBox.SelectedValue != null))
            {
                UpdateChords();
                FillStackPanel();
            }
        }

        private void UpdateChords()
        {
            this.ScaleLabel.Content = "Scale: ";
            StringBuilder builder = new StringBuilder();
            foreach (
                String note in
                    _controller.GetScaleNotes(this.ScaleBox.SelectedValue.ToString(), this.KeyBox.SelectedValue.ToString()))
            {
                if (builder.Length != 0)
                {
                    builder.Append(", " + note);
                }
                else
                {
                    builder.Append(note);
                }
            }
            this.ScaleLabel.Content += builder.ToString();
        }

        private void FillStackPanel()
        {
            StackPanel[] chordPanels = {ChordPanel1, ChordPanel2, ChordPanel3, ChordPanel4, ChordPanel5, ChordPanel6, ChordPanel7};

            foreach (StackPanel panel in chordPanels)
            {
                panel.Children.Clear();
            }

            int i = 0;
            foreach (List<String> chords in _controller.GetPossibleChordsInScale(this.ScaleBox.SelectedValue.ToString(), this.KeyBox.SelectedValue.ToString()))
            {
                foreach (String chordName in chords)
                {
                    Button temp = new Button();
                    temp.Content = chordName;
                    temp.Click += On_ChordButton_Click;
                    chordPanels[i].Children.Add(temp);
                }
                i++;
            }
        }

        private void On_ChordButton_Click(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;

            String chordAndKey = senderButton.Content.ToString();
            String key;
            String chord;

            this.ChordLabel.Content = "Chord " + chordAndKey + ": ";

            if (chordAndKey[1].Equals('#'))
            {
                key = chordAndKey[0] + "Sharp";
                chord = chordAndKey.Substring(2);
            }
            else
            {
                key = chordAndKey[0].ToString();
                chord = chordAndKey.Substring(1);
            }

            StringBuilder notes = new StringBuilder();

            foreach (String note in _controller.GetChordNotes(key, chord))
            {
                notes.Append(note + ", ");
            }

            this.ChordLabel.Content += notes.ToString(0, notes.Length - 2);
        }
    }
}
