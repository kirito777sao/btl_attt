/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package attt;

import java.math.BigInteger;
import java.util.Scanner;
/**
 *
 * @author Admin
 */
public class RSA {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Nhập vào p, q, e
        System.out.print("Nhập p: ");
        BigInteger p = scanner.nextBigInteger();
        System.out.print("Nhập q: ");
        BigInteger q = scanner.nextBigInteger();
        System.out.print("Nhập e: ");
        BigInteger e = scanner.nextBigInteger();

        // 1. Tạo khóa
        BigInteger n = p.multiply(q); // n = p * q
        BigInteger phiN = p.subtract(BigInteger.ONE).multiply(q.subtract(BigInteger.ONE)); // phi(n) = (p-1)(q-1)
        BigInteger d = e.modInverse(phiN); // d là nghịch đảo của e theo modulo phi(n)

        System.out.println("Khóa công khai (e, n): (" + e + ", " + n + ")");
        System.out.println("Khóa bí mật (d, n): (" + d + ", " + n + ")");

        // Nhập vào bản rõ P
        System.out.print("Nhập bản rõ P: ");
        BigInteger plaintext = scanner.nextBigInteger();

        // 2. Mã hóa
        BigInteger ciphertext = encrypt(plaintext, e, n);
        System.out.println("Bản rõ: " + plaintext);
        System.out.println("Bản mã: " + ciphertext);

        // 3. Giải mã
        BigInteger decryptedText = decrypt(ciphertext, d, n);
        System.out.println("Bản giải mã: " + decryptedText);
        
        // Giải mã với bản mã nhập từ người dùng
        System.out.print("Nhập bản mã để giải mã: ");
        BigInteger inputCiphertext = scanner.nextBigInteger();
        BigInteger decryptedInputText = decrypt(inputCiphertext, d, n);
        System.out.println("Bản giải mã từ bản mã nhập: " + decryptedInputText);
        
        scanner.close();
    }

    // Hàm mã hóa
    public static BigInteger encrypt(BigInteger message, BigInteger e, BigInteger n) {
        return message.modPow(e, n); // message^e mod n
    }

    // Hàm giải mã
    public static BigInteger decrypt(BigInteger encryptedMessage, BigInteger d, BigInteger n) {
        return encryptedMessage.modPow(d, n); // encryptedMessage^d mod n
    }

    // Thuật toán Euclid mở rộng để tính nghịch đảo modulo
    public static BigInteger[] extendedEuclidean(BigInteger a, BigInteger b) {
        if (b.equals(BigInteger.ZERO)) {
            return new BigInteger[]{a, BigInteger.ONE, BigInteger.ZERO};
        }

        BigInteger[] result = extendedEuclidean(b, a.mod(b));
        BigInteger gcd = result[0];
        BigInteger x = result[2];
        BigInteger y = result[1].subtract(a.divide(b).multiply(result[2]));

        return new BigInteger[]{gcd, x, y};
    }
}
