//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
#if NETFX_CORE
using Windows.UI;
#else
using System.Drawing;
#endif

namespace Emgu.CV.Reflection
{
   /// <summary>
   /// A collection of reflection function that can be applied to ColorType object
   /// </summary>
   public static class ReflectColorType
   {
#if !NETFX_CORE
      /// <summary>
      /// Get the display color for each channel
      /// </summary>
      /// <param name="color">The color</param>
      /// <returns>The display color for each channel</returns>
      public static Color[] GetDisplayColorOfChannels(IColor color)
      {
         List<Color> channelColor = new List<Color>();
         foreach (System.Reflection.PropertyInfo pInfo in color.GetType().GetProperties())
         {
            Object[] displayAtts = pInfo.GetCustomAttributes(typeof(DisplayColorAttribute), true);
            if (displayAtts.Length > 0)
               channelColor.Add(((DisplayColorAttribute)displayAtts[0]).DisplayColor);
         }
         if (channelColor.Count > 0) return channelColor.ToArray();

         //create default color
         Color[] res = new Color[color.Dimension];
         for (int i = 0; i < res.Length; i++)
            //res[i] = Color.FromArgb(255, 125, 125, 125);
            res[i] = Color.Gray;
         return res;
      }

      /// <summary>
      /// Get the names of the channels
      /// </summary>
      /// <param name="color">The color</param>
      /// <returns>The names of the channels</returns>
      public static String[] GetNamesOfChannels(IColor color)
      {
         List<String> channelNames = new List<string>();
         foreach (System.Reflection.PropertyInfo pInfo in color.GetType().GetProperties())
         {
            if (pInfo.GetCustomAttributes(typeof(DisplayColorAttribute), true).Length > 0)
               channelNames.Add(pInfo.Name);
         }
         if (channelNames.Count > 0) return channelNames.ToArray();

         //Create default channel names
         String[] res = new string[color.Dimension];
         for (int i = 0; i < res.Length; i++)
            res[i] = String.Format("Channel {0}", i);
         return res;
      }
#endif
   }
}
