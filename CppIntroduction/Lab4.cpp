#include <iostream>
#include "../Lab4/Lab4.hpp"
#include "../Utils/defines.h"

namespace Utils
{
	extern "C"
	{
#include "../Utils/Reader.h"
	}
}

void DoTask1()
{
	bool exit = false;

	do {
		Lab4::time_Print(Lab4::ReadTime("write time to convert: "));

		exit = Utils::ReadBool("Continue?") == false;
	} while (exit == false);
}

void DoTask2()
{
	Lab4::time time1 = Lab4::ReadTime("Write 1st timestamp (hh:mm:ss):");
	Lab4::time time2 = Lab4::ReadTime("Write 2nd timestamp (hh:mm:ss):");

	Lab4::time_Print(Lab4::secs_to_time(Lab4::time_to_secs(time1) + Lab4::time_to_secs(time2)));
}

void DoTask3()
{
	int value1 = 10;
	int value2 = 20;

	std::cout << "Before swap: value1 = " << value1 << ", value2 = " << value2 << std::endl;

	Lab4::swap(value1, value2);

	std::cout << "After swap: value1 = " << value1 << ", value2 = " << value2 << std::endl;
}

void DoTask4()
{
	Lab4::time value1{ 10,10,10 };
	Lab4::time value2{ 11,11,11 };

	std::cout << "Before swap: value1 seconds = " << Lab4::time_to_secs(value1) << ", value2 seconds = " << Lab4::time_to_secs(value2) << std::endl;

	swap(value1, value2);

	std::cout << "After swap: value1 seconds = " << Lab4::time_to_secs(value1) << ", value2 seconds = " << Lab4::time_to_secs(value2) << std::endl;
}

void DoTask5()
{
	Lab4::PrintCallCountGlobal();
	Lab4::PrintCallCountGlobal();
	Lab4::PrintCallCountGlobal();

	Lab4::PrintCallCountLocal();
	Lab4::PrintCallCountLocal();
	Lab4::PrintCallCountLocal();
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
