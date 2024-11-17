/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package attt;
import java.util.Scanner;
/**fffff
 * bổ sung thêm điều kiện kiểm tra khóa có bị trùng lặp không, có phải kí tự chữ cái không
 * @author Admin
 */
public class ThayTheDonBang {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Nhập khóa mã hóa
        System.out.print("Nhập khóa mã hóa (26 ký tự): ");
        String key = scanner.nextLine().toUpperCase(); // Chuyển khóa thành chữ hoa

        // Kiểm tra độ dài của khóa
        if (key.length() != 26) {
            System.out.println("Khóa phải có độ dài 26 ký tự.");
            return;
        }

        // Kiểm tra tính hợp lệ của khóa
        if (!isValidKey(key)) {
            System.out.println("Khóa không hợp lệ. Khóa phải chứa 26 ký tự chữ cái khác nhau.");
            return;
        }

        // Chuyển khóa thành mảng ký tự
        char[] keyArray = key.toCharArray();

        // Nhập văn bản cần mã hóa
        System.out.print("Nhập văn bản cần mã hóa: ");
        String textmh = scanner.nextLine();

        // Mã hóa văn bản
        String encodedText = encode(textmh, keyArray);
        System.out.println("Bản mã: " + encodedText);
        
        // Nhập văn bản cần giải mã
        System.out.print("Nhập văn bản cần giải mã: ");
        String textgm = scanner.nextLine();

        // Giải mã bản mã
        String decodedText = decode(textgm, keyArray);
        System.out.println("Bản rõ: " + decodedText);
    }

    // Hàm kiểm tra tính hợp lệ của khóa
    public static boolean isValidKey(String key) {
        if (key.length() != 26) {
            return false;
        }
        for (int i = 0; i < 26; i++) {
            if (!Character.isLetter(key.charAt(i))) {
                return false;
            }
            for (int j = i + 1; j < 26; j++) {
                if (key.charAt(i) == key.charAt(j)) {
                    return false;
                }
            }
        }
        return true;
    }

    // Hàm mã hóa
    public static String encode(String text, char[] keyArray) {
        String encodedText = ""; 
        for (int i = 0; i < text.length(); i++) {
            char ch = text.charAt(i);
            if (Character.isLetter(ch)) {
                // Chuyển chữ cái thành chữ hoa
                ch = Character.toUpperCase(ch);
                // Tìm vị trí của chữ cái trong bảng chữ cái
                int index = ch - 65; 
                // Mã hóa chữ cái bằng ký tự trong khóa
                encodedText += keyArray[index];
            } else {
                // Giữ nguyên các ký tự không phải chữ cái
                encodedText += ch;
            }
        }
        return encodedText;
    }

    // Hàm giải mã
    public static String decode(String text, char[] keyArray) {
        String decodedText = "";
        for (int i = 0; i < text.length(); i++) {
            char ch = text.charAt(i);
            if (Character.isLetter(ch)) {
                // Chuyển chữ cái thành chữ hoa
                ch = Character.toUpperCase(ch);
                // Tìm vị trí của chữ cái trong khóa
                int index = findIndex(keyArray, ch);
                // Giải mã chữ cái bằng ký tự trong bảng chữ cái
                decodedText += (char)(65 + index);
            } else {
                // Giữ nguyên các ký tự không phải chữ cái
                decodedText += ch;
            }
        }
        return decodedText;
    }

    // Hàm tìm vị trí của một ký tự trong một mảng
    public static int findIndex(char[] arr, char ch) {
        for (int i = 0; i < arr.length; i++) {
            if (arr[i] == ch) {
                return i;
            }
        }
        return -1; // Ký tự không tìm thấy trong mảng
    }
}
