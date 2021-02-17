import java.util.Random;


// singleton pattern
//single static instance of something inside a class
// which we then use throughout
public class Rng {

    static Random rng = new Random(); // making a pseudo-rng

    public static int randInt(int incMin, int incMax) {
        // this call takes an exclusive upper bound
        // returns a number between 0 and and that bound - 1

        //rng.nextInt()

        int rand = incMin + rng.nextInt((incMax - incMin) + 1); //incMin to (incMac + incMin)

        return rand;

    }
    public static double randDouble( double incMin, double incMax) {
        double rand = incMin + rng.nextDouble() * (incMax - incMin);

        return rand;
    }


    public static boolean coinFlip() {
        return rng.nextBoolean();
    }
}
