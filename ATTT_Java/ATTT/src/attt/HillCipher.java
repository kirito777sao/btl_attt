/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package attt;

import java.util.Arrays;
import java.util.Scanner;

/**
 *
 * @author Admin
 */
public class HillCipher {
    private static final int MOD = 26;

    // Hàm mã hóa Hill (Không dùng StringBuilder)
    public static String encrypt(String plaintext, int[][] key) {
        int m = key.length;
        plaintext = plaintext.toUpperCase(); // Chuyển về chữ hoa

        // Xử lý ký tự đặc biệt và số
        char[] specialChars = new char[plaintext.length()];
        int[] specialCharPositions = new int[plaintext.length()];
        int specialCharCount = 0;

        String plain = ""; // Chuỗi chứa chỉ ký tự chữ cái

        for (int i = 0; i < plaintext.length(); i++) {
            char c = plaintext.charAt(i);
            if (Character.isLetter(c)) {
                plain += c;
            } else {
                specialChars[specialCharCount] = c;
                specialCharPositions[specialCharCount++] = i;
            }
        }

        // Padding
        int padding = m - (plain.length() % m);
        if (padding < m) {
            for (int i = 0; i < padding; i++) {
                plain += 'X';
            }
        }

        int[] digitizedPlaintext = new int[plain.length()];
        for (int i = 0; i < plain.length(); i++) {
            digitizedPlaintext[i] = plain.charAt(i) - 'A';
        }

        int[] ciphertext = new int[plain.length()];
        for (int i = 0; i < plain.length(); i += m) {
            int[][] vector = new int[1][m];
            for (int j = 0; j < m; j++) {
                vector[0][j] = digitizedPlaintext[i + j];
            }

            int[][] result = multiplyMatrix(vector, key);
            for (int j = 0; j < m; j++) {
                ciphertext[i + j] = result[0][j];
            }
        }

        char[] cipherChar = new char[plain.length()];
        for (int i = 0; i < plain.length(); i++) {
            cipherChar[i] = Character.toUpperCase((char) (ciphertext[i] + 'A'));
        }

        // Gộp lại chuỗi kết quả
        char[] resultCipher = new char[plaintext.length()];
        int cipherIndex = 0;
        int specialIndex = 0;

        for (int i = 0; i < plaintext.length(); i++) {
            if (specialIndex < specialCharCount && specialCharPositions[specialIndex] == i) {
                resultCipher[i] = specialChars[specialIndex++];
            } else {
                resultCipher[i] = cipherChar[cipherIndex++];
            }
        }

        return new String(resultCipher);
    }

    // Hàm giải mã Hill (Không dùng StringBuilder)
    public static String decrypt(String ciphertext, int[][] key) {
        int m = key.length;
        ciphertext = ciphertext.toUpperCase();

        // Xử lý ký tự đặc biệt và số
        char[] specialChars = new char[ciphertext.length()];
        int[] specialCharPositions = new int[ciphertext.length()];
        int specialCharCount = 0;

        String cipher = ""; // Chuỗi chứa chỉ ký tự chữ cái

        for (int i = 0; i < ciphertext.length(); i++) {
            char c = ciphertext.charAt(i);
            if (Character.isLetter(c)) {
                cipher += c;
            } else {
                specialChars[specialCharCount] = c;
                specialCharPositions[specialCharCount++] = i;
            }
        }

        int det = determinant(key);
        int detInv = modInverse(det, MOD);
        int[][] keyInverse = inverseMatrix(key, detInv);

        int[] digitizedCiphertext = new int[cipher.length()];
        for (int i = 0; i < cipher.length(); i++) {
            digitizedCiphertext[i] = cipher.charAt(i) - 'A';
        }

        int[] plaintext = new int[cipher.length()];
        for (int i = 0; i < cipher.length(); i += m) {
            int[][] vector = new int[1][m];
            for (int j = 0; j < m; j++) {
                vector[0][j] = digitizedCiphertext[i + j];
            }

            int[][] result = multiplyMatrix(vector, keyInverse);
            for (int j = 0; j < m; j++) {
                plaintext[i + j] = result[0][j];
            }
        }

        char[] plainChar = new char[cipher.length()];
        for (int i = 0; i < cipher.length(); i++) {
            plainChar[i] = (char) (plaintext[i] + 'A');
        }

        // Gộp lại chuỗi kết quả
        char[] resultPlain = new char[ciphertext.length()];
        int plainIndex = 0;
        int specialIndex = 0;

        for (int i = 0; i < ciphertext.length(); i++) {
            if (specialIndex < specialCharCount && specialCharPositions[specialIndex] == i) {
                resultPlain[i] = specialChars[specialIndex++];
            } else {

                resultPlain[i] = plainChar[plainIndex++];
            }
        }

        return new String(resultPlain);
    }

