namespace cw7.Models;

public class PrimeNumbers {
    
    private static bool isPrime(int number) {
        if (number < 2) {
            return false;
        }
        for (int i = 2; i*i <= number; i++) {
            if (number%i==0) {
                return false;
            }
        }
        return true;
    }
    
    public static List<int> GeneratePrime(int amount) {
        List<int> PrimeNumbers = new List<int>();
        int number = 0;
        
        for (int i = 0; i < amount; i++) {
            while (!isPrime(number)) {
                number++;
            }
            PrimeNumbers.Add(number);
            number++;
        }
        return PrimeNumbers;
    }
}