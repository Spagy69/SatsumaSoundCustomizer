using System;
using System.IO;
using System.Text;
using UnityEngine;

public static class WavUtility
{
    public static AudioClip ToAudioClip(string filePath, string name = "wav")
    {
        bool flag = !File.Exists(filePath);
        if (flag)
        {
            throw new FileNotFoundException("Файл не найден: " + filePath);
        }
        byte[] wav = File.ReadAllBytes(filePath);
        WavUtility.WAV wav2 = new WavUtility.WAV(wav);
        AudioClip audioClip = AudioClip.Create(name, wav2.SampleCount, wav2.ChannelCount, wav2.Frequency, false);
        audioClip.SetData(wav2.GetStereoSamples(), 0);
        return audioClip;
    }

    private class WAV
    {
        public float[] LeftChannel { get; private set; }

        public float[] RightChannel { get; private set; }

        public int ChannelCount { get; private set; }

        public int SampleCount { get; private set; }

        public int Frequency { get; private set; }

        public WAV(byte[] wav)
        {
            bool flag = wav.Length < 44;
            if (flag)
            {
                throw new Exception("Invalid WAV file format.");
            }
            string @string = Encoding.ASCII.GetString(wav, 0, 4);
            string string2 = Encoding.ASCII.GetString(wav, 8, 4);
            bool flag2 = @string != "RIFF" || string2 != "WAVE";
            if (flag2)
            {
                throw new Exception("Invalid WAV file format.");
            }
            this.ChannelCount = (int)BitConverter.ToInt16(wav, 22);
            this.Frequency = BitConverter.ToInt32(wav, 24);
            int i;
            int num;
            for (i = 12; i < wav.Length - 8; i += 8 + num)
            {
                string string3 = Encoding.ASCII.GetString(wav, i, 4);
                num = BitConverter.ToInt32(wav, i + 4);
                bool flag3 = string3 == "data";
                if (flag3)
                {
                    i += 8;
                    this.SampleCount = num / 2 / this.ChannelCount;
                    break;
                }
            }
            bool flag4 = i >= wav.Length;
            if (flag4)
            {
                throw new Exception("Data section not found in WAV file.");
            }
            this.LeftChannel = new float[this.SampleCount];
            bool flag5 = this.ChannelCount > 1;
            if (flag5)
            {
                this.RightChannel = new float[this.SampleCount];
            }
            int num2 = 0;
            while (i + 1 < wav.Length && num2 < this.SampleCount)
            {
                this.LeftChannel[num2] = WavUtility.WAV.BytesToFloat(wav[i], wav[i + 1]);
                i += 2;
                bool flag6 = this.ChannelCount > 1 && i + 1 < wav.Length;
                if (flag6)
                {
                    this.RightChannel[num2] = WavUtility.WAV.BytesToFloat(wav[i], wav[i + 1]);
                    i += 2;
                }
                num2++;
            }
        }

        public float[] GetStereoSamples()
        {
            bool flag = this.ChannelCount == 2;
            float[] result;
            if (flag)
            {
                float[] array = new float[this.SampleCount * 2];
                for (int i = 0; i < this.SampleCount; i++)
                {
                    array[i * 2] = this.LeftChannel[i];
                    array[i * 2 + 1] = this.RightChannel[i];
                }
                result = array;
            }
            else
            {
                result = this.LeftChannel;
            }
            return result;
        }

        private static float BytesToFloat(byte firstByte, byte secondByte)
        {
            short num = (short)((int)secondByte << 8 | (int)firstByte);
            return (float)num / 32768f;
        }
    }
}
