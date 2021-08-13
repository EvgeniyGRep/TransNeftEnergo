namespace TransNeftEnergo.DTO
{
    public class PostPowerMeasuringPointParam
    {
        public string Name { get; set; }
        public int CurrentMeterId { get; set; }
        public int CurrentTransformerId { get; set; }
        public int VoltageTransformerId { get; set; }
        public int ConsumptionObjectId { get; set; }
    }
}
