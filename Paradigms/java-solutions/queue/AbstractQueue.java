package queue;

import java.util.function.Predicate;

abstract public class AbstractQueue implements Queue {

	// Pre Predicate a
	// Post R = Amount of elements matching a
	public int countIf(Predicate<Integer> a) {
		int buf;
		int res = 0;
		int i = size();
		for (int j = 0; j < i; j++) {
			buf = dequeue();
			if (a.test(buf))
				res++;
			enqueue(buf);
		}
		return res;
	}
}
