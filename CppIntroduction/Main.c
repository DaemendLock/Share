#include <stdio.h>

#ifdef _WIN32
#define NEWLINE "\r\n"
#elif defined macintosh
#define NEWLINE "\r"
#else
#define NEWLINE "\n"
#endif

#pragma region Task1
void ShowPoem()
{
	printf("Some deserts on this planet were oceans once%sSomewhere shrouded by the night, the sun will shine", NEWLINE);
}
#pragma endregion

#pragma region Task2
float ReadFloat(char message[])
{
	float result;
	printf(message);
	scanf_s("%f", &result);
	return result;
}

float ConvertToFahrenheit(float degreeCelsius)
{
	return degreeCelsius * 9 / 5 + 32;
}
#pragma endregion

#pragma region Task3
typedef struct 
{
	int numerator;
	int denominator;
} Fraction;

Fraction ReadFraction(char message[])
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

Fraction SumFraction(Fraction value1, Fraction value2)
{
	Fraction result;

	result.numerator = (value1.numerator * value2.denominator + value2.numerator * value1.denominator);
	result.denominator = (value1.denominator * value2.denominator);

	return result;
}

void print_Fraction(Fraction fraction)
{
	printf("%i/%i", fraction.numerator, fraction.denominator);
}
#pragma endregion

#pragma region Task4

#define SHILLING_IN_POUND 20
#define PEN_IN_SHILLING 12
#define NEW_PEN_IN_POUND 100

typedef struct
{
	int Pound;
	unsigned short Shilling;
	unsigned short Pens;
} OldPound;

typedef struct
{
	int Pound;
	unsigned short Pens;
} Pound;

OldPound ReadOldPound(char message[])
{
	OldPound result;
	
	printf(message);
	scanf_s("%d\u002E%hu\u002E%hu", &result.Pound, &result.Shilling, &result.Pens);

	return result;
}

Pound ConvertOldToNewPound(OldPound value)
{
	Pound result;

	result.Pound = value.Pound;

	int pens = value.Shilling * PEN_IN_SHILLING + value.Pens;
	float newPens = ((float)pens) / (SHILLING_IN_POUND * PEN_IN_SHILLING);
	result.Pens = (unsigned short)(newPens * NEW_PEN_IN_POUND);

	return result;
}

PrintOldPound(OldPound value)
{
	printf("%d\u002E%hu\u002E%hu", value.Pound, value.Shilling, value.Pens);
}

PrintNewPound(Pound value)
{
	printf("%d\u002E%hu", value.Pound, value.Pens);
}
#pragma endregion

#pragma region Task5
Pound ReadPound(char message[]) {
	Pound result;

	printf(message);
	scanf_s("%d\u002E%hu", &result.Pound, &result.Pens);

	return result;
}

OldPound ConvertPoundToOldPound(Pound value)
{
	OldPound result;

	result.Pound = value.Pound;

	int oldPens = value.Pens * (SHILLING_IN_POUND * PEN_IN_SHILLING) / NEW_PEN_IN_POUND;
	result.Pens = oldPens % PEN_IN_SHILLING;
	result.Shilling = oldPens / PEN_IN_SHILLING;

	return result;
}
#pragma endregion
