using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platformPerformer.sortingmethods {
   class parMerge : platformMethod<int[], int[]> {

        public int[] performMethod(int[] input) {
            Paralle.Sort<int>( input );
            return input;
        }

        public String getName() {
            return "Par merge";
        }

     
    }
}
