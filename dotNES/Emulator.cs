﻿using System;
using System.Collections.Generic;

namespace dotNES
{
    class Emulator
    {
        private static readonly Dictionary<int, Type> Mappers = new Dictionary<int, Type> {
            {0, typeof(NROM)},
            {2, typeof(UxROM)},
            {180, typeof(Mapper180)}
        };

        public Emulator(string path, NES001Controller controller)
        {
            Cartridge = new Cartridge(path);
            Mapper = (Memory)Activator.CreateInstance(Mappers[Cartridge.MapperNumber], this);
            CPU = new CPU(this);
            PPU = new PPU(this);
            Controller = controller;
        }

        public NES001Controller Controller;

        public readonly CPU CPU;

        public readonly PPU PPU;

        public readonly Memory Mapper;

        public readonly Cartridge Cartridge;
    }
}
