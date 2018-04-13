//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;
using Emgu.Util;

namespace Emgu.CV.VideoSurveillance
{
   /// <summary>
   /// A blob detector
   /// </summary>
   public class BlobDetector : UnmanagedObject
   {
      /// <summary>
      /// Create a blob detector of specific type
      /// </summary>
      /// <param name="type">The type of the detector</param>
      public BlobDetector(CvEnum.BLOB_DETECTOR_TYPE type)
      {
         switch (type)
         {
            case Emgu.CV.CvEnum.BLOB_DETECTOR_TYPE.Simple:
               _ptr = CvInvoke.CvCreateBlobDetectorSimple();
               break;
            case Emgu.CV.CvEnum.BLOB_DETECTOR_TYPE.CC:
               _ptr = CvInvoke.CvCreateBlobDetectorCC();
               break;
         }
      }

      /// <summary>
      /// Detect new blobs
      /// </summary>
      /// <param name="imageForeground">The foreground mask</param>
      /// <param name="newBlob">The new blob list</param>
      /// <param name="oldBlob">The old blob list, can be null if not needed</param>
      /// <returns>True if new blob is detected</returns>
      public bool DetectNewBlob(Image<Gray, Byte> imageForeground, BlobSeq newBlob, BlobSeq oldBlob)
      {
         return CvInvoke.CvBlobDetectorDetectNewBlob(_ptr, IntPtr.Zero, imageForeground.Ptr, newBlob.Ptr, oldBlob);
      }

      /// <summary>
      /// Release the detector
      /// </summary>
      protected override void DisposeObject()
      {
         CvInvoke.CvBlobDetectorRelease(ref _ptr);
      }
   }
}

namespace Emgu.CV
{
   public static partial class CvInvoke
   {
      /// <summary>
      /// Release the blob detector
      /// </summary>
      /// <param name="detector">the detector to be released</param>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void CvBlobDetectorRelease(ref IntPtr detector);

      /// <summary>
      /// Detect new blobs.
      /// </summary>
      /// <param name="detector">The blob detector</param>
      /// <param name="img">The image</param>
      /// <param name="imgFG">The foreground mask</param>
      /// <param name="newBlobList">The new blob list</param>
      /// <param name="oldBlobList">The old blob list</param>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      [return: MarshalAs(CvInvoke.BoolToIntMarshalType)]
      internal extern static bool CvBlobDetectorDetectNewBlob(IntPtr detector, IntPtr img, IntPtr imgFG, IntPtr newBlobList, IntPtr oldBlobList);

      /// <summary>
      /// Get a simple blob detector 
      /// </summary>
      /// <returns>Pointer to the blob detector</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvCreateBlobDetectorSimple();

      /// <summary>
      /// Get a CC blob detector 
      /// </summary>
      /// <returns>Pointer to the blob detector</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvCreateBlobDetectorCC();
   }
}