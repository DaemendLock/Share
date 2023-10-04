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

OldPound ReadOldPound(const char message[]);

Pound OldPound_ConvertToNewPound(OldPound value);

void OldPound_Print(OldPound value);

void Pound_Print(Pound value);
#pragma endregion

#pragma region Task5
Pound ReadPound(const char message[]);

OldPound Pound_ConvertToOldPound(Pound value);
#pragma endregion