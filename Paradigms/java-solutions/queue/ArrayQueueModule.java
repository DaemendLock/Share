package queue;

public class ArrayQueueModule {
	protected static int SIZE = 32;
	protected static int front, rear;
	protected static int items[] = new int[SIZE];

	ArrayQueueModule() {
		front = -1;
		rear = -1;
	}

	// Pre true
	// Post !(HasEmptySpace)
	public static boolean isFull() {
		if (front == 0 && rear == SIZE - 1) {
			return true;
		}
		if (front == rear + 1) {
			return true;
		}
		return false;
	}

	// Pre ture
	// Post (HasAnyElements)
	public static int size() {
		return rear - front;
	}
	// Pre true
	// Post (HasAnyElements)
	public static boolean isEmpty() {
		if (front == -1)
			return true;
		else
			return false;
	}
	// Pre true
	// Post reset queue
	public static void clear() {
		items = new int[SIZE];
		front = -1;
		rear = -1;
	}
	// Pre true
	// Post Add element to queue
	public static void enqueue(int element) {
		if (isFull()) {
			int buf[] = new int[SIZE * 2];
			for (int i = 0; i < SIZE; i++)
				buf[i] = items[i];
			items = buf;
			SIZE *= 2;

		} else {
			if (front == -1)
				front = 0;
			rear = (rear + 1) % SIZE;
			items[rear] = element;
		}
	}
	// Pre true
	// Post R = 0 || first queue element
	public static int dequeue() {
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
	// Pre true
	// Post First queue element
	public static int element() {
		return items[front];
	}
	
	// Pre true
	// Post (element count)
	public static int count(int x) {
		int res = 0;
		for (int i = front; i <= rear; i++) {
			if (x == items[rear])
				res += 1;
		}

		return res;
	}

}
