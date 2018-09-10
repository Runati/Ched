﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ched.Components;
using Ched.Components.Exporter;

namespace Ched.UI
{
    public partial class SusExportForm : Form
    {
        public SusExportForm(ScoreBook book, SusExporter exporter)
        {
            InitializeComponent();
            Icon = Properties.Resources.MainIcon;
            ShowInTaskbar = false;

            levelDropDown.Items.AddRange(Enumerable.Range(1, 14).SelectMany(p => new string[] { p.ToString(), p + "+" }).ToArray());
            difficultyDropDown.Items.AddRange(new string[] { "BASIC", "ADVANCED", "EXPERT", "MASTER", "WORLD'S END" });

            var args = exporter.CustomArgs;

            titleBox.Text = book.Title;
            artistBox.Text = book.ArtistName;
            notesDesignerBox.Text = book.NotesDesignerName;
            difficultyDropDown.SelectedIndex = (int)args.PlayDifficulty;
            levelDropDown.Text = args.PlayLevel;
            songIdBox.Text = args.SongId;
            soundFileBox.Text = args.SoundFileName;
            soundOffsetBox.Value = args.SoundOffset;
            jacketFileBox.Text = args.JacketFilePath;
            hasPaddingBarBox.Checked = args.HasPaddingBar;

            exportButton.Click += (s, e) =>
            {
                book.Title = titleBox.Text;
                book.ArtistName = artistBox.Text;
                book.NotesDesignerName = notesDesignerBox.Text;
                args.PlayDifficulty = (SusArgs.Difficulty)difficultyDropDown.SelectedIndex;
                args.PlayLevel = levelDropDown.Text;
                args.SongId = songIdBox.Text;
                args.SoundFileName = soundFileBox.Text;
                args.SoundOffset = soundOffsetBox.Value;
                args.JacketFilePath = jacketFileBox.Text;
                args.HasPaddingBar = hasPaddingBarBox.Checked;

                DialogResult = DialogResult.OK;
                Close();
            };
        }
    }
}