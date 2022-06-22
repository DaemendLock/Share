package search;

public class BinarySearchMissing {

	BinarySearchMissing(int x, int[] a){
		this.x = x;
		int res = binRecursive(x, a);
		//Check for exist
		if (a[res]!=x) 
			//Not in array
			System.out.println(res);
	}
	private int x = 0;
	//Pre true
	//Post Is 'a' match conditions 
	private boolean func(int a){
		return a>=x;
	}
	//Pre Any i>0 a[i] < a[i-1] 
	//Post R a[R]>= x  and (a[R-1] < x || R = 0) 
	public int binIterative(int x, int[] a) {
		int l = 0;
		int r = a.length;
		int md = 0;
		while(r-l>0) {
			//l < r
			md = (l+r)/2;
			//md >= l; md < r;
			if(func(a[md]))
				//a[md] < x
				r = md;
				//a[r] < x
				//r' - l < r - l
			else
				//a[md]>=x
				l = md+1;
				//a[l-1] >= x
				//r - l' < r - l
		}
		//l - correct answer
		return l;
	}
	//Pre Any i > 0 a[i] < a[i-1]
	//Post R a[R]>= x  and (a[R-1] < x || R = 0) 
	public int binRecursive(int x, int[] a) {
		//x - value to compare with, a - array: Any i>0 a[i] < a[i-1] , l - first index to search, a.lenght - max index to search
		return binRecursive(x, a, 0, a.length);
		//R a[R] <= x and (a[R-1]> x || R = 0) || R = -1 => x < a[0]
	}
	//Pre x - value to compare with, a - array: Any i>0 a[i] < a[i-1] , l - first index to search, a.lenght - max index to search
	//Post R a[R]>= x  and (a[R-1] < x || R = 0) 
	int binRecursive(int x, int[] a, int l, int r) {
		if(r-l>0) {
			//l < r
			int md = (l+r)/2;
			//md >= l, md < r
			if(func(a[md]))
				//a[md] < x
				return binRecursive(x, a, l, md);
				//Post R a[R]>= x  and (a[R-1] < x || R = 0) 
			else
				//a[md] >= x
				return binRecursive(x, a, md+1, r);
				//Post R a[R]>= x  and (a[R-1] < x || R = 0) 
				
		}
		//l - correct answer
		return l;
	}
}
