package com.mycompany.app;

/**
 * https://projecteuler.net/problem=8
 *
 * Largest product in a series
 * Problem 8
 *
    The four adjacent digits in the 1000-digit number that
 have the greatest product are 9 × 9 × 8 × 9 = 5832.

 73167176531330624919225119674426574742355349194934
 96983520312774506326239578318016984801869478851843
 85861560789112949495459501737958331952853208805511
 12540698747158523863050715693290963295227443043557
 66896648950445244523161731856403098711121722383113
 62229893423380308135336276614282806444486645238749
 30358907296290491560440772390713810515859307960866
 70172427121883998797908792274921901699720888093776
 65727333001053367881220235421809751254540594752243
 52584907711670556013604839586446706324415722155397
 53697817977846174064955149290862569321978468622482
 83972241375657056057490261407972968652414535100474
 82166370484403199890008895243450658541227588666881
 16427171479924442928230863465674813919123162824586
 17866458359124566529476545682848912883142607690042
 24219022671055626321111109370544217506941658960408
 07198403850962455444362981230987879927244284909188
 84580156166097919133875499200524063689912560717606
 05886116467109405077541002256983155200055935729725
 71636269561882670428252483600823257530420752963450

 Find the thirteen adjacent digits in the 1000-digit number that have the greatest product.
 What is the value of this product?
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        System.out.println("Problem #8" );

        SoveProblemCase1();
        SoveProblemCase2();
        SoveProblemCase3();
    }
    public static void SoveProblemCase1(){
        int numberOfDigits = 2;
        String input = "01234567899";
        SolveProblem(numberOfDigits, input);
    }
    public static void SoveProblemCase2(){
        int numberOfDigits = 4;
        StringBuffer buffer= new StringBuffer();
        buffer.append("73167176531330624919225119674426574742355349194934");
        buffer.append("96983520312774506326239578318016984801869478851843");
        buffer.append("85861560789112949495459501737958331952853208805511");
        buffer.append("12540698747158523863050715693290963295227443043557");
        buffer.append("66896648950445244523161731856403098711121722383113");
        buffer.append("62229893423380308135336276614282806444486645238749");
        buffer.append("30358907296290491560440772390713810515859307960866");
        buffer.append("70172427121883998797908792274921901699720888093776");
        buffer.append("65727333001053367881220235421809751254540594752243");
        buffer.append("52584907711670556013604839586446706324415722155397");
        buffer.append("53697817977846174064955149290862569321978468622482");
        buffer.append("83972241375657056057490261407972968652414535100474");
        buffer.append("82166370484403199890008895243450658541227588666881");
        buffer.append("16427171479924442928230863465674813919123162824586");
        buffer.append("17866458359124566529476545682848912883142607690042");
        buffer.append("24219022671055626321111109370544217506941658960408");
        buffer.append("07198403850962455444362981230987879927244284909188");
        buffer.append("84580156166097919133875499200524063689912560717606");
        buffer.append("05886116467109405077541002256983155200055935729725");
        buffer.append("71636269561882670428252483600823257530420752963450");
        SolveProblem(numberOfDigits, buffer.toString());
    }
    public static void SoveProblemCase3(){
        int numberOfDigits = 13;
        StringBuffer buffer= new StringBuffer();
        buffer.append("73167176531330624919225119674426574742355349194934");
        buffer.append("96983520312774506326239578318016984801869478851843");
        buffer.append("85861560789112949495459501737958331952853208805511");
        buffer.append("12540698747158523863050715693290963295227443043557");
        buffer.append("66896648950445244523161731856403098711121722383113");
        buffer.append("62229893423380308135336276614282806444486645238749");
        buffer.append("30358907296290491560440772390713810515859307960866");
        buffer.append("70172427121883998797908792274921901699720888093776");
        buffer.append("65727333001053367881220235421809751254540594752243");
        buffer.append("52584907711670556013604839586446706324415722155397");
        buffer.append("53697817977846174064955149290862569321978468622482");
        buffer.append("83972241375657056057490261407972968652414535100474");
        buffer.append("82166370484403199890008895243450658541227588666881");
        buffer.append("16427171479924442928230863465674813919123162824586");
        buffer.append("17866458359124566529476545682848912883142607690042");
        buffer.append("24219022671055626321111109370544217506941658960408");
        buffer.append("07198403850962455444362981230987879927244284909188");
        buffer.append("84580156166097919133875499200524063689912560717606");
        buffer.append("05886116467109405077541002256983155200055935729725");
        buffer.append("71636269561882670428252483600823257530420752963450");
        SolveProblem(numberOfDigits, buffer.toString());
    }

    public static long SolveProblem(int numberOfDigits, String input){
        long maxProduct = Integer.MIN_VALUE;

        byte[] allDigits = input.replace("\n", "").getBytes();
        int codeZero = '0' & 0x00FF;
        byte codeByteZero = (byte) codeZero;
        for (int i = 0; i < allDigits.length; i++) {
            allDigits[i] = (byte)(allDigits[i] - codeByteZero);
        }
        System.out.println("Size of allDigits: " + allDigits.length);

        for (int i = 0; i < allDigits.length - numberOfDigits + 1; i++){
            long currentProduct = 1;
            for (int j = 0; j < numberOfDigits; j++){
                currentProduct *= allDigits[i+j];
            }
            if (currentProduct > maxProduct){
                maxProduct = currentProduct;
            }
        }
        System.out.println("Max product: " + maxProduct);
        return maxProduct;
    }
}
