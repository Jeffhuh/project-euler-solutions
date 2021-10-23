package Problems_1_15;

import java.util.HashMap;

public class p014 {

	static HashMap<Long, Long> tree = new HashMap<>();
	
	public static void main(String[] args) {
		long max = 0;
		long maxKey = 0;
		for (long i = 1; i < 1_000_000; i++) {
			long n = add(i, 1L);
			tree.put(i, n);
			if (n > max) {
				max = n;
				maxKey = i;
			}
		}
		System.out.println(maxKey);
	}
	
	public static long add(long n, long count) {
		if (tree.containsKey(n)) return count + tree.get(n);
		if (n == 1) return count;
		if (n % 2 == 0) {
			n = n >> 1; 
		} else {
			n = 3 * n + 1;
		}
		return add(n, ++count);
	}

}
