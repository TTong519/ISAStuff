using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Assembler
{
    internal class Assembler
    {
        const char COMMENT_PREFIX = '#';
        static Dictionary<string, byte> OpCodes = new Dictionary<string, byte>()
        {
            ["ADD"] = 0x1,
            ["SUB"] = 0x2,
            ["MUL"] = 0x3,
            ["DIV"] = 0x4,
            ["MOD"] = 0x5,
            ["OR"] = 0x6,
            ["AND"] = 0x7,
            ["NOT"] = 0x8,
            ["XOR"] = 0x9,
            ["SHL"] = 0xA,
            ["SHR"] = 0xB,
            ["SETBIT"] = 0xC,
            ["CLRBIT"] = 0xD,
            ["FLIPBIT"] = 0xE,
            ["EV"] = 0xF,
            ["SET"] = 0x10,
            ["JMP"] = 0x11,
            ["JMPZ"] = 0x12,
        };
        static Dictionary<string, byte> Registers = new Dictionary<string, byte>()
        {
            ["R0"] = 0x00,
            ["R1"] = 0x01,
            ["R2"] = 0x02,
            ["R3"] = 0x03,
            ["R4"] = 0x04,
            ["R5"] = 0x05,
            ["R6"] = 0x06,
            ["R7"] = 0x07,
            ["R8"] = 0x08,
            ["R9"] = 0x09,
            ["R10"] = 0x0A,
            ["R11"] = 0x0B,
            ["R12"] = 0x0C,
            ["R13"] = 0x0D,
            ["R14"] = 0x0E,
            ["R15"] = 0x0F,
            ["R16"] = 0x10,
            ["R17"] = 0x11,
            ["R18"] = 0x12,
            ["R19"] = 0x13,
            ["R20"] = 0x14,
            ["R21"] = 0x15,
            ["R22"] = 0x16,
            ["R23"] = 0x17,
            ["R24"] = 0x18,
            ["R25"] = 0x19,
            ["R26"] = 0x1A,
            ["R27"] = 0x1B,
            ["R28"] = 0x1C,
            ["R29"] = 0x1D,
            ["R30"] = 0x1E,
            ["R31"] = 0x1F,
            ["R32"] = 0x20,
            ["R33"] = 0x21,
            ["R34"] = 0x22,
            ["R35"] = 0x23,
            ["R36"] = 0x24,
            ["R37"] = 0x25,
            ["R38"] = 0x26,
            ["R39"] = 0x27,
            ["R40"] = 0x28,
            ["R41"] = 0x29,
            ["R42"] = 0x2A,
            ["R43"] = 0x2B,
            ["R44"] = 0x2C,
            ["R45"] = 0x2D,
            ["R46"] = 0x2E,
            ["R47"] = 0x2F,
            ["PAD"] = 0xFF,
        };
        
        static void Main(string[] args)
        {
            string[] assemblyLines = File.ReadAllLines(@"Input\Counter.asm");
            List<byte> machineCode = new List<byte>();
            foreach (string line in assemblyLines)
            {
                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (word == COMMENT_PREFIX.ToString()) break;
                    bool isOpCode = OpCodes.TryGetValue(word, out byte opcode);
                    if(isOpCode)
                    {
                        Console.Write("0x" + opcode.ToString("X2") + " ");
                        machineCode.Add(opcode);
                        continue;
                    }
                    else if (Registers.TryGetValue(word, out byte reg))
                    {
                        Console.Write("0x" + reg.ToString("X2") + " ");
                        machineCode.Add(reg);
                        continue;
                    }
                    Console.Write(word + " ");
                    machineCode.Add(byte.Parse(word));
                }
                Console.WriteLine();
            }
            File.WriteAllBytes(@"..\..\..\Output\Counter.bin", machineCode.ToArray());
        }
    }
}