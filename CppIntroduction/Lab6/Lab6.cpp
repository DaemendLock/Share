#include "Lab6.hpp"
#include <iostream>
#include <sstream>

using namespace Lab6;

Double::Double(double value): m_value(value)
{
}

void Lab6::Double::Clear()
{
	SetValue(0);
}

void Lab6::Double::Print()
{
	std::cout << m_value;
}

void Lab6::Double::SetValue(int value)
{
	m_value = value;
}

Double Lab6::Double::operator+(const Double& value2)
{
	return Double(m_value + value2.m_value);
}

Lab6::Employee::Employee(int id, float salary) : m_id(id), m_sellary(salary)
{
}

Lab6::Employee::Employee(int id, float salary, Date date, Position position): m_id(id), m_sellary(salary), m_joinDate(date), m_position(position)
{
}



int Lab6::Employee::GetId()
{
	return m_id;
}

void Lab6::Employee::SetId(int value)
{
	m_id = value;
}

float Lab6::Employee::GetSellary()
{
	return m_sellary;
}

void Lab6::Employee::SetSellary(float value)
{
	if (value < 0)
	{
		return;
	}

	m_sellary = value;
}

Lab6::Date Lab6::Employee::GetJoinDate()
{
	return m_joinDate;
}

Position Lab6::Employee::GetPosition()
{
	return m_position;
}

Lab6::Date::Date()
{
}

Lab6::Date::Date(int month, int day, int year) : m_month(month), m_day(day), m_year(year)
{
}

void Lab6::Date::GetDate(const char value[])
{
	std::stringstream source;
	source << value;

	char dummychar;

	source >> m_month >> dummychar >> m_day >> dummychar >> m_year;
}

inline void Lab6::Date::ShowDate()
{
	std::cout << m_month << '/' << m_day << '/' << m_year << std::endl;
}

Lab6::Time::Time()
{
}

Lab6::Time::Time(int hours, int minutes, int seconds) : m_hours(hours), m_minutes(minutes), m_seconds(minutes)
{
}
