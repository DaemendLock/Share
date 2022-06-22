package queue;

import java.util.function.Predicate;

interface Queue {
	
	// Pre int element
	// Post Add element to queue
	void enqueue(int x);
	// Pre true
	// Post R = 0 || first queue element
	int dequeue();
	// Pre true
	// Post First queue element
	int element();
	// Pre true
	// Post (element count)
	int size();

	// Pre ture
	// Post (HasAnyElements)
	boolean isEmpty();
	// Pre true
	// Post reset queue
	void clear();
	//Pre Predicate a
	//Post R = Amount of elements matching a
	int countIf(Predicate<Integer> a);
}
