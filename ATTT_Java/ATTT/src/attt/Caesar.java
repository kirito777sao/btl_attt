/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package attt;
import java.util.Scanner;

/**
 * bổ sung điều kiện + số âm ở khóa, cộng quá vd như 53
 * @author Admin
 */
public class Caesar {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Nhập vào văn bản cần mã hóa: ");
        String plainText = scanner.nextLine();

        System.out.print("Nhập vào khóa (số nguyên dương): ");
        int key = scanner.nextInt();
        
         // Xử lý trường hợp khóa âm hoặc quá lớn
        if (key < 0) {
            key = key % 26 + 26; // Chuyển về khóa dương tương đương
        } else if (key > 26) {
            key = key % 26; // Chuyển về khóa trong khoảng 0-25
        }

        String cipherText = encrypt(plainText, key);
        System.out.println("Văn bản đã mã hóa: " + cipherText);

        String decryptedText = decrypt(cipherText, key);
        System.out.println("Văn bản đã giải mã: " + decryptedText);

        scanner.close();
    }

    public static String encrypt(String plainText, int key) {
        String cipherText = ""; 

        for (char character : plainText.toCharArray()) { 
            if (Character.isLetter(character)) { 
                boolean isUpperCase = Character.isUpperCase(character); 
                character = Character.toLowerCase(character); 
                int charIndex = character - 97; 
                int encryptedIndex = (charIndex + key) % 26; 
                char encryptedChar = (char) (encryptedIndex + 97); 
                if (isUpperCase) {
                    encryptedChar = Character.toUpperCase(encryptedChar); 
                }
                cipherText += encryptedChar; 
            } else {
                cipherText += character; 
            }
        }
        return cipherText; 
    }

    public static String decrypt(String cipherText, int key) {
        String plainText = ""; 

        for (char character : cipherText.toCharArray()) { 
            if (Character.isLetter(character)) { 
                boolean isUpperCase = Character.isUpperCase(character); 
                character = Character.toLowerCase(character); 
                int charIndex = character - 97; 
                int decryptedIndex = (charIndex - key + 26) % 26; 
                char decryptedChar = (char) (decryptedIndex + 97); 
                if (isUpperCase) {
                    decryptedChar = Character.toUpperCase(decryptedChar); 
                }
                plainText += decryptedChar; 
            } else {
                plainText += character; 
            }
        }
        return plainText; 
    }
}
