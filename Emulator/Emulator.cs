namespace Emulator
{
    internal class Emulator
    {
        internal enum Layout
        {
            registers3,
            registers2,
            register,
            register1value1,
            value
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
            ["JMP"] = Layout.value,
            ["JMPZ"] = Layout.register1value1,
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
        public static void ADD(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            int result = memory[reg2] + memory[reg3];
            memory[reg1] = result;
        }
        public static void SUB(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            int result = memory[reg2] - memory[reg3];
            memory[reg1] = result;
        }
        public static void MUL(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            int result = memory[reg2] * memory[reg3];
            memory[reg1] = result;
        }
        public static void DIV(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            if (memory[reg3] == 0) throw new DivideByZeroException("Division by zero is not allowed.");
            int result = memory[reg2] / memory[reg3];
            memory[reg1] = result;
        }
        public static void MOD(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            if (memory[reg3] == 0) throw new DivideByZeroException("Division by zero is not allowed.");
            int result = memory[reg2] % memory[reg3];
            memory[reg1] = result;
        }
        public static void OR(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            memory[reg1] = (memory[reg2] | memory[reg3]);
        }
        public static void AND(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            memory[reg1] = (memory[reg2] & memory[reg3]);
        }
        public static void NOT(int[] memory, byte reg1, byte reg2)
        {
            memory[reg1] = ~memory[reg2];
        }
        public static void XOR(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            memory[reg1] = (memory[reg2] ^ memory[reg3]);
        }
        public static void SHL(int[] memory, byte reg1, byte reg2, byte value)
        {
            int result = memory[reg2] << value;
            memory[reg1] = result;
        }
        public static void SHR(int[] memory, byte reg1, byte reg2, byte value)
        {
            int result = memory[reg2] >> value;
            memory[reg1] = result;
        }
        public static void SETBIT(int[] memory, byte reg1, byte value)
        {
            memory[reg1] |= (1 << value);
        }
        public static void CLRBIT(int[] memory, byte reg1, byte value)
        {
            memory[reg1] &= ~(1 << value);
        }
        public static void FLIPBIT(int[] memory, byte reg1, byte value)
        {
            memory[reg1] ^= (1 << value);
        }
        public static void EV(int[] memory, byte reg1, byte reg2, byte reg3)
        {
            if(memory[reg2] > memory[reg3])
            {
                memory[reg1] = 1;
            }
            else if(memory[reg2] < memory[reg3])
            {
                memory[reg1] = -1;
            }
            else
            {
                memory[reg1] = 0;
            }
        }
        public static void SET(int[] memory, byte reg1, byte value)
        {
            memory[reg1] = value;
        }
        public static void COPY(int[] memory, byte reg1, byte reg2)
        {
            memory[reg1] = memory[reg2];
        }
        public static void JMP(int[] memory, ref int programCounter, byte value)
        {
            programCounter = value;
        }
        public static void JMPZ(int[] memory, ref int programCounter, byte reg1, byte value)
        {
            if (memory[reg1] == 0)
            {
                programCounter = value;
            }
        }
        //static Dictionary<byte, string> Registers = new Dictionary<byte, string>()
        //{
        //    [0x00] = "R0",
        //    [0x01] = "R1",
        //    [0x02] = "R2",
        //    [0x03] = "R3",
        //    [0x04] = "R4",
        //    [0x05] = "R5",
        //    [0x06] = "R6",
        //    [0x07] = "R7",
        //    [0x08] = "R8",
        //    [0x09] = "R9",
        //    [0x0A] = "R10",
        //    [0x0B] = "R11",
        //    [0x0C] = "R12",
        //    [0x0D] = "R13",
        //    [0x0E] = "R14",
        //    [0x0F] = "R15",
        //    [0x10] = "R16",
        //    [0x11] = "R17",
        //    [0x12] = "R18",
        //    [0x13] = "R19",
        //    [0x14] = "R20",
        //    [0x15] = "R21",
        //    [0x16] = "R22",
        //    [0x17] = "R23",
        //    [0x18] = "R24",
        //    [0x19] = "R25",
        //    [0x1A] = "R26",
        //    [0x1B] = "R27",
        //    [0x1C] = "R28",
        //    [0x1D] = "R29",
        //    [0x1E] = "R30",
        //    [0x1F] = "R31",
        //    [0x20] = "R32",
        //    [0x21] = "R33",
        //    [0x22] = "R34",
        //    [0x23] = "R35",
        //    [0x24] = "R36",
        //    [0x25] = "R37",
        //    [0x26] = "R38",
        //    [0x27] = "R39",
        //    [0x28] = "R40",
        //    [0x29] = "R41",
        //    [0x2A] = "R42",
        //    [0x2B] = "R43",
        //    [0x2C] = "R44",
        //    [0x2D] = "R45",
        //    [0x2E] = "R46",
        //    [0x2F] = "R47",
        //    [0xFF] = "PAD",
        //};
        const byte INPUT_REGISTRER = 0x2F;
        const byte INPUT_FLAG = 0x2E;
        const byte OUTPUT_REGISTRER = 0x2D;
        const byte OUTPUT_FLAG = 0x2C;
        const byte RANDOM_REGISTRER = 0x2B;
        const byte RANDOM_FLAG = 0x2A;
        static void Main(string[] args)
        {
            byte[] code = File.ReadAllBytes(@"..\..\..\Input\Count.bin");
            int[] memory = new int[48];
            int programCounter = 0;
            for(programCounter = 0; programCounter < code.Length/4; programCounter++)
            {
                string opcode = OpCodes[code[programCounter * 4]];
                switch (opcode)
                {
                    case "ADD":
                        ADD(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "SUB":
                        SUB(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "MUL":
                        MUL(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "DIV":
                        DIV(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "MOD":
                        MOD(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "OR":
                        OR(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "AND":
                        AND(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "NOT":
                        NOT(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2]);
                        break;
                    case "XOR":
                        XOR(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "SHL":
                        SHL(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "SHR":
                        SHR(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "SETBIT":
                        SETBIT(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2]);
                        break;
                    case "CLRBIT":
                        CLRBIT(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2]);
                        break;
                    case "FLIPBIT":
                        FLIPBIT(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2]);
                        break;
                    case "EV":
                        EV(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2], code[programCounter * 4 + 3]);
                        break;
                    case "SET":
                        SET(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2]);
                        break;
                    case "COPY":
                        COPY(memory, code[programCounter * 4 + 1], code[programCounter * 4 + 2]);
                        break;
                    case "JMP":
                        JMP(memory, ref programCounter, code[programCounter * 4 + 1]);
                        break;
                    case "JMPZ":
                        JMPZ(memory, ref programCounter, code[programCounter * 4 + 1], code[programCounter * 4 + 2]);
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown opcode: {opcode} at position {programCounter}");
                }
                if(memory[INPUT_FLAG] == 1)
                {
                    memory[INPUT_REGISTRER] = Console.Read();
                    memory[INPUT_FLAG] = 0;
                }
                if(memory[OUTPUT_FLAG] == 1)
                {
                    Console.Write(memory[OUTPUT_REGISTRER]);
                    memory[OUTPUT_FLAG] = 0;
                }
                if(memory[RANDOM_FLAG] == 1)
                {
                    Random random = new Random();
                    memory[RANDOM_REGISTRER] = random.Next();
                    memory[RANDOM_FLAG] = 0;
                }
            }
        }
    }
}
