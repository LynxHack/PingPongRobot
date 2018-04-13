//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;

namespace Emgu.CV.VideoSurveillance
{
   /// <summary>
   /// A Blob Tracker
   /// </summary>
   public class BlobTracker : BlobSeqBase
   {
      /// <summary>
      /// Create a blob trakcer of the specific type
      /// </summary>
      /// <param name="type">The type of the blob tracker</param>
      public BlobTracker(CvEnum.BLOBTRACKER_TYPE type)
      {
         switch (type)
         {
            case Emgu.CV.CvEnum.BLOBTRACKER_TYPE.CC:
               _ptr = CvInvoke.CvCreateBlobTrackerCC();
               break;
            case Emgu.CV.CvEnum.BLOBTRACKER_TYPE.CCMSPF:
               _ptr = CvInvoke.CvCreateBlobTrackerCCMSPF();
               break;
            case Emgu.CV.CvEnum.BLOBTRACKER_TYPE.MS:
               _ptr = CvInvoke.CvCreateBlobTrackerMS();
               break;
            case Emgu.CV.CvEnum.BLOBTRACKER_TYPE.MSFG:
               _ptr = CvInvoke.CvCreateBlobTrackerMSFG();
               break;
            case Emgu.CV.CvEnum.BLOBTRACKER_TYPE.MSFGS:
               _ptr = CvInvoke.CvCreateBlobTrackerMSFGS();
               break;
            case Emgu.CV.CvEnum.BLOBTRACKER_TYPE.MSPF:
               _ptr = CvInvoke.CvCreateBlobTrackerMSPF();
               break;
         }
      }

      /// <summary>
      /// Add new blob to track it and assign to this blob personal ID
      /// </summary>
      /// <param name="blob">Structure with blob parameters (ID is ignored)</param>
      /// <param name="currentImage">current image</param>
      /// <param name="currentForegroundMask">Current foreground mask</param>
      /// <returns>Newly added blob</returns>
      public MCvBlob Add(MCvBlob blob, IImage currentImage, Image<Gray, Byte> currentForegroundMask)
      {
         IntPtr bobPtr = CvInvoke.CvBlobTrackerAddBlob(
            _ptr,
            ref blob,
            currentImage == null ? IntPtr.Zero : currentImage.Ptr,
            currentForegroundMask);
         return (MCvBlob)Marshal.PtrToStructure(bobPtr, typeof(MCvBlob));
      }

      /// <summary>
      /// Delete blob by its index
      /// </summary>
      /// <param name="blobIndex">The index of the blob</param>
      public void RemoveAt(int blobIndex)
      {
         CvInvoke.CvBlobTrackerDelBlob(_ptr, blobIndex);
      }

      #region BolbSeqBase Members
      /// <summary>
      /// Return the blob given the specific index
      /// </summary>
      /// <param name="i">The index of the blob</param>
      /// <returns>The blob in the specific index</returns>
      public override MCvBlob this[int i]
      {
         get
         {
            return (MCvBlob)Marshal.PtrToStructure(CvInvoke.CvBlobTrackerGetBlob(_ptr, i), typeof(MCvBlob));
         }
      }

      /// <summary>
      /// Get the blob with the specific id
      /// </summary>
      /// <param name="blobID">The id of the blob</param>
      /// <returns>The blob of the specific id, if it doesn't exist, MCvBlob.Empty is returned</returns>
      public override MCvBlob GetBlobByID(int blobID)
      {
         IntPtr blobPtr = CvInvoke.CvBlobTrackerGetBlobByID(_ptr, blobID);
         if (blobPtr == IntPtr.Zero) return MCvBlob.Empty;
         return (MCvBlob)Marshal.PtrToStructure(blobPtr, typeof(MCvBlob));
      }

      /// <summary>
      /// Get the number of blobs in this tracker
      /// </summary>
      public override int Count
      {
         get
         {
            return CvInvoke.CvBlobTrackerGetBlobNum(_ptr);
         }
      }

      /// <summary>
      /// Release the blob trakcer
      /// </summary>
      protected override void DisposeObject()
      {
         CvInvoke.CvBlobTrackerRealease(ref _ptr);
      }
      #endregion

   }
}

namespace Emgu.CV
{
   public static partial class CvInvoke
   {
      /// <summary>
      /// Simple blob tracker based on connected component tracking
      /// </summary>
      /// <returns>Pointer to the blob tracker</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvCreateBlobTrackerCC();

      /// <summary>
      /// Connected component tracking and mean-shift particle filter collion-resolver
      /// </summary>
      /// <returns>Pointer to the blob tracker</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvCreateBlobTrackerCCMSPF();

      /// <summary>
      /// Blob tracker that integrates meanshift and connected components
      /// </summary>
      /// <returns>Pointer to the blob tracker</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvCreateBlobTrackerMSFG();

      /// <summary>
      /// Blob tracker that integrates meanshift and connected components:
      /// </summary>
      /// <returns>Pointer to the blob tracker</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvCreateBlobTrackerMSFGS();

      /// <summary>
      /// Meanshift without connected-components
      /// </summary>
      /// <returns>Pointer to the blob tracker</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvCreateBlobTrackerMS();

      /// <summary>
      /// Particle filtering via Bhattacharya coefficient, which
      /// is roughly the dot-product of two probability densities.
      /// </summary>
      /// <remarks>See: Real-Time Tracking of Non-Rigid Objects using Mean Shift Comanicius, Ramesh, Meer, 2000, 8p</remarks>
      /// <returns>Pointer to the blob tracker</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvCreateBlobTrackerMSPF();

      /// <summary>
      /// Release the blob tracker
      /// </summary>
      /// <param name="tracker">The tracker to be released</param>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void CvBlobTrackerRealease(ref IntPtr tracker);

      /// <summary>
      /// Return number of currently tracked blobs
      /// </summary>
      /// <param name="tracker">The tracker</param>
      /// <returns>Number of currently tracked blobs</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static int CvBlobTrackerGetBlobNum(IntPtr tracker);

      /// <summary>
      /// Return pointer to specified by index blob
      /// </summary>
      /// <param name="tracker">The tracker</param>
      /// <param name="blobIndex">The index of the blob</param>
      /// <returns>Pointer to the blob with the specific index</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvBlobTrackerGetBlob(IntPtr tracker, int blobIndex);

      /// <summary>
      /// Return pointer to specified by index blob
      /// </summary>
      /// <param name="tracker">The tracker</param>
      /// <param name="blobId">The id of the blob</param>
      /// <returns>Pointer to the blob with specific id</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvBlobTrackerGetBlobByID(IntPtr tracker, int blobId);

      /// <summary>
      /// Delete blob by its index
      /// </summary>
      /// <param name="tracker">The tracker</param>
      /// <param name="blobIndex">The index of the blob</param>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void CvBlobTrackerDelBlob(IntPtr tracker, int blobIndex);

      /// <summary>
      /// Add new blob to track it and assign to this blob personal ID
      /// </summary>
      /// <param name="tracker">The tracker</param>
      /// <param name="blob">pointer to structure with blob parameters (ID is ignored)</param>
      /// <param name="currentImage">current image</param>
      /// <param name="currentForegroundMask">current foreground mask</param>
      /// <returns>Pointer to new added blob</returns>
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr CvBlobTrackerAddBlob(IntPtr tracker, ref MCvBlob blob, IntPtr currentImage, IntPtr currentForegroundMask);
   }
}