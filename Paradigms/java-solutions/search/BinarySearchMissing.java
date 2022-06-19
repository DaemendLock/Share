package search;

public class BinarySearchMissing {

	BinarySearchMissing(int x, int[] a){
		this.x = x;
		int res = binRecursive(x, a);
		if (a[res]!=x) 
			System.out.println(res);
	}
	int x = 0;
	boolean func(int a){
		return a>=x;
	}
	
	int binIterative(int x, int[] a) {
		int l = 0;
		int r = a.length;
		int md = 0;
		while(r-l>0) {
			md = (l+r)/2;
			if(func(a[md]))
				r = md;
			else
				l = md+1;
		}
		return l;
	}
	
	int binRecursive(int x, int[] a) {
		return binRecursive(x, a, 0, a.length);
	}
	
	int binRecursive(int x, int[] a, int l, int r) {
		if(r-l>0) {
			int md = (l+r)/2;
			if(func(a[md]))
				return binRecursive(x, a, l, md);
			else
				return binRecursive(x, a, md+1, r);
		}
		return l;
	}
}
