namespace Roblox;

public static class math
{
    /// <summary>The value of pi.</summary>
    public static extern float pi { get; }
    /// <summary>Returns a value larger than or equal to any other numerical value (about 2¹⁰²⁴).</summary>
    public static extern int huge { get; }

    /// <summary>Returns the absolute value of x.</summary>
    public static extern float abs(float x);

    /// <summary>Returns the arc cosine of x.</summary>
    public static extern float acos(float x);

    /// <summary>Returns the arc sine of x.</summary>
    public static extern float asin(float x);

    /// <summary>Returns the arc tangent of x in radians.</summary>
    public static extern float atan(float x);

    /// <summary>Returns the arc tangent of y/x (in radians) while using the signs of both parameters to find the quadrant of the result.</summary>
    public static extern float atan2(float y, float x);

    /// <summary>Returns the smallest integer larger than or equal to x.</summary>
    public static extern float ceil(float x);

    /// <summary>Returns a number between min and max, inclusive.</summary>
    public static extern float clamp(float x, float min, float max);

    /// <summary>Returns the cosine of x, assumed to be in radians.</summary>
    public static extern float cos(float x);

    /// <summary>Returns the hyperbolic cosine of x.</summary>
    public static extern float cosh(float x);

    /// <summary>Returns the angle x (given in radians) in degrees.</summary>
    public static extern float deg(float x);

    /// <summary>Returns the value e^x.</summary>
    public static extern float exp(float x);

    /// <summary>Returns the largest integer smaller than or equal to x.</summary>
    public static extern float floor(float x);

    /// <summary>Returns the remainder of the division of x by y that rounds the quotient towards zero.</summary>
    public static extern float fmod(float x, float y);

    /// <summary>Returns m and e such that x = m*2^e.</summary>
    public static extern (float, float) frexp(float x);

    /// <summary>Returns x*2^e (e should be an integer).</summary>
    public static extern float ldexp(float x, float e);

    /// <summary>Returns the logarithm of x using the given base.</summary>
    public static extern float log(float x, float @base);

    /// <summary>Returns the base-10 logarithm of x.</summary>
    public static extern float log10(float x);

    /// <summary>Returns the maximum value among the numbers passed to the function.</summary>
    public static extern float max(float x, params float[] numbers);

    /// <summary>Returns the minimum value among the numbers passed to the function.</summary>
    public static extern float min(float x, params float[] numbers);

    /// <summary>Returns two numbers: the integral part of x and the fractional part of x.</summary>
    public static extern (float, float) modf(float x);

    /// <summary>Returns a Perlin noise value.</summary>
    public static extern float noise(float x, float y, float z);

    /// <summary>Returns x^y.</summary>
    public static extern float pow(float x, float exp);

    /// <summary>Returns the angle x (given in degrees) in radians.</summary>
    public static extern float rad(float x);

    /// <summary>Returns a random number within the range provided.</summary>
    public static extern float random(float m, float n);

    /// <summary>Sets x as the seed for the pseudo-random generator.</summary>
    public static extern void randomseed(float x);

    /// <summary>Returns the integer with the smallest difference between it and the given number.></summary>
    public static extern float round(float x);

    /// <summary>Returns -1 if x is less than 0, 0 if x equals 0, or 1 if x is greater than 0.</summary>
    public static extern float sign(float x);

    /// <summary>Returns the sine of x, assumed to be in radians.</summary>
    public static extern float sin(float x);

    /// <summary>Returns the hyperbolic sine of x.</summary>
    public static extern float sinh(float x);

    /// <summary>Returns the square root of x.</summary>
    public static extern float sqrt(float x);

    /// <summary>Returns the tangent of x, assumed to be in radians.</summary>
    public static extern float tan(float x);

    /// <summary>Returns the hyperbolic tangent of x.</summary>
    public static extern float tanh(float x);
}