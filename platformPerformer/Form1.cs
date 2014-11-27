using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using platformPerformer.sortingmethods;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platformPerformer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e ) {
            test();
        }


        private void test() {
            int loopTime = 1;

            long frequency = Stopwatch.Frequency;
            Console.WriteLine( "  Timer frequency in ticks per second = {0}",
                frequency );
            long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            Console.WriteLine( "  Timer is accurate within {0} nanoseconds",
                nanosecPerTick );

            Stopwatch sw = new Stopwatch();

            int fail = new Random().Next();
            sw.Start();
            for ( int i = 0; i < loopTime; i++ ) {
                i += 200;
                i *= fail;
                fail = i;
            }
            sw.Stop();
            long swTimeInNs = sw.ElapsedMilliseconds;
            textBox1.Text += "time for stopwatch(ms):" + swTimeInNs.ToString() + "\r\n";

            Timer tim = new Timer();

            tim.start();
            for ( int i = 0; i < loopTime; i++ ) {
                i += 200;
                i *= fail;
                fail = i;
            }
            tim.stop();
            textBox1.Text += " timer gave cpu counter difference as:" + tim.getDifferenceInTimers().ToString() + "\r\n";
            textBox1.Text += " in secounds:" + tim.getDiffTimeInSec().ToString() + "\r\n";


        }

        private void button2_Click( object sender, EventArgs e ) {

            BackgroundWorker work = new BackgroundWorker();
            work.DoWork += runTest;
            work.RunWorkerAsync();

        }

        private void runTest( object sender, DoWorkEventArgs e ) {
            PlatformTester pt = new PlatformTester();
            pt.addTestSize( 10 );
            pt.addTestSize( 100 );
            pt.addTestSize( 1000 );
            pt.addTestSize( 10000 );
            pt.addTestSize( 100000 );
            pt.addTestSize( 1000000 );
            pt.addTestSize( 20000000 );
            /*pt.addTestSize( 30000000 );
            pt.addTestSize( 40000000 );
            pt.addTestSize( 50000000 );
            pt.addTestSize( 60000000 );*/

            pt.addMethod( new inbuildSort() );
            //pt.addMethod( new quickSo() );
            //pt.addMethod( new quick2() );
            //pt.addMethod( new parMerge() );
            //pt.addMethod( new merge() );
            //pt.addMethod( new Mergesort_T() ); // ???
            //pt.addMethod( new OMS() ); // ???
            pt.test( ( string name, long time, long arrSize ) => {
                var str = string.Format( "method \"{0}\": {1} ms. size: {2}", name, time, arrSize );
                textBox2.BeginInvoke( (MethodInvoker)(() => { textBox2.Text += str + "\r\n"; }) );
            } );
            List<String> winners = pt.getWinnersAndTime();
            textBox1.BeginInvoke( (MethodInvoker)(() => {
                textBox1.Text = ""; foreach ( var str in winners ) {
                    textBox1.Text += str + "\r\n";
                }
            }) );
        }

        private void Form1_Load( object sender, EventArgs e ) {

        }
    }
}
