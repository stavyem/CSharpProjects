﻿using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;
        private readonly string r_Message;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_Message)
            : base(i_Message)
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
            r_Message = i_Message;
        }
    }
}
