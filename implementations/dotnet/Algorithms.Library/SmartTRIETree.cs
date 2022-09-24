using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Library
{
    public class PairNode
    {

        public PairNode(int index, SmartTRIENode tmp)
        {
            this.Index = index;
            this.Last = tmp;
        }

        public int Index { get; set; }
        public SmartTRIENode Last { get; set; }
    }
    public class SmartTRIENode
    {
        public char Character { get; set; }

        public SmartTRIENode()
        {
            this.Character = '^';
            this.Children = new SortedDictionary<int, SmartTRIENode>();
        }
        public SmartTRIENode(char character)
        {
            this.Character = character;
            this.Children = new SortedDictionary<int, SmartTRIENode>();
        }

        public SortedDictionary<int, SmartTRIENode> Children { get; set; }
        public bool IsEnd { get; internal set; }
    }
    public class SmartTRIETree
    {
        private SmartTRIENode root;
        public SmartTRIETree()
        {
            root = new SmartTRIENode();
        }

        public void AddWord(string literal)
        {
            int index = 0;
            SmartTRIENode tmp = root;

            while (index < literal.Length)
            {
                int key = literal[index] - 97;

                if (!tmp.Children.ContainsKey(key))
                {
                    SmartTRIENode child = new SmartTRIENode(literal[index]);
                    tmp.Children.Add(key, child);
                }
                tmp = tmp.Children[key];

                index++;

            }

            tmp.IsEnd = true;
        }


        public bool ContainsWord(string wordToCheck)
        {
            return LevelOrder(this.root, wordToCheck, 0);
        }

        public static bool LevelOrder(SmartTRIENode source, string word, int index)
        {
            if (index == word.Length)
            {
                if (source.IsEnd)
                    return true;
                return false;
            }
            if (word[index] == '.')
            {
                foreach(var suspectedChild in source.Children.Values)
                {
                    if(LevelOrder(suspectedChild,word,index+1))
                        return true;
                }
                return false;
            }
            int key = word[index] - 97;

            if (!source.Children.ContainsKey(key))
                return false;
            return LevelOrder(source.Children[key],word,index+1);


        }


    }
}