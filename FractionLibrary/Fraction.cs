// У файлі FractionLibrary\Fraction.cs
using System;

namespace FractionLibrary
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;
        }

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

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            int numerator = fraction1.Numerator * fraction2.Denominator + fraction2.Numerator * fraction1.Denominator;
            int denominator = fraction1.Denominator * fraction2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            int numerator = fraction1.Numerator * fraction2.Denominator - fraction2.Numerator * fraction1.Denominator;
            int denominator = fraction1.Denominator * fraction2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            int numerator = fraction1.Numerator * fraction2.Numerator;
            int denominator = fraction1.Denominator * fraction2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            int numerator = fraction1.Numerator * fraction2.Denominator;
            int denominator = fraction1.Denominator * fraction2.Numerator;

            if (denominator == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return new Fraction(numerator, denominator);
        }

        public static bool operator >(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Numerator * fraction2.Denominator > fraction2.Numerator * fraction1.Denominator;
        }

        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Numerator * fraction2.Denominator < fraction2.Numerator * fraction1.Denominator;
        }

        public static bool operator >=(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Numerator * fraction2.Denominator >= fraction2.Numerator * fraction1.Denominator;
        }

        public static bool operator <=(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Numerator * fraction2.Denominator <= fraction2.Numerator * fraction1.Denominator;
        }

        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Numerator * fraction2.Denominator == fraction2.Numerator * fraction1.Denominator;
        }

        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Numerator * fraction2.Denominator != fraction2.Numerator * fraction1.Denominator;
        }

        public static implicit operator double(Fraction fraction)
        {
            return (double)fraction.Numerator / fraction.Denominator;
        }

        public static implicit operator Fraction(double value)
        {
            int denominator = 1;
            while (Math.Abs(value - Math.Floor(value)) > double.Epsilon)
            {
                value *= 10;
                denominator *= 10;
            }

            int numerator = (int)Math.Floor(value);

            return new Fraction(numerator, denominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
