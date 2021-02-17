public class Aggregate {

    public static int min( int[] arr) {
        //find the min number and return it
        int minValue = arr[0];
        for( int i = 0; i < arr.length; i++) {
            if (arr[i] < minValue) {
                minValue = arr[i];
            }
        }
        return minValue;

    }

    public static int max( int[] arr) {
        //find the min number and return it
        int maxValue = arr[0];
        for( int i = 0; i < arr.length; i++) {
            if (arr[i] > maxValue) {
                maxValue = arr[i];
            }

        }
        return maxValue;
    }

    public static int sum( int[] arr) {
        int sumValue = arr[0];
        for (int i = 1; i < arr.length; i++) {
            sumValue += arr[i];
        }
        return sumValue;
    }

    public static double average( int[] arr) {
        double avgValue = arr[0];
        for (int i = 1; i < arr.length; i++) {
            avgValue += arr[i];

        }
        double average = avgValue / arr.length;
        return average;
    }

    public static double stdDeviation( int[] arr) {
        //first compute the average
        // then add the square of the difference between the average and each number
        // then take the square root
        double avgValue = average(arr);
        double diffSum = 0;
        for (int i = 0; i < arr.length; i++) {

            double diff = arr[i] - avgValue;
            diff *= diff;
            diffSum += diff;

        }
        double avg = diffSum / arr.length;
        double sqr = Math.sqrt(avg);
        return sqr;



    }
}
