List<double> allPrimes = new();
allPrimes.Add(2);

for (double i = 3; i<= 1000000; i++)
{
    bool isPrime = true;
    foreach(double prime in allPrimes)
    {
        if(i%prime == 0)
        {
            isPrime = false;
            break;
        }
    }
    if(isPrime)
        allPrimes.Add(i);
}

double totalNumsComply = 4; //Count all primes below 10 already
for(int i = 11; i < 1000000; i = i+2)
{
    bool complies = true;
    bool numbersOk = true;
    foreach(char c in i.ToString()) //Discarting all numbers that contain digits that are pairs. 5 or 0s
    {
        if(i.ToString().Length > 1 && (c == '0' || c == '2' || c == '4' || c == '5' || c == '6' || c == '8'))
        {
            numbersOk = false;
            break;
        }
    }
    if (!numbersOk)
        continue;
    if (allPrimes.Contains(i)) //This if contains all the code that swap the digits to create new numbers
    {
        char[] strNum = i.ToString().ToCharArray(); 
        string swapValue = i.ToString();
        for (int j = 1; j < i.ToString().Length; j++)
        {
            char tempChar = swapValue[0];
            for (int k = 0; k < i.ToString().Length-1; k++)
            {
                strNum[k] = strNum[k+1];
            }
            strNum[i.ToString().Length - 1] = tempChar;
            swapValue = new string(strNum);
            if (!allPrimes.Contains(Convert.ToDouble(swapValue)))
                complies = false;
        }
    }
    else
        complies = false;
    if (complies)
        totalNumsComply++;
}
Console.WriteLine("There are {0} circular primes below one million", totalNumsComply);
