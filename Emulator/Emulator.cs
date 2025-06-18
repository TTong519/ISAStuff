namespace Emulator
{
    internal class Emulator
    {
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
            [0x11] = "JMP",
            [0x12] = "JMPZ",
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

        }
    }
}
