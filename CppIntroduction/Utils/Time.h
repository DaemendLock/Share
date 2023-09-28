#define SECONDS_IN_MINUTE 60
#define MINUTES_IN_HOUR 60

typedef struct time
{
	int hours;
	int minutes;
	int seconds;
} time;

time time_FromSeconds(long seconds);

long time_GetSeconds(time value);

time ReadTime(const char* message);