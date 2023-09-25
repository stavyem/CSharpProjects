using System;
using System.Runtime.InteropServices;

namespace Ex03.GarageLogic
{
    public class PetrolEnergy : Energy
    {
        private readonly ePetrolType r_PetrolType;

        internal ePetrolType PetrolType
        {
            get
            {
                return r_PetrolType;
            }
        }

        public enum ePetrolType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        internal PetrolEnergy(float i_RemainingEnergy, float i_MaximumEnergy, ePetrolType i_PetrolType) : base(i_RemainingEnergy, i_MaximumEnergy)
        {
            r_PetrolType = i_PetrolType;
        }

        public override string ToString()
        {
            return string.Format(
@"Petrol
Remaining tank: {0}
Maximum tank: {1}
Petrol type: {2}", m_RemainingEnergy, r_MaximumEnergy, r_PetrolType);
        }
    }
}