using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace platformPerformer.sortingmethods {
    public class Mergesort_T : platformMethod<int[], int[]> {
        public string getName() {
            return "T merge sort";
        }

        public int[] performMethod( int[] input ) {
            handleWork( input );
            return input;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void handleWork( int[] input ) {
            for ( int width = 1; width < input.Length; width++ ) {
                for ( int i = 0; i < input.Length; i += width * 2 ) {
                    //look at [i; i+width[ -> [i+width;i+width*2[;'
                    if ( i + width < input.Length ) {
                        merge( input, i, i + width, Math.Min( i + width, input.Length - 2 ), Math.Min( i + (width * 2), input.Length ) );
                    }
                    //they are sorted so call merge with that.
                }
            }
            //return input;c
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void merge( int[] arr, int a_start, int a_end, int b_start, int b_end ) {
            int oneLenght = a_end - a_start;
            int[] buffer = new int[b_end - a_start];

            int a_ptr = a_start;
            int b_ptr = b_start;
            for ( int i = 0; i < oneLenght; i++ ) {
                int val;
                if ( arr[a_ptr] < arr[b_ptr] ) {
                    val = arr[a_ptr];
                    buffer[i] = val;
                    a_ptr++;
                    if ( a_ptr >= a_end ) {
                        //copy the rest from b. OPTIMIZED
                        copyToLen( buffer, arr, 0, a_ptr - a_start, a_start ); //since we know that b is sorted and that we are out of A,
                                                                               //then by moving the buffer into the orginal array, we know that we dont have to move around B and that B is sorted,
                                                                               //and that this buffer is also sorted, meaning we dont have to work with the rest of B.
                        return;
                    }
                } else {
                    val = arr[b_ptr];
                    buffer[i] = val;
                    b_ptr++;
                    if ( b_ptr >= b_end ) {
                        //but before that move a_ptr - a_end to a "new" buffer ??? 
                        copyToLen( arr, buffer, a_ptr, a_end - 1, i );
                        break;

                    }
                }
            }
            buffer.CopyTo( arr, a_start );

        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        //excl dest.
        private static void copyToLen( int[] src, int[] dest, int startSrc, int endSrc, int startDst ) {
            for ( int i = 0; i < (endSrc - startSrc); i++ ) {
                dest[startDst + i] = src[startSrc + i];
            }
        }
    }
}
