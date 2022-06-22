package queue;

public class ArrayQueueADT extends ArrayQueue {
	protected int SIZE = 32;
	protected int front, rear;
	protected int items[] = new int[SIZE];

	ArrayQueueADT() {
		front = -1;
		rear = -1;
	}

	// Pre Q!=Null
	// Post !(HasSpace)
	public static boolean isFull(ArrayQueueADT q) {
		if (q.front == 0 && q.rear == q.SIZE - 1) {
			return true;
		}
		if (q.front == q.rear + 1) {
			return true;
		}
		return false;
	}
	// UPDATE OTHER -- UPDATE OTHER -- UPDATE OTHER

	// Pre Q!=Null
	// Post R = Size of Q
	public static int size(ArrayQueueADT q) {
		return q.rear - q.front;
	}

	// Pre Q!=Null
	// Post Has Q Any elements
	public boolean isEmpty(ArrayQueueADT q) {
		if (q.front == -1)
			return true;
		else
			return false;
	}

	// Pre Q!=Null
	// Post Remove all elements of Q
	public void clear(ArrayQueueADT q) {
		q.items = new int[SIZE];
		q.front = -1;
		q.rear = -1;
	}

	// Pre Q!=Null
	// Post Add element to Q
	public void enqueue(ArrayQueueADT q, int element) {
		if (q.isFull()) {
			int buf[] = new int[q.SIZE * 2];
			for (int i = 0; i < q.SIZE; i++)
				buf[i] = q.items[i];
			q.items = buf;
			q.SIZE *= 2;

		} else {
			if (q.front == -1)
				q.front = 0;
			q.rear = (q.rear + 1) % q.SIZE;
			q.items[q.rear] = element;
		}
	}

	// Pre Q!=Null
	// Post R = first element of Q
	public int dequeue(ArrayQueueADT q) {
		int element;
		if (isEmpty()) {
			return 0;
		} else {
			element = items[front];
			if (front == rear) {
				front = -1;
				rear = -1;
			} else {
				front = (front + 1) % SIZE;
			}
			return (element);
		}
	}

	// Pre Q!=Null
	// Post R = first element of Q
	public int element(ArrayQueueADT q) {
		return items[front];
	}

	// Pre Q!=Null
	// Post R = first element of Q
	int count(ArrayQueueADT q, int x) {
		int res = 0;
		for (int i = q.front; i <= q.rear; i++) {
			if (x == q.items[q.rear])
				res += 1;
		}

		return res;
	}

}
