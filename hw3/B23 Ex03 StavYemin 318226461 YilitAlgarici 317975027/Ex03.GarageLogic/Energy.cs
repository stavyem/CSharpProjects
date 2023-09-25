namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        protected float m_RemainingEnergy;
        protected readonly float r_MaximumEnergy;

        internal Energy(float i_RemainingEnergy, float i_MaximumEnergy)
        {
            m_RemainingEnergy = i_RemainingEnergy;
            r_MaximumEnergy = i_MaximumEnergy;
        }
        
        internal void FillEnergy(float i_AmountToFill)
        {
            if (i_AmountToFill > 0 && (m_RemainingEnergy + i_AmountToFill) <= r_MaximumEnergy)
            {
                m_RemainingEnergy += i_AmountToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaximumEnergy - m_RemainingEnergy,
                    string.Format("Invalid amount. Valid values: {0}-{1}", 0, r_MaximumEnergy - m_RemainingEnergy));
            }
        }
        
        public enum eEnergyType
        {
            Petrol,
            Electric
        }
    }
}