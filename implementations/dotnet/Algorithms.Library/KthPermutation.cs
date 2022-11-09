namespace Algorithms.Library
{
    class KthPermutation
    {
        int indicator = 0;
        string response = "";
        public string GetPermutation(int n, int k)
        {
            perm(n, k, new bool[n], formed: "");
            return response;
        }

        public void perm(int n, int k, bool[] marks, string formed)
        {
            if (formed.Length == n)
            {
                indicator++;
                if (indicator == k)
                {
                    response = formed;
                }
                return;
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    if (!marks[i - 1])
                    {
                        marks[i - 1] = true;
                        perm(n, k, marks, formed + i);
                        marks[i - 1] = false;
                    }
                }
            }
        }
    }
}