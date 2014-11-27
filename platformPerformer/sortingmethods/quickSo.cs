using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platformPerformer {
    class quickSo : platformMethod<int[], int[]> {

        public int[] performMethod(int[] input) {
            QuickSort( input, 0, input.Length );
            return input;
        }


        public string getName() {
            return "quicksort SO edition";
        }

        private static void QuickSort(int[] data, int left, int right) {
            int i = left - 1,
                j = right;

            while ( true ) {
                int d = data[left];
                do i++; while ( data[i] < d );
                do j--; while ( data[j] > d );

                if ( i < j ) {
                    int tmp = data[i];
                    data[i] = data[j];
                    data[j] = tmp;
                } else {
                    if ( left < j ) QuickSort( data, left, j );
                    if ( ++j < right ) QuickSort( data, j, right );
                    return;
                }
            }
        }
    }
}
