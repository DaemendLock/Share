/// <summary>
/// Fraction with integer signed numerator and denominator.
/// </summary>
typedef struct Fraction
{
	int numerator;
	int denominator;
} Fraction;

/// <summary>
/// Reads fraction from console in format "numerator/denominator". 
/// If denominator 0 or not given - denominator sets to 1.
/// </summary>
/// <param name="message">Console request message</param>
/// <returns>Fraction.</returns>
Fraction ReadFraction(const char message[]);

/// <summary>
/// Sums 2 fractions
/// </summary>
Fraction Fraction_Sum(Fraction value1, Fraction value2);

/// <summary>
/// Prints fraction in format "numerator/denominator"
/// </summary>
void Fraction_Print(Fraction fraction);

Fraction Fraction_Simplify(Fraction fraction);