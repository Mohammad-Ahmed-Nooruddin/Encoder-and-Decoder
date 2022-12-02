using System;

public class Encoder
{
  public static char addChars(char char1, char char2, bool adding)
  {
    int result = 0;
    char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`~!@#$%^&*()-_=+,<.>/?;:\'\"[{]}\\|1234567890".ToCharArray();

    int x = 0;
    while(x < chars.Length)
    {
        if(char1 == chars[x])
        {
            result += x;
        }
        x += 1;
    }
    x = 0;
    while(x < chars.Length)
    {
        if(char2 == chars[x])
        {
            if(adding)
            {
                result += x;
            }
            else
            {
                result -= x;
            }
        }
        x += 1;
    }
    if(result < 0)
    {
        result = result * -1;
    }
    return chars[result % chars.Length];
  }
  
  public static string encode(string text, string key, bool encoding)
  {
    string encodedText = "";
    char[] keyArray = key.ToCharArray();
    char[] textArray = text.ToCharArray();
    
    int x = 0;
    while(x < textArray.Length)
    {
        char newCharacter;
        if(encoding)
        {
            newCharacter = addChars(textArray[x], keyArray[x % keyArray.Length], true);
        }
        else
        {
            newCharacter = addChars(textArray[x], keyArray[x % keyArray.Length], false);
        }
        encodedText += newCharacter;
        x += 1;
    }
    
    return encodedText;
  }
  public static void Main()
  {
    Console.WriteLine("This program encodes and decodes text.\nType encode or decode followed by the word you want to encode or decode followed by the key, all seperated with commas.\n");
    
    while(true)
    {
        Console.WriteLine("Encode or decode your text.");
        string input = Console.ReadLine();
        input = input.Replace(" ", "");
        string[] inputArray = input.Split(',');
        
        if(inputArray[0].ToLower() == "decode")
        {
            Console.WriteLine(encode(inputArray[1], inputArray[2], false));
        }
        else
        {
            Console.WriteLine(encode(inputArray[1], inputArray[2], true));
        }
        Console.Write("\n");
    }
  }
}
