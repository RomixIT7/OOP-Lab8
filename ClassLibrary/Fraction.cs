// Клас Fraction у бібліотеці ClassLibrary

using System;

namespace ClassLibrary
{
    public class Fraction
    {
        // Поля класу Fraction
        private int numerator;
        private int denominator;

        // Конструктори класу Fraction
        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator != 0 ? denominator : 1;
        }

        // Конструктор копіювання
        public Fraction(Fraction other)
        {
            this.numerator = other.numerator;
            this.denominator = other.denominator;
        }

        // Метод для скорочення дробу
        private void Reduce()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        // Метод для знаходження найменшого спільного знаменника
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Перевантаження операцій

        // Унарний плюс
        public static Fraction operator +(Fraction fraction)
        {
            return new Fraction(fraction);
        }

        // Унарний мінус
        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.numerator, fraction.denominator);
        }

        // Бінарні операції

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            int commonDenominator = fraction1.denominator * fraction2.denominator;
            int newNumerator = fraction1.numerator * fraction2.denominator + fraction2.numerator * fraction1.denominator;

            return new Fraction(newNumerator, commonDenominator);
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            int commonDenominator = fraction1.denominator * fraction2.denominator;
            int newNumerator = fraction1.numerator * fraction2.denominator - fraction2.numerator * fraction1.denominator;

            return new Fraction(newNumerator, commonDenominator);
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.numerator * fraction2.numerator, fraction1.denominator * fraction2.denominator);
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            if (fraction2.numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return new Fraction(fraction1.numerator * fraction2.denominator, fraction1.denominator * fraction2.numerator);
        }

        // Порівняння

        public static bool operator >(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.numerator * fraction2.denominator > fraction2.numerator * fraction1.denominator;
        }

        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.numerator * fraction2.denominator < fraction2.numerator * fraction1.denominator;
        }

        public static bool operator >=(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.numerator * fraction2.denominator >= fraction2.numerator * fraction1.denominator;
        }

        public static bool operator <=(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.numerator * fraction2.denominator <= fraction2.numerator * fraction1.denominator;
        }

        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.numerator * fraction2.denominator == fraction2.numerator * fraction1.denominator;
        }

        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.numerator * fraction2.denominator != fraction2.numerator * fraction1.denominator;
        }

        // Операція приведення типу до double
        public static explicit operator double(Fraction fraction)
        {
            return (double)fraction.numerator / fraction.denominator;
        }

        // Перевизначений метод ToString()
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        // Метод ShowInfo()
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Sum: {this}");
        }
    }
}
