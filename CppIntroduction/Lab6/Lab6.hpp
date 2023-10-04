
namespace Lab6
{
	enum Position
	{
		Laborant,
		Adutant,
		Manager
	};

	class Double
	{
	public:
		Double(double value);

		void Clear();

		void Print();

		void SetValue(int value);

		Double operator+(const Double& value2);

	private:
		double m_value{ 0 };
	};

	class Date
	{
	public:
		Date();

		Date(int month, int day, int year);

		void GetDate(const char value[]);

		void ShowDate();

	private:
		int m_month{ 1 };
		int m_day{ 1 };
		int m_year{ 1 };
	};

	class Employee
	{
	public:
		Employee(int id, float sellary);

		Employee(int id, float sellary, Date date, Position position);

		int GetId();

		void SetId(int value);

		float GetSellary();

		void SetSellary(float value);

		Date GetJoinDate();

		Position GetPosition();

	private:
		int m_id{ 0 };
		float m_sellary{ 0 };
		Date m_joinDate {0, 0, 0};
		Position m_position{ (Position)0 };
	};

	class Time
	{
	public:
		Time();

		Time(int hours, int minutes, int seconds);

	private:
		int m_hours{ 0 };
		int m_minutes{ 0 };
		int m_seconds{ 0 };
	};
}