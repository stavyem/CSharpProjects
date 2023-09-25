using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public enum eLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }
        
        internal Motorcycle(Dictionary<string, object> i_CarDetails, eLicenseType i_LicenseType, int i_EngineCapacity) : base(i_CarDetails)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public static float GetMaxEnergy(Energy.eEnergyType i_EnergyType)
        {
            float maxEnergy;
            
            if (i_EnergyType == Energy.eEnergyType.Electric)
            {
                maxEnergy = 2.6f;
            }
            else
            {
                maxEnergy = 6.4f;
            }

            return maxEnergy;
        }
        
        public static float GetMaxWheelPressure()
        {
            return 31;
        }

        public override string ToString()
        {
            return string.Format(
@"Motorcycle
License type: {0}
Engine capacity: {1}
{2}
", r_LicenseType, r_EngineCapacity, base.ToString());
        }
    }
}
