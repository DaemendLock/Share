package queue;

public class ArrayQueue {

	protected int SIZE = 32;
	protected int front, rear;
	protected int items[] = new int[SIZE];

	ArrayQueue() {
		front = -1;
		rear = -1;
	}

	// Pre true
	// Post !(HasEmptySpace)
	public boolean isFull() {
		if (front == 0 && rear == SIZE - 1) {
			return true;
		}
		if (front == rear + 1) {
			return true;
		}
		return false;
	}

	// Pre true
	// Post (element count)
	public int size() {
		return rear - front;
	}

	// Pre true
	// Post (HasAnyElements)
	public boolean isEmpty() {
		if (front == -1)
			return true;
		else
			return false;
	}

	// Pre true
	// Post reset queue
	public void clear() {
		items = new int[SIZE];
		front = -1;
		rear = -1;
	}

	// Pre int element
	// Post Add element to queue
	public void enqueue(int element) {
		//If queue full increase size
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
	public int dequeue() {
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
	public int element() {
		return items[front];
	}
	//Pre X to look for
	//Post R amount of X in queue
	int count(int x) {
		int res = 0;
		for (int i = front; i <= rear; i++) {
			if (x == items[rear])
				res += 1;
		}

		return res;
	}

}
