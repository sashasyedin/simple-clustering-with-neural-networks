namespace ExpertSystem
{
    using System.Collections.Generic;
    using System.IO;
    using Network;

    public class Ensemble : List<Network>
    {
        private readonly List<string> _fileData;

        private Ensemble()
        {
            this._fileData = new List<string>();
        }

        public Ensemble(string path, int num)
            : this()
        {
            this.ReadFile(path);

            for (int i = 0; i < num; i++)
            {
                base.Add(new Network(this._fileData));
            }
        }

        private void ReadFile(string path)
        {
            using (var file = File.OpenText(path))
            {
                while (!file.EndOfStream)
                {
                    this._fileData.Add(file.ReadLine());
                }
            }
        }
    }
}
