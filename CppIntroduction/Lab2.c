#include "../Lab2/Lab2.h"
#include "../Utils/Reader.h"
#include "../Utils/Fraction.h"

#define PYRAMID_SIZE 20

void DoTask1()
{
	for (int i = 1; i <= PYRAMID_SIZE; i++)
	{
		PrintInSpace('x', ' ', i, PYRAMID_SIZE);
	}
}

void DoTask2()
{
	int userInput = ReadInt("Write number to evaluate factorial or 0 to exit: ");

	while (userInput != 0)
	{
		printf("%i! = %d%s", userInput, EvaluateFactorial(userInput), NEWLINE);
		userInput = ReadInt("Write number to evaluate factorial: ");
	}
}

void DoTask3()
{
	float value = ReadFloat("Write initial deposit: ");
	int time = ReadInt("Write years quantity: ");
	float percent = ReadFloat("Write interest rate: ") / 100 + 1;

	for (int i = 1; i <= time; i++)
	{
		value = GetNextDepositValue(value, percent);
		printf("After %i years your deposit is: %.2f%s", i, value, NEWLINE);
	}
}

void DoTask4()
{
	float value = ReadFloat("Write initial credit: ");
	float payment = ReadFloat("Write payment: ");
	int time = ReadInt("Write time: ");
	float percent = ReadFloat("Write year interest rate: ") / 100 ;

	float sum = 0;

	float yearPayment = GetYearPayment(value - payment, percent, time);

	for (int i = 0; i < time; i++)
	{
		sum += yearPayment;
		printf("Paid: %.2f", sum);
	}
}

void DoTask5()
{
	bool exit = false;

	OldPound value1;
	OldPound value2;

	do {
		value1 = ReadOldPound("Write first pounds: ");
		value2 = ReadOldPound("Write second pounds: ");

		printf("Sum: ");
		OldPound_Print(OldPound_Sum(value1, value2));

		exit = ReadBool("Continue?") == false;
	} while (exit == false);
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
