#ifdef _WIN32
#define NEWLINE "\r\n"
#elif defined macintosh
#define NEWLINE "\r"
#else
#define NEWLINE "\n"
#endif

#define malloc Memory_Allocate
#define realloc Memory_Reallocate
#define free Memory_Free
