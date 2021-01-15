import java.util.Random;

public class TicTacToe {
    public static boolean gameOver = false;
    public static boolean isOccupied = false;
    public static void generateBoard() {
        System.out.println();
        System.out.println("Welcome to TicTacToe! Player 1 (the user) will go first.");

        // 3x3 board
        // 1 for X, 0 for O
        char[][] board = {
                {' ', '|', ' ', '|', ' '},
                {'-', '-', '-', '-', '-'},
                {' ', '|', ' ', '|', ' '},
                {'-', '-', '-', '-', '-'},
                {' ', '|', ' ', '|', ' '}};

        printBoard(board);
        while (!gameOver) {


                //int numGames = Console.readInt("How many games would you like to play (max 9)? ", 1, 9);
                    int tile = Console.readInt("Enter a tile to place your piece in (1-9): ", 1, 9);
                    tileOccupied(board);
                    if (!isOccupied) {
                        tile = Console.readInt("Enter a tile to place your piece in (1-9): ", 1, 9);
                    }
                    tileChoice(board, tile, "user");
                    //isTileOccupied(board);
                    checkWinner(board);
                    if(gameOver == true) {
                        break;
                    }
                    System.out.println();
                    System.out.println("CPU's move:");
                    System.out.println();
                    Random rand = new Random();
                    int cpuTile = rand.nextInt(9) + 1;
                    tileOccupied(board);
                    if (!isOccupied) {
                        cpuTile = rand.nextInt(9) + 1;
                    }
                    tileChoice(board, cpuTile, "cpu");
                    //isTileOccupied(board);
                    System.out.println();

                    checkWinner(board);
                    if(gameOver == true) {
                        break;
                    }


        }
    }



    public static void printBoard(char[][] board) {
        for (char[] row : board) {
            for (char i : row) {
                System.out.print(i);
            }
            System.out.println();
        }

    }

    public static void tileChoice(char[][] board, int tile, String player) {

        char team = ' ';

            if (player.equals("user")) {
                team = 'X';
            } else if (player.equals("cpu")) {
                team = 'O';
            }

                if (tile == 1) {
                    board[0][0] = team;
                    // checks if tile is already occupied or not


                } else if (tile == 2) {
                    board[0][2] = team;
                } else if (tile == 3) {
                    board[0][4] = team;
                } else if (tile == 4) {
                    board[2][0] = team;
                } else if (tile == 5) {
                    board[2][2] = team;
                } else if (tile == 6) {
                    board[2][4] = team;
                } else if (tile == 7) {
                    board[4][0] = team;
                } else if (tile == 8) {
                    board[4][2] = team;
                } else if (tile == 9) {
                    board[4][4] = team;
                }


            printBoard(board);

    }


    public static boolean checkWinner(char[][] board) {
        // check if player wins, check all 8 conditions

        if (board[0][0] == 'X' && board[0][2] == 'X' && board[0][4] == 'X') {
            System.out.println("Congrats! You Win!");
            gameOver = true;
        } else if (board[0][0] == 'X' && board[2][0] == 'X' && board[4][0] == 'X') {
            System.out.println("Congrats! You Win!");
            gameOver = true;
        }
        else if (board[2][0] == 'X' && board[2][2] == 'X' && board[2][4] == 'X') {
            System.out.println("Congrats! You Win!");
            gameOver = true;
        }
        else if (board[4][0] == 'X' && board[4][2] == 'X' && board[4][4] == 'X') {
            System.out.println("Congrats! You Win!");
            gameOver = true;
        }
        else if (board[0][2] == 'X' && board[2][2] == 'X' && board[4][2] == 'X') {
            System.out.println("Congrats! You Win!");
            gameOver = true;
        }
        else if (board[0][4] == 'X' && board[2][4] == 'X' && board[4][4] == 'X') {
            System.out.println("Congrats! You Win!");
            gameOver = true;
        }
        else if (board[0][0] == 'X' && board[2][2] == 'X' && board[4][4] == 'X') {
            System.out.println("Congrats! You Win!");
            gameOver = true;
        }
        else if (board[4][0] == 'X' && board[2][2] == 'X' && board[0][4] == 'X') {
            System.out.println("Congrats! You Win!");
            gameOver = true;
        }
        
        // Check if CPU has won
        if (board[0][0] == 'O' && board[0][2] == 'O' && board[0][4] == 'O') {
            System.out.println("Oh no! You lost!");
            gameOver = true;

        } else if (board[0][0] == 'O' && board[2][0] == 'O' && board[4][0] == 'O') {
            System.out.println("Oh no! You lost!");
            gameOver = true;
        }
        else if (board[2][0] == 'O' && board[2][2] == 'O' && board[2][4] == 'O') {
            System.out.println("Oh no! You lost!");
            gameOver = true;
        }
        else if (board[4][0] == 'O' && board[4][2] == 'O' && board[4][4] == 'O') {
            System.out.println("Oh no! You lost!");
            gameOver = true;
        }
        else if (board[0][2] == 'O' && board[2][2] == 'O' && board[4][2] == 'O') {
            System.out.println("Oh no! You lost!");
            gameOver = true;
        }
        else if (board[0][4] == 'O' && board[2][4] == 'O' && board[4][4] == 'O') {
            System.out.println("Oh no! You lost!");
            gameOver = true;
        }
        else if (board[0][0] == 'O' && board[2][2] == 'O' && board[4][4] == 'O') {
            System.out.println("Oh no! You lost!");
            gameOver = true;
        }
        else if (board[4][0] == 'O' && board[2][2] == 'O' && board[0][4] == 'O') {
            System.out.println("Oh no! You lost!");
            gameOver = true;
        }
        return gameOver;
    }
        public static boolean tileOccupied(char[][] board) {
            if (board[0][0] == 'X' || board[0][0] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else if (board[0][2] == 'X' || board[0][2] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else if (board[0][4] == 'X' || board[0][4] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else if (board[2][0] == 'X' || board[2][0] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else if (board[2][2] == 'X' || board[2][2] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else if (board[2][4] == 'X' || board[2][4] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else if (board[4][0] == 'X' || board[4][0] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else if (board[4][2] == 'X' || board[4][2] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else if (board[4][4] == 'X' || board[4][4] == 'O') {
                System.out.println("Tile already chosen, pick again.");
                isOccupied = true;

            }
            else {
                isOccupied = false;
            }
            return isOccupied;
        }
}



