namespace Lab4
{
#include "../Utils/Time.h"

	long hms_to_sec(int hours, int minutes, int seconds);

	time secs_to_time(long secs);

	long time_to_secs(time time);

	template <typename T>
	void swap(T& value1, T& value2)
	{
		T buffer = value1;

		value1 = value2;
		value2 = buffer;
	}

	void PrintCallCountLocal();

	void PrintCallCountGlobal();
}