#include "../Utils/defines.h"

#pragma region Task1
/// <summary>
/// Выводит стихотворение.
/// </summary>
void ShowPoem();
#pragma endregion

#pragma region Task2
#define FAHRENHEIT_CONVERTIONT_MULTIPLYER 9 / 5
#define FAHRENHEIT_CONVERTIONT_ADD 32

/// <summary>
/// Convert value in degree celsius to degree fahrenheit
/// </summary>
/// <param name="degreeCelsius">convertion value</param>
/// <returns>float value representing temperature in fahrenheit</returns>
float ConvertToFahrenheit(float degreeCelsius);
#pragma endregion

#pragma region Task3
/// <summary>
/// Fraction with integer signed numerator and denominator.
/// </summary>
typedef struct
{
	int numerator;
	int denominator;
} Fraction;


/// <summary>
/// Reads fraction from console in format "numerator/denominator"<br>
/// If denominator 0 or not given - denominator sets to 1.
/// </summary>
/// <param name="message">Console request message</param>
/// <returns>Fraction.</returns>
Fraction ReadFraction(char message[]);

/// <summary>
/// Sums 2 fractions
/// </summary>
Fraction Fraction_Sum(Fraction value1, Fraction value2);

/// <summary>
/// Prints fraction in format "numerator/denominator"
/// </summary>
void Fraction_print(Fraction fraction);
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

OldPound ReadOldPound(char message[]);

Pound OldPound_ConvertToNewPound(OldPound value);

void OldPound_Print(OldPound value);

void Pound_Print(Pound value);
#pragma endregion

#pragma region Task5
Pound ReadPound(char message[]);

OldPound Pound_ConvertToOldPound(Pound value);
#pragma endregion
