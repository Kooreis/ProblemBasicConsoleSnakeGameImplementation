Here is a simple implementation of a snake game in Java:

```java
import java.util.LinkedList;
import java.util.Random;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Game game = new Game();
        game.start();
    }
}

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

    public void start() {
        Scanner scanner = new Scanner(System.in);
        while (true) {
            drawBoard();
            char move = scanner.next().charAt(0);
            if (!makeMove(move)) {
                break;
            }
        }
        System.out.println("Game Over!");
    }

    private void drawBoard() {
        for (int i = 0; i < HEIGHT; i++) {
            for (int j = 0; j < WIDTH; j++) {
                Point p = new Point(j, i);
                if (snake.contains(p)) {
                    System.out.print(SNAKE);
                } else if (p.equals(fruit)) {
                    System.out.print(FRUIT);
                } else {
                    System.out.print(EMPTY);
                }
            }
            System.out.println();
        }
    }

    private boolean makeMove(char direction) {
        Point head = snake.getFirst();
        Point newHead;
        switch (direction) {
            case 'w':
                newHead = new Point(head.x, head.y - 1);
                break;
            case 's':
                newHead = new Point(head.x, head.y + 1);
                break;
            case 'a':
                newHead = new Point(head.x - 1, head.y);
                break;
            case 'd':
                newHead = new Point(head.x + 1, head.y);
                break;
            default:
                return false;
        }
        if (newHead.x < 0 || newHead.y < 0 || newHead.x >= WIDTH || newHead.y >= HEIGHT || snake.contains(newHead)) {
            return false;
        }
        snake.addFirst(newHead);
        if (newHead.equals(fruit)) {
            fruit = new Point(new Random().nextInt(WIDTH), new Random().nextInt(HEIGHT));
        } else {
            snake.removeLast();
        }
        return true;
    }
}

class Point {
    int x, y;

    Point(int x, int y) {
        this.x = x;
        this.y = y;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Point point = (Point) o;
        return x == point.x && y == point.y;
    }

    @Override
    public int hashCode() {
        return 31 * x + y;
    }
}
```

This game is played in the console. The snake is represented by 'S' and the fruit by 'F'. The snake moves in the direction specified by the user input: 'w' for up, 's' for down, 'a' for left, and 'd' for right. The game ends when the snake hits the wall or itself.