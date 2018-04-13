﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;
using Emgu.Util;

namespace Emgu.CV.Cvb
{
   /// <summary>
   /// CvBlob
   /// </summary>
   public class CvBlob
   {
      /// <summary>
      /// Blob Moments
      /// </summary>
      public struct Moments
      {
         /// <summary>
         /// Mement 00
         /// </summary>
         public double M00;
         /// <summary>
         /// Moment 10
         /// </summary>
         public double M10;
         /// <summary>
         /// Moment 01
         /// </summary>
         public double M01;
         /// <summary>
         /// Moment 11
         /// </summary>
         public double M11;
         /// <summary>
         /// Moment 20
         /// </summary>
         public double M20;
         /// <summary>
         ///  Moment 02
         /// </summary>
         public double M02;

         /// <summary>
         /// Central moment 11
         /// </summary>
         public double U11;
         /// <summary>
         /// Central moment 20
         /// </summary>
         public double U20;
         /// <summary>
         /// Central moment 02
         /// </summary>
         public double U02;

         /// <summary>
         /// Normalized central moment 11
         /// </summary>
         public double N11;
         /// <summary>
         /// Normalized central moment 20
         /// </summary>
         public double N20;
         /// <summary>
         /// Normalized central moment 02
         /// </summary>
         public double N02;

         /// <summary>
         /// Hu moment 1
         /// </summary>
         public double P1;
         /// <summary>
         /// Hu moment 2
         /// </summary>
         public double P2;
      }

      private IntPtr _ptr;

      internal CvBlob(IntPtr blob)
      {
         _ptr = blob;
      }

      /// <summary>
      /// Get the contour that defines the blob
      /// </summary>
      /// <param name="storage">The memory storage when the resulting contour will be allocated</param>
      /// <returns>The contour of the blob</returns>
      public Contour<Point> GetContour(MemStorage storage)
      {
         Contour<Point> contour = new Contour<Point>(storage);
         CvInvoke.cvbCvBlobGetContour(_ptr, contour);
         return contour;
      }

      /// <summary>
      /// Get the blob label
      /// </summary>
      public uint Label
      {
         get
         {
            return CvInvoke.cvbCvBlobGetLabel(_ptr);
         }
      }

      /// <summary>
      /// The minimum bounding box of the blob
      /// </summary>
      public Rectangle BoundingBox
      {
         get
         {
            Rectangle rect = new Rectangle();
            CvInvoke.cvbCvBlobGetRect(_ptr, ref rect);
            return rect;
         }
      }

      /// <summary>
      /// Get the Blob Moments
      /// </summary>
      public Moments BlobMoments
      {
         get
         {
            Moments m = new Moments();
            CvInvoke.cvbCvBlobGetMoment(_ptr, ref m);
            return m;
         }
      }

      /// <summary>
      /// The centroid of the blob
      /// </summary>
      public PointF Centroid
      {
         get
         {
            Moments m = BlobMoments;
            return new PointF((float)(m.M10 / m.M00), (float)(m.M01 / m.M00));
         }
      }

      /// <summary>
      /// The number of pixels in this blob
      /// </summary>
      public int Area
      {
         get
         {
            return (int)BlobMoments.M00;
         }
      }

      /// <summary>
      /// Pointer to the blob
      /// </summary>
      public IntPtr Ptr
      {
         get
         {
            return _ptr;
         }
      }

      /// <summary>
      /// Implicit operator for IntPtr
      /// </summary>
      /// <param name="obj">The CvBlob</param>
      /// <returns>The unmanaged pointer for this object</returns>
      public static implicit operator IntPtr(CvBlob obj)
      {
         return obj == null ? IntPtr.Zero : obj._ptr;
      }
   }
}

namespace Emgu.CV
{
   public static partial class CvInvoke
   {
      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static uint cvbCvBlobGetLabel(IntPtr blob);

      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void cvbCvBlobGetRect(IntPtr blob, ref Rectangle rect);

      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void cvbCvBlobGetMoment(IntPtr blob, ref Emgu.CV.Cvb.CvBlob.Moments moments);

      [DllImport(CvInvoke.EXTERN_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void cvbCvBlobGetContour(IntPtr blob, IntPtr contour);
   }
}