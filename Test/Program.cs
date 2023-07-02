// See https://aka.ms/new-console-template for more information

int[,] matrix = new int[1, 5]
{
    { 1, 2, 3, 4, 5 },
};

foreach (var row in matrix)
{
    Console.Write(row);
}

Console.WriteLine("Hello, World!");