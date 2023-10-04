#include "Lab2.h"

void PrintInSpace(char printSymbol, char fillSymbol, int count, int length)
{
	for (int i = 0; i < length; i++)
	{
		if (i < length - count)
		{
			printf("%c", fillSymbol);
			continue;
		}

		printf("%c", printSymbol);
	}

	printf(NEWLINE);
}

long EvaluateFactorial(int value)
{
	if (value == 0)
	{
		return 1;
	}

	int result = 1;

	for (int i = 2; i <= value; i++)
	{
		result *= i;
	}

	return result;
}

float GetNextDepositValue(float value, float multiplier)
{
	return value * multiplier;
}

OldPound OldPound_Sum(OldPound value1, OldPound value2)
{
	OldPound result;

	result.Pens = value1.Pens + value2.Pens;
	result.Shilling = value1.Shilling + value2.Shilling;
	result.Pound = value1.Pound + value2.Pound;

	if (result.Pens >= PEN_IN_SHILLING)
	{
		result.Pens -= PEN_IN_SHILLING;
		result.Shilling += 1;
	}

	if (result.Shilling >= SHILLING_IN_POUND)
	{
		result.Shilling -= SHILLING_IN_POUND;
		result.Pound += 1;
	}

	return result;
}
