package Problems_1_15;

public class p006 {

	public static void main(String[] args) {
		int n1 = 5050 * 5050;
		int sum = 0;
		for (int i = 1; i <= 100; i++) {
			sum += i*i;
		}
		System.out.println(n1 - sum);
	}

}
