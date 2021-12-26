using System.Collections;

internal class Solver
{
    public Solver(int distance, int height, int width, (int, int)[] postiveCells)
    {
        Distance = distance;
        _grid = new int[height, width];

        foreach (var cell in postiveCells)
        {
            if (cell.Item1 >= 0 && cell.Item1 < height && cell.Item2 >= 0 && cell.Item2 < width)
            {
                _positiveCellCount++;
                _grid[cell.Item1, cell.Item2] = 1;
            }
        }
    }

    public void Solve()
    {
        Console.WriteLine("Solving grid size: [{0}, {1}], distance: {2}, positive cells: {3}", _grid.GetLength(0), _grid.GetLength(1), Distance, _positiveCellCount);
        Console.WriteLine();
        for (int x = 0; x < _grid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                if (_grid[x, y] > 0)
                {
                    Console.WriteLine("Neighborhood found at ({0}, {1})", x, y);
                    ProcessNeighborhood(x, y);
                }
            }
        }
    }

    private void ProcessNeighborhood(int x, int y)
    {
        for (int xOffset = 0; xOffset < Distance + 1; xOffset++)
        {
            for (int yOffset = 0; yOffset < Distance + 1 - xOffset; yOffset++)
            {
                ProcessCell(x + xOffset, y + yOffset);
                if (xOffset != 0)
                {
                    ProcessCell(x - xOffset, y + yOffset);
                }
                if (yOffset != 0)
                {
                    ProcessCell(x + xOffset, y - yOffset);
                }
                if (xOffset != 0 && yOffset != 0)
                {
                    ProcessCell(x - xOffset, y - yOffset);
                }
            }
        }
    }

    private void ProcessCell(int x, int y)
    {
        if (x >= 0 && x < _grid.GetLength(0) && y >= 0 && y < _grid.GetLength(1))
        {
            if (!_hashedCells.ContainsKey((x, y)))
            {
                _hashedCells.Add((x, y), null);
            }
        }
    }
    public int CellCount
    {
        get
        {
            return _hashedCells.Count;
        }
    }
    public int Distance
    {
        get;
        set;
    }
    private int[,] _grid;
    private int _positiveCellCount = 0;
    private Hashtable _hashedCells = new Hashtable();
}

