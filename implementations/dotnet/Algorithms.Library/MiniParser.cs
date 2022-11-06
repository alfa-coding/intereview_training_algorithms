using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Library
{
    public class NestedInteger
    {
        private int _number { get; set; }
        private List<NestedInteger> _internals { get; set; }
        // Constructor initializes an empty nested list.
        public NestedInteger()
        {
        }

        // Constructor initializes a single integer.
        public NestedInteger(int value)
        {
            this._number = value;

        }

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger()
        {
            return this._internals == null;
        }

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger()
        {
            return this._number;
        }

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value)
        {
            this._number = value;
            this._internals = null;
        }

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni)
        {
            if (this._internals == null)
            {
                this._internals = new List<NestedInteger>();
            }
            this._internals.Add(ni);
        }

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList()
        {
            return this._internals;
        }
    }
    public class MiniParser
    {
        public NestedInteger Deserialize(string s)
        {
            if (s.Contains(' '))
                s = s.Replace(" ", "");
            return DeserializeR(s, 0);

        }
        private bool ComesDigit(char c)=> Char.IsDigit(c) || c=='-';

        private NestedIntegerInfo GetNumber(string s, int lookUp)
        {
            StringBuilder b = new();
            int sign = s[lookUp] == '-' ? -1 : 1;
            lookUp = sign > 0 ? lookUp : lookUp + 1;
            while (lookUp < s.Length && ComesDigit(s[lookUp]))
            {
                b.Append(s[lookUp]);
                lookUp++;
            }
            int n = sign * int.Parse(b.ToString());
            return new NestedIntegerInfo(n, lookUp);
        }

        private NestedIntegerListInfo DeserializeList(string s, int index)
        {
            List<NestedInteger> response = new List<NestedInteger>();

            while (index < s.Length)
            {
                if (s[index] == ']')
                {
                    if (index + 1<s.Length)
                    {
                        if(s[index+1]==',' ||s[index+1]==']' )
                            return new NestedIntegerListInfo(response, index+1);
                    }
                    
                    break;
                }
                if (ComesDigit(s[index]))
                {
                    var numberInfo = GetNumber(s, index);
                    response.Add(numberInfo.v);
                    index = numberInfo.lookUp;
                    continue;
                }

                if (s[index] == ',')
                {
                    index++;
                    continue;
                }
                if (s[index] == '[')
                {
                    var listInfo = DeserializeList(s, index + 1);
                    NestedInteger nConLista = new NestedInteger();
                    foreach (var item in listInfo.response)
                    {
                        nConLista.Add(item);
                    }
                    response.Add(nConLista);
                    index = listInfo.index;

                }

            }
            return new NestedIntegerListInfo(response, index);
        }
        private NestedInteger DeserializeR(string s, int index)
        {
            if (s[0] == '[')
            {
                var listInfo = DeserializeList(s, index + 1);
                NestedInteger nConLista = new NestedInteger();
                foreach (var item in listInfo.response)
                {
                    nConLista.Add(item);
                }
                return nConLista;
            }
            else
            {
                return GetNumber(s, index).v;
            }
        }
    }

    public class NestedIntegerListInfo
    {
        public List<NestedInteger> response;
        public int index;

        public NestedIntegerListInfo(List<NestedInteger> response, int index)
        {
            this.response = response;
            this.index = index;
        }
    }

    public class NestedIntegerInfo
    {
        public NestedInteger v;
        public int lookUp;

        public NestedIntegerInfo(int v, int lookUp)
        {
            this.v = new NestedInteger(v);
            this.lookUp = lookUp;
        }
    }
}