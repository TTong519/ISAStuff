using System.Reflection.Emit;

namespace Disassembler
{
    internal class Disassembler
    {
        internal enum Layout
        {
            registers3,
            registers2,
            register,
            register1value1
        };
        static Dictionary<byte, string> OpCodes = new Dictionary<byte, string>()
        {
            [0x1] = "ADD",
            [0x2] = "SUB",
            [0x3] = "MUL",
            [0x4] = "DIV",
            [0x5] = "MOD",
            [0x6] = "OR",
            [0x7] = "AND",
            [0x8] = "NOT",
            [0x9] = "XOR",
            [0xA] = "SHL",
            [0xB] = "SHR",
            [0xC] = "SETBIT",
            [0xD] = "CLRBIT",
            [0xE] = "FLIPBIT",
            [0xF] = "EV",
            [0x10] = "SET",
            [0x11] = "COPY",
            [0x12] = "JMP",
            [0x13] = "JMPZ",
        };
        static Dictionary<string, Layout> Layouts = new Dictionary<string, Layout>()
        {
            ["ADD"] = Layout.registers3,
            ["SUB"] = Layout.registers3,
            ["MUL"] = Layout.registers3,
            ["DIV"] = Layout.registers3,
            ["MOD"] = Layout.registers3,
            ["OR"] = Layout.registers3,
            ["AND"] = Layout.registers3,
            ["NOT"] = Layout.register,
            ["XOR"] = Layout.registers3,
            ["SHL"] = Layout.register1value1,
            ["SHR"] = Layout.register1value1,
            ["SETBIT"] = Layout.register1value1,
            ["CLRBIT"] = Layout.register1value1,
            ["FLIPBIT"] = Layout.register1value1,
            ["EV"] = Layout.registers3,
            ["SET"] = Layout.register1value1,
            ["COPY"] = Layout.registers2,
            ["JMP"] = Layout.register,
            ["JMPZ"] = Layout.register1value1,
        };

        static Dictionary<byte, string> Registers = new Dictionary<byte, string>()
        {
            [0x00] = "R0",
            [0x01] = "R1",
            [0x02] = "R2",
            [0x03] = "R3",
            [0x04] = "R4",
            [0x05] = "R5",
            [0x06] = "R6",
            [0x07] = "R7",
            [0x08] = "R8",
            [0x09] = "R9",
            [0x0A] = "R10",
            [0x0B] = "R11",
            [0x0C] = "R12",
            [0x0D] = "R13",
            [0x0E] = "R14",
            [0x0F] = "R15",
            [0x10] = "R16",
            [0x11] = "R17",
            [0x12] = "R18",
            [0x13] = "R19",
            [0x14] = "R20",
            [0x15] = "R21",
            [0x16] = "R22",
            [0x17] = "R23",
            [0x18] = "R24",
            [0x19] = "R25",
            [0x1A] = "R26",
            [0x1B] = "R27",
            [0x1C] = "R28",
            [0x1D] = "R29",
            [0x1E] = "R30",
            [0x1F] = "R31",
            [0x20] = "R32",
            [0x21] = "R33",
            [0x22] = "R34",
            [0x23] = "R35",
            [0x24] = "R36",
            [0x25] = "R37",
            [0x26] = "R38",
            [0x27] = "R39",
            [0x28] = "R40",
            [0x29] = "R41",
            [0x2A] = "R42",
            [0x2B] = "R43",
            [0x2C] = "R44",
            [0x2D] = "R45",
            [0x2E] = "R46",
            [0x2F] = "R47",
            [0xFF] = "PAD",
        };
        static void Main(string[] args)
        {
            byte[] code = File.ReadAllBytes(@"..\..\..\Input\Counter.bin");
            List<string> assemblyLines = new List<string>();
            for (int i = 0; i < code.Length/4; i++)
            {
                OpCodes.TryGetValue(code[4 * i], out string opCode);
                assemblyLines.Add(opCode + " ");
                Layouts.TryGetValue(opCode, out Layout layout);
                switch (layout)
                {
                    case Layout.registers3:
                        assemblyLines[i] += Registers[code[4 * i + 1]] + " " +
                                            Registers[code[4 * i + 2]] + " " +
                                            Registers[code[4 * i + 3]];
                        break;
                    case Layout.registers2:
                        assemblyLines[i] += Registers[code[4 * i + 1]] + " " +
                                            Registers[code[4 * i + 2]] + " " + Registers[0xFF];
                        break;
                    case Layout.register:
                        assemblyLines[i] += Registers[code[4 * i + 1]] + " " + Registers[0xFF] + " " + Registers[0xFF];
                        break;
                    case Layout.register1value1:
                        assemblyLines[i] += Registers[code[4 * i + 1]] + " " +
                                            code[4 * i + 2] + " " + Registers[0xFF];
                        break;
                }
            }
            File.WriteAllLines(@"..\..\..\Output\Counter.asm", assemblyLines);
        }
    }
}
