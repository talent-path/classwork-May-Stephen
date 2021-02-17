import org.w3c.dom.ls.LSOutput;

public class LongestCollatz {
        public static void main (String[]args){
            // store highest value
            long max = 0;
            // num to loop
            long num = 0;
            //store highest value to return
            long highest = 0;
            // track size of the list
            long size = 0;
            // loop through to 1000000
            // exclude 1 because it will always have size of 1
            for (long i = 2; i < 1000000; i++) {
                size = 0;
                num = i;

                while (num != 1) {
                    // check if num is even, if so num / 2
                    if (num % 2 == 0) {
                        num = num / 2;
                    }
                    // check if num is odd, if so 3(num) + 1
                    else {
                        num = 3 * num + 1;
                    }
                    // increase size of list by 1
                    size++;
                }
                // if size is higher than max, store max as size
                if (size > max) {
                    max = size;
                    highest = i;
                }
            }

            System.out.println(highest);
        }
    }


