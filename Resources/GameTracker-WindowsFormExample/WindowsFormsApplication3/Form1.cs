using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3 {
    public partial class Form1 : Form { 

        private static List<Game> single;
        private static List<Game> multi;

        private static Dictionary<string, List<Game>> singleCategories;
        private static Dictionary<string, List<Game>> multiCategories;

        private static string filter;
        
        public Form1() {

        

            string file = null;
            try {
                file = System.IO.File.ReadAllText(@"InputFile.txt");
            } catch (FileNotFoundException) { }

            if (file == null)
                throw new Exception("File missing!");


            int iterator, numGames = -1;

            string[] lines = file.Split('\n');

            numGames = Convert.ToInt32(lines[0]);

            if (numGames == -1)
                throw new Exception("Invalid Input File");

            List<Game> temp = new List<Game>();

            single = new List<Game>();
            multi  = new List<Game>();

            singleCategories = new Dictionary<string, List<Game>>();
            multiCategories  = new Dictionary<string, List<Game>>();

            for (iterator = 2; iterator < (numGames + 1) * 5 + 3; iterator += 6) {
                string name = lines[iterator].Trim();

                DateTime day = Convert.ToDateTime(lines[iterator + 1]);

                string[] genres1 = lines[iterator + 2].Split('/');

                double rating = Convert.ToDouble(lines[iterator + 3]);

                int numPlayers = Convert.ToInt32(lines[iterator + 4]);

                List<string> genres2 = new List<string>();

                foreach (string s in genres1)
                    genres2.Add(s.Trim());


                Game g = new Game(name, day, genres2, rating, numPlayers);





                if (numPlayers > 1) {
                    multi.Add(g);

                    foreach (string key in genres2) {

                        if (!multiCategories.ContainsKey(key))
                            multiCategories.Add(key, new List<Game>());

                        try {
                            temp = multiCategories[key];
                        } catch (KeyNotFoundException) { }
                        temp.Add(g);

                    }
                }
                else {
                    single.Add(g);

                    foreach (string key in genres2) {

                        if (!singleCategories.ContainsKey(key))
                            singleCategories.Add(key, new List<Game>());

                        try {
                            temp = singleCategories[key];
                        } catch (KeyNotFoundException) { }


                        temp.Add(g);

                    }
                }

            }

            InitializeComponent();
            radioButton1.Checked = true;


           

            foreach (KeyValuePair<string, List<Game>> e in singleCategories) {
                comboBox1.Items.Add(e.Key);
            }
            foreach (KeyValuePair<string, List<Game>> e in singleCategories) {
                if(!comboBox1.Items.Contains(e.Key))
                    comboBox1.Items.Add(e.Key);
            }

            comboBox1.Items.Add(@"All");
            comboBox1.SelectedItem = @"All";

            /*
            Console.WriteLine("=======================================================");
            Console.WriteLine("===============Singleplayer Entries====================");
            Console.WriteLine("=======================================================");


            Console.WriteLine("================================== Sorting By Releases");
            Game.printByReleases(single);

            Console.WriteLine("================================== Sorting By Genres");
            foreach (KeyValuePair<string, List<Game>> e in singleCategories) {

                Console.WriteLine("------------------- " + e.Key);
                Game.printByReleases(e.Value);

            }

            Console.WriteLine("================================== Sorting By Ratings");
            Game.printByRatings(single);
            */

            /****************************************************************************/
            /****************************************************************************/
            /****************************************************************************/
            /****************************************************************************/

            /*
            Console.WriteLine("=======================================================");
            Console.WriteLine("================Multiplayer Entries====================");
            Console.WriteLine("=======================================================");


            Console.WriteLine("================================== Sorting By Releases");
            Game.printByReleases(multi);

            Console.WriteLine("================================== Sorting By Genres");
            foreach (KeyValuePair<string, List<Game>> e in multiCategories) {

                Console.WriteLine("------------------- " + e.Key);
                Game.printByReleases(e.Value);

            }

            Console.WriteLine("================================== Sorting By Ratings");
            Game.printByRatings(multi);
            */


            
            
        }



        private void Form1_Load(object sender, EventArgs e) { }

        /******************************************************************************/


        private void newReleasesButton(object sender, EventArgs e) {
            richTextBox1.Clear();

            List<Game> print = null;
            string genre = null;
              
            genre = (string)comboBox1.SelectedItem;

            if (genre.Equals(@"All"))
                print = (radioButton1.Checked) ? single : multi;
            else {
                if (radioButton1.Checked)
                    print = singleCategories[genre];
                else
                    print = multiCategories[genre];
            }


            richTextBox1.AppendText(Game.printByReleases(print));

        }


        private void topRatingButton(object sender, EventArgs e) {
            richTextBox1.Clear();

            List<Game> print = null;
            string genre = null;

            genre = (string)comboBox1.SelectedItem;

            if (genre.Equals(@"All"))
                print = (radioButton1.Checked) ? single : multi;
            else {
                if (radioButton1.Checked)
                    print = singleCategories[genre];
                else
                    print = multiCategories[genre];
            }


            richTextBox1.AppendText(Game.printByRatings(print));
   
        }

        /******************************************************************************/

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            filter = (string)comboBox1.SelectedItem;
        }

        
       

        

        

        

        

    }
}
