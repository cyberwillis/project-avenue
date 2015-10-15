using System.Collections.Generic;
using System.Text;

namespace AvenueEntrega.Model
{
    public class ModelBase
    {
        private IDictionary<string, string> _brokenRules;

        public IDictionary<string, string> BrokenRules
        {
            get { return _brokenRules; }
            protected set { _brokenRules = value; }
        }

        public ModelBase()
        {
            this.BrokenRules = new Dictionary<string, string>();
        }

        public StringBuilder GetErrorMessages()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Erro: ");

            foreach (var error in this._brokenRules)
            {
                stringBuilder.Append("</br>");
                stringBuilder.AppendLine(error.Value);
            }

            return stringBuilder;
        }

        private void AddBrokenRules(string key, string message)
        {
            if (this.BrokenRules.ContainsKey(key))
                this.BrokenRules[key] = message;
            else
                this.BrokenRules.Add(key, message);
        }

        public void ClearBrokenRules()
        {
            this.BrokenRules.Clear();
        }

    }
}