    // Hàm nhân 2 ma trận (đã sửa)
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

    private static int[] multiplyMatrixVector(int[][] matrix, int[] vector) {
        int m = matrix.length;
        int[] result = new int[m];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < m; j++) {
                result[i] = (result[i] + matrix[i][j] * vector[j]) % MOD; // Tính modulo ở đây
                if (result[i] < 0) {
                    result[i] += MOD; // Đảm bảo giá trị dương
                }
            }
        }
        return result;
    }

    private static int determinant(int[][] matrix) {
        int n = matrix.length;
        if (n == 1) {
            return matrix[0][0];
        }
        if (n == 2) {
            return (matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0]) % MOD;
        }

        int det = 0;
        for (int j = 0; j < n; j++) {
            int[][] submatrix = createSubMatrix(matrix, 0, j);
            det = (det + (int) (Math.pow(-1, j) * matrix[0][j] * determinant(submatrix))) % MOD;
        }
        return (det + MOD) % MOD; // Đảm bảo giá trị dương
    }

    private static int[][] createSubMatrix(int[][] matrix, int excludingRow, int excludingCol) {
        int n = matrix.length;
        int[][] submatrix = new int[n - 1][n - 1];
        int row = 0;
        for (int i = 0; i < n; i++) {
            if (i == excludingRow) {
                continue;
            }
            int col = 0;
            for (int j = 0; j < n; j++) {
                if (j == excludingCol) {
                    continue;
                }
                submatrix[row][col] = matrix[i][j];
                col++;
            }
            row++;
        }
        return submatrix;
    }

    private static int modInverse(int a, int m) {
        a = (a % m + m) % m; // Đảm bảo a nằm trong khoảng 0 đến m-1
        for (int x = 1; x < m; x++) {
            if ((a * x) % m == 1) {
                return x; // Trả về nghịch đảo
            }
        }
        return 0; // Không có nghịch đảo
    }

    private static int[][] inverseMatrix(int[][] matrix, int detInv) {
        int m = matrix.length;
        int[][] cofactorMatrix = cofactor(matrix);
        int[][] transposedMatrix = transpose(cofactorMatrix);
        int[][] inverse = new int[m][m];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < m; j++) {
                inverse[i][j] = (transposedMatrix[i][j] * detInv) % MOD; // Nhân với detInv trước khi modulo
                if (inverse[i][j] < 0) {
                    inverse[i][j] += MOD; // Đảm bảo giá trị dương
                }
            }
        }
        return inverse;
    }

    private static int[][] transpose(int[][] matrix) {
        int m = matrix.length;
        int[][] transposedMatrix = new int[m][m];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < m; j++) {
                transposedMatrix[i][j] = matrix[j][i];
            }
        }
        return transposedMatrix;
    }

    private static int[][] cofactor(int[][] matrix) {
        int n = matrix.length;
        int[][] cofactorMatrix = new int[n][n];

        for (int r = 0; r < n; r++) {
            for (int c = 0; c < n; c++) {
                int[][] submatrix = createSubMatrix(matrix, r, c);
                cofactorMatrix[r][c] = (int) (Math.pow(-1, r + c) * determinant(submatrix));
                cofactorMatrix[r][c] = (cofactorMatrix[r][c] % MOD + MOD) % MOD; // Đảm bảo giá trị dương
            }
        }
        return cofactorMatrix;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Nhập bản rõ: ");
        String plaintext = scanner.nextLine();

        System.out.print("Nhập cấp của ma trận khóa (m): ");
        int m = scanner.nextInt();
        scanner.nextLine(); // Consume newline

        int[][] key = new int[m][m];
        System.out.println("Nhập ma trận khóa (" + m + "x" + m + "):");
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < m; j++) {
                key[i][j] = scanner.nextInt();
            }
            scanner.nextLine(); // Consume newline after reading each row
        }

        if (determinant(key) == 0 || modInverse(determinant(key), MOD) == 0) {
            System.out.println("Ma trận khóa không hợp lệ (định thức bằng 0 hoặc không khả nghịch theo modulo 26).");
            return;
        }

        String ciphertext = encrypt(plaintext, key);
        System.out.println("Bản mã: " + ciphertext);

        System.out.print("Nhập bản mã để giải mã: ");
        String ciphertextToDecrypt = scanner.nextLine();

        String decryptedText = decrypt(ciphertextToDecrypt, key);
        System.out.println("Bản rõ sau giải mã: " + decryptedText);

        // In ma trận khóa
        System.out.println("Ma trận khóa:");
        for (int i = 0; i < m; i++) {
            System.out.println(Arrays.toString(key[i]));
        }

        scanner.close();
    }
}
