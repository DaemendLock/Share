#include "Lab3.h"
#include <stdio.h>

Employee ReadEmployee()
{
	int id;
	float sellary;

	printf("Write id: ");
	scanf_s("%i", &id);

	printf("Write employee sellary:");
	scanf_s("%f", &sellary);

	Employee result = { id, sellary };
	return result;
}

static const char* employeePositionsList[] = { "laborer", "secretary", "manager", "accountant", "executive", "researcher" };

EmployeePosition EmployeePosition_Read()
{
	char input;
	
	printf("Write employee position: ");
	scanf_s("%c", &input);

	for (int i = 0; i < sizeof(employeePositionsList) / sizeof(char*); i++)
	{
		if (input == employeePositionsList[i][0])
		{
			return (EmployeePosition) i;
		}
	}

	return -1;
}

void EmployeePosition_Print(EmployeePosition value)
{
	printf("%s", employeePositionsList[value]);
}

