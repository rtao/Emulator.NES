﻿using System;

namespace dotNES
{
    partial class CPU
    {
        public void Initialize()
        {
            A = 0;
            X = 0;
            Y = 0;
            SP = 0xFD;
            P = 0x24;

            PC = 0xC000;
        }

        public void Reset()
        {
            SP -= 3;
            F.BreakSource = true;
        }

        public void ExecuteSingleInstruction()
        {
            currentInstruction = NextByte();

            ResetInstructionAddressingMode();

            // if (cycle >= 4900)
            Console.WriteLine($"{(PC - 1).ToString("X4")}  {currentInstruction.ToString("X2")}	\t\t\tA:{A.ToString("X2")} X:{X.ToString("X2")} Y:{Y.ToString("X2")} P:{P.ToString("X2")} SP:{SP.ToString("X2")}");

            Opcode op = opcodes[currentInstruction];
            if (op == null)
                throw new ArgumentException(currentInstruction.ToString("X2"));
            op();
        }
    }
}