




static void main()
{
    string fullRollString = "";
    Console.Write("write dice string (ndX+mdY+...)\n");

    //get roll
    try
    {
        fullRollString = Console.ReadLine();
    }

    catch (Exception error)
    {
        Console.WriteLine(error.Message);
        Console.WriteLine("Try again...\n\n\n");
        return;
    }

    //split de ndX into [n, X]
   
    string[] diceParametersString = fullRollString.Split("+");
    
   
    int[,] diceParameters = new int[diceParametersString.Length,2];


    //make int and add to diceParameters array
    int i = 0;
    foreach (string parameterString in diceParametersString)
    {
        //get each side of the d
        string[] paramStringArray = parameterString.Split("d");

        //dice amount is i,0. dice type is i,1
        diceParameters[i,0] = int.Parse(paramStringArray[0]);
        diceParameters[i, 1] = int.Parse(paramStringArray[1]);

        i++;
    }

   
    //create dices in array
    DiceGroup[] rolledDice = new DiceGroup[diceParameters.GetUpperBound(0)+1];
    
    for (int j = 0; j < diceParameters.GetUpperBound(0)+1; j++)
    {
        rolledDice[j] = new DiceGroup(diceParameters[j,0], diceParameters[j,1]);
    }

    //add expected values of dices in array
    decimal result = 0M;
    foreach (DiceGroup rolledDiceGroup in rolledDice)
    {
        if (rolledDiceGroup != null) 
        {
            result += rolledDiceGroup.ExpectedValue();
        }

    }
    
    Console.WriteLine($"\nThe expected value is:{result:N1}\n\n");
    Console.WriteLine("press enter for new roll");
    return;
}


Console.Write("Welcome to the expected value calculator for dice rolls!\n\n");
while (true)
{
    main();
    Console.ReadLine();
}






class DiceGroup (int amount = 1, int max = 6)
{
    decimal diceType = max;
    decimal diceAmount = amount;


    decimal value = 0M;
    public decimal ExpectedValue()
    {
        //expected value of each individual dice
        for (int k = 1; k <= diceType; k++)
        {
            value += k / diceType;
        }

        return value * diceAmount;
    }
}

