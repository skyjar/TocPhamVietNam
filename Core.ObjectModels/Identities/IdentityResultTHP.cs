namespace Core.ObjectModels.Identities
{
    using System.Collections.Generic;

    public class IdentityResultTHP 
    {
        public object Data { get; set; }

        public bool IsErrors => this.Errors.Count > 0;

        private List<string> _errors;

        public List<string> Errors => _errors ?? (_errors = new List<string>());
    }
}
