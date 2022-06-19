package queue;

import java.util.function.Predicate;

public class LinkedQueue extends AbstractQueue{
	
	protected class Element{
		int val;
		Element next, prev;
	
		Element(int x){
			val = x;
		}
		Element(int x, Element prev){
			val = x;
			this.prev = prev;
			prev.next = this;
		}
		void addNext(int x) {
			next = new Element(x, this);
		}
	}
	int size = 0;
	Element first;
	Element last;

	public void enqueue(int x) {
		if(last==null) {
			last = new Element(x);
			first = last;
			size = 1;
			return;
		}
		size++;
		last.addNext(x);
		last = last.next;
	}

	public int dequeue() {
		
		if(size == 0) {
			return 0;
		}
		if(size==1) {
			last = null;
			int res = first.val;
			first = null;
			size = 0;
			return res;
		}
		first = first.next;
		return first.prev.val;
	}

	public int element() {
		return first.val;
	}

	public int size() {
		return size;
	}

	public boolean isEmpty() {
		return first==null && last == null;
	}

	public void clear() {
		while(first!=null) 
			first = null;
			last = null;
			size = 0;
	}

	@Override
	public int countIf(Predicate<Integer> a) {
		Element cur = first;
		int res = 0;
		while(cur!=null) {
			if(a.test(cur.val))
				res++;
			cur = cur.next;
		}
		return res;
	}
}
