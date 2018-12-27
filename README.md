# American-Checkers
A simple American Checkers game written in C#.

**Requirements**
***
* 8 x 8 dimensions
* red and black squares
* bottom left corner is red

**Rules**
***
* pieces only go on red squares
* if a piece can capture another, it must
* no backwards captures allowed by regular pieces
* when a piece reaches the end it becomes a queen
* a queen may capture backwards

**To Do**
* Board Class
* Cell Class
  * Queen Status
  * Status (Unoccupied, Occupied Red, Occupied Black)
  * Location
* Movemaker/Controller/Rules Class
  * Pass it a cell.
  * Heuristics Object
* Heuristic Class
* GUI
