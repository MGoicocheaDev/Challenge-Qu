namespace app_lib.Matrix
{
    internal class WordFinder : IWordFinder
    {
        public readonly char[][] _matrix;
        public WordFinder(IEnumerable<string> matrix)
        {
            if(matrix.Count() > 64) throw new ArgumentException("Matrix can't be exceded 64x64");

            if(matrix.Any(x => x.Length > 64)) throw new ArgumentException("Matrix can't be exceded 64x64");

            _matrix = matrix.Select(x => x.ToCharArray()).ToArray();
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var words = new HashSet<string>(wordstream);
            var counts = new Dictionary<string, int>();

            // Horizontal
            for(int i = 0; i < _matrix.Length; i++)
            {
                string row = new string(_matrix[i]);
                foreach(var word in words)
                {
                    if (row.ToUpper().Contains(word.ToUpper()))
                    {
                        counts[word] = CountOccurrences(row,word);
                    }
                }
            }

            // Vertical
            for(int i = 0; i < _matrix[0].Length; i++)
            {
                string column = new string(_matrix.Select(x => x[i]).ToArray());
                foreach (var word in words)
                {
                    if (column.ToUpper().Contains(word.ToUpper()))
                    {
                        counts[word] = CountOccurrences(column, word);
                    }
                }
            }

            return counts.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key);
        }

        private static int CountOccurrences(string text, string pattern)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                count++;
                i += pattern.Length;
            }
            return count;
        }
    }
}
