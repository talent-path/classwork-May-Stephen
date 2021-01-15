import java.util.Scanner;


public class Console {
    public static void print(String printmsg)
    {
        System.out.println(printmsg);
    }
    public static int readInt(String msg, int min, int max)
    {
        boolean valid = false;
        int parsedAge = Integer.MIN_VALUE;
        while(!valid)
        {
            parsedAge = readInt(msg);
            valid = parsedAge >= min && parsedAge <= max;
        }
        return parsedAge;

    }
    public static int readInt (String msg)
    {
        Scanner input = new Scanner(System.in);
        boolean valid = false;
        int parsedInt = Integer.MIN_VALUE;
        while(!valid)
        {
            print(msg);
            String userInput = input.nextLine();
            try
            {
                parsedInt = Integer.parseInt(userInput);
                valid = true;
            } catch(NumberFormatException ex) {
                //keep looping
            }
        }
        return parsedInt;
    }


    public static double readDouble (String msg)
    {
        Scanner input = new Scanner(System.in);
        boolean dub = false;
        double parsedDub = Double.NaN;
        while(!dub) {
            print(msg);
            String userInput = input.nextLine();
            try {
                parsedDub = Double.parseDouble(userInput);
                dub = true;
            }
            catch(NumberFormatException ex) {

            }
        }
        return parsedDub;
    }
    public static double readDouble(String msg, int min, int max)
    {
        boolean valid = false;
        double parsedAge = Double.NaN;
        while(!valid)
        {
            parsedAge = readDouble(msg);
            valid = parsedAge >= min && parsedAge <= max;
        }
        return parsedAge;

    }
}
