﻿using CoreSpectrum.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSpectrum.Hardware
{
    public class Spectrum48k : MachineBase
    {
        private static readonly MachineTimmings Timmings48k = new MachineTimmings 
        { 
            CpuClock = 3500000,
            ScansPerFrame = 312,
            TStatesPerScan = 224
        };

        public Spectrum48k(byte[][] RomSet, IVideoRenderer Renderer) : base(RomSet, Renderer) { }

        protected override MachineHardware GetHardware(byte[][] RomSet, IVideoRenderer Renderer)
        {
            var ula = new ULA48k(Timmings48k.CpuClock, 44100, Renderer);
            var memory = new Memory48k(RomSet);

            MachineHardware hardware = new MachineHardware
            { 
                ULA = ula, 
                Memory = memory, 
                Timmings = Timmings48k 
            };

            return hardware;
        }
    }
}
