﻿using System;
using System.Collections.Generic;
using SoLeap.Domain;

namespace SoLeap.Devices
{
    public class HandsFrame
    {
        public long Id { get; private set; }

        public DateTime TimeStamp { get; private set; }

        public IEnumerable<Hand> Hands { get; private set; }

        public HandsFrame()
        {
        }

        public HandsFrame(long id, DateTime timesStamp, IEnumerable<Hand> hands)
        {
            Id = id;
            TimeStamp = timesStamp;
            Hands = hands;
        }
    }
}