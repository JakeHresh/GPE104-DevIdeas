using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Take a decimal number from the designer and convert the number into hexadecimal, octal, and binary
public class NumberConverter : MonoBehaviour
{
    public int decInput;
    public string hexInput;
    public string octInput;
    public string binInput;

    // Start is called before the first frame update
    void Start()
    {
        // Convert Decimal to Hexadecimal
        Debug.Log(convertDecToHex(decInput));
        // Convert Decimal to Octal
        Debug.Log(convertDecToOct(decInput));
        // Convert Decimal to Binary
        Debug.Log(convertDecToBin(decInput));

        // Convert Hexadecimal to Decimal
        Debug.Log(convertHexToDec(hexInput));
        // Convert Octal to Decimal
        Debug.Log(convertOctToDec(octInput));
        // Convert Binary to Decimal
        Debug.Log(convertBinToDec(binInput));

        // Convert Binary to Hexadecimal
        Debug.Log(convertBinToHex(binInput));
        // Convert Hexadecimal to Binary
        Debug.Log(convertHexToBin(hexInput));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string convertDecToHex(int input)
    {
        // YOUR CODE HERE
        int quot = input;
        int rem = 0;
        string remstr = "";
        string result = "";
        while (quot > 0)
        {
            rem = quot % 16;
            quot = quot / 16;
            if (rem < 10)
            {
                remstr = "" + rem;
            }
            else if (rem == 10)
            {
                remstr = "A";
            }
            else if (rem == 11)
            {
                remstr = "B";
            }
            else if (rem == 12)
            {
                remstr = "C";
            }
            else if (rem == 13)
            {
                remstr = "D";
            }
            else if (rem == 14)
            {
                remstr = "E";
            }
            else if (rem == 15)
            {
                remstr = "F";
            }
            result = remstr + result;
        }
        return result;
    }

    public string convertDecToOct(int input)
    {
        // YOUR CODE HERE
        int quot = input;
        int rem = 0;
        string result = "";
        while (quot > 0)
        {
            rem = quot % 8;
            quot = quot / 8;
            result = "" + rem + result;
        }
        return result;
    }

    public string convertDecToBin(int input)
    {
        // YOUR CODE HERE
        int quot = input;
        int rem = 0;
        string result = "";
        while (quot > 0)
        {
            rem = quot % 2;
            quot = quot / 2;
            result = "" + rem + result;
        }
        return result;
    }

    public int convertHexToDec(string inp)
    {
        // YOUR CODE HERE
        string input = inp.ToUpper();
        int length = input.Length;
        int result = 0;
        foreach (char c in input)
        {
            if (c == 'A')
            {
                result += 10 * (int)Mathf.Pow(16, length - 1);
            }
            else if (c == 'B')
            {
                result += 11 * (int)Mathf.Pow(16, length - 1);
            }
            else if (c == 'C')
            {
                result += 12 * (int)Mathf.Pow(16, length - 1);
            }
            else if (c == 'D')
            {
                result += 13 * (int)Mathf.Pow(16, length - 1);
            }
            else if (c == 'E')
            {
                result += 14 * (int)Mathf.Pow(16, length - 1);
            }
            else if (c == 'F')
            {
                result += 15 * (int)Mathf.Pow(16, length - 1);
            }
            else
            {
                result += (int)Char.GetNumericValue(c) * (int)Mathf.Pow(16, length - 1);
            }
            length--;
        }
        return result;
    }

    public int convertOctToDec(string input)
    {
        // YOUR CODE HERE
        int length = input.Length;
        int result = 0;
        foreach (char c in input)
        {
            result += (int)Char.GetNumericValue(c) * (int)Mathf.Pow(8, length - 1);
            length--;
        }
        return result;
    }

    public int convertBinToDec(string input)
    {
        // YOUR CODE HERE
        int length = input.Length;
        int result = 0;
        foreach (char c in input)
        {
            result += (int)Char.GetNumericValue(c) * (int)Mathf.Pow(2, length - 1);
            length--;
        }
        return result;
    }

    public string convertBinToHex(string input)
    {
        // YOUR CODE HERE
        int length = input.Length;
        string result = "";
        string inputWithLeadingZeros = "";
        int zeroCount = 4 - (length % 4);
        for (int i = 0; i < zeroCount; i++)
        {
            inputWithLeadingZeros += "0";
        }
        inputWithLeadingZeros += input;
        for (int i = 0; i < zeroCount + length; i += 4)
        {
            string binSegment = "" + inputWithLeadingZeros[i] + inputWithLeadingZeros[i + 1] + inputWithLeadingZeros[i + 2] + inputWithLeadingZeros[i + 3];
            if (binSegment == "0000")
            {
                result += "0";
            }
            else if (binSegment == "0001")
            {
                result += "1";
            }
            else if (binSegment == "0010")
            {
                result += "2";
            }
            else if (binSegment == "0011")
            {
                result += "3";
            }
            else if (binSegment == "0100")
            {
                result += "4";
            }
            else if (binSegment == "0101")
            {
                result += "5";
            }
            else if (binSegment == "0110")
            {
                result += "6";
            }
            else if (binSegment == "0111")
            {
                result += "7";
            }
            else if (binSegment == "1000")
            {
                result += "8";
            }
            else if (binSegment == "1001")
            {
                result += "9";
            }
            else if (binSegment == "1010")
            {
                result += "A";
            }
            else if (binSegment == "1011")
            {
                result += "B";
            }
            else if (binSegment == "1100")
            {
                result += "C";
            }
            else if (binSegment == "1101")
            {
                result += "D";
            }
            else if (binSegment == "1110")
            {
                result += "E";
            }
            else if (binSegment == "1111")
            {
                result += "F";
            }
        }
        // remove leading 0's from result
        foreach (char c in result)
        {
            if (c == '0')
            {
                result = result.Remove(0, 1);
            }
            else
            {
                break;
            }
        }
        return result;
    }

    public string convertHexToBin(string inp)
    {
        string input = inp.ToUpper();
        string result = "";
        foreach (char c in input)
        {
            if (c == '0')
            {
                result += "0000";
            }
            else if (c == '1')
            {
                result += "0001";
            }
            else if (c == '2')
            {
                result += "0010";
            }
            else if (c == '3')
            {
                result += "0011";
            }
            else if (c == '4')
            {
                result += "0100";
            }
            else if (c == '5')
            {
                result += "0101";
            }
            else if (c == '6')
            {
                result += "0110";
            }
            else if (c == '7')
            {
                result += "0111";
            }
            else if (c == '8')
            {
                result += "1000";
            }
            else if (c == '9')
            {
                result += "1001";
            }
            else if (c == 'A')
            {
                result += "A";
            }
            else if (c == 'B')
            {
                result += "1011";
            }
            else if (c == 'C')
            {
                result += "1100";
            }
            else if (c == 'D')
            {
                result += "1101";
            }
            else if (c == 'E')
            {
                result += "1110";
            }
            else if (c == 'F')
            {
                result += "1111";
            }
        }
        // remove leading 0's from result
        foreach (char c in result)
        {
            if (c == '0')
            {
                result = result.Remove(0, 1);
            }
            else
            {
                break;
            }
        }
        return result;
    }
}
