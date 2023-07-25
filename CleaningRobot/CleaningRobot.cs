namespace CleaningRobot;

using System.Diagnostics;

public class Cleaning
{
   private static Stopwatch stopwatch;
   private readonly int[,] terrain;
   public int X { get; private set; }
   public int Y { get; private set; }

   private static Random random;
   public Cleaning(int[,] terrain, int x, int y)
   {
      X = x;
      Y = y;

      this.terrain = new int[terrain.GetLength(0), terrain.GetLength(1)];

      Array.Copy(terrain, this.terrain, terrain.GetLength(0) * terrain.GetLength(1));
      stopwatch = new Stopwatch();
      random = new Random();
   }

   public void Start(int miliseconds)
   {
      stopwatch.Start();
      do
      {
         if (IsDirty)
         {
            Console.WriteLine($"Cleaning X({X})-Y({Y})");
            Clean();
         }
         else
         {
            Move(SelectMove());
         }
      } while (!IsTerrainClean() && !(stopwatch.ElapsedMilliseconds > miliseconds));
   }

   public bool IsDirty => terrain[X, Y] > 0;
   public void Clean() => terrain[X, Y] -= 1;

   public bool MoveAvailable(int x, int y) =>
      x >= 0 &&
      y >= 0 &&
      x < terrain.GetLength(0) &&
      y < terrain.GetLength(1);

   public bool IsTerrainClean()
   {
      // For all cell in terrain; cell equals 0
      foreach (var c in terrain)
      {
         if (c > 0)
         {
            return false;
         }
      }

      return true;
   }

   public void Print()
   {
      var col = terrain.GetLength(1);
      var i = 0;
      var line = "";
      Console.WriteLine("--------------");
      foreach (var c in terrain)
      {
         line += string.Format("  {0}  ", c);
         i++;
         if (col == i)
         {
            Console.WriteLine(line);
            line = "";
            i = 0;
         }
      }
   }

   private Direction SelectMove()
   {
      var list = new List<Direction> { Direction.Down, Direction.Up, Direction.Right, Direction.Left };
      return list[random.Next(0, list.Count)];
   }

   private void Move(Direction direction)
   {
      switch (direction)
      {
         case Direction.Up:
            if (MoveAvailable(X - 1, Y))
            {
               X -= 1;
               break;
            }
            break;
         case Direction.Down:
            if (MoveAvailable(X + 1, Y))
            {
               X += 1;
            }
            break;
         case Direction.Left:
            if (MoveAvailable(X, Y - 1))
            {
               Y -= 1;
            }
            break;
         case Direction.Right:
            if (MoveAvailable(X, Y + 1))
            {
               Y += 1;
            }
            break;
         default:
            break;
      }
   }
}
