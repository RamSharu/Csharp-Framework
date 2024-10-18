using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.Identification;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Defra.UI.Tests.Data.EHC
{
    public class EHC
    {
        public IdentificationData Identification { get; set; }
        public string GrossWeight { get; set; } = null;
        public string GrossWeightUnit { get; set; } = null;
        public string GoodsCertifiedAs { get; set; } = null;
        public string ContainerNumber { get; set; } = null;
        public string SealNumber { get; set; } = null;
        public string PurposeOfTheExport { get; set; } = null;
        public string DocumentType { get; set; } = null;
        public string DocumentRef { get; set; } = null;
        public string ConsignorName { get; set; } = null;
        public string ConsigneeCountry { get; set; } = null;
        public string ConsigneeName { get; set; } = null;
        public string CertifierName { get; set; } = null;
        public string CertificationRegion { get; set; } = null;
        public string ResponsibleLoadConutry { get; set; } = null;
        public string ResponsibleForLoad { get; set; } = null;
        public string CountryOfOrigin { get; set; } = null;
        public string RegionOfOrigins { get; set; } = null;
        public string PlaceOfDispatchCountry { get; set; } = null;
        public string PlaceOfDispatch { get; set; } = null;
        public string PlaceOfLoadingCountry { get; set; } = null;
        public string PlaceOfLoading { get; set; } = null;
        public string BorderControlPostCountry { get; set; } = null;
        public string BorderControlPost { get; set; } = null;
        public string TransportCondition { get; set; } = null;
        public string MeansOfTransport { get; set; } = null;
        public string Identifier { get; set; } = null;
        public string PlaceOfDestinationCountry { get; set; } = null;
        public string PlaceOfDestination { get; set; } = null;
    }


    public interface IEHCData
    {
        public List<EHC> GetEHCdata(string certificateNum);
    }

    public class EHCData : IEHCData
    {
        private IObjectContainer _objectContainer;

        public EHCData(IObjectContainer objectContainer) => _objectContainer = objectContainer;
        private readonly object _lock = new object();

        public List<EHC> GetEHCdata(string certificateNum)
        {
            lock (_lock)
            {
                certificateNum = certificateNum.Replace("EHC", "");
                lock (_lock)
                {
                    string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string EHCDataJson = "EHC" + certificateNum + ".json";
                    var filePath = Path.Combine(jsonPath, "Data", "EHC", EHCDataJson);
                    if (ConfigSetup.BaseConfiguration.TestConfiguration.Environment.Contains("pre"))
                        filePath = Path.Combine(jsonPath, "Data", "EHC","Pre", EHCDataJson);

                    var builder = new ConfigurationBuilder();
                    builder.AddJsonFile(filePath, false, true);
                    var settings = builder.Build();
                    var dataList = settings.GetSection("EHC").Get<List<EHC>>();
                    return dataList;
                }
            }
        }
    }
}