using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HangmanSolver
{
    class Greedy_Algorithm
    {
        private IEnumerable<string> _PossibleChar;
        public IEnumerable<string> _PossibleWords
        {
            get { return _PossibleChar; }
        }
        public Greedy_Algorithm(String _file)
        {
            _PossibleChar = LoadFile(_file);
        }
        private List<string> LoadFile(string _file)
        {
            return new List<string>(File.ReadAllLines(_file));
        }
        public void WordSizeFilter(int _wordSize)
        {
            _PossibleChar = _PossibleChar.Where(word => word.Length == _wordSize).ToList();
        }
        public void GuessedCharFilter(char _guess, string _result)
        {
            if (_result.Contains(_guess))
            {
                MatchWithCharacter(_result);
            }
            else
            {
                RemoveByCharacter(_guess);
            }
        }
        private void RemoveByCharacter(char _removeByCharacter)
        {
            _PossibleChar = _PossibleChar.Where(word => !word.Contains(_removeByCharacter)).ToList();
        }
        private void MatchWithCharacter(string _partialWord)
        {
            _PossibleChar = _PossibleChar.Where(word => word.Matche(_partialWord)).ToList();
        }
        public char GuessBestCharacter(string _Word)
        {
            var _availableCharacters = new Dictionary<char, int>();
            foreach (var _possibleGuess in _PossibleChar)
            {
                foreach (var c in _possibleGuess.Distinct())
                {
                    if (_availableCharacters.ContainsKey(c))
                    {
                        var _value = _availableCharacters[c];
                        _availableCharacters.Remove(c);
                        _availableCharacters.Add(c, _value + 1);
                    }
                    else
                    {
                        _availableCharacters.Add(c, 1);
                    }
                }
            }

            foreach (var c in _Word)
            {
                if (_availableCharacters.ContainsKey(c))
                {
                    _availableCharacters.Remove(c);
                }
            }

            int _targetValue = _PossibleChar.Count() / 2;
            char _bestChar = '_';
            int _bestValue = 0;
            foreach (var entry in _availableCharacters)
            {
                if (_bestValue == 0)
                {
                    _bestChar = entry.Key;
                    _bestValue = entry.Value;
                    continue;
                }

                int _currentDifference = Math.Abs(_targetValue - _bestValue);
                int _entryDifference = Math.Abs(_targetValue - entry.Value);

                if (_entryDifference < _currentDifference)
                {
                    _bestChar = entry.Key;
                    _bestValue = entry.Value;
                }
            }
            return _bestChar;
        }
        public bool HasSolution()
        {
            return _PossibleChar.Count() == 1;
        }
        public string Solution()
        {
            return _PossibleChar.First();
        }
    }
}
