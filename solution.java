class Game {
    private static final int WIDTH = 10;
    private static final int HEIGHT = 10;
    private static final char EMPTY = ' ';
    private static final char SNAKE = 'S';
    private static final char FRUIT = 'F';

    private char[][] board;
    private LinkedList<Point> snake;
    private Point fruit;

    public Game() {
        board = new char[HEIGHT][WIDTH];
        snake = new LinkedList<>();
        snake.add(new Point(WIDTH / 2, HEIGHT / 2));
        fruit = new Point(new Random().nextInt(WIDTH), new Random().nextInt(HEIGHT));
    }
}