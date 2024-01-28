using System.Security.Cryptography;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {
            Random randomGenerator = new Random();
            int randomIndex = randomGenerator.Next(_words.Count());

            for (int j = 0; j < _words.Count; j++)
            {
                if (_words[j] == _words[randomIndex])
                {
                    if (_words[j].IsHidden())
                    {
                        return;
                    }
                    else
                    {
                        _words[j].Hide();
                    }
                }
            }
        }
    }
    public string GetScriptureDisplay()
    {
        string scriptureString = "";

        foreach (Word word in _words)
        {
            scriptureString += $"{word.GetWordDisplay()} ";
        }

        return $"{_reference.GetReferenceDisplay()} {scriptureString}";
    }
    public bool IsCompletelyHidden()
    {
        bool wordsAreUnderscores = false;

        int wordsHidden = 0;

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                wordsHidden += 1;
            }
            if (wordsHidden == _words.Count())
            {
                wordsAreUnderscores = true;
            }
        }

        return wordsAreUnderscores;
    }
}