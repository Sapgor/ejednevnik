using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Serialization;
using System.IO;

namespace DailyPlannerWPF
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Note> notes;
        private string filePath = "notes.xml";

        public MainWindow()
        {
            InitializeComponent();
            LoadNotes();
        }

        private void LoadNotes()
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Note>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    notes = (ObservableCollection<Note>)serializer.Deserialize(fileStream);
                }
            }
            else
            {
                notes = new ObservableCollection<Note>();
            }

            NotesListBox.ItemsSource = notes;
            UpdateNotesCount();
        }

        private void SaveNotes()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Note>));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, notes);
            }
        }

        private void UpdateNotesCount()
        {
            NotesCountLabel.Content = $"Всего заметок: {notes.Count}";
        }

        private void AddNote(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = DatePicker.SelectedDate ?? DateTime.Today;
            Note newNote = new Note(TitleTextBox.Text, DescriptionTextBox.Text, selectedDate);
            notes.Add(newNote);
            SaveNotes();
            UpdateNotesCount();
            ClearFields();
        }

        private void ClearFields()
        {
            TitleTextBox.Clear();
            DescriptionTextBox.Clear();
            DatePicker.SelectedDate = null;
        }

        private void DeleteNote(object sender, RoutedEventArgs e)
        {
            Note selectedNote = (Note)NotesListBox.SelectedItem;
            if (selectedNote != null)
            {
                notes.Remove(selectedNote);
                ClearFields();
                SaveNotes();
                UpdateNotesCount();
                selectedNote = null;
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NotesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var a = NotesListBox.SelectedItem;
            Note note = a as Note;
            if (note == null)
                ClearFields();
            else
                TitleTextBox.Text = note.Title;
            if (note == null)
                ClearFields();
            else
                DescriptionTextBox.Text = note.Description;
            if (note == null)
                ClearFields();
            else
                DatePicker.Text = note.DueDate.ToString();
        }
    }

    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public Note()
        {
        }

        public Note(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
        }
    }
}
