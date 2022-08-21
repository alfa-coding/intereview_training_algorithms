using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    class TrieEnumerator : IEnumerator
    {
        private TRIENode root;

        public TrieEnumerator(TRIENode root)
        {
            this.root = root;
        }

        public object Current => throw new System.NotImplementedException();

        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
    class TRIENode
    {
        public char Character { get; set; }

        public TRIENode()
        {
            this.Character = '^';
            this.Children = new TRIENode[26];
        }
        public TRIENode(char character)
        {
            this.Character = character;
            this.Children = new TRIENode[26];
        }

        public TRIENode[] Children { get; set; }
        public bool IsEnd { get; internal set; }
    }
    public class TRIETree : IEnumerable
    {
        private TRIENode root;
        public TRIETree()
        {
            root = new TRIENode();
        }

        public void AddWord(string literal)
        {
            int index = 0;
            TRIENode tmp = root;

            while (index < literal.Length)
            {
                if (tmp.Children[literal[index] - 97] is null)
                {
                    TRIENode child = new TRIENode(literal[index]);
                    tmp.Children[literal[index] - 97] = child;
                }
                tmp = tmp.Children[literal[index] - 97];

                index++;

            }

            tmp.IsEnd = true;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TrieEnumerator(root);
        }

        public List<string> ListAlphabetically()
        {
            List<string> response = new List<string>();
            ListAlphabeticallyHelper(root, response, "");
            return response;
        }

        private void ListAlphabeticallyHelper(TRIENode current, List<string> response, string forming)
        {
            if (current.IsEnd)
            {
                response.Add(forming);
            }
            if (current.Children is not null)
            {
                foreach (var children in current.Children)
                {
                    if (children is not null)
                    {
                        ListAlphabeticallyHelper(children, response, forming + children.Character);
                    }
                }
            }
        }

        public List<string> SufixesOf(string prefix)
        {
            return null;
        }

        public bool ContainsWord(string wordToCheck)
        {
            TRIENode tmp = root;
            int index = 0;
            while (index < wordToCheck.Length)
            {
                if (tmp.Children[wordToCheck[index] - 97] is null)
                    return false;
                tmp = tmp.Children[wordToCheck[index] - 97];
                index++;
            }

            return true;
        }


    }
}