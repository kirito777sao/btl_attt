/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package attt;
import java.util.Scanner;
/**
 *
 * @author Admin
 */
public class Vegenere {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Nhập vào văn bản cần mã hóa: ");
        String plainText = scanner.nextLine().toUpperCase();

        System.out.print("Nhập vào khóa: ");
        String key = scanner.nextLine().toUpperCase();

        String cipherText = encrypt(plainText, key);
        System.out.println("Văn bản đã mã hóa: " + cipherText);

        String decryptedText = decrypt(cipherText, key); // Thêm phần giải mã
        System.out.println("Văn bản đã giải mã: " + decryptedText);

        scanner.close();
    }

    public static String encrypt(String plainText, String key) {
        String cipherText = ""; // Khởi tạo chuỗi rỗng để lưu văn bản đã mã hóa
        int keyIndex = 0;

        for (int i = 0; i < plainText.length(); i++) {
            char plainChar = plainText.charAt(i);
            char keyChar = key.charAt(keyIndex);

            if (Character.isLetter(plainChar)) {
                // Tìm vị trí của ký tự trong bảng chữ cái (bằng ASCII)
                int plainCharIndex = plainChar - 'A';
                int keyCharIndex = keyChar - 'A';

                // Thực hiện mã hóa Vigenere
                int cipherCharIndex = (plainCharIndex + keyCharIndex) % 26;
                char cipherChar = (char) (cipherCharIndex + 'A');
                cipherText += cipherChar; // Nối thêm ký tự mã hóa vào chuỗi cipherText
            } else {
                cipherText += plainChar; // Giữ nguyên ký tự không phải chữ cái
            }

            keyIndex = (keyIndex + 1) % key.length(); // Di chuyển đến ký tự tiếp theo trong khóa
        }
        return cipherText; // Trả về chuỗi văn bản đã mã hóa
    }

    public static String decrypt(String cipherText, String key) { // Hàm giải mã
        String decryptedText = ""; // Khởi tạo chuỗi rỗng để lưu văn bản đã giải mã
        int keyIndex = 0;

        for (int i = 0; i < cipherText.length(); i++) {
            char cipherChar = cipherText.charAt(i);
            char keyChar = key.charAt(keyIndex);

            if (Character.isLetter(cipherChar)) {
                // Tìm vị trí của ký tự trong bảng chữ cái (bằng ASCII)
                int cipherCharIndex = cipherChar - 'A';
                int keyCharIndex = keyChar - 'A';

                // Thực hiện giải mã Vigenere
                int decryptedCharIndex = (cipherCharIndex - keyCharIndex + 26) % 26; // Trừ mã số và tính modulo
                char decryptedChar = (char) (decryptedCharIndex + 'A');
                decryptedText += decryptedChar; // Nối thêm ký tự giải mã vào chuỗi decryptedText
            } else {
                decryptedText += cipherChar; // Giữ nguyên ký tự không phải chữ cái
            }

            keyIndex = (keyIndex + 1) % key.length(); // Di chuyển đến ký tự tiếp theo trong khóa
        }

        return decryptedText; // Trả về chuỗi văn bản đã giải mã
    }
}
