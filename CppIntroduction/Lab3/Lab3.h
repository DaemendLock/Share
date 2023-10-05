#include <string.h>

typedef enum EmployeePosition
{
	laborer, secretary, manager, accountant, executive, researcher
} EmployeePosition;

typedef struct Employee
{
	int id;
	float sellary;
} Employee;

Employee ReadEmployee();

EmployeePosition EmployeePosition_Read();

void EmployeePosition_Print(EmployeePosition value);


