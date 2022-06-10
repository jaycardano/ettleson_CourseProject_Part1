using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* CEIS 209
 * Devry University
 * Keith S
 * 11/5/2021
*/

//***********************************************************************************************************
//*************************************************FUNCTIONS*************************************************
//***********************************************************************************************************

namespace ettleson_courseproject
{
    public partial class VideoManager
    {
        //*******************************
        //**********Setup Array's********
        //*******************************
        string[] titleArray = new string[5];
        string[] artistArray = new string[5];
        string[] genreArray = new string[5];
        int[] yearArray = new int[5];
        string[] urlArray = new string[5];
        int songCount = 0;
        const String FILENAME = "Songs.txt";
        //*******************************
        //*******Song List Function******
        //*******************************
        private bool SongInList(string SongTitle)
        {
            bool inList = false;
            foreach (string currentSong in songList.Items)
            {
                if (SongTitle == currentSong)
                {
                    inList = true;
                    //Break out of loop
                    break;
                }
            }
            //Return Result
            return inList;
        }
        //*******************************
        //*****Verify Input Function*****
        //*******************************
        private bool ValidInput()
        {
            bool isValid = true;
            List<string[]> controlList = new List<string[]>(); //Control name, then display name.

            controlList.Add(new[] { "titleText", "Title" });
            controlList.Add(new[] { "artistText", "Artist" });
            controlList.Add(new[] { "genreCombo", "Genre" });
            controlList.Add(new[] { "yearText", "Year" });
            controlList.Add(new[] { "urlText", "URL" });

            for (int i = 0; i < controlList.Count; i++)
            {
                if (string.IsNullOrEmpty(this.Controls[controlList[i][0]].Text))
                {
                    MB("The " + controlList[i][1] + " can't be blank!", "Error!", MessageBoxIcon.Error);
                    this.Controls[controlList[i][0]].Focus();
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
        //*******************************
        //*********Clear Function********
        //*******************************
        private void clear()
        {
            //Clears Text
            titleText.Clear();
            artistText.Clear();
            genreCombo.SelectedIndex = -1;
            yearText.Clear();
            urlText.Clear();

            //Sets Focus
            _ = titleText.Focus();
        }
        //*******************************
        //******Message Box Function*****
        //*******************************
        private void MB(string Text, String Title, MessageBoxIcon ICON)
        {
            MessageBox.Show(Text, Title, MessageBoxButtons.OKCancel, ICON);
        }
        private int GetSongIndex(string songTitle)
        {
            int songIndex = songList.Items.IndexOf(songTitle);
            return songIndex;
        }
        //*******************************
        //*****Selected Song Function****
        //*******************************
        private void songList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int songIndex = songList.SelectedIndex;

            StringBuilder sb = new StringBuilder(String.Empty);
            string nl = "\r\n";

            //Build the output Text
            sb.Append(titleArray[songIndex]);
            sb.Append(nl);
            sb.Append(artistArray[songIndex]);
            sb.Append(nl);
            sb.Append(genreArray[songIndex]);
            sb.Append(nl);
            sb.Append(yearArray[songIndex]);
            sb.Append(nl);
            sb.Append(urlArray[songIndex]);
            sb.Append(nl);

            //Output built text
            outputText.Text = sb.ToString();
        }
    }//End Class
}//End NameSpace
 //***********************************************************************************************************
 //**************************************BUTTONS CAN BE FOUND IN FORM.CS**************************************
 //***********************************************************************************************************

