/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package attt;
import java.util.Scanner;
/**
 * Đa bảng
 * @author Admin
 */
public class Playfair {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Nhập vào văn bản cần mã hóa: ");
        String plainText = scanner.nextLine().toUpperCase().replaceAll("J", "I");

        System.out.print("Nhập vào khóa: ");
        String key = scanner.nextLine().toUpperCase().replaceAll("J", "I");

        // Loại bỏ ký tự trùng lặp trong khóa
        key = removeDuplicateChars(key);

        // Chèn "X" vào giữa các cặp chữ cái lặp lại
        plainText = insertXForDuplicates(plainText);

        char[][] matrix = createMatrix(key);
        
        // In ra ma trận khóa
        System.out.println("Ma trận khóa:");
        printMatrix(matrix);

        String cipherText = encrypt(plainText, key);
        System.out.println("Văn bản đã mã hóa: " + cipherText);

        String decryptedText = decrypt(cipherText, key); // Thêm phần giải mã
        System.out.println("Văn bản đã giải mã: " + decryptedText);

        scanner.close();
    }
    
    // In ma trận khóa
    private static void printMatrix(char[][] matrix) {
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                System.out.print(matrix[i][j] + " ");
            }
            System.out.println();
        }
    }

    // Tìm vị trí của ký tự trong ma trận
    private static int[] findPosition(char[][] matrix, char character) {
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (matrix[i][j] == character) {
                    return new int[] { i, j };
                }
            }
        }
        // Nếu không tìm thấy, in ra thông báo lỗi và thoát chương trình
        System.err.println("Lỗi: Không tìm thấy ký tự '" + character + "' trong ma trận.");
        System.exit(1);
        return null; // Dòng này sẽ không được thực thi
    }

    // Chèn "X" vào giữa các cặp chữ cái lặp lại
    private static String insertXForDuplicates(String plainText) {
        StringBuilder sb = new StringBuilder(plainText);

        // Duyệt từng cặp ký tự trong chuỗi và chèn 'X' khi cần thiết
        for (int i = 0; i < sb.length() - 1; i += 2) {
            char char1 = sb.charAt(i);
            char char2 = sb.charAt(i + 1);
            if (char1 == char2) {
                sb.insert(i + 1, 'X');  // Chèn 'X' vào giữa 2 ký tự trùng
            }
        }

        // Nếu chuỗi có độ dài lẻ, thêm 'X' vào cuối chuỗi
        if (sb.length() % 2 != 0) {
            sb.append('X');
        }
        return sb.toString();
    }

    public static String encrypt(String plainText, String key) {
        // Loại bỏ khoảng trắng, số và ký tự đặc biệt
        String originalPlainText = plainText; // Lưu trữ bản rõ gốc
        plainText = plainText.replaceAll("[^A-Za-z]", "");
        // Lưu trữ vị trí các số và ký tự đặc biệt
        StringBuilder numbersAndSymbols = new StringBuilder();
        for (int i = 0; i < originalPlainText.length(); i++) {
            if (!Character.isLetter(originalPlainText.charAt(i))) {
                numbersAndSymbols.append(originalPlainText.charAt(i));
            }
        }

        char[][] matrix = createMatrix(key);
        String cipherText = "";

        for (int i = 0; i < plainText.length(); i += 2) {
            char char1 = plainText.charAt(i);
            char char2 = (i + 1 < plainText.length()) ? plainText.charAt(i + 1) : 'X';

            int[] pos1 = findPosition(matrix, char1);
            int[] pos2 = findPosition(matrix, char2);

            if (pos1[0] == pos2[0]) { // TH1: Cùng hàng
                cipherText += matrix[pos1[0]][(pos1[1] + 1) % 5];
                cipherText += matrix[pos2[0]][(pos2[1] + 1) % 5];
            } else if (pos1[1] == pos2[1]) { // TH2: Cùng cột
                cipherText += matrix[(pos1[0] + 1) % 5][pos1[1]];
                cipherText += matrix[(pos2[0] + 1) % 5][pos2[1]];
            } else { // TH3: Khác hàng, khác cột
                cipherText += matrix[pos1[0]][pos2[1]];
                cipherText += matrix[pos2[0]][pos1[1]];
            }
        }

        // Thêm lại số và ký tự đặc biệt vào bản mã
        int j = 0; // Chỉ số cho numbersAndSymbols
        int k = 0; // Chỉ số cho cipherText
        while (j < numbersAndSymbols.length()) {
            if (k < cipherText.length() && Character.isLetter(cipherText.charAt(k))) {
                // Nếu ký tự hiện tại trong cipherText là chữ cái
                k++;
            } else {
                // Nếu ký tự hiện tại trong cipherText không phải chữ cái
                // hoặc đã đến cuối cipherText
                cipherText = cipherText.substring(0, k) + numbersAndSymbols.charAt(j) + cipherText.substring(k);
                k++;
                j++;
            }
        }

        return cipherText; // Trả về chuỗi văn bản đã mã hóa
    }

    public static String decrypt(String cipherText, String key) { // Hàm giải mã
        char[][] matrix = createMatrix(key);
        String decryptedText = ""; // Khởi tạo chuỗi rỗng để lưu văn bản đã giải mã

        // Loại bỏ số và ký tự đặc biệt
        StringBuilder numbersAndSymbols = new StringBuilder();
        for (int i = 0; i < cipherText.length(); i++) {
            if (!Character.isLetter(cipherText.charAt(i))) {
                numbersAndSymbols.append(cipherText.charAt(i));
                cipherText = cipherText.substring(0, i) + cipherText.substring(i + 1);
                i--;
            }
        }

        for (int i = 0; i < cipherText.length(); i += 2) {
            char char1 = cipherText.charAt(i);
            char char2 = cipherText.charAt(i + 1);

            int[] pos1 = findPosition(matrix, char1);
            int[] pos2 = findPosition(matrix, char2);

            if (pos1[0] == pos2[0]) { // TH1: Cùng hàng
                decryptedText += matrix[pos1[0]][(pos1[1] - 1 + 5) % 5]; // Chọn ký tự bên trái
                decryptedText += matrix[pos2[0]][(pos2[1] - 1 + 5) % 5];
            } else if (pos1[1] == pos2[1]) { // TH2: Cùng cột
                decryptedText += matrix[(pos1[0] - 1 + 5) % 5][pos1[1]]; // Chọn ký tự bên trên
                decryptedText += matrix[(pos2[0] - 1 + 5) % 5][pos2[1]];
            } else { // TH3: Khác hàng, khác cột
                decryptedText += matrix[pos1[0]][pos2[1]];
                decryptedText += matrix[pos2[0]][pos1[1]];
            }
        }

        // Thêm lại số và ký tự đặc biệt vào bản giải mã
        int j = 0; // Chỉ số cho numbersAndSymbols
        int k = 0; // Chỉ số cho decryptedText
        while (j < numbersAndSymbols.length()) {
            if (k < decryptedText.length() && Character.isLetter(decryptedText.charAt(k))) {
                // Nếu ký tự hiện tại trong decryptedText là chữ cái
                k++;
            } else {
                // Nếu ký tự hiện tại trong decryptedText không phải chữ cái
                // hoặc đã đến cuối decryptedText
                decryptedText = decryptedText.substring(0, k) + numbersAndSymbols.charAt(j) + decryptedText.substring(k);
                k++;
                j++;
            }
        }

        return decryptedText; // Trả về chuỗi văn bản đã giải mã
    }

    // Tạo ma trận Playfair
    private static char[][] createMatrix(String key) {
        char[][] matrix = new char[5][5];
        String alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; // Bảng chữ cái
        int index = 0;

        // Thêm khóa vào ma trận
        for (int i = 0; i < key.length(); i++) {
            if (!Character.isWhitespace(key.charAt(i)) && !contains(matrix, key.charAt(i))) {
                matrix[index / 5][index % 5] = key.charAt(i);
                index++;
            }
        }

        // Thêm các chữ cái còn lại vào ma trận
        for (int i = 0; i < alphabet.length(); i++) {
            if (!Character.isWhitespace(alphabet.charAt(i)) && !contains(matrix, alphabet.charAt(i))) {
                matrix[index / 5][index % 5] = alphabet.charAt(i);
                index++;
            }
        }

        return matrix;
    }

    // Kiểm tra xem một ký tự có tồn tại trong ma trận hay không
    private static boolean contains(char[][] matrix, char character) {
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (matrix[i][j] == character) {
                    return true;
                }
            }
        }
        return false;
    }

    // Loại bỏ ký tự trùng lặp trong khóa
    private static String removeDuplicateChars(String key) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < key.length(); i++) {
            if (!sb.toString().contains(String.valueOf(key.charAt(i)))) {
                sb.append(key.charAt(i));
            }
        }
        return sb.toString();
    }
}