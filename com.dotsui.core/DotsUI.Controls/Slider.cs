﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DotsUI.Controls
{
    struct Slider : IComponentData
    {
        public enum Direction
        {
            /// <summary>
            /// From the left to the right
            /// </summary>
            LeftToRight,

            /// <summary>
            /// From the right to the left
            /// </summary>
            RightToLeft,

            /// <summary>
            /// From the bottom to the top.
            /// </summary>
            BottomToTop,

            /// <summary>
            /// From the top to the bottom.
            /// </summary>
            TopToBottom,
        }

        public Direction SliderDirection;
        public float MinValue;
        public float MaxValue;
        public float Value;
        public bool WholeNumbers;
        public Entity FillRect;
        public Entity HandleRect;

        public float NormalizedValue
        {
            get
            {
                // TODO: Replace mathf with new math library
                if (Mathf.Approximately(MinValue, MaxValue))
                    return 0;
                return math.saturate((Value - MinValue) / (MaxValue - MinValue));
            }
        }
    }

    static class SliderExtensions
    {
        public static int GetAxis(this Slider slider)
        {
            return slider.SliderDirection == Slider.Direction.LeftToRight ||
                   slider.SliderDirection == Slider.Direction.RightToLeft
                ? 0
                : 1;
        }
    }
}