package Problems_1_15;

public class p004 {

	public static void main(String[] args) {
		int number = 0;
		for (int i = 100; i < 1000; i++) {
			for (int j = 100; j < 1000; j++) {
				int product = j * i; 
				boolean b = palindrome(String.valueOf(product));
				if (b && product > number) {
					number = product;
				}
			}
		}
		System.out.println(number);
	}
	
	public static boolean palindrome(String s) {
		for (int i = 0; i < s.length()/2; i++) {
			if (s.charAt(i) != s.charAt(s.length()-1-i)) {
				return false;
			}
		}
		return true;
	}
}
