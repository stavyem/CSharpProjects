using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private readonly string r_LicenseNum;
        private readonly List<Wheel> r_WheelCollection;
        private readonly Energy r_Energy;
        private GarageManager.eVehicleStatus m_Status;
        public string LicenseNum
        {
            get
            {
                return r_LicenseNum;
            }
        }

        public GarageManager.eVehicleStatus Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }
        
        public Energy Energy
        {
            get
            {
                return r_Energy;
            }
        }

        internal Vehicle(Dictionary<string, object> i_VehicleDetails)
        {
            r_Model = (string)i_VehicleDetails["model"];
            m_OwnerName = (string)i_VehicleDetails["owner name"];
            m_OwnerPhone = (string)i_VehicleDetails["owner phone"];
            r_LicenseNum = (string)i_VehicleDetails["license number"];
            r_WheelCollection = (List<Wheel>)i_VehicleDetails["wheels collection"];
            r_Energy = (Energy)i_VehicleDetails["energy"];
            m_Status = (GarageManager.eVehicleStatus)i_VehicleDetails["status"];

        }

        internal void FillTiresToMax()
        {
            foreach (Wheel wheel in r_WheelCollection)
            {
                wheel.FillAir(wheel.MaximumAirPressure - wheel.CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            return String.Format(
@"License number: {0}
Model: {1}
Owner name: {2}
Owner phone: {3}
Vehicle's status: {4}
Energy source: {5}
Amount of wheels: {6}
{7}
", r_LicenseNum, r_Model, m_OwnerName, m_OwnerPhone, m_Status, r_Energy, r_WheelCollection.Count, r_WheelCollection[0]);
        }
    }
}