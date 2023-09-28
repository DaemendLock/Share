#include <stdbool.h>

/// <summary>
/// Read float from console.
/// </summary>
/// <param name="message">Console request message</param>
/// <returns>Float value</returns>
float ReadFloat(const char message[]);


/// <summary>
/// Read int from console.
/// </summary>
/// <param name="message">Console request message</param>
/// <returns>Int value</returns>
int ReadInt(const char message[]);

/// <summary>
/// Read yes ot no from console.
/// </summary>
/// <param name="message">Console request message</param>
/// <returns>Bool value</returns>
bool ReadBool(const char message[]);

const char* ReadLine(const char message[]);
