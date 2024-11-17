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
public class Hill2x2 {
    private static final int MOD = 26;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Nhập cấp của ma trận khóa
        System.out.print("Nhập m: ");
        int m = scanner.nextInt();
        scanner.nextLine(); // Consume newline

        // Nhập ma trận khóa
        int[][] keyMatrix = new int[m][m];
        System.out.println("Nhập ma trận khóa K:");
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < m; j++) {
                System.out.print("Phần tử (" + i + ", " + j + "): ");
                keyMatrix[i][j] = scanner.nextInt();
            }
            scanner.nextLine(); // Consume newline
        }


        // Nhập bản rõ
        System.out.print("Nhập văn bản: ");
        String plaintext = scanner.nextLine().toLowerCase();

        // Số hóa bản rõ
        int[] digitizedPlaintext = new int[plaintext.length()];
        for (int i = 0; i < plaintext.length(); i++) {
            digitizedPlaintext[i] = plaintext.charAt(i) - 'a';
        }


        // Mã hóa
        int[] ciphertext = new int[plaintext.length()];
        for (int i = 0; i < plaintext.length(); i += m) {
            int[][] vector = new int[1][m];
            for (int j = i; j < i + m && j < plaintext.length(); j++) {
                vector[0][j % m] = digitizedPlaintext[j];
            }


            int[][] result = multiplyMatrix(vector, keyMatrix);

            for (int k = i; k < i + m && k < plaintext.length(); k++) {
                ciphertext[k] = result[0][k % m];

            }
        }


        // In bản mã (số)
        System.out.print("Bản mã (số hóa): ");
        for (int i = 0; i < ciphertext.length; i++) {
            System.out.print(ciphertext[i] + " ");
        }
        System.out.println();

        // In bản mã (ký tự)
        System.out.print("Bản mã (ký tự): ");
        for (int i = 0; i < ciphertext.length; i++) {
            System.out.print(Character.toUpperCase((char) (ciphertext[i] + 'a')) + " ");
        }
        System.out.println();

        scanner.close();
    }




    // Hàm nhân 2 ma trận
    private static int[][] multiplyMatrix(int[][] a, int[][] b) {

        int rowsA = a.length;
        int colsA = a[0].length;
        int colsB = b[0].length;

        int[][] result = new int[rowsA][colsB];

        for (int i = 0; i < rowsA; i++) {
            for (int j = 0; j < colsB; j++) {
                for (int k = 0; k < colsA; k++) {

                    result[i][j] = (result[i][j] + a[i][k] * b[k][j]) % MOD;
                }


            }
        }
        return result;
    }
}
