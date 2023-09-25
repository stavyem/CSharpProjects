namespace Ex03.GarageLogic
{
    internal class ElectricEnergy : Energy
    {
        internal ElectricEnergy(float i_RemainingEnergy, float i_MaximumEnergy) : base(
            i_RemainingEnergy, i_MaximumEnergy)
        {
            
        }

        public override string ToString()
        {
            return string.Format(
@"Electric
Remaining battery: {0}
Maximum battery: {1}", m_RemainingEnergy, r_MaximumEnergy);
        }
    }
}