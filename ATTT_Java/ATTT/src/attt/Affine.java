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
public class Affine {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Nhập văn bản cần mã hóa: ");
        String plainText = scanner.nextLine();

        System.out.print("Nhập khóa a: ");
        int a = scanner.nextInt();

        System.out.print("Nhập khóa b: ");
        int b = scanner.nextInt();
        
        // Xử lý trường hợp khóa âm hoặc quá lớn
        if (a < 0) {
            a = a % 26 + 26; // Chuyển về khóa dương tương đương
        } else if (a > 26) {
            a = a % 26; // Chuyển về khóa trong khoảng 0-25
        }
        
        // Xử lý trường hợp khóa âm hoặc quá lớn
        if (b < 0) {
            b = b % 26 + 26; // Chuyển về khóa dương tương đương
        } else if (b > 26) {
            b = b % 26; // Chuyển về khóa trong khoảng 0-25
        }
        
        int n = 26;
        if (UCLN(a, n) != 1) {
            System.out.println("a và n(26) phải có ước số chung là 1.");
        } else {
            System.out.println("Văn bản đã mã hóa: " + encode(plainText, a, b));

            System.out.print("Nhập văn bản cần giải mã: ");
            scanner.nextLine(); // Đọc bỏ dòng trống
            String cipherText = scanner.nextLine();

            System.out.println("Văn bản đã giải mã: " + decode(cipherText, a, b));
            
            // In bảng tính a^-1
            System.out.println("\nBảng tính a^-1:");
            printExtendedEuclideanTable(a, 26);

//            // In bảng tính mã hóa
//            System.out.println("\nBảng tính mã hóa:");
//            printEncodeTable(a, b);
//
//            // In bảng tính giải mã
//            System.out.println("\nBảng tính giải mã:");
//            printDecodeTable(a, b);
        }
    }

    // Hàm mã hóa Affine
    public static String encode(String plainText, int a, int b) {
        String cipherText = "";
        for (int i = 0; i < plainText.length(); i++) {
            char ch = plainText.charAt(i);
            if (Character.isLetter(ch)) {
                // Chuyển chữ cái sang số theo bảng chữ cái (A=0, B=1, ..., Z=25)
                int charCode = Character.toLowerCase(ch) - 'a';
                // Áp dụng công thức mã hóa Affine
                int encodedCharCode = ((a%26) * charCode + (b%26)) % 26;
                // Chuyển số về chữ cái
                char encodedChar = (char) (encodedCharCode + 'a');
                cipherText += encodedChar;
            } else {
                // Giữ nguyên các kí tự không phải chữ cái
                cipherText += ch;
            }
        }
        return cipherText;
    }

    // Hàm giải mã Affine
    public static String decode(String cipherText, int a, int b) {
        // Tìm a^-1 bằng thuật toán Euclid mở rộng
        int aInverse = extendedEuclidean(a, 26);
        String plainText = "";
        for (int i = 0; i < cipherText.length(); i++) {
            char ch = cipherText.charAt(i);
            if (Character.isLetter(ch)) {
                // Chuyển chữ cái sang số theo bảng chữ cái (A=0, B=1, ..., Z=25)
                int charCode = Character.toLowerCase(ch) - 'a';
                // Áp dụng công thức giải mã Affine
                int decodedCharCode = (aInverse * (charCode - b)) % 26;
                // Chuyển số về chữ cái
                char decodedChar = (char) (decodedCharCode + 'a');
                plainText += decodedChar;
            } else {
                // Giữ nguyên các kí tự không phải chữ cái
                plainText += ch;
            }
        }
        return plainText;
    }
    
    // Hàm tìm ước số chung
    public static int UCLN(int a, int b) {
        if (b == 0) return a;
        return UCLN(b, a % b);
    }

    // Thuật toán Euclid mở rộng để tìm a^-1
    public static int extendedEuclidean(int a, int n) {
        int r1 = n, r2 = a, t1 = 0, t2 = 1;
        int q, r, t;
        while (r2 > 0) {
            q = r1 / r2;
            r = r1 - q * r2;
            t = t1 - q * t2;
            r1 = r2;
            r2 = r;
            t1 = t2;
            t2 = t;
        }
        // Khi r2 = 0, t1 chính là a^-1
        return (t1 % n + n) % n;
    }
    
    // In bảng tính thuật toán Euclid mở rộng
    public static void printExtendedEuclideanTable(int a, int n) {
        int r1 = n, r2 = a, t1 = 0, t2 = 1;
        int q, r, t;
        System.out.println("q\tr1\tr2\tr\tt1\tt2\tt");
        System.out.println("-------------------------------------------------------");
        while (r2 > 0) {
            q = r1 / r2;
            r = r1 - q * r2;
            t = t1 - q * t2;
            System.out.println(q + "\t" + r1 + "\t" + r2 + "\t" + r + "\t" + t1 + "\t" + t2 + "\t" + t);
            r1 = r2;
            r2 = r;
            t1 = t2;
            t2 = t;
        }
        System.out.println("a^-1 = " + (t1 % n + n) % n);
    }

