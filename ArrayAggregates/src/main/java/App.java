public class App {
    public static void main(String[] args) {


        int[] testArr = {82, 95, 71, 6, 34};

        int min = Aggregate.min(testArr);
        int max = Aggregate.max(testArr);
        int sum = Aggregate.sum(testArr);
        double avg = Aggregate.average(testArr);
        double stdDev = Aggregate.stdDeviation(testArr);

        System.out.println(min);
        System.out.println(max);
        System.out.println(sum);
        System.out.println(avg);
        System.out.println(stdDev);
    }
}
