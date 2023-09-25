using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly List<Vehicle> r_Vehicles = new List<Vehicle>();
      
        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid
        }

        public bool DoesVehicleExistInGarage(string i_LicenseNum)
        {
            bool exist = false;

            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.LicenseNum == i_LicenseNum)
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }

        public void ChangeVehicleStatus(string i_LicenseNum, eVehicleStatus i_Status)
        {
            foreach(Vehicle vehicle in r_Vehicles)
            {
                if(vehicle.LicenseNum == i_LicenseNum)
                {
                    vehicle.Status = i_Status;
                    break;
                }
            }
        }

        public void AddVehicleToGarage(Vehicle i_Vehicle)
        {
            r_Vehicles.Add(i_Vehicle);
        }

        public List<string> GetAllVehiclesLicenses()
        {
            List<string> vehiclesLicenseNums = new List<string>();

            foreach (Vehicle vehicle in r_Vehicles)
            {
                vehiclesLicenseNums.Add(vehicle.LicenseNum);
            }
            
            return vehiclesLicenseNums;
        }
        
        public List<string> GetAllVehiclesLicenses(eVehicleStatus i_StatusFilter)
        {
            List<string> filteredVehiclesLicenseNums = new List<string>();

            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.Status == i_StatusFilter)
                {
                    filteredVehiclesLicenseNums.Add(vehicle.LicenseNum);
                }
            }
            
            return filteredVehiclesLicenseNums;
        }

        public void FillVehicleTiresToMax(string i_LicenseNum)
        {
            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.LicenseNum == i_LicenseNum)
                {
                    vehicle.FillTiresToMax();
                    break;
                }
            }
        }

        public void FillPetrol(string i_LicenseNum, float i_AmountToFill, PetrolEnergy.ePetrolType i_PetrolType)
        {
            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.LicenseNum == i_LicenseNum)
                {
                    PetrolEnergy petrolEnergy = vehicle.Energy as PetrolEnergy;
                    if (petrolEnergy != null)
                    {
                        if (petrolEnergy.PetrolType == i_PetrolType)
                        {
                            vehicle.Energy.FillEnergy(i_AmountToFill);
                            break;
                        }
                        else
                        {
                            throw new ArgumentException(string.Format("You tried to fill {0} petrol to a vehicle with {1} petrol.",
                                i_PetrolType.ToString(), petrolEnergy.PetrolType.ToString()));
                        }
                    }
                    else
                    {
                        throw new ArgumentException("You tried to fill petrol to a vehicle with electric energy.");
                    }
                }
            }
        }

        public void ChargeBattery(string i_LicenseNum, float i_AmountToFill)
        {
            foreach(Vehicle vehicle in r_Vehicles)
            {
                if(vehicle.LicenseNum == i_LicenseNum)
                {
                    if (vehicle.Energy is ElectricEnergy)
                    {
                        vehicle.Energy.FillEnergy(i_AmountToFill);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("You tried to charge a battery of a vehicle with petrol energy.");
                    }
                }
            }
        }

        public Vehicle GetVehicleByLicenseNum(string i_LicenseNum)
        {
            Vehicle wantedVehicle = null;

            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.LicenseNum == i_LicenseNum)
                {
                    wantedVehicle = vehicle;
                    break;
                }
            }

            return wantedVehicle;
        }
    }
}
