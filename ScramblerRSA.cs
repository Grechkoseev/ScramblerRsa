using System.Numerics;
using System.Text;

namespace Lab_4;

internal class ScramblerRsa
{
    private readonly int _p;
    private readonly int _q;
    private readonly Dictionary<char, int> _alphabetDictionary = new()
    {
        { 'А', 10 },
        { 'Б', 11 },
        { 'В', 12 },
        { 'Г', 13 },
        { 'Д', 14 },
        { 'Е', 15 },
        { 'Ж', 16 },
        { 'З', 17 },
        { 'И', 18 },
        { 'Й', 19 },
        { 'К', 20 },
        { 'Л', 21 },
        { 'М', 22 },
        { 'Н', 23 },
        { 'О', 24 },
        { 'П', 25 },
        { 'Р', 26 },
        { 'С', 27 },
        { 'Т', 28 },
        { 'У', 29 },
        { 'Ф', 30 },
        { 'Х', 31 },
        { 'Ц', 32 },
        { 'Ч', 33 },
        { 'Ш', 34 },
        { 'Щ', 35 },
        { 'Ъ', 36 },
        { 'Ы', 37 },
        { 'Ь', 38 },
        { 'Э', 39 },
        { 'Ю', 40 },
        { 'Я', 41 },
        { ' ', 99 }
    };
    private readonly int _n;
    private int _e;
    private int _d;

    public ScramblerRsa(int p, int q)
    {
        _p = p;
        _q = q;
        _n = p * q;
    }

    /// <summary>
    /// Шифрование строки
    /// </summary>
    /// <param name="text"></param>
    /// <param name="keyValuePair"></param>
    /// <returns></returns>
    public string EncryptString(string text, KeyValuePair<int, int> keyValuePair)
    {
        _e = keyValuePair.Key;
        _d = keyValuePair.Value;
        var numberString = NumberRepresentationList(text);
        var blocks = EncryptionBlocks(numberString);
        var encryptedString = new StringBuilder();

        var encryptedList = blocks.Select(encryptionBlock => BigInteger.Pow(encryptionBlock, _e) % _n).ToList();

        foreach (var number in encryptedList)
        {
            encryptedString.Append(number + " ");
        }

        return encryptedString.ToString();
    }

    /// <summary>
    /// Расшифровка строки
    /// </summary>
    /// <param name="text"></param>
    /// <param name="keyValuePair"></param>
    /// <returns></returns>
    public string DecryptString(string text, KeyValuePair<int, int> keyValuePair)
    {
        _e = keyValuePair.Key;
        _d = keyValuePair.Value;
        var decryptNumbers = new StringBuilder();

        List<int> numbers = text.TrimEnd(' ').Split(' ').Select(int.Parse).ToList();

        foreach (var number in numbers)
        {
            decryptNumbers.Append(BigInteger.Pow(number, _d) % _n);
        }

        return ConvertNumbersToText(decryptNumbers.ToString());
    }

    /// <summary>
    /// Список блоков сообщения
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private List<int> EncryptionBlocks(string text)
    {
        var encryptionBlocks = new List<int>();
        var tempString = new StringBuilder();

        foreach (var number in text)
        {
            int.TryParse(number.ToString(), out var result);
            tempString.Append(result);

            if (tempString[0] == '0')
            {
                encryptionBlocks.Add(0);
                tempString.Remove(0, 1);
            }
            else
            {
                if (int.Parse(tempString.ToString()) >= _p * _q)
                {
                    encryptionBlocks.Add(int.Parse(tempString.ToString()[..(tempString.Length - 1)]));
                    tempString.Clear();
                    tempString.Append(result);
                }
            }
        }

        encryptionBlocks.Add(int.Parse(tempString.ToString()));

        return encryptionBlocks;
    }

    /// <summary>
    /// Преобразование текстовой строки в строку с кодами символов
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private string NumberRepresentationList(string text)
    {
        var upperText = text.ToUpper();
        var numberStringBuilder = new StringBuilder(upperText);

        foreach (var keyValuePair in _alphabetDictionary)
        {
            numberStringBuilder.Replace(keyValuePair.Key.ToString(), keyValuePair.Value.ToString());
        }

        return numberStringBuilder.ToString();
    }

    /// <summary>
    /// Преобразование строки с кодами символов в строку текста
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    private string ConvertNumbersToText(string numbers)
    {
        var outputString = new StringBuilder();

        for (var i = 0; i < numbers.Length / 2; i++)
        {
            var number = int.Parse(numbers.Substring(i * 2, 2));
            outputString.Append(_alphabetDictionary.First(a => a.Value == number).Key);
        }

        return outputString.ToString();
    }

    /// <summary>
    /// Получение словаря из нескольких пар e и d
    /// </summary>
    /// <returns></returns>
    public Dictionary<int, int> EdPairDictionary()
    {
        var edPAirDictionary = new Dictionary<int, int>();
        var pqMultiplier = 1;

        while (edPAirDictionary.Count < 4)
        {
            if (IsPrime(pqMultiplier * (_p - 1) * (_q - 1) + 1))
            {
                pqMultiplier++;
            }
            else
            {
                var primeFactors = GetPrimeFactors(pqMultiplier * (_p - 1) * (_q - 1) + 1);
                var tempEDPairDictionary = new Dictionary<int, int>();

                foreach (var primeFactor in primeFactors.Where(primeFactor =>
                             FindGcd(primeFactor, pqMultiplier * (_p - 1) * (_q - 1)) == 1))
                {
                    tempEDPairDictionary.TryAdd(primeFactor, (pqMultiplier * (_p - 1) * (_q - 1) + 1) / primeFactor);
                }

                var tempKeys = new List<int>();

                if (tempEDPairDictionary.Count > 1)
                {
                    tempKeys.AddRange(tempEDPairDictionary.Keys);

                    var allKeys = new List<int>();

                    for (var i = 0; i < tempKeys.Count; i++)
                    {
                        for (var j = i + 1; j < tempKeys.Count; j++)
                        {
                            var key = tempKeys[i] * tempKeys[j];
                            allKeys.Add(key);
                        }
                    }

                    foreach (var key in allKeys.Where(key =>
                                 key != 1 && (pqMultiplier * (_p - 1) * (_q - 1) + 1) / key != 1))
                    {
                        tempEDPairDictionary.Add(key, (pqMultiplier * (_p - 1) * (_q - 1) + 1) / key);
                    }
                }

                foreach (var edKeyValuePair in tempEDPairDictionary)
                {
                    edPAirDictionary.TryAdd(edKeyValuePair.Key, edKeyValuePair.Value);
                }

                pqMultiplier++;
            }
        }

        return edPAirDictionary;
    }

    /// <summary>
    /// Проверка числа на простоту с помощью решета Эратосфена
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static bool IsPrime(int number)
    {
        if (number < 2) return false;

        var primes = new bool[number + 1];

        for (var i = 2; i <= number; i++)
        {
            primes[i] = true;
        }

        for (var p = 2; p * p <= number; p++)
        {
            if (primes[p])
            {
                for (var i = p * 2; i <= number; i += p)
                {
                    primes[i] = false;
                }
            }
        }

        return primes[number];
    }

    /// <summary>
    /// Разложение числа на простые множители
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static List<int> GetPrimeFactors(int number)
    {
        var factors = new List<int>();
        var divisor = 2;

        while (number > 1)
        {
            if (number % divisor == 0)
            {
                factors.Add(divisor);
                number /= divisor;
            }
            else
            {
                divisor++;
            }
        }

        return factors;
    }

    /// <summary>
    /// Поиск НОД двух чисел
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private static int FindGcd(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

}