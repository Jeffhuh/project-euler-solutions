package Problems_1_15;

public class p015 {

	public static void main(String[] args) {
		long n = 1;
		for (int i = 21; i < 41; i++) {
			if ((i & 1) == 0) {
				n = n << 1;
			} else {
				n *= i ;
			}
		}
		for (int i = 2; i < 11; i++) {
			n /= i;
		}
		System.out.println(n);
	}

}
