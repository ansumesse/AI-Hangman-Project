using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanSolver
{
    static class StringMatching
    {
        private const char wildcard = '_';

        public static bool Matche(this string _origin, string _match)
        {
            for (int i = 0; i < _origin.Length; ++i)
            {
                if (_match[i] == wildcard)
                {
                    continue;
                }
                else if (_match[i] != _origin[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
