package Problems_1_15;

public class p010 {

	private static boolean[] primes = new boolean[1_999_998];
	public static void main(String[] args) {
		long sum = 0; 
		for (int i = 2; i < Math.sqrt(primes.length + 2); i++) {
			if (primes[i-2] == false) {
				boolean b = true;
				for (int j = 2; j <= Math.sqrt(i); j++) {
					if (i % j == 0) {
						b = false;
						break;
					}
				}
				if (b) { 
					for (int k = i - 1; k < primes.length; k++) {
						if ((k+2) % i == 0) {
							primes[k] = true;
						}
					}
				}
			}
		}
		for (int l = 2; l < primes.length + 2; l++) {
			if (primes[l-2] == false) {
				sum += l;
			}
		}
		System.out.println(sum);
	}

}
