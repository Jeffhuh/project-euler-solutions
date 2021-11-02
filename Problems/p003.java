package Problems_1_15;

public class p003 {

	public static void main(String[] args) {
		long n = 600851475143L;
		long primeFactor = 2L;
		for (long i = 2; i < n; i++) {
			if (n % i == 0) {
				while (n % i == 0) {
					n /= i;
				}
			}
		}
		System.out.println(n);
	}

}
