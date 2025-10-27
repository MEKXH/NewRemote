namespace _1RM.Model.ProtocolRunner
{
    public class ExternalRunnerForSSH : ExternalRunner
    {
        public ExternalRunnerForSSH(string runnerName, string ownerProtocolName) : base(runnerName, ownerProtocolName)
        {
        }


        private string _argumentsForPrivateKey = "";
        public string ArgumentsForPrivateKey
        {
            get => _argumentsForPrivateKey;
            set
            {
                _argumentsForPrivateKey = value;
                RaisePropertyChanged();
            }
        }
    }
}
