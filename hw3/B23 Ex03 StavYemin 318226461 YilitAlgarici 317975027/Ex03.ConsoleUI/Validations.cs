using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Validations
    {
        internal static void ValidatesDigitsOnly(string i_OwnerPhone)
        {
            foreach(char c in i_OwnerPhone)
            {
                if(!char.IsDigit(c))
                {
                    throw new FormatException("Invalid phone number. you are expected to enter only digits.");
                }
            }
        }

        internal static void ValidateVehicleType(string i_VehicleType)
        {
            if(i_VehicleType != "car" && i_VehicleType != "motorcycle" && i_VehicleType != "truck")
            {
                throw new ArgumentException("Invalid vehicle Type. You had to choose car, motorcycle or truck.");
            }
        }

        internal static void ValidatesVehicleExistInGarage(GarageManager i_Manager, string i_LicenseNum)
        {
            if(!i_Manager.DoesVehicleExistInGarage(i_LicenseNum))
            {
                throw new ArgumentException("Your vehicle is not in the garage. Please insert it first.");
            }
        }

        internal static void ValidateVehicleEngineType(string i_VehicleEngineType)
        {
            if (i_VehicleEngineType != "petrol" && i_VehicleEngineType != "electric")
            {
                throw new ArgumentException("Invalid vehicle engine type. You had to choose petrol or electric.");
            }
        }

        internal static void ValidateRemainingEnergy(float i_RemainingEnergy, VehicleManufacturer.eVehicleType i_VehicleType, Energy.eEnergyType i_EnergyType)
        {
            float maxEnergy = 0; 

            switch (i_VehicleType)
            {
                case VehicleManufacturer.eVehicleType.Car:
                    maxEnergy = Car.GetMaxEnergy(i_EnergyType);
                    break;
                case VehicleManufacturer.eVehicleType.Truck:
                    maxEnergy = Truck.GetMaxEnergy();
                    break;
                case VehicleManufacturer.eVehicleType.Motorcycle:
                    maxEnergy = Motorcycle.GetMaxEnergy(i_EnergyType);
                    break;
            }

            if (!(i_RemainingEnergy >= 0 && i_RemainingEnergy <= maxEnergy))
            {
                string message = string.Format("Input is out of range, valid range is : {0} - {1} liters", 0, maxEnergy);
                throw new ValueOutOfRangeException(0, maxEnergy, message);
            }
        }

        internal static void ValidateWheelAirPressure(VehicleManufacturer.eVehicleType i_VehicleType, float i_WheelsAir)
        {
            float maxPressure = 0;

            switch (i_VehicleType)
            {
                case VehicleManufacturer.eVehicleType.Car:
                    maxPressure = Car.GetMaxWheelPressure();
                    break;
                case VehicleManufacturer.eVehicleType.Truck:
                    maxPressure = Truck.GetMaxWheelPressure();
                    break;
                case VehicleManufacturer.eVehicleType.Motorcycle:
                    maxPressure = Motorcycle.GetMaxWheelPressure();
                    break;
            }
            if (!(i_WheelsAir >= 0 && i_WheelsAir <= maxPressure))
            {
                string message = string.Format("Input is out of range, valid range is : {0} - {1}", 0, maxPressure);
                throw new ValueOutOfRangeException(0, maxPressure, message);
            }
        }

        internal static void ValidateCarColor(string i_CarColor)
        {
            if (i_CarColor != "white" && i_CarColor != "red" && i_CarColor != "black" && i_CarColor != "yellow")
            {
                throw new ArgumentException("Invalid car color. You had to choose between White, Red, Black or Yellow.");
            }
        }

        internal static void ValidateDoorNum(string i_DoorNum)
        {
            if (i_DoorNum != "2" && i_DoorNum != "3" && i_DoorNum != "4" && i_DoorNum != "5")
            {
                throw new ArgumentException("Invalid doors number. You had to choose between 2, 3, 4 or 5.");
            }
        }

        internal static void ValidateLicenseType(string i_LicenseType)
        {
            if (i_LicenseType != "A1" && i_LicenseType != "A2" && i_LicenseType != "AA" && i_LicenseType != "B1")
            {
                throw new ArgumentException("Invalid license type. You had to choose between A1, A2, AA or B1.");
            }
        }

        internal static void ValidateIfInt(string i_UserInput, string i_Identifier, out int o_UserInput)
        {
            string exception = "";

            if (!int.TryParse(i_UserInput, out o_UserInput))
            {
                if (i_Identifier == "Engine capacity")
                {
                    exception = "Invalid engine capacity.";
                }

                string message = string.Format("{0}  Please enter a valid integer value.", exception);
                throw new FormatException(message);
            }
        }

        internal static void ValidateIfBool(string i_UserInput, out bool o_UserInput)
        {
            if(!bool.TryParse(i_UserInput, out o_UserInput))
            {
                throw new FormatException("Invalid input. Please enter 'true' or 'false'.");
            }
        }

        internal static void ValidateIfFloat(string i_UserInput, string i_Identifier , out float o_UserInput)
        {
            string exception = "";

            if (!float.TryParse(i_UserInput, out o_UserInput))
            {
                if(i_Identifier == "Cargo volume")
                {
                    exception = "Invalid cargo volume.";
                }
                else if(i_Identifier == "Petrol amount")
                {
                    exception = "Invalid petrol amount.";
                }
                else if(i_Identifier == "Charging time")
                {
                    exception = "Invalid charging time.";
                }
                else if(i_Identifier == "Air pressure")
                {
                    exception = "Invalid amount of air pressure.";
                }

                string message = string.Format("{0} Please enter a number (could be a number with decimal point as well).", exception);
                throw new FormatException(message);

            }
        }
    }
}
