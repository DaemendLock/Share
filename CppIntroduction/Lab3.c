#include "../Utils/Fraction.h"
#include "../Utils/Reader.h"
#include "../Utils/Time.h"
#include "../Lab3/Lab3.h"
#include <stdio.h>

#define EMPLOYEE_COUNT 3

void DoTask1()
{
	Employee employees[EMPLOYEE_COUNT];

	for (int i = 0; i < EMPLOYEE_COUNT; i++)
	{
		employees[i] = ReadEmployee();
	}

	for (int i = 0; i < EMPLOYEE_COUNT; i++)
	{
		printf("Employee %i: sellary - %.2f", employees[i].id, employees[i].sellary);
	}
}

void DoTask2()
{
	EmployeePosition position = EmployeePosition_Read();
	EmployeePosition_Print(position);
}

void DoTask3()
{
	Fraction fraction1 = ReadFraction("Write 1st fraction: ");
	Fraction fraction2 = ReadFraction("Write 2nd fraction: ");

	Fraction_Print(Fraction_Simplify(Fraction_Sum(fraction1, fraction2)));
}

void DoTask4()
{
	time time = ReadTime("Write time (hh:mm:ss):");
	printf("Time in seconds: %d", time_GetSeconds(time));
}

void DoTask5()
{
	time time1 = ReadTime("Write 1st timestamp (hh:mm:ss):");
	time time2 = ReadTime("Write 2nd timestamp (hh:mm:ss):");

	time_Print(time_FromSeconds(time_GetSeconds(time1) + time_GetSeconds(time2)));
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
