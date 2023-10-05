#include <stdio.h>
#include <conio.h>
#include "Reader.h"
#include "defines.h"

float ReadFloat(const char message[])
{
	float result;
	printf(message);
	scanf_s("%f", &result);
	return result;
}

int ReadInt(const char message[])
{
	int result;
	printf(message);
	scanf_s("%i", &result);
	return result;
}

int ReadLong(const char message[])
{
	long result;
	printf(message);
	scanf_s("%d", &result);
	return result;
}

bool ReadBool(const char message[])
{
	char result = '\0';
	printf("%s (y/n)", message);

	while (result != 'y' && result != 'n')
	{
		result = _getch();
	}

	printf(NEWLINE);
	return result == 'y';
}

/*
const char* ReadLine(const char message[])
{
	const char* result;

	//scanf_s("%s", result);

	return result;
}*/
