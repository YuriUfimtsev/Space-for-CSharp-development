namespace Game;

public class Game
{
    private char[,]? mapMatrix;
    private (int, int) CurrentCursorPosition { get; set; }

    public (int, int) CurrentMatrixPosition { get; set; }

    public void OnLeft(object sendler, EventArgs args)
    {
        if (this.CurrentMatrixPosition.Item2 - 1 >= 0
            && mapMatrix![this.CurrentMatrixPosition.Item1, this.CurrentMatrixPosition.Item2 - 1] == ' ')
        {
            this.CurrentMatrixPosition = (this.CurrentMatrixPosition.Item1, this.CurrentMatrixPosition.Item2 - 1);
        }
    }

    public void OnRight(object sendler, EventArgs args)
    {
        if (this.CurrentMatrixPosition.Item2 + 1 < mapMatrix!.GetLength(1)
            && mapMatrix![this.CurrentMatrixPosition.Item1, this.CurrentMatrixPosition.Item2 + 1] == ' ')
        {
            this.CurrentMatrixPosition = (this.CurrentMatrixPosition.Item1, this.CurrentMatrixPosition.Item2 + 1);
        }
    }

    public void Up(object sendler, EventArgs args)
    {
        if (this.CurrentMatrixPosition.Item1 - 1 >= 0
            && mapMatrix![this.CurrentMatrixPosition.Item1 - 1, this.CurrentMatrixPosition.Item2] == ' ')
        {
            this.CurrentMatrixPosition = (this.CurrentMatrixPosition.Item1 - 1, this.CurrentMatrixPosition.Item2);
        }
    }

    public void Down(object sendler, EventArgs args)
    {
        if (this.CurrentMatrixPosition.Item1 + 1 < mapMatrix!.GetLength(0)
            && mapMatrix![this.CurrentMatrixPosition.Item1 + 1, this.CurrentMatrixPosition.Item2] == ' ')
        {
            this.CurrentMatrixPosition = (this.CurrentMatrixPosition.Item1 + 1, this.CurrentMatrixPosition.Item2);
        }
    }

    public void CreateMatrixFromFileMap(string pathToFile)
    {
        StreamReader streamReader = new(pathToFile);
        var line = streamReader.ReadLine();
        if (line == null)
        {
            throw new InvalidDataException();
        }

        var countOfColumns = line.Length;
        var countOfLines = 1;
        while ((line = streamReader.ReadLine()) != null)
        {
            ++countOfLines;
        }

        streamReader.Close();
        streamReader = new(pathToFile);
        this.CurrentCursorPosition = (0, 0);
        var resultMatrix = new char[countOfLines, countOfColumns];
        for (var i = 0; i < countOfLines; ++i)
        {
            line = streamReader.ReadLine();
            if (line == null)
            {
                throw new InvalidDataException();
            }

            for (var j = 0; j < countOfColumns; ++j)
            {
                resultMatrix[i, j] = line[j];
                if (Equals(this.CurrentCursorPosition, (0, 0)) && resultMatrix[i, j] == ' ')
                {
                    this.CurrentCursorPosition = (j, i);
                    this.CurrentMatrixPosition = (i, j);
                }
            }
        }

        if (Equals(this.CurrentCursorPosition, (0, 0)))
        {
            throw new InvalidDataException();
        }

        mapMatrix = resultMatrix;
    }

    public void PrintMapMatrix()
    {
        if (mapMatrix == null)
        {
            throw new InvalidDataException();
        }

        for (var i = 0; i < mapMatrix.GetLength(0); ++i)
        {
            for (var j = 0; j < mapMatrix.GetLength(1); ++j)
            {
                Console.Write(mapMatrix[i, j]);
            }
            Console.WriteLine();
        }

        SetCursor(this.CurrentMatrixPosition);
    }

    public void UpdateCursorPosition(object sendler, EventArgs args)
    {
        Console.Write(" ");
        SetCursor((this.CurrentMatrixPosition));
    }

    private void SetCursor((int, int) newPosition)
    {
        Console.SetCursorPosition(newPosition.Item2, newPosition.Item1);
        Console.Write("@");
        Console.SetCursorPosition(newPosition.Item2, newPosition.Item1);
        this.CurrentCursorPosition = newPosition;
    }
}