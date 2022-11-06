using System;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class PrintBTree
    {
        private List<IList<string>> response = new();
        private int h;

        private int Height(TreeNode current)
        {
            if (current == null) return 0;

            return 1 + Math.Max(Height(current.left), Height(current.right));
        }
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            this.h = Height(root);

            //cant rows is h+1.
            //cant cols is 
            string[] tmp = new string[(int)Math.Pow(2, h) - 1];
            Array.Fill(tmp, "");

            for (int i = 0; i < h; i++)
            {
                response.Add(new List<string>(tmp));
            }

            Fill(root, f: 0, c: tmp.Length / 2);

            return response;
        }
        private void Fill(TreeNode current, int f, int c)
        {
            if (current == null) return;
            
            //poner a la raiz
            this.response[f][c] = current.val.ToString();
            int shift = (int)Math.Pow(2, h - f - 2);
            if (current.left != null)
            {
                //marcar en la matriz por la izquierda y llamar recursivo
                this.response[f + 1][c - shift] = current.left.val.ToString();
                Fill(current.left,f + 1,c-shift);
            }
            

            if (current.right != null)
            {
                //marcar en la matriz por la derecha y llamar recursivo
                this.response[f + 1][c + shift] = current.right.val.ToString();
                Fill(current.right,f + 1,c + shift);

            }
        }
    }
}