package Problems_1_15;

public class p002 {
	public static void main(String[] args) {
		int sum = 0;
		int fibonacci1 = 1;
		int fibonacci2 = 2;
		do {
			if (fibonacci2 % 2 == 0) {
				sum += fibonacci2;
			}
			int temp = fibonacci2;
			fibonacci2 += fibonacci1; 
			fibonacci1 = temp;
		} while (fibonacci2 < 4000000L);
		System.out.println(sum);
	}
}
