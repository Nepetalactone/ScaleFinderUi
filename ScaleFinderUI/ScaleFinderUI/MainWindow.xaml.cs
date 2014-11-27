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
            }
        }

        private void ScaleBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((this.ScaleBox.SelectedValue != null) && (this.KeyBox.SelectedValue != null))
            {
                UpdateChords();
            }
        }

        private void UpdateChords()
        {
            this.ScaleLabel.Content = "";
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
            this.ScaleLabel.Content = builder.ToString();
        }
    }
}
