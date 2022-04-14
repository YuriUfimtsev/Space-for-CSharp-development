namespace Game;

public class Game
{
    private char[,]? mapMatrix;
    private (int, int) currentCursorPosition;

    public void OnLeft(object sendler, EventArgs args)
    {
        if (currentCursorPosition.Item1 - 1 >= 0
            && mapMatrix![currentCursorPosition.Item2, currentCursorPosition.Item1 - 1] == ' ')
        {
            Console.Write(" ");
            SetCursor((currentCursorPosition.Item1 - 1, currentCursorPosition.Item2));
        }
    }

    public void OnRight(object sendler, EventArgs args)
    {
        if (currentCursorPosition.Item1 + 1 < mapMatrix!.GetLength(1)
            && mapMatrix![currentCursorPosition.Item2, currentCursorPosition.Item1 + 1] == ' ')
        {
            Console.Write(" ");
            SetCursor((currentCursorPosition.Item1 + 1, currentCursorPosition.Item2));
        }
    }

    public void Up(object sendler, EventArgs args)
    {
        if (currentCursorPosition.Item2 - 1 >= 0
            && mapMatrix![currentCursorPosition.Item2 - 1, currentCursorPosition.Item1] == ' ')
        {
            Console.Write(" ");
            SetCursor((currentCursorPosition.Item1, currentCursorPosition.Item2 - 1));
        }
    }

    public void Down(object sendler, EventArgs args)
    {
        if (currentCursorPosition.Item2 + 1 < mapMatrix!.GetLength(0)
            && mapMatrix![currentCursorPosition.Item2 + 1, currentCursorPosition.Item1] == ' ')
        {
            Console.Write(" ");
            SetCursor((currentCursorPosition.Item1, currentCursorPosition.Item2 + 1));
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
            }
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
                Console.Write(mapMatrix[i,j]);
            }
            Console.WriteLine();
        }

        var isSpaceEmpty = true;
        currentCursorPosition = (0, 0);
        for (var i = 0; i < mapMatrix.GetLength(0); ++i)
        {
            if (!isSpaceEmpty)
            {
                break;
            }

            for (var j = 0; j < mapMatrix.GetLength(1); ++j)
            {
                if (mapMatrix[i, j] == ' ')
                {
                    SetCursor((j, i));
                    currentCursorPosition = (j, i);
                    isSpaceEmpty = false;
                    break;
                }
            }
        }
    }

    private void SetCursor((int, int) newPosition)
    {
        Console.SetCursorPosition(newPosition.Item1, newPosition.Item2);
        Console.Write("@");
        Console.SetCursorPosition(newPosition.Item1, newPosition.Item2);
        currentCursorPosition = newPosition;
    }

}
