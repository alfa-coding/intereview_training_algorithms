using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    class TRIENode
    {
        public char Character { get; set; }

        public TRIENode()
        {
            this.Character = '$';
            this.Children = new TRIENode[26];
        }
        public TRIENode(char character)
        {
            this.Character = character;
            this.Children = new TRIENode[26];
        }

        public TRIENode[] Children { get; set; }
    }
    public class TRIETree<T> : IEnumerable<T>, IEnumerable
    {
        private TRIENode root;
        public TRIETree()
        {
            root = new TRIENode();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}