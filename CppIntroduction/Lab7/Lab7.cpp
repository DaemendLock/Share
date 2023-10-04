#include "Lab7.hpp"

int Lab7::compstr(const char* value1, const char* value2)

{
	int length = sizeof(value1) < sizeof(value2) ? sizeof(value1) : sizeof(value2);

	for (int i = 0; i < length; i++)
	{
		if (value1[i] == value2[i])
		{
			continue;
		}

		return ( value1 < value2 );
	}

	if (sizeof(value1) == sizeof(value2))
	{
		return 0;
	}

	if (sizeof(value1) == length)
	{
		return -1;
	}

	return 1;
}

Lab7::Person::Person(const char* name, float sellary) : m_name(name), m_sellary(sellary)
{
}
