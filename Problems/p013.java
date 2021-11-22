package Problems_1_15;

import java.io.File;
import java.util.Scanner;

public class p013 {

	public static void main(String[] args) {
		byte[][] numbers = new byte[100][52];
		short[] digitSum = new short[52];
 		try {
			File f = new File("./files/p013.txt");
			Scanner scan = new Scanner(f);
			int j = 0;
			while (scan.hasNext()) {
				String str = scan.nextLine();
				for (int i = 2; i < numbers[0].length; i++) {
					numbers[j][i] = (byte)((int)str.charAt(i-2) - 48);
				}
				j++;
			}
			scan.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
 		String digits = "";
 		for (int i = numbers[0].length - 1; 0 <= i; i--) {
 			for (int j = 0; j < numbers.length; j++) {
 				digitSum[i] += numbers[j][i];
 			}
 			String s = String.valueOf(digitSum[i]);
			int l = s.length();
			if (l == 3) {
				digitSum[i-2] += (short)(s.charAt(0) - 48);
				digitSum[i-1] += (short)(s.charAt(1) - 48);
			} else if (l == 2) {
				digitSum[i-1] += (short)(s.charAt(0) - 48);
			}
			digits = String.valueOf(s.charAt(s.length() - 1)) + digits;
 		}
 		System.out.println(digits.substring(0,10));
	}

}
