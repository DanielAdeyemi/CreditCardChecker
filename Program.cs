using System;
using static System.Console;
using System.Collections.Generic;

namespace credit.solution
{
class Program
{
	static void Main(string[] args)
	{
		string inN = ReadLine();
		long cardNumber;
		List<long> cardDigits = new List<long>();
		if (Int64.TryParse(inN, out cardNumber))
		{
			int count = 1;
			while (cardNumber > 0)
			{	
				if (count%2 != 0)
				{
					cardDigits.Add(cardNumber % 10);
				}
				else
				{
					long cardInDigit = (cardNumber %10) * 2;
					if (cardInDigit > 10)
					{
						cardInDigit = cardInDigit%10 + 1;
					}
					cardDigits.Add(cardInDigit);
				}
				cardNumber /=10;
				count ++;
			}
			int sum = 0;
			foreach (int digit in cardDigits)
			{
				sum += digit;
			}
			if (count != 16 && count != 17 && count != 14 && sum % 10 != 0)
			{
				WriteLine("Invalid Number");
			}
			if ((count == 17 && cardDigits[15] == 8)|| (count == 14 && cardDigits[12] == 4))
			{
				WriteLine("Visa");
			}
			else if(count == 17 && cardDigits[15] == 10 && (cardDigits[14] == 1 ||  cardDigits[14] == 2 
			||  cardDigits[14] == 3 ||  cardDigits[14] == 4 ||  cardDigits[14] == 5))
			{
				WriteLine("MasterCard");
			}
			else if(count == 16 && cardDigits[14] == 3 && (cardDigits[13] == 5 || cardDigits[13] == 6))
			{
				WriteLine("American Express");
			}
			else
			{
				WriteLine("Invalid number");
			}
		}
		else
		{
			WriteLine("Invalid number");
		}
	}
}
}
