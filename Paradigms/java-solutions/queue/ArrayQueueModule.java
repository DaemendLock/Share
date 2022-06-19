package queue;

import java.util.function.Predicate;

public class ArrayQueueModule extends AbstractQueue{
	  int SIZE = 32; 
	  int front, rear;
	  int items[] = new int[SIZE];

	  ArrayQueueModule() {
	    front = -1;
	    rear = -1;
	  }

	
	  boolean isFull() {
	    if (front == 0 && rear == SIZE - 1) {
	      return true;
	    }
	    if (front == rear + 1) {
	      return true;
	    }
	    return false;
	  }

	  public int size() {
		  return rear - front;
	  }
	  public boolean isEmpty() {
	    if (front == -1)
	      return true;
	    else
	      return false;
	  }
	  public void clear() {
		  items = new int[SIZE];
		  front = -1;
		  rear = -1;
	  }

	  public void enqueue(int element) {
	    if (isFull()) {
	    	int buf[] = new int[SIZE*2];
	    	for (int i = 0;i < SIZE;i++)
	    		buf[i] = items[i];
	    	items = buf;
	    	SIZE*=2;
	    	
	    } else {
	      if (front == -1)
	        front = 0;
	      rear = (rear + 1) % SIZE;
	      items[rear] = element;
	    }
	  }


	  public int dequeue() {
	    int element;
	    if (isEmpty()) {
	      return 0;
	    } else {
	      element = items[front];
	      if (front == rear) {
	        front = -1;
	        rear = -1;
	      } 
	      else {
	        front = (front + 1) % SIZE;
	      }
	      return (element);
	    }
	  }
	  public int element() {
		  return items[front];
	  }
	  int count(int x) {
		  int res = 0;
		  for(int i = front; front<=rear;i++) {
			  if(x==items[rear])
				  res+=1;
		  }
		  
		  return res;
	  }

	public int countIf(Predicate<Integer> a) {
		int res = 0;
		for(int i = front; front<=rear;i++) {
			  if(a.test(items[i]))
				  res+=1;
		  }
		return res;
	}




	}