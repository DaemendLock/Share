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

