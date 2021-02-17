

import java.sql.SQLOutput;
import java.util.*;
import java.util.stream.Collectors;

public class App {

    public static void main(String[] args) {
        // arithmetic expressions left side will be a valid integer may or may not have spaces
        // operator followed by 0 or more spaces and second valid number

        letterCasePermutation("a1b2");




    }




        public static List<String> letterCasePermutation(String S) {
            List<String> output = new ArrayList();
            output.add(S);

            for (int i = 0; i < S.length(); i++) {
                if (Character.isLetter(S.charAt(i))) {
                    Character.toUpperCase(S.charAt(i));
                    output.add(S);

                }

            }


            return output;
        }

    private static void changeCase(char check) {
            Character.toUpperCase(check);


    }


// char[][] board2 = {{'.','.','4','.','.','.','6','3','.'},
//        {'.','.','.','.','.','.','.','.','.'},
//        {'5','.','.','.','.','.','.','9','.'},
//        {'.','.','.','5','6','.','.','.','.'},
//        {'4','.','3','.','.','.','.','.','1'},
//        {'.','.','.','7','.','.','.','.','.'},
//        {'.','.','.','5','.','.','.','.','.'},
//        {'.','.','.','.','.','.','.','.','.'},
//        {'.','.','.','.','.','.','.','.','.'}};
//
//        isValidSudoku(board2);

     public static int calculate(String expression) {
         String noSpace = expression.replace(" ", "");
         System.out.println(noSpace);
         String operation = noSpace.substring(1,2);
         String firstNum = noSpace.substring(0,1);
         String secondNum = noSpace.substring(2,3);
         int x1 = Integer.parseInt(firstNum);
         int x2 = Integer.parseInt(secondNum);
         int answer = Integer.MIN_VALUE;
         switch(operation) {
             case "+" : answer = x1 + x2; break;

             case "-" : answer = x1 - x2; break;

             case "*" : answer =x1 * x2; break;


             case "/" : answer = x1 / x2; break;



        }


//        switch(operation) {
//            case "+" :
//
//
//
//        }







         return answer;
     }
















    public static boolean isValidSudoku(char[][] board) {
        boolean valid = true;
        for (int row = 0; valid && row < 9; row++) {
            for (int col = 0; valid && col < 9; col++) {
                if (board[row][col] != '.') {

                    int boxTopRow = row / 3 * 3;
                    int boxLeftCol = col / 3 * 3;


                    for (int i = 0; valid && i < 9; i++) {
                        int boxRow = boxTopRow + i / 3;
                        int boxCol = boxLeftCol + i % 3;


                        if (i != col && board[row][i] == board[row][col]) {
                            valid = false;
                        }

                        if (i != row && board[i][col] == board[row][col]) {
                            valid = false;
                        }
                        if ((boxRow != row || boxCol != col)
                                && board[boxRow][boxCol] == board[row][col]) {
                            valid = false;
                        }
                    }


                }
            }
        }

        return valid;
    }

    public static void solveSudoku(char[][] board) {

        for (int row = 0; row < 9; row++) {
            for (int col = 0; col < 9; col++) {
                if (board[row][col] != '.') {
                    continue;
                }
                else {
                    for (char num = '1'; num <= '9'; num++) {
                        board[row][col] = num;
                        if (isValidSudoku(board)) {
                            continue;
                        }
                        else{
                            break;
                        }
                    }
                }

            }
        }
        System.out.println(board);
    }

    public boolean validTicTacToe(String[] board) {
        char[][] gameBoard = new char[3][3];

        for( int i = 0; i < 3; i++){
            gameBoard[i]=board[i].toCharArray();
        }

        int countX = 0;
        int countO = 0;

        for( int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++) {
                char check = gameBoard[i][j];

                if (check == 'X') countX++;
                if (check == 'O') countO++;
            }
        }

        if (countX < countO) return false;

        if (countX - countO > 1) return false;

        if(countX - countO == 1 && gameOver(gameBoard, 'O')) return false;

        if(countX - countO == 0 && gameOver(gameBoard, 'X')) return false;


        return true;
    }
    public boolean gameOver(char[][] gameBoard, char team) {
        for (int i = 0; i < 3; i++) {
            if (gameBoard[i][0] == team &&
                    gameBoard[i][1] == team &&
                    gameBoard[i][2] == team) {
                return true;
            }
            if (gameBoard[0][i] == team &&
                    gameBoard[1][i] == team &&
                    gameBoard[2][i] == team) {
                return true;
            }
            if (gameBoard[0][0] == team &&
                    gameBoard[1][1] == team &&
                    gameBoard[2][2] == team) {
                return true;
            }
            if (gameBoard[0][2] == team &&
                    gameBoard[1][1] == team &&
                    gameBoard[2][0] == team) {
                return true;
            }
        }
        return false;
    }
}