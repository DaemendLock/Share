#include "Fraction.h"
#include "defines.h"
#include <stdio.h>

Fraction ReadFraction(const char message[])
{
	Fraction result;

	printf(message);
	scanf_s("%i/%i", &result.numerator, &result.denominator);

	if (result.denominator == 0)
	{
		result.denominator = 1;
	}

	return result;
}

Fraction Fraction_Sum(Fraction value1, Fraction value2)
{
	Fraction result;

	result.numerator = ( value1.numerator * value2.denominator + value2.numerator * value1.denominator );
	result.denominator = ( value1.denominator * value2.denominator );

	return result;
}

void Fraction_Print(Fraction fraction)
{
	printf("%i/%i%s", fraction.numerator, fraction.denominator, NEWLINE);
}

Fraction Fraction_Simplify(Fraction value)
{
	for (int i = 2; value.denominator >= i * i; i++)
	{
		if ((value.denominator % i) != 0 || (value.numerator % i) != 0)
		{
			continue;
		}

		value.numerator /= value.denominator / i;
		value.denominator = i;
		return value;
	}

	return value;
}



//25 - lms
//25 - examination
//20 - dictanti
//10 - presentaion
//10 - grammar control
//10 - visiting