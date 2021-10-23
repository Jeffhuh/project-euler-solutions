package Problems_1_15;

public class p009 {

	public static void main(String[] args) {
		for(int a = 1; a < 998; a++) {
			for (int b = 1; b < 998; b++) {
				if (a+b > 999) continue;
				int c = 1000 - a - b;
				if (c*c == a*a + b*b) {
					System.out.println(c*a*b);
				}
			}
		}
	}

}
