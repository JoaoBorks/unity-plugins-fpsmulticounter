/**
 * Originally created by Jasper Flick [catlikecoding.com]
 * Modified and updated by Joao Borks [joao.borks@gmail.com]
 */

using UnityEngine;
using System.Text;

namespace com.JoaoBorks.Plugins
{
    public class FPSCounter : MonoBehaviour
    {
        /// <summary>
        /// Constant for defining the fps value buffer size. Can be adjusted for different results
        /// </summary>
        const int BufferSize = 15;

        public int AverageFPS { get; private set; }
        public int HighestFPS { get; private set; }
        public int LowestFPS { get; private set; }

        int[] buffer;
        int bufferIndex;

        void Awake()
        {
            InitializeBuffer();
        }

        void Update()
        {
            UpdateBuffer();
            CalculateFPS();
        }
        
        void InitializeBuffer()
        {
            buffer = new int[BufferSize];
            bufferIndex = 0;
        }

        /// <summary>
        /// Stores the current fps value on the buffer
        /// </summary>
        void UpdateBuffer()
        {
            buffer[bufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
            if (bufferIndex >= BufferSize)
                bufferIndex = 0;
        }

        /// <summary>
        /// Calculates the highest, average, and lowest fps based on the values on the buffer
        /// </summary>
        void CalculateFPS()
        {
            int sum = 0,
                highest = 0,
                lowest = int.MaxValue,
                fps,
                zeros = 0; // Necessary if the buffer is not yet filled with values
            for (int i = 0; i < BufferSize; i++)
            {
                fps = buffer[i];
                if (fps != 0)
                {
                    sum += fps;
                    if (fps > highest)
                        highest = fps;
                    if (fps < lowest)
                        lowest = fps;
                }
                else
                    zeros++;
            }
            int filledValues = zeros == BufferSize ? 1 : BufferSize - zeros;
            AverageFPS = sum / filledValues;
            HighestFPS = highest;
            LowestFPS = lowest;
        }
    }
}