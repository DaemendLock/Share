#include "Time.h"
#include <stdio.h>

time time_FromSeconds(long seconds)
{
	time result;

	result.hours = seconds / ( MINUTES_IN_HOUR * SECONDS_IN_MINUTE );
	result.minutes = seconds / SECONDS_IN_MINUTE % MINUTES_IN_HOUR;
	result.seconds = seconds % SECONDS_IN_MINUTE;

	return result;
}

long time_GetSeconds(time time)
{
	return (long) time.hours * SECONDS_IN_MINUTE * MINUTES_IN_HOUR + time.minutes * SECONDS_IN_MINUTE + time.seconds;
}

time ReadTime(const char* message)
{
	printf(message);

	time result;
	scanf_s("%i:%i:%i", &result.hours, &result.minutes, &result.seconds);

	return result;
}

void time_Print(time value)
{
	printf("%d:%i:%i", value.hours, value.minutes, value.seconds);
}
