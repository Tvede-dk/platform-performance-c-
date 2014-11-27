using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platformPerformer.sortingmethods {
    /*class quick3 : platformMethod<int[], int[]> {

        public int[] performMethod(int[] input) {
            return quicksort( new List<int>(input) ).ToArray();
        }
        private static List<int> quicksort(List<int> arr) {
            List<int> loe = new List<int>(), gt = new List<int>();
            if ( arr.Count < 2 )
                return arr;
            int pivot = arr.Count / 2;
            int pivot_val = arr[pivot];
            arr.RemoveAt( pivot );
            foreach ( int i in arr ) {
                if ( i <= pivot_val )
                    loe.Add( i );
                else if ( i > pivot_val )
                    gt.Add( i );
            }

            List<int> resultSet = new List<int>();
            resultSet.AddRange( quicksort( loe ) );
            gt.Add( pivot_val );
            resultSet.AddRange( quicksort( gt ) );
            return resultSet;
        }
        public string getName() {
            return "quick sort 3";
        }
    }*/
}
