using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinalProjectSharp;

public class Dictionary
{
    public List<Translation> Words { get; set; }
    private string? FromLanguage { get; set; }
    private string? ToLanguage { get; set; }

    public Dictionary(string? fromLanguage, string? toLanguage)
    {
        Words = new List<Translation>();
        FromLanguage = fromLanguage;
        ToLanguage = toLanguage;
    }

    public void Print()
    {
        Console.WriteLine($"From: {FromLanguage}" +
                          $"\nTo: {ToLanguage}");

        foreach (var translation in Words)
        {
            translation.Print();
        }
    }

    public void Append(Translation appendedTranslation)
    {
        Words.Add(appendedTranslation);
    }

    public void Delete(int position)
    {
        Words.RemoveAt(position);
    }

    public static void Serialization(List<Translation> dictionary)
    {
        using FileStream fs = new("translation.json", FileMode.OpenOrCreate);
        JsonSerializer.Serialize(fs, dictionary);

        fs.Close();
    }

    public static List<Translation> Deserialization()
    {
        using FileStream fs = new("translation.json", FileMode.OpenOrCreate);
        var newDictionary = JsonSerializer.Deserialize<List<Translation>>(fs);
        fs.Close();

        return newDictionary;
    }
}


public class Translation
{
    private string Word { get; set; }
    private List<string> Translations;

    [JsonConstructor] public Translation(string word, List<string> translations)
    {
        Word = word;
        Translations = translations;
    }

    public void Print()
    {
        Console.Write($"\nWord - {Word}" +
                      $"\nTranslations: ");

        foreach (var word in Translations)
        {
            Console.Write($"{word} , ");
        }
    }

    public void AddTranslation(string transl)
    {
        Translations.Add(transl);
    }

    public void DeleteTranslation(int position)
    {
        Translations.RemoveAt(position);
    }

    public void ChangeTranslation(int position, string newTranslation)
    {
        Translations[position] = newTranslation;
    }

    public void ChangeWord(int position, string newWord)
    {
        Word = newWord;
    }

}