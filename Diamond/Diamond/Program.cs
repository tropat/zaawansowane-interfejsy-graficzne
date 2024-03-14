
List<int> diamonds = new List<int>() {1,1,1,1,1};
int combo = 0;

Console.WriteLine("Combo: " + combo + "/3");
Console.WriteLine("Diamonds: " + diamonds.Count);

Console.WriteLine();

Random rnd = new Random();
int math_operator = rnd.Next(0, 4);

int first = rnd.Next(1, 10);
int second = rnd.Next(1, 10);

int user_guess_num = 0;

int result = 0;

string op = "";

while(diamonds.Count > 0)
{
    switch (math_operator)
    {
        case 0:
            op = "+";
            result = first + second;

            break;
        case 1:
            op = "-";
            result = first - second;

            break;
        case 2:
            op = "*";
            result = first * second;

            break;
        case 3:
            op = "/";
            result = first / second;

            break;
        default:
            break;
    }

    Console.Write(first + op + second + " = ");

    try
    {
        var user_guess = Console.ReadLine();
        if (user_guess is not null)
        {
            user_guess_num = Int32.Parse(user_guess);
        }

        if(result == user_guess_num)
        {
            combo += 1;
            if(combo == 3)
            {
                combo = 0;
                diamonds.Add(1);
            }
        } else
        {
            diamonds.RemoveAt(0);
        }
    }
    catch
    {
        diamonds.RemoveAt(0);
    }

    Console.WriteLine();

    Console.WriteLine("Combo: " + combo + "/3");
    Console.WriteLine("Diamonds: " + diamonds.Count);

    Console.WriteLine();

    math_operator = rnd.Next(0, 4);

    first = rnd.Next(1, 10);
    second = rnd.Next(1, 10);

}

Console.WriteLine("Koniec!");