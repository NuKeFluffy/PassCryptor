/* 
 * MIT License
 * 
 * Copyright © 2020 NuKe Fluffy
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */

/*
 * Documentation and GitHub repository:
 * https://github.com/NuKeFluffy/PassCryptor
 */

using System;
using System.Text;

namespace PassCryptor
{
    public class Cryptor
    {
        /// <summary>The character that all entered characters will be replaced with.<para>Default: '*'</para></summary>
        public char HashKey { get; set; } = '*';
        /// <summary>The message the user will be prompted with to enter their password.<para>Default: "Password: "</para></summary>
        public string InputMessage { get; set; } = "Password: ";

        /// <summary>This will go through the process of hashing the password.</summary>
        /// <returns>Decrypted password</returns>
        public string GetPassword()
        {
            StringBuilder output = new StringBuilder();

            Console.Write(InputMessage);

            while (true)
            {
                var key = Console.ReadKey(true).KeyChar;
                Console.Clear();

                if (key == Convert.ToChar(ConsoleKey.Enter)) break;
                if (key == Convert.ToChar(ConsoleKey.Backspace)) output.Remove(output.Length - 1, 1);
                else output.Append(key);

                string hash = new string(HashKey, output.Length);

                Console.Write($"{InputMessage}{hash}");
            }
            Console.Clear();

            return output.ToString();
        }
    }
}
