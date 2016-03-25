using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;
using BibliotecaT2;
using System.Text;

namespace Tarea2
{
    public class LlaveAmarilla:ILlave
    {
        public static byte[] ToByteArray(BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return bytes;
        }

        public int[] convertAListInt(char[] stBitesChar, int largo)
        {   
            int[] inBites = new int[largo];

            for (int i = 0; i < largo; i++)
            {
                if (stBitesChar[i] == '0')
                {

                    inBites[i] = 0;
                }
                else
                {
                    inBites[i] = 1;
                }
            }
            return inBites;

        }

        public static String convertToStringOfBits(byte b)
        {
            StringBuilder str = new StringBuilder(8);
            int[] bl = new int[8];

            for (int i = 0; i < bl.Length; i++)
            {
                bl[bl.Length - 1 - i] = ((b & (1 << i)) != 0) ? 1 : 0;
            }

            foreach (int num in bl) str.Append(num);

            return str.ToString();
        }

        public BitArray convertAbiTaRRay(int[] tByteInt)
        {
            BitArray uf = new BitArray(tByteInt);
            for (int i = 0; i < 8; i++)
            {
                if (tByteInt[i] == 0)
                {
                    uf[i] = false;
                }
                else
                {
                    uf[i] = true;
                }
            }
            return uf;
        }

        public string cortarString(int[] IntBites, int a)
        {
            string toByte = "";
            for (int i = 0; i < 8; i++)
            {
                toByte += IntBites[a + i];
            }
            return toByte;
        }


        public string Decriptar(string aDecrip)
        {
            
            byte[] bytes = File.ReadAllBytes(aDecrip);
            string StBites = "";

            for (int i = 0; i < bytes.Length; i++)
            {
                StBites+=convertToStringOfBits(bytes[i]);
            }
            char[] stBitesChar = StBites.ToCharArray();
            int[] IntBites = convertAListInt(stBitesChar, bytes.Length*8);
            BinaryReader br = new BinaryReader(File.Open(aDecrip, FileMode.Open));
            
            byte nn = br.ReadByte();
            int n = nn;

            byte letraletra = br.ReadByte();
            char letra =  Convert.ToChar(letraletra);

            string Decriptado = letra+"";
            int a = 16 + n;
            for (int j = 0; j < bytes.Length+16+n&& a+7 < IntBites.Length; j++)
            {
                
                char[] tByte = cortarString(IntBites, a).ToCharArray();
                int[] tByteInt = convertAListInt(tByte, 8);
                byte letra22 = ToByteArray(convertAbiTaRRay(tByteInt))[0];
                char letra2 = Convert.ToChar(letra22);
                Decriptado += letra2;
                a += 8 + n;

            }


            return Decriptado;
        }
    }
}
