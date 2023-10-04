namespace Lab7
{
	template <typename T>
	class FragmentedArray
	{
	public:
		FragmentedArray(size_t fragmentLength, size_t fragmentCount);

		~FragmentedArray();

		T* operator[](int index);

		size_t GetLength();

		size_t GetFragmentCount();

		size_t GetFragmentLength();

	private:
		size_t m_fragmentLength{ 0 };
		size_t m_fragmentCount{ 0 };
		T** m_arraies;
	};

	class Person
	{
	public:
		Person(const char* name, float sellary);

	private:
		float m_sellary;
		const char* m_name;
	};

	template <typename T>
	void addarrays(T& array1, T& array2, T& result, size_t size1, size_t size2)
	{
		result = (T*) malloc(sizeof(T) * size1 + size2);

		for (int i = 0; i < size1; i++)
		{
			result[i] = array1[i];
		}

		for (int i = 0; i < size2; i++)
		{
			result[i + size1] = array2[i];
		}
	}

	int compstr(const char* value1, const char* value2);

	template<typename T>
	FragmentedArray<T>::FragmentedArray(size_t fragmentLength, size_t fragmentCount): m_fragmentCount(fragmentCount), m_fragmentLength(fragmentLength)
	{
		m_arraies = ( T** ) malloc(sizeof(T**) * fragmentCount);

		if (m_arraies == nullptr)
		{
			
		}

		for (int i = 0; i < fragmentCount; i++)
		{
			m_arraies[i] = (T*) malloc(sizeof(T*) * fragmentLength);
		}
	}

	template<typename T>
	FragmentedArray<T>::~FragmentedArray()
	{
		for (int i = 0; i < m_fragmentCount; i++)
		{
			free(m_arraies[i]);
		}

		free(m_arraies);
	}

	template<typename T>
	T* FragmentedArray<T>::operator[](int index)
	{
		return m_arraies[index];
	}

	template<typename T>
	inline size_t FragmentedArray<T>::GetLength()
	{
		return m_fragmentCount * m_fragmentLength;
	}

	template<typename T>
	inline size_t FragmentedArray<T>::GetFragmentCount()
	{
		return m_fragmentCount;
	}

	template<typename T>
	inline size_t FragmentedArray<T>::GetFragmentLength()
	{
		return m_fragmentLength;
	}
}