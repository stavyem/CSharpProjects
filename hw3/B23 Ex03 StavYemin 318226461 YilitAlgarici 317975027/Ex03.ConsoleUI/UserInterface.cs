using System;
using System.Collections.Generic;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private readonly GarageManager r_GarageManager;
        private readonly VehicleManufacturer r_VehicleManufacturer;

        public UserInterface()
        {
            r_GarageManager = new GarageManager();
            r_VehicleManufacturer = new VehicleManufacturer();
            startGarage();
        }

        private void startGarage()
        {
            string functionality =
@"Welcome To The Garage!
These are your options:
1. Insert vehicle to the garage.
2. List all vehicles license numbers in garage.
3. Change vehicle status.
4. Inflate air pressure in wheels.
5. Fill vehicle tank with petrol.
6. Charge vehicle battery.
7. Present full vehicle details.
8. Exit the garage.

please choose one of the options above:";

            string errorMessage = "";

            while (true)
            {
                Console.Clear();
                if (errorMessage != "")
                {
                    Console.WriteLine(string.Format("{0}\n", errorMessage));
                    errorMessage = "";
                }
                
                Console.WriteLine(functionality);
                int userInput = 0;
                while (true)
                {
                    try
                    {
                        userInput = getUserInput();
                        break;
                    }
                    catch (Exception exception)
                    {
                        string message = string.Format(
@"{0}
Please try again.",
exception.Message);
                        Console.WriteLine(message);
                    }
                }
                
                if (userInput == 8)
                {
                    Console.WriteLine("Bye!");
                    Thread.Sleep(400);
                    break;
                }
                
                try
                {
                    executeCommand(userInput);
                }
                catch (Exception exception)
                {
                    errorMessage = string.Format("{0}\nPlease try again.\n",exception.Message);
                }
            }
        }

        private int getUserInput()
        {
            while (true)
            {
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int input))
                {
                    if (input < 1 || input > 8)
                    {
                        throw new ValueOutOfRangeException(1,8, string.Format("Invalid selection. Valid range: {0}-{1}", 1, 8));
                    }
                    
                    return input;
                }
                else
                {
                    throw new FormatException("Input not valid. Please enter a number.");
                }
            }
        }

        private void executeCommand(int i_Input)
        {
            switch(i_Input)
            {
                case 1:
                    insertVehicleToGarage();
                    break;
                case 2:
                    listAllVehiclesLicenseNumbersInGarage();
                    break;
                case 3:
                    changeVehicleStatus();
                    break;
                case 4:
                    fillWheelsAirPressure();
                    break;
                case 5:
                    fillVehicleTankWithPetrol();
                    break;
                case 6:
                    chargeVehicleBattery();
                    break;
                case 7:
                    presentFullVehicleDetails();
                    break;
            }

            pressAnyKeyToContinue();
        }

        private void insertVehicleToGarage()
        {
            Console.WriteLine("Please enter a license number.");
            string licenseNum = Console.ReadLine();
            if(licenseNum == "")
            {
                throw new ArgumentException("License number invalid.");
            }
            
            while (true)
            {
                try
                {
                    if (!r_GarageManager.DoesVehicleExistInGarage(licenseNum))
                    {
                        r_VehicleManufacturer.VehicleProperties.Clear();
                        Vehicle vehicle = createVehicleFromUserInput(licenseNum);
                        r_GarageManager.AddVehicleToGarage(vehicle);
                        Console.WriteLine("\nVehicle inserted to garage successfully!\n");
                        break;
                    }
                    else
                    {
                        r_GarageManager.ChangeVehicleStatus(licenseNum, GarageManager.eVehicleStatus.InRepair);
                        Console.WriteLine("\nThis vehicle exists already in the garage, its status was changed to in repair.\n");
                        break;
                    }
                }
                catch (Exception exception)
                {
                    string message = string.Format("\n{0}\nYou will be asked everything again.", exception.Message);
                    Console.WriteLine(message);
                    r_VehicleManufacturer.VehicleProperties.Clear();
                }
            }
        }

        private Vehicle createVehicleFromUserInput(string i_LicenseNum)
        {
            r_VehicleManufacturer.VehicleProperties.Add("license number", i_LicenseNum);
            getGeneralVehicleDetails();
            switch(r_VehicleManufacturer.VehicleProperties["vehicle type"])
            {
                case VehicleManufacturer.eVehicleType.Car:
                    getCarDetails();
                    break;
                case VehicleManufacturer.eVehicleType.Motorcycle:
                    getMotorcycleDetails();
                    break;
                case VehicleManufacturer.eVehicleType.Truck:
                    getTruckDetails();
                    break;
            }

            return r_VehicleManufacturer.CreateVehicle();
        }

        private void getGeneralVehicleDetails()
        {
            Console.WriteLine("What vehicle are you interested to insert to the Garage? (Car, Motorcycle, Truck)");
            string vehicleType = Console.ReadLine();
            Validations.ValidateVehicleType(vehicleType.ToLower());
            insertVehicleType(vehicleType);
            Console.WriteLine("What Model is your vehicle?");
            string model = Console.ReadLine();
            r_VehicleManufacturer.VehicleProperties.Add("model", model);
            Console.WriteLine("what is the owner's name?");
            string ownerName = Console.ReadLine();
            r_VehicleManufacturer.VehicleProperties.Add("owner name", ownerName);
            Console.WriteLine("what is the owner's phone number?");
            string ownerPhone = Console.ReadLine();
            Validations.ValidatesDigitsOnly(ownerPhone);
            r_VehicleManufacturer.VehicleProperties.Add("owner phone", ownerPhone);
            r_VehicleManufacturer.VehicleProperties.Add("status", GarageManager.eVehicleStatus.InRepair);
        }

        private void insertVehicleType(string i_VehicleType)
        {
            switch (i_VehicleType.ToLower())
            {
                case "car":
                    r_VehicleManufacturer.VehicleProperties.Add("vehicle type", VehicleManufacturer.eVehicleType.Car);
                    break;
                case "motorcycle":
                    r_VehicleManufacturer.VehicleProperties.Add("vehicle type", VehicleManufacturer.eVehicleType.Motorcycle);
                    break;
                case "truck":
                    r_VehicleManufacturer.VehicleProperties.Add("vehicle type", VehicleManufacturer.eVehicleType.Truck);
                    break;
            }
        }

        private void getCarDetails()
        {
            getEngineDetails(VehicleManufacturer.eVehicleType.Car);
            getWheelDetails(VehicleManufacturer.eVehicleType.Car);
            getCarColor();
            getDoorNum();
        }

        private void getMotorcycleDetails()
        {
            getEngineDetails(VehicleManufacturer.eVehicleType.Motorcycle);
            getWheelDetails(VehicleManufacturer.eVehicleType.Motorcycle);
            getLicenseType();
            getEngineCapacity();
        }
        private void getTruckDetails()
        {
            getEngineDetails(VehicleManufacturer.eVehicleType.Truck);
            getWheelDetails(VehicleManufacturer.eVehicleType.Truck);
            doesTransportHazardousMaterials();
            getCargoVolume();
        }

        private void getEngineDetails(VehicleManufacturer.eVehicleType i_VehicleType)
        {
            string engineType = "petrol";

            if(i_VehicleType != VehicleManufacturer.eVehicleType.Truck)
            {
                Console.WriteLine("What kind of engine your vehicle has? (Petrol or Electric)");
                engineType = Console.ReadLine();
                Validations.ValidateVehicleEngineType(engineType.ToLower());
            }

            if(engineType == "petrol")
            {
                r_VehicleManufacturer.VehicleProperties.Add("engine type", Energy.eEnergyType.Petrol);
                switch(i_VehicleType)
                {
                    case VehicleManufacturer.eVehicleType.Car:
                        r_VehicleManufacturer.VehicleProperties.Add("petrol type", PetrolEnergy.ePetrolType.Octan95);
                        break;
                    case VehicleManufacturer.eVehicleType.Motorcycle:
                        r_VehicleManufacturer.VehicleProperties.Add("petrol type", PetrolEnergy.ePetrolType.Octan98);
                        break;
                    case VehicleManufacturer.eVehicleType.Truck:
                        r_VehicleManufacturer.VehicleProperties.Add("petrol type", PetrolEnergy.ePetrolType.Soler);
                        break;
                }
            }
            else
            {
                r_VehicleManufacturer.VehicleProperties.Add("engine type", Energy.eEnergyType.Electric);
            }

            getAmountOfEnergy(i_VehicleType);
        }

        private void getAmountOfEnergy(VehicleManufacturer.eVehicleType i_VehicleType)
        {
            string remainingEnergyStr;
            if ((Energy.eEnergyType)r_VehicleManufacturer.VehicleProperties["engine type"] == Energy.eEnergyType.Petrol)
            {
                Console.WriteLine("what is the vehicle's amount of petrol remaining in liters?");
                remainingEnergyStr = Console.ReadLine();
                Validations.ValidateIfFloat(remainingEnergyStr, "Petrol amount", out float remainingEnergy);
                Validations.ValidateRemainingEnergy(remainingEnergy, i_VehicleType, Energy.eEnergyType.Petrol);
                r_VehicleManufacturer.VehicleProperties.Add("remaining energy", remainingEnergy);
            }
            else
            {
                Console.WriteLine("what is the vehicle's battery time remaining in hours?");
                remainingEnergyStr = Console.ReadLine();
                Validations.ValidateIfFloat(remainingEnergyStr, "Charging time", out float remainingEnergy);
                Validations.ValidateRemainingEnergy(remainingEnergy, i_VehicleType, Energy.eEnergyType.Electric);
                r_VehicleManufacturer.VehicleProperties.Add("remaining energy", remainingEnergy);
            }
        }

        private void getWheelDetails(VehicleManufacturer.eVehicleType i_VehicleType)
        {
            Console.WriteLine("What is the wheel manufacturer?");
            string wheelManufacturer = Console.ReadLine();
            r_VehicleManufacturer.VehicleProperties.Add("wheel manufacturer", wheelManufacturer);
            Console.WriteLine("What is the current wheels' air pressure?");
            string wheelsAirStr = Console.ReadLine();
            Validations.ValidateIfFloat(wheelsAirStr, "Air pressure", out float wheelsAir);
            Validations.ValidateWheelAirPressure(i_VehicleType, wheelsAir);
            r_VehicleManufacturer.VehicleProperties.Add("wheels air", wheelsAir);
        }

        private void getCarColor()
        {
            Console.WriteLine("What is the car color? (White, Red, Black, Yellow)");
            string carColor = Console.ReadLine();
            Validations.ValidateCarColor(carColor.ToLower());
            r_VehicleManufacturer.VehicleProperties.Add("car color", convertToColor(carColor));
        }

        private static Car.eColor convertToColor(string i_Color)
        {
            Car.eColor color = Car.eColor.White;

            switch(i_Color.ToLower())
            {
                case "white":
                    break;
                case "black":
                    color = Car.eColor.Black;
                    break;
                case "red":
                    color = Car.eColor.Red;
                    break;
                case "yellow":
                    color = Car.eColor.Yellow;
                    break;
            }

            return color;
        }

        private void getDoorNum()
        {
            Console.WriteLine("How many doors your car has? (2, 3, 4 or 5)");
            string doorNum = Console.ReadLine();
            Validations.ValidateDoorNum(doorNum);
            r_VehicleManufacturer.VehicleProperties.Add("number of doors", convertToDoorNum(doorNum));
        }

        private Car.eNumOfDoors convertToDoorNum(string i_DoorNum)
        {
            Car.eNumOfDoors doorNum = Car.eNumOfDoors.Two;

            switch (i_DoorNum)
            {
                case "2":
                    break;
                case "3":
                    doorNum = Car.eNumOfDoors.Three;
                    break;
                case "4":
                    doorNum = Car.eNumOfDoors.Four;
                    break;
                case "5":
                    doorNum = Car.eNumOfDoors.Five;
                    break;
            }

            return doorNum;
        }

        private void getLicenseType()
        {
            Console.WriteLine("What is your license type? (A1, A2, AA or B1)");
            string licenseType = Console.ReadLine();
            Validations.ValidateLicenseType(licenseType);
            r_VehicleManufacturer.VehicleProperties.Add("license type", convertToLicenseType(licenseType));
        }

        private static Motorcycle.eLicenseType convertToLicenseType(string i_LicenseType)
        {
            Motorcycle.eLicenseType licenseType = Motorcycle.eLicenseType.A1;

            switch (i_LicenseType.ToLower())
            {
                case "A1":
                    licenseType = Motorcycle.eLicenseType.A1;
                    break;
                case "A2":
                    licenseType = Motorcycle.eLicenseType.A2;
                    break;
                case "AA":
                    licenseType = Motorcycle.eLicenseType.AA;
                    break;
                case "B1":
                    licenseType = Motorcycle.eLicenseType.B1;
                    break;
            }

            return licenseType;
        }

        private void getEngineCapacity()
        {
            Console.WriteLine("What is your motorcycle's engine capacity? (in whole numbers)");
            string engineCapacityStr = Console.ReadLine();
            Validations.ValidateIfInt(engineCapacityStr, "Engine capacity", out int engineCapacity);
            r_VehicleManufacturer.VehicleProperties.Add("engine capacity", engineCapacity);
        }

        private void doesTransportHazardousMaterials()
        {
            Console.WriteLine("Does your truck transport hazardous materials? (true or false)");
            string doesTransportStr = Console.ReadLine();
            Validations.ValidateIfBool(doesTransportStr, out bool doesTransport);
            r_VehicleManufacturer.VehicleProperties.Add("hazard materials", doesTransport);
        }

        private void getCargoVolume()
        {
            Console.WriteLine("What is your truck's cargo volume? (numbers with decimal point are allowed)");
            string cargoVolumeStr = Console.ReadLine();
            Validations.ValidateIfFloat(cargoVolumeStr, "Cargo volume", out float cargoVolume);
            r_VehicleManufacturer.VehicleProperties.Add("cargo volume", cargoVolume);
        }

        private void getValidLicenseNumber(out string o_LicenseNum)
        {
            Console.WriteLine("What is your license number?");
            o_LicenseNum = Console.ReadLine();
            Validations.ValidatesVehicleExistInGarage(r_GarageManager, o_LicenseNum);
        }

        private void listAllVehiclesLicenseNumbersInGarage()
        {
            List<string> vehiclesLicenseNums;
            Console.WriteLine(
@"If you want to get only a list of vehicles with a specific status
(in repair, repaired, paid) please mention it, or enter 'none'.");
            string filterAnswer = Console.ReadLine();
            GarageManager.eVehicleStatus vehicleStatusFilter = convertToStatus(filterAnswer, out bool isNone);
            if(!isNone)
            {
                vehiclesLicenseNums = r_GarageManager.GetAllVehiclesLicenses(vehicleStatusFilter);
            }
            else
            {
                vehiclesLicenseNums = r_GarageManager.GetAllVehiclesLicenses();
            }

            foreach (string licenseNum in vehiclesLicenseNums)
            {
                Console.WriteLine(licenseNum);
            }
        }

        private static GarageManager.eVehicleStatus convertToStatus(string i_FilterAnswer, out bool o_IsNone)
        {
            GarageManager.eVehicleStatus vehicleStatus = GarageManager.eVehicleStatus.InRepair;
            o_IsNone = false;

            switch (i_FilterAnswer.ToLower())
            {
                case "in repair":
                    break;
                case "repaired":
                    vehicleStatus = GarageManager.eVehicleStatus.Repaired;
                    break;
                case "paid":
                    vehicleStatus = GarageManager.eVehicleStatus.Paid;
                    break;
                case "none":
                    o_IsNone = true;
                    break;
                default:
                    throw new ArgumentException("Invalid status.");
            }

            return vehicleStatus;
        }

        private void changeVehicleStatus()
        {
            getValidLicenseNumber(out string licenseNum);
            Console.WriteLine("What status would you like to change your vehicle to? (in repair, repaired, paid)");
            string vehicleStatusFromUser = Console.ReadLine();
            r_GarageManager.ChangeVehicleStatus(licenseNum, convertToStatus(vehicleStatusFromUser, out bool isNone));
            Console.WriteLine(string.Format("\nYour vehicle's status was successfully changed to {0}!\n", vehicleStatusFromUser));
        }

        private void fillWheelsAirPressure()
        {
            getValidLicenseNumber(out string licenseNum);
            r_GarageManager.FillVehicleTiresToMax(licenseNum);
            Console.WriteLine("Your vehicle's tires were filled to their maximum.");
        }

        private void fillVehicleTankWithPetrol()
        {
            getValidLicenseNumber(out string licenseNum);
            Console.WriteLine("What type of fuel does your vehicle have? (Soler, Octan95, Octan96, Octan98)");
            string petrolType = Console.ReadLine();
            PetrolEnergy.ePetrolType convertedPetrolType = convertToPatrol(petrolType);
            Console.WriteLine("What is your desired amount to fill your vehicle's tank?");
            string amountToFillStr = Console.ReadLine();
            Validations.ValidateIfFloat(amountToFillStr, "Petrol amount", out float amountToFill);
            r_GarageManager.FillPetrol(licenseNum, amountToFill, convertedPetrolType);
            Console.WriteLine(string.Format("Vehicle was successfully filled with {0} liters of {1} petrol.\n", amountToFill, petrolType));
        }

        private static PetrolEnergy.ePetrolType convertToPatrol(string i_PetrolType)
        {
            PetrolEnergy.ePetrolType petrolType = PetrolEnergy.ePetrolType.Soler;
            
            switch (i_PetrolType.ToLower())
            {
                case "soler":
                    break;
                case "octan95":
                    petrolType = PetrolEnergy.ePetrolType.Octan95;
                    break;
                case "octan96":
                    petrolType = PetrolEnergy.ePetrolType.Octan96;
                    break;
                case "octan98":
                    petrolType = PetrolEnergy.ePetrolType.Octan98;
                    break;
                default:
                    throw new FormatException("Invalid petrol type.");
            }

            return petrolType;
        }

        private void chargeVehicleBattery()
        {
            getValidLicenseNumber(out string licenseNum);
            Console.WriteLine("What is the the amount of hours you want to charge your battery");
            string chargingTimeStr = Console.ReadLine();
            Validations.ValidateIfFloat(chargingTimeStr, "Charging time", out float chargingTime);
            r_GarageManager.ChargeBattery(licenseNum, chargingTime);
            Console.WriteLine(string.Format("Vehicle was successfully charged for {0} hours.\n", chargingTime));
        }

        private void presentFullVehicleDetails()
        {
            getValidLicenseNumber(out string licenseNum);
            Vehicle wantedVehicle = r_GarageManager.GetVehicleByLicenseNum(licenseNum);
            string vehicleFullDetails = wantedVehicle.ToString();
            string message = string.Format(
@"
Vehicle's Full Details:
{0}
", vehicleFullDetails);
            Console.WriteLine(message);
        }

        private static void pressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey(true);
        }
    }
}
