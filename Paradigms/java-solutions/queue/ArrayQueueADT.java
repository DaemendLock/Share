package queue;

abstract public class ArrayQueueADT extends ArrayQueueModule{
	  int SIZE = 32; 
	  int front, rear;
	  int items[] = new int[SIZE];

	  ArrayQueueADT(ArrayQueueModule val) {
	    front = val.front;
	    rear = val.rear;
	    SIZE = val.SIZE;
	    items = val.items;
	  }


	}
