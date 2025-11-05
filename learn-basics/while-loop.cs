bool DisplayMenu = true;
while (DisplayMenu)
{
    DisplayMenu = MainMenu();
}

static bool MainMenu()
{
    Console.Clear();
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1) Print Numbers");
    Console.WriteLine("2) Guessing Game");
    Console.WriteLine("3) Exit");
    Console.Write("Your option: ");
    string result = Console.ReadLine();
    if (result == "1")
    {
        PrintNumbers();
        return true;
    }
    else if (result == "2")
    {
        GuessingGame();
        return true;
    }
    else if (result == "3")
        return false;
    else
        return true;
}

static void PrintNumbers()
{
    Console.Clear();
    Console.WriteLine("Print Numbers!");
    Console.WriteLine("Type a number:");
    int result = int.Parse(Console.ReadLine());
    int counter = 1;
    while (counter <= result)
    {
        Console.Write(counter + " ");
        counter++;
    }
    Console.WriteLine();
    Console.WriteLine("Press Enter to return to Main Menu");
    Console.ReadLine();
}

static void GuessingGame()
{
    Console.Clear();
    Console.WriteLine("Guessing Game!");

    Random myRandom = new Random();
    int randomNumber = myRandom.Next(1, 101);

    int guesses = 0;
    bool incorrect = true;

    do
    {
        Console.WriteLine("Guess a number between 1 and 10:");
        int guessedNumber = int.Parse(Console.ReadLine());
        guesses++;
        if (guessedNumber == randomNumber)
            incorrect = false;
        else
            Console.WriteLine("Wrong! Try again.");
    } while (incorrect);
    
    Console.WriteLine("Correct! The number was " + randomNumber + ", then you guessed " + guesses + " times.");
    Console.WriteLine("Press Enter to return to Main Menu");
    Console.ReadLine();
}