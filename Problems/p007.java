package Problems_1_15;

public class p007 {

	public static void main(String[] args) {
		long[] primes = new long[10001];
		long number = 2L;
		int index = 0;
		boolean b = true;
		while (primes[10_000] == 0) {
			for (long i = 2L; i <= Math.sqrt(number); i++) {
				if (number % i == 0) {
					b = false;
					break;
				}
			}
			if (b) {
				primes[index++] = number;
			}
			b = true;
			number++;
			//System.out.println(number+"  "+index);
		}
		System.out.println(primes[10000]);
	}

}
