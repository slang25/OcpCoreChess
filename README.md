# OCP Core Chess

3rd attempt at making a chess playing engine.

## Developer Notes

### TODOs

- Get movement working before adding state and pooling to `_cells` in `Board`.
- Move ordering?
  - Captures preferred. 
  - Lower valur taking higher even better.
  - Moves that don't go onto an attacked square.

### Cell Arrangement

```
         File
         a  b  c  d  e  f  g  h
       +------------------------
Rank 8 | 56 57 58 59 60 61 62 62
     7 | 48 49 50 51 52 53 54 55
     6 | 40 41 42 43 44 45 46 47
     5 | 32 33 34 35 36 37 38 39
     4 | 24 25 26 27 28 29 30 31
     3 | 16 17 18 19 20 21 22 23
     2 | 8  9  10 11 12 13 14 15
     1 | 0  1  2  3  4  5  6  7
```