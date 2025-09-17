using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoastingPhrasesDB", menuName = "SO/RoastingPhrasesDB")]
public class RoastingPhrasesSO : ScriptableObject
{
    [SerializeField] private List<string> _phrases = new();
    public string GetRandomPhrase()
    {
        if (_phrases == null || _phrases.Count == 0)
            return string.Empty;

        int index = Random.Range(0, _phrases.Count);
        return _phrases[index];
    }
}
