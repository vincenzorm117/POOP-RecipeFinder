using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3 {
    class Game {

        
        private string name;
        private DateTime release;
        private List<string> genres;
        private double rating;
        private int players;
        private StringBuilder str;

        

        public override string ToString() {
           
            if(str == null){
                str = new StringBuilder();

                str.Append(name);
                str.Append("\n");
                str.Append(release.ToString(Game.format));
                str.Append("\n");
                str.Append(genres[0]);
                for (int i = 1; i < genres.Count(); i++ ) {
                    str.Append(" / ");
                    str.Append(genres[i]);
                }
                str.Append("\n");
                str.Append(rating);
                str.Append("\n");
                str.Append(players);
                str.Append("\n");

            }

            return str.ToString();
        }

        

        public Game(string name, DateTime release, List<string> genres, double rating, int players) {
            this.name = name;
            this.release = release;
            this.genres = genres;
            this.rating = rating;
            this.players = players;
        }

        public static bool operator >(Game a, Game b){
            return a.rating > b.rating;
        }

        public static bool operator <(Game a, Game b) {
            return a.rating < b.rating;
        }



        public static bool operator <=(Game a, Game b) {
            return a.release < b.release;
        }


        public static bool operator >=(Game a, Game b) {
            return a.release > b.release;
        }


        /*****************************************************************************************/
        /*****************************************************************************************/
        /**********************************STATIC FIELDS and METHODS******************************/
        /*****************************************************************************************/

        static String format = "MM/dd/yyyy";

        public static string printByRatings(List<Game> arg){
            

            
            int size = arg.Count();

            if (size <= 0)
                return null;

            StringBuilder s = new StringBuilder();
            List<Game> games = new List<Game>();

            foreach (Game a in arg) {
                games.Add(a);
            }

            Game[] top = new Game[3];

            for (int i = 0; i < games.Count(); i++) {

                for (int j = 0; j < 3; j++) {
                    if (top[j] == null) {
                        top[j] = games[i];
                        break;
                    }
                    else if (games[i] > top[j]) {
                        Game a = games[i];
                        games[i] = top[j];
                        top[j] = a;
                    }
                }
            
            }

            size = (size > 3) ? 3 : size;

            for (int i = 0; i < size; i++) {
                s.Append(top[i]);
                s.Append(Environment.NewLine);
            }
            
            return s.ToString();
        }


        public static string printByReleases(List<Game> arg) {
            
            
            int size = arg.Count();

            if (size <= 0)
                return null;

            StringBuilder s = new StringBuilder();
            List<Game> games = new List<Game>();

            foreach (Game a in arg) {
                games.Add(a);
            }

            Game[] top = new Game[3];

            for (int i = 0; i < games.Count(); i++) {

                for (int j = 0; j < 3; j++) {
                    if (top[j] == null) {
                        top[j] = games[i];
                        break;
                    }
                    else if (games[i] >= top[j]) {
                        Game a = games[i];
                        games[i] = top[j];
                        top[j] = a;
                    }
                }

            }

            size = (size > 3) ? 3 : size;

            for (int i = 0; i < size; i++) {
                s.Append(top[i]);
                s.Append(Environment.NewLine);
            }
            return s.ToString();
        }



        
    }
}
