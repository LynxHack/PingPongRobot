//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Runtime.InteropServices;

namespace Emgu.CV
{
   /// <summary>
   /// Adaptive Skin Detector
   /// </summary>
   public class AdaptiveSkinDetector : UnmanagedObject
   {
      /// <summary>
      /// Morphing method
      /// </summary>
      public enum MorphingMethod
      {
         /// <summary>
         /// None
         /// </summary>
         NONE = 0,
         /// <summary>
         /// Erode
         /// </summary>
         ERODE = 1,
         /// <summary>
         /// Double Erode 
         /// </summary>
         ERODE_ERODE = 2,
         /// <summary>
         /// Erode dilate
         /// </summary>
         ERODE_DILATE = 3
      }

      /// <summary>
      /// Create an Adaptive Skin Detector
      /// </summary>
      /// <param name="samplingDivider">Use 1 for default</param>
      /// <param name="morphingMethod">The morphine method for the skin detector</param>
      public AdaptiveSkinDetector(int samplingDivider, MorphingMethod morphingMethod)
      {
         _ptr = CvInvoke.CvAdaptiveSkinDetectorCreate(samplingDivider, morphingMethod);
      }

      /// <summary>
      /// Process the image to produce a hue mask
      /// </summary>
      /// <param name="image">The input image</param>
      /// <param name="hueMask">The resulting mask</param>
      public void Process(Image<Bgr, Byte> image, Image<Gray, Byte> hueMask)
      {
         CvInvoke.CvAdaptiveSkinDetectorProcess(_ptr, image.Ptr, hueMask.Ptr);
      }

      /// <summary>
      /// Release the unmanaged memory associated with this detector
      /// </summary>
      protected override void DisposeObject()
      {
         CvInvoke.CvAdaptiveSkinDetectorRelease(_ptr);
      }
   }

   public static partial class CvInvoke
   {
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvAdaptiveSkinDetectorCreate(int samplingDivider, AdaptiveSkinDetector.MorphingMethod morphingMethod);

      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void CvAdaptiveSkinDetectorRelease(IntPtr detector);

      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void CvAdaptiveSkinDetectorProcess(IntPtr detector, IntPtr inputBGRImage, IntPtr outputHueMask);
   }
}
