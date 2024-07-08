using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CodingStandard {

    class Program {

        delegate void DelTester( string s );

        static void M( string s ) {
            Console.WriteLine( s );
        }

        static int NUMBER_MEMBERS = 6;


        //Fields are always private with a getter or a setter depending on which is needed
        private int cherry;

        public int getCherry( ) {
            return this.cherry;
        }

        //Name setter and constructor parameters the same as their respective fields
        public void setCherry( int cherry ) {
            this.cherry = cherry;
        }

        public Program( int cherry ) {
            this.cherry = cherry;
        }

        ~Program( ) {
            //Use only when a stream, window, readers, writers, etc are opened
        }


        static void Main( string[] args ) {



            //No Float
            double x = 3.14;
            int camelCase = 5, fontBook = 6;
            bool p = true;
            bool y = ( 5 == 6 );

            string hello = ( camelCase == 5 ) ? "Hello" : "World!";

            //Use String for static methods not string
            String.Compare( "1234" , "abcd" );

            Program q = new Program( 5 );


            DelTester t1 = new DelTester( M );
            DelTester t2 = delegate( string s ) { Console.WriteLine( s ); };
            //Use only for testing
            DelTester t3 = ( l ) => { Console.WriteLine( l ); };

            t1( "Hello" );
            t2( "World!" );
            t3( "Get back to work :P" );

            try {
                throw new InvalidCastException( "This is a test" );
            } catch( InvalidCastException e ) {

            } catch( IndexOutOfRangeException e ) {

            }


            Console.ReadKey();
        }

    }

}
