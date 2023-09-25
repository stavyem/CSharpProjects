using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly eColor r_Color;
        private readonly eNumOfDoors r_NumOfDoors;

        public enum eColor
        {
            White,
            Black,
            Yellow,
            Red
        }

        public enum eNumOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }

        internal Car(Dictionary<string, object> i_CarDetails, eColor i_Color, eNumOfDoors i_NumOfDoors) : base(i_CarDetails)
        {
            r_Color = i_Color;
            r_NumOfDoors = i_NumOfDoors;
        }

        public static float GetMaxEnergy(Energy.eEnergyType i_EnergyType)
        {
            float maxEnergy;
            
            if (i_EnergyType == Energy.eEnergyType.Electric)
            {
                maxEnergy = 5.2f;
            }
            else
            {
                maxEnergy = 46;
            }

            return maxEnergy;
        }

        public static float GetMaxWheelPressure()
        {
            return 33;
        }

        public override string ToString()
        {
            return String.Format(
@"Car
Color: {0}
Number of doors: {1}
{2}
", r_Color, r_NumOfDoors, base.ToString());
        }
    }
}