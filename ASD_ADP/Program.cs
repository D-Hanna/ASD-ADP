using ASD_ADP;

Console.WriteLine("Please enter the desired algorithm name!");
var algorithm = Console.ReadLine();

switch (algorithm)
{
    case ("testing"):
        {
            Algorithm1.Main(args);
            break;
        }
        default:
        {
            Console.WriteLine("could not find this algorithm");
            break;
        }
}