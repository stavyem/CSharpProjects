using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleManufacturer
    {
        private readonly Dictionary<string, object> r_VehicleProperties = new Dictionary<string, object>();

        public Dictionary<string, object> VehicleProperties
        {
            get
            {
                return r_VehicleProperties;
            }
        }

        public enum eVehicleType
        {
            Car,
            Truck,
            Motorcycle
        }

        public Vehicle CreateVehicle()
        {
            Vehicle vehicle = null;
            switch (r_VehicleProperties["vehicle type"])
            {
                case eVehicleType.Car:
                    if ((Energy.eEnergyType)r_VehicleProperties["engine type"] == Energy.eEnergyType.Electric)
                    {
                        r_VehicleProperties["energy"] = new ElectricEnergy((float)r_VehicleProperties["remaining energy"], Car.GetMaxEnergy(Energy.eEnergyType.Electric));
                    }
                    else
                    {
                        r_VehicleProperties["energy"] = new PetrolEnergy((float)r_VehicleProperties["remaining energy"],
                            Car.GetMaxEnergy(Energy.eEnergyType.Petrol), (PetrolEnergy.ePetrolType)r_VehicleProperties["petrol type"]);
                    }

                    r_VehicleProperties["wheels collection"] = createWheelsCollection(5, Car.GetMaxWheelPressure());
                    vehicle = new Car(r_VehicleProperties, (Car.eColor)r_VehicleProperties["car color"], (Car.eNumOfDoors)r_VehicleProperties["number of doors"]);
                    break;

                case eVehicleType.Motorcycle:
                    if ((Energy.eEnergyType)r_VehicleProperties["engine type"] == Energy.eEnergyType.Electric)
                    {
                        r_VehicleProperties["energy"] = new ElectricEnergy((float)r_VehicleProperties["remaining energy"],
                            Motorcycle.GetMaxEnergy(Energy.eEnergyType.Electric));
                    }
                    else
                    {
                        r_VehicleProperties["energy"] = new PetrolEnergy((float)r_VehicleProperties["remaining energy"],
                            Motorcycle.GetMaxEnergy(Energy.eEnergyType.Petrol), (PetrolEnergy.ePetrolType)r_VehicleProperties["petrol type"]);
                    }

                    r_VehicleProperties["wheels collection"] = createWheelsCollection(2, Motorcycle.GetMaxWheelPressure());
                    vehicle = new Motorcycle(r_VehicleProperties, (Motorcycle.eLicenseType)r_VehicleProperties["license type"], (int)r_VehicleProperties["engine capacity"]);
                    break;

                case eVehicleType.Truck:
                    r_VehicleProperties["energy"] = new PetrolEnergy((float)r_VehicleProperties["remaining energy"],
                        Truck.GetMaxEnergy(), (PetrolEnergy.ePetrolType)r_VehicleProperties["petrol type"]);
                    r_VehicleProperties["wheels collection"] = createWheelsCollection(14, Truck.GetMaxWheelPressure());
                    vehicle = new Truck(r_VehicleProperties, (bool)r_VehicleProperties["hazard materials"], (float)r_VehicleProperties["cargo volume"]);
                    break;
            }

            return vehicle;
        }

        private List<Wheel> createWheelsCollection(int i_AmountOfWheels, float i_MaxWheelPressure)
        {
            List<Wheel> wheels = new List<Wheel>();

            for (int i = 0; i < i_AmountOfWheels; i++)
            {
                wheels.Add(new Wheel((string)r_VehicleProperties["wheel manufacturer"], (float)r_VehicleProperties["wheels air"], i_MaxWheelPressure));
            }

            return wheels;
        }
    }
}
