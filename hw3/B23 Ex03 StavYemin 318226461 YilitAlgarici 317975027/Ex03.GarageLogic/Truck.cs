using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_HazardMaterials;
        private readonly float r_CargoVolume;
        
        internal Truck(Dictionary<string, object> i_CarDetails, bool i_HazardMaterials, float i_CargoVolume) : base(i_CarDetails)
        {
            r_HazardMaterials = i_HazardMaterials;
            r_CargoVolume = i_CargoVolume;
        }
        
        public static float GetMaxEnergy()
        {
            return 135;
        }
        
        public static float GetMaxWheelPressure()
        {
            return 26;
        }

        public override string ToString()
        {
            return string.Format(
                @"Truck
Hazardous materials: {0}
Cargo volume: {1}
{2}
", r_HazardMaterials, r_CargoVolume, base.ToString());
        }
    }
}
