using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platformPerformer.sortingmethods {
    class quick2 : platformMethod<int[], int[]> {


        public int[] performMethod(int[] input) {

            Quicksort( input, 0, input.Length-1 );

            return input;

        }

        public string getName() {
            return "quicksort random 2";
        }


        public static void Quicksort(int[] elements, int left, int right) {
            int i = left, j = right;

            int pivot = elements[(left + right) / 2];

            while ( i <= j ) {
                while ( elements[i].CompareTo( pivot ) < 0 ) {
                    i++;
                }

                while ( elements[j].CompareTo( pivot ) > 0 ) {
                    j--;
                }

                if ( i <= j ) {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if ( left < j ) {
                Quicksort( elements, left, j );
            }

            if ( i < right ) {
                Quicksort( elements, i, right );
            }
        }

    }
}
