#include "Task1.h"

void DoTask1()
{
	ShowPoem();
}

void DoTask2()
{
	printf("Temperature fahrenheit: %.2f", ConvertToFahrenheit(ReadFloat("Write temperature in celsius: ")));
}

void DoTask3()
{
	Fraction fraction1 = ReadFraction("Write fraction 1:");
	Fraction fraction2 = ReadFraction("Write fraction 2:");

	Fraction_print(Fraction_Sum(fraction1, fraction2));
}

void DoTask4()
{
	Pound_Print(OldPound_ConvertToNewPound(ReadOldPound("Write old pound:")));
}

void DoTask5()
{
	OldPound_Print(Pound_ConvertToOldPound(ReadPound("Write pounds : ")));
}

int main(int argCount, char* args[])
{
	if (argCount != 2)
	{
		return 128;
	}

	switch (args[1][0])
	{
	case '1':
		DoTask1();
		break;

	case '2':
		DoTask2();
		break;

	case '3':
		DoTask3();
		break;

	case '4':
		DoTask4();
		break;

	case '5':
		DoTask5();
		break;

	default:
		return 1;
	}

	return 0;
}
