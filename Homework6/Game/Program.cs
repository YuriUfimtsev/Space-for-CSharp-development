using Game;

var eventLoop = new EventLoop();
var game = new Game.Game();

var pathToFile = "C:\\Users\\Home\\source\\repos\\Space-for-CSharp-development\\Homework6\\Game\\Map.txt";
game.CreateMatrixFromFileMap(pathToFile);
game.PrintMapMatrix();

eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.TopHandler += game.Up;
eventLoop.BottomHandler += game.Down;


eventLoop.Run();