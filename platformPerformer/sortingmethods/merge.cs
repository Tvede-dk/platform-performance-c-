using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace platformPerformer.sortingmethods {
    class merge : platformMethod<int[], int[]> {

        static Barrier sync;    

        public merge(){
            sync = new Barrier(3);  
        }

        public string getName() {
            return "mergesort ";
        }


        public int[] performMethod(int[] input) {
             MergeSort( input ,0, input.Length-1);
             return input;
        }


      

        public static void MergeSort(int[] input, int left, int right) {
            if ( left < right ) {
                int middle = (left + right) / 2;

                MergeSort( input, left, middle );
                MergeSort( input, middle + 1, right );

                //Merge
                int[] leftArray = new int[middle - left + 1];
                int[] rightArray = new int[right - middle];

                Array.Copy( input, left, leftArray, 0, middle - left + 1 );
                Array.Copy( input, middle + 1, rightArray, 0, right - middle );

                int i = 0;
                int j = 0;
                for ( int k = left ; k < right + 1 ; k++ ) {
                    if ( i == leftArray.Length ) {
                        input[k] = rightArray[j];
                        j++;
                    } else if ( j == rightArray.Length ) {
                        input[k] = leftArray[i];
                        i++;
                    } else if ( leftArray[i] <= rightArray[j] ) {
                        input[k] = leftArray[i];
                        i++;
                    } else {
                        input[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }
    }
}
