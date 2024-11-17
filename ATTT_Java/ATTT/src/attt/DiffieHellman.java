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
public class DiffieHellman {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Nhập vào q và alpha
        System.out.print("Nhập q (số nguyên tố): ");
        BigInteger q = scanner.nextBigInteger();
        System.out.print("Nhập alpha (cơ sở): ");
        BigInteger alpha = scanner.nextBigInteger();

        // Nhập khóa riêng của Alice
        System.out.print("Nhập khóa riêng của Alice: ");
        BigInteger alicePrivateKey = scanner.nextBigInteger();
        // Tính toán khóa công khai của Alice
        BigInteger alicePublicKey = alpha.modPow(alicePrivateKey, q);

        // Nhập khóa riêng của Bob
        System.out.print("Nhập khóa riêng của Bob: ");
        BigInteger bobPrivateKey = scanner.nextBigInteger();
        // Tính toán khóa công khai của Bob
        BigInteger bobPublicKey = alpha.modPow(bobPrivateKey, q);

        // Tính toán khóa bí mật chung
        BigInteger aliceSharedSecret = bobPublicKey.modPow(alicePrivateKey, q);
        BigInteger bobSharedSecret = alicePublicKey.modPow(bobPrivateKey, q);

        // In ra khóa công khai và khóa bí mật chung
        System.out.println("Khóa công khai của Alice: " + alicePublicKey);
        System.out.println("Khóa công khai của Bob: " + bobPublicKey);
        System.out.println("Khóa bí mật chung (Alice): " + aliceSharedSecret);
        System.out.println("Khóa bí mật chung (Bob): " + bobSharedSecret);

        scanner.close();
    }

    // Thuật toán Euclid mở rộng để tính nghịch đảo modular
    public static BigInteger[] extendedEuclidean(BigInteger a, BigInteger b) {
        if (b.equals(BigInteger.ZERO)) {
            return new BigInteger[]{a, BigInteger.ONE, BigInteger.ZERO};
        }

        BigInteger[] result = extendedEuclidean(b, a.mod(b));
        BigInteger x = result[2];
        BigInteger y = result[1].subtract(a.divide(b).multiply(result[2]));

        return new BigInteger[]{result[0], x, y};
    }
}
