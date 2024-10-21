namespace Defra.UI.Test.Data.Configuration
{
    public class DataSetupConfig
    {
        private static IDataSetupConfig _configuration;
        public static IDataSetupConfig Configuration
        {
            get
            {
                return _configuration = _configuration ?? throw new Exception("Datasetup config not initialized");
            }
            set
            {
                _configuration = value;
                
            }
        }

    }
}
