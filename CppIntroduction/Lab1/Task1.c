#include "Task1.h"
#include <stdio.h>

#pragma region Task1
void ShowPoem()
{
	printf("Some deserts on this planet were oceans once%sSomewhere shrouded by the night, the sun will shine%s", NEWLINE,NEWLINE);
}
#pragma endregion

#pragma region Task2
#define FAHRENHEIT_CONVERTIONT_MULTIPLYER 9 / 5
#define FAHRENHEIT_CONVERTIONT_ADD 32

float ConvertToFahrenheit(float degreeCelsius)
{
	return degreeCelsius * FAHRENHEIT_CONVERTIONT_MULTIPLYER + FAHRENHEIT_CONVERTIONT_ADD;
}
#pragma endregion

#pragma region Task3
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

Fraction Fraction_Sum(Fraction value1, Fraction value2)
{
	Fraction result;

	result.numerator = (value1.numerator * value2.denominator + value2.numerator * value1.denominator);
	result.denominator = (value1.denominator * value2.denominator);

	return result;
}

void Fraction_print(Fraction fraction)
{
	printf("%i/%i%s", fraction.numerator, fraction.denominator,NEWLINE);
}
#pragma endregion

#pragma region Task4

#define SHILLING_IN_POUND 20
#define PEN_IN_SHILLING 12
#define NEW_PEN_IN_POUND 100

void OldPound_Print(OldPound value)
{
	printf("%d\u002E%hu\u002E%hu%s", value.Pound, value.Shilling, value.Pens,NEWLINE);
}

void Pound_Print(Pound value)
{
	printf("%d\u002E%hu%s", value.Pound, value.Pens, NEWLINE);
}

Pound ReadPound(char message[]) {
	Pound result;
	printf(message);
	scanf_s("%d\u002E%hu", &result.Pound, &result.Pens);

	return result;
}

OldPound ReadOldPound(char message[])
{
	OldPound result;

	printf(message);
	scanf_s("%d\u002E%hu\u002E%hu", &result.Pound, &result.Shilling, &result.Pens);
	return result;
}

Pound OldPound_ConvertToNewPound(OldPound value)
{
	Pound result;

	result.Pound = value.Pound;
	int pens = value.Shilling * PEN_IN_SHILLING + value.Pens;
	float newPens = ((float)pens) / (SHILLING_IN_POUND * PEN_IN_SHILLING);
	result.Pens = (unsigned short)(newPens * NEW_PEN_IN_POUND);

	return result;
}

OldPound Pound_ConvertToOldPound(Pound value)
{
	OldPound result;
	
	result.Pound = value.Pound;

	int oldPens = value.Pens * (SHILLING_IN_POUND * PEN_IN_SHILLING) / NEW_PEN_IN_POUND;
	result.Pens = oldPens % PEN_IN_SHILLING;
	result.Shilling = oldPens / PEN_IN_SHILLING;

	return result;
}
#pragma endregion
