#include "Lab4.hpp"
#include <iostream>

namespace Lab4
{
	long hms_to_sec(int hours, int minutes, int seconds)
	{
		time Time = { hours, minutes, seconds };
		return time_GetSeconds(Time);
	}

	long time_to_secs(time Time)
	{
		return time_GetSeconds(Time);
	}

	time secs_to_time(long seconds)
	{
		return time_FromSeconds(seconds);
	}

	void PrintCallCountLocal()
	{
		static int count;
		std::cout << count << std::endl;
	}

	int GlobalCallCount = 0;

	void PrintCallCountGlobal()
	{
		std::cout << GlobalCallCount++ << std::endl;
	}
}