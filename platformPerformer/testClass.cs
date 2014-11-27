using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace platformPerformer {


    public class PlatformTester {

        private List<long> sizeArray = new List<long>();

        private List<platformMethod<int[], int[]>> methodsToTest = new List<platformMethod<int[], int[]>>();

        private platformMethod<int[], int[]>[] methodsToUse;

        private List<long> timings = new List<long>();

        public List<String> getWinners() {
            List<String> strList = new List<string>();
            foreach ( var method in methodsToUse ) {
                strList.Add( method.getName() );
            }
            return strList;
        }

        public List<String> getWinnersTime() {
            List<String> strList = new List<string>();
            foreach ( var time in timings ) {
                strList.Add( time + "" );
            }
            return strList;
        }
        public List<String> getWinnersAndTime() {
            List<String> strList = new List<string>();
            int i = 0;
            foreach ( var me in methodsToUse ) {
                strList.Add( me.getName() + ":" + timings[i] );
                i++;
            }
            return strList;
        }




        public PlatformTester() {

        }

        /// <summary>
        /// must be greater than the previous size
        /// </summary>
        /// <param name="size"></param>
        public void addTestSize( long size ) {
            sizeArray.Add( size );
            timings.Add( long.MaxValue - 1 );
        }

        public void addMethod( platformMethod<int[], int[]> method ) {
            this.methodsToTest.Add( method );
        }

        public void test( Action<string, long, long> callbackResult = null ) {
            methodsToUse = new platformMethod<int[], int[]>[sizeArray.Count];
            int i = 0;
            Timer t = new Timer();
            foreach ( var method in methodsToTest ) {
                //warmup system
                method.performMethod( makeTestArray( 10 ) );
            }
            foreach ( var arrSize in sizeArray ) {
                foreach ( var method in methodsToTest ) {
                    int[] testArr = makeTestArray( arrSize );
                    t.start();
                    int[] tempRes = method.performMethod( testArr );
                    t.stop();
                    if ( tempRes.Length != testArr.Length ) {
                        throw new Exception( "METHOD  " + method.getName() + " IS INCORRECT..." );
                    }
                    if ( timings[i] > t.getDifferenceInTimers() ) {
                        methodsToUse[i] = method;
                        timings[i] = t.getDifferenceInTimers();
                    }
                    if ( callbackResult != null ) {
                        callbackResult( method.getName(), t.getDiffTimeInMs(), arrSize );
                    }
                }
                i++;
            }
        }

        public int[] sort( int[] input ) {
            int index = sizeArray.BinarySearch( input.Length );
            return methodsToUse[index].performMethod( input );
        }

        public static int[] makeTestArray( long size ) {
            Random rand = new Random();
            int[] arr = new int[size];
            for ( int i = 0; i < size; i++ ) {
                arr[i] = rand.Next();
            }
            return arr;
        }

    }
}