//    // In bảng tính mã hóa
//    public static void printEncodeTable(int a, int b) {
//        System.out.println("P\ta\tb\tc\td\te\tf\tg\th\ti\tj\tk\tl\tm\tn\to\tp\tq\tr\ts\tu\tv\tw\tx\ty\tz");
//        System.out.println("--------------------------------------------------------------------------------------------------");
//        for (int i = 0; i < 26; i++) {
//            int encodedCharCode = (a * i + b) % 26;
//            System.out.print((char) (i + 'a') + "\t");
//            System.out.print((char) (encodedCharCode + 'a') + "\t");
//        }
//        System.out.println();
//    }
//
//    // In bảng tính giải mã
//    public static void printDecodeTable(int a, int b) {
//        int aInverse = extendedEuclidean(a, 26);
//        System.out.println("C\ta\tb\tc\td\te\tf\tg\th\ti\tj\tk\tl\tm\tn\to\tp\tq\tr\ts\tu\tv\tw\tx\ty\tz");
//        System.out.println("--------------------------------------------------------------------------------------------------");
//        for (int i = 0; i < 26; i++) {
//            int decodedCharCode = (aInverse * (i - b)) % 26;
//            System.out.print((char) (i + 'a') + "\t");
//            System.out.print((char) (decodedCharCode + 'a') + "\t");
//        }
//        System.out.println();
//    }
    
//    private int a;
//    private int b;
//    private int m;
//
//    public Affine(int a, int b) {
//        this.a = a;
//        this.b = b;
//        this.m = 26; // Kích thước bảng chữ cái tiếng Anh
//        if (gcd(a, m) != 1) {
//            System.out.println("a và m phải có ước số chung là 1.");
//        }
//        System.exit(1);
//    }
//
//    // Phương thức mã hóa
//    public String encrypt(String plaintext) {
//        StringBuilder ciphertext = new StringBuilder();
//        for (char c : plaintext.toCharArray()) {
//            if (Character.isLetter(c)) {
//                int x = Character.toLowerCase(c) - 'a';
//                int encryptedChar = (a * x + b) % m;
//                ciphertext.append((char) (encryptedChar + 'a'));
//            } else {
//                ciphertext.append(c); // Giữ nguyên ký tự không phải chữ cái
//            }
//        }
//        return ciphertext.toString();
//    }
//
//    // Phương thức giải mã
//    public String decrypt(String ciphertext) {
//        StringBuilder plaintext = new StringBuilder();
//        int aInverse = modInverse(a, m);
//        for (char c : ciphertext.toCharArray()) {
//            if (Character.isLetter(c)) {
//                int y = Character.toLowerCase(c) - 'a';
//                int decryptedChar = (aInverse * (y - b + m)) % m;
//                plaintext.append((char) (decryptedChar + 'a'));
//            } else {
//                plaintext.append(c); // Giữ nguyên ký tự không phải chữ cái
//            }
//        }
//        return plaintext.toString();
//    }
//
//    // Hàm tìm ước số chung
//    private int gcd(int a, int b) {
//        if (b == 0) return a;
//        return gcd(b, a % b);
//    }
//
//    // Hàm tìm số nghịch đảo modulo
//    private int modInverse(int a, int m) {
//        a = a % m;
//        for (int x = 1; x < m; x++) {
//            if ((a * x) % m == 1) {
//                return x;
//            }
//        }
//        return 1; // Nếu không tìm được, trả về 1
//    }        
//    public static void main(String[] args) {
//            Scanner scanner = new Scanner(System.in);
//            System.out.print("Nhập giá trị a: ");
//            int a = scanner.nextInt();
//            
//            System.out.print("Nhập giá trị b: ");
//            int b = scanner.nextInt();
//            
//            Affine cipher = new Affine(a, b);
//            
//            while(true){
//                System.out.print("Nhập văn bản cần mã hóa: ");
//                String plaintext = scanner.nextLine();
//
//                String ciphertext = cipher.encrypt(plaintext);
//                System.out.println("Mã hóa: " + ciphertext);
//                System.out.println("Giải mã: " + cipher.decrypt(ciphertext));
//
//                scanner.close();
//            }
//    }
}
