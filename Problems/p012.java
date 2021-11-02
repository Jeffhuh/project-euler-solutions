package Problems_1_15;

public class p012 {

	public static void main(String[] args) {
		long numberWithOver500Divisors = 0; 
		long add = 1;
		while (true) {
			numberWithOver500Divisors += add;
			long divisors = 2;
			long sqrtNumber = (int) Math.sqrt(numberWithOver500Divisors);
			for (long i = 2; i <= sqrtNumber; i++) {
				if (numberWithOver500Divisors % i == 0) {
					divisors += 2;
				}
			}
			if (sqrtNumber * sqrtNumber == numberWithOver500Divisors) {
				divisors--;
			}
			if (divisors > 500) {
				System.out.println(numberWithOver500Divisors);
				break;
			}
			add++;
		}
	}

}
