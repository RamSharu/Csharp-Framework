namespace Defra.UI.Tests.Data.Identification
{
    public class IdentificationData
    {
        public string PrdDesc { get; set; } = null;
        public bool FillColdStore { get; set; }
        public ColdStore ColdStore { get; set; }
        public string IdentificationMark { get; set; } = null;
        public string BreedCategory { get; set; } = null;
        public string PkgCount { get; set; } = null;
        public string PkgUnit { get; set; } = null;
        public string Weight { get; set; } = null;
        public string WeightUnit { get; set; } = null;
        public string TreatmentType { get; set; } = null;
        public string NatureOfCommodity { get; set; } = null;
        public string BatchNumber { get; set; } = null;
        public bool FinalConsumerRadio { get; set; } = false;
        public bool FinalConsumer { get; set; }
        public string CollectionDate { get; set; } = null;
        public string Quantity { get; set; } = null;
        public string QuantityUnit { get; set; } = null;
        public string Species { get; set; } = null;
        //public string Breed { get; set; } = null;
        public bool FillManufacturingPlant { get; set; }
        public ManufacturingPlant ManufacturingPlant { get; set; }
        public bool FillSlaughterHouse { get; set; }
        public SlaughterHouse SlaughterHouse { get; set; }
        public string ProductionDate { get; set; } = null;
        public string CollectionProductionDate { get; set; } = null;
        public string StorageLifeDate { get; set; } = null;
        public bool FillPlantEstablishmentCentre { get; set; }
        public PlantEstablishmentCentre PlantEstablishmentCentre { get; set; }
    }
}
