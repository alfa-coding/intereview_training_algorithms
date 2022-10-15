using System.Text;
using System.Collections.Generic;
using System;

namespace Algorithms.Library
{


    class Trie
    {

        private TRIENode root;

        public Trie()
        {
            root = new TRIENode();
        }

        public void Insert(string word)
        {
            int index = 0;
            TRIENode tmp = root;

            while (index < word.Length)
            {
                if (tmp.Children[word[index] - 97] is null)
                {
                    TRIENode child = new TRIENode(word[index]);
                    tmp.Children[word[index] - 97] = child;
                }
                tmp = tmp.Children[word[index] - 97];

                index++;

            }

            tmp.IsEnd = true;
        }

        public bool Search(string word)
        {
            TRIENode tmp = root;
            if (word.Length == 0) return false;
            foreach (var character in word)
            {
                int key = character - 97;
                if (tmp.Children[key] == null)
                    return false;
                tmp = tmp.Children[key];
            }
            return tmp.IsEnd;

        }

        public bool StartsWith(string prefix)
        {
            TRIENode tmp = root;
            if (prefix.Length == 0) return false;
            foreach (var character in prefix)
            {
                int key = character - 97;
                if (tmp.Children[key] == null)
                    return false;
                tmp = tmp.Children[key];
            }
            return true;
        }

        internal string CalcPref(string prefix)
        {
            StringBuilder b = new StringBuilder();
            TRIENode tmp = root;

            foreach (var character in prefix)
            {
                int key = character - 97;
                if (tmp.IsEnd||tmp.Children[key] == null)
                    break;
                tmp = tmp.Children[key];
                b.Append(character);
            }

            return tmp.IsEnd?b.ToString():"";
        }
    }

    public class ReplaceWordsEx
    {
        Trie myTrie = new();

        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            var source = sentence.Split();

            foreach (var word in dictionary)
            {
                myTrie.Insert(word);
            }
            StringBuilder response = new StringBuilder();

            for(int i=0;i<source.Length;i++)
            {
                string prefix = source[i];
                string calculatedPref = myTrie.CalcPref(prefix);
                if (!string.IsNullOrEmpty(calculatedPref))
                    response.Append(calculatedPref);
                else
                {
                    response.Append(prefix);
                }
                if (i<source.Length-1)
                {
                    response.Append(' ');
                }
                    
            }

            return response.ToString();

        }
    }
}