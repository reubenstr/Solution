Console.WriteLine("Neighborhood Cell Solver");
Console.WriteLine();

var positiveCells = new[] { (100, 100), (500, 500)
		};
Solver solver = new Solver(500, 10000, 10000, positiveCells);
solver.Solve();


Console.WriteLine();
Console.WriteLine("Solved: {0} unique cells found at a distance of {1}", solver.CellCount, solver.Distance);