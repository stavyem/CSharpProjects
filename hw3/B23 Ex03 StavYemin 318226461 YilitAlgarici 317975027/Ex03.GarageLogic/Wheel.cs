namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaximumAirPressure;

        internal Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaximumAirPressure = i_MaximumAirPressure;
        }

        public float MaximumAirPressure
        {
            get
            {
                return r_MaximumAirPressure;
            }
        }
        
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        internal void FillAir(float i_AirToFill)
        {
            if (i_AirToFill > 0 && (m_CurrentAirPressure + i_AirToFill) <= r_MaximumAirPressure)
            {
                m_CurrentAirPressure += i_AirToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(0,r_MaximumAirPressure - m_CurrentAirPressure, 
                    string.Format("Invalid air pressure. Valid values: {0}-{1}", 0, r_MaximumAirPressure - m_CurrentAirPressure));
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Wheels manufacturer: {0}
Current wheels air pressure: {1}
Maximum wheels air pressure: {2}
", r_Manufacturer, m_CurrentAirPressure, r_MaximumAirPressure);
        }
    }
}
