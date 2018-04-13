//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------
using System;
using System.Drawing;

#if ANDROID
using Bitmap =  Android.Graphics.Bitmap;
#elif IOS
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
#endif

namespace Emgu.CV
{
   /// <summary>
   /// IImage interface
   /// </summary>
   public interface IImage : IDisposable, ICloneable
   {
#if NETFX_CORE
#elif IOS 
      /// <summary>
      /// Conver this image to UIImage
      /// </summary>
      /// <returns>
      /// The UIImage
      /// </returns>
      UIImage ToUIImage();
#else
      /// <summary>
      /// Convert this image into Bitmap, when avaialbe, data is shared with this image.
      /// </summary>
      /// <returns>The Bitmap, when avaialbe, data is shared with this image</returns>
      Bitmap Bitmap
      {
         get;
      }
#endif

      /// <summary>
      /// The size of this image
      /// </summary>
      Size Size
      {
         get;
      }

      /// <summary>
      /// Returns the min / max location and values for the image
      /// </summary>
      /// <returns>
      /// Returns the min / max location and values for the image
      /// </returns>
      void MinMax(out double[] minValues, out double[] maxValues, out Point[] minLocations, out Point[] maxLocations);

      ///<summary> 
      /// Split current IImage into an array of gray scale images where each element 
      /// in the array represent a single color channel of the original image
      ///</summary>
      ///<returns> 
      /// An array of gray scale images where each element 
      /// in the array represent a single color channel of the original image 
      ///</returns>
      IImage[] Split();

      /// <summary>
      /// Get the pointer to the unmanaged memory
      /// </summary>
      IntPtr Ptr
      {
         get;
      }

      /// <summary>
      /// Save the image to the specific <paramref name="fileName"/> 
      /// </summary>
      /// <param name="fileName">The file name of the image</param>
      void Save(String fileName);

      /// <summary>
      /// Get the number of channels for this image
      /// </summary>
      int NumberOfChannels
      {
         get;
      }
   }
}
