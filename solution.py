```python
snk_x = sw//4
snk_y = sh//2
snake = [
    [snk_y, snk_x],
    [snk_y, snk_x-1],
    [snk_y, snk_x-2]
]

food = [sh//2, sw//2]
w.addch(int(food[0]), int(food[1]), curses.ACS_PI)

key = curses.KEY_RIGHT
```