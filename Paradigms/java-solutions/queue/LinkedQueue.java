package queue;

public class LinkedQueue extends AbstractQueue {

	protected class Element {
		int val;
		Element next, prev;

		// Pre X to store
		// Post Element with out links to prev/next elem
		Element(int x) {
			val = x;
		}

		// Pre X to store
		// Post Element with out links to next elem
		Element(int x, Element prev) {
			val = x;
			this.prev = prev;
			prev.next = this;
		}

		// Pre X to store
		// Post Add next element of queue
		void addNext(int x) {
			next = new Element(x, this);
		}
	}

	int size = 0;
	Element first;
	Element last;

	// Pre int element
	// Post Add element to queue
	public void enqueue(int x) {
		if (last == null) {
			last = new Element(x);
			first = last;
			size = 1;
			return;
		}
		size++;
		last.addNext(x);
		last = last.next;
	}

	// Pre true
	// Post R = (0 && Queue empty) || first queue element
	public int dequeue() {

		if (size == 0) {
			return 0;
		}
		if (size == 1) {
			last = null;
			int res = first.val;
			first = null;
			size = 0;
			return res;
		}
		first = first.next;
		return first.prev.val;
	}

	// Pre true
	// Post (element count)
	public int element() {
		return first.val;
	}

	// Pre true
	// Post (element count)
	public int size() {
		return size;
	}

	// Pre true
	// Post (HasAnyElements)
	public boolean isEmpty() {
		return first == null && last == null;
	}

	// Pre true
	// Post reset queue
	public void clear() {
		while (first != null)
			first = null;
		last = null;
		size = 0;
	}

}
