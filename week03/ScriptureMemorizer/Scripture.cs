using System;


public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        foreach (string _words in text.Split(' '))
                     {

            
        }
    }


    .Selector(word)