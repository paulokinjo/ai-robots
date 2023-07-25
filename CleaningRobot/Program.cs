// See https://aka.ms/new-console-template for more information
using CleaningRobot;

Console.WriteLine("Hello, World!");

var terrain = new[,]
{
   {0,0,0 },
   {1,1,1},
   {2,2,2}
};

var cleaningRobot = new Cleaning(terrain, 0, 0);
cleaningRobot.Print();
cleaningRobot.Start(5000);
cleaningRobot.Print();

