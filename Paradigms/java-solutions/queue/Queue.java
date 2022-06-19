package queue;

import java.util.function.Predicate;

interface Queue {
	void enqueue(int x);
	int dequeue();
	int element();
	int size();
	boolean isEmpty();
	void clear();
	int countIf(Predicate<Integer> a);
}
