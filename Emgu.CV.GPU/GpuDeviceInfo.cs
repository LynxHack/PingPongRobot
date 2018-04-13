﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Emgu.Util;

namespace Emgu.CV.GPU
{
   /// <summary>
   /// The Gpu device information
   /// </summary>
   public class GpuDeviceInfo : UnmanagedObject
   {
      private int _deviceID;

      /// <summary>
      /// Query the information of the gpu device that is currently in use.
      /// </summary>
      public GpuDeviceInfo()
         : this(GpuInvoke.GetDevice())
      {
      }

      /// <summary>
      /// Query the information of the gpu device with the specific id.
      /// </summary>
      /// <param name="deviceId">The device id</param>
      public GpuDeviceInfo(int deviceId)
      {
         _ptr = GpuInvoke.gpuDeviceInfoCreate(ref deviceId);
         _deviceID = deviceId;
      }

      /// <summary>
      /// The id of the device
      /// </summary>
      public int ID
      {
         get { return _deviceID; }
      }

      /// <summary>
      /// The name of the device
      /// </summary>
      public String Name
      {
         get
         {
            StringBuilder buffer = new StringBuilder(1024);
            GpuInvoke.gpuDeviceInfoDeviceName(_ptr, buffer, 1024);
            return buffer.ToString();
         }
      }

      /// <summary>
      /// The compute capability
      /// </summary>
      public Version CudaComputeCapability
      {
         get
         {
            int major = 0, minor = 0;
            GpuInvoke.gpuDeviceInfoComputeCapability(_ptr, ref major, ref minor);
            return new Version(major, minor);
         }
      }

      /// <summary>
      /// The number of single multi processors
      /// </summary>
      public int MultiProcessorCount
      {
         get
         {
            return GpuInvoke.gpuDeviceInfoMultiProcessorCount(_ptr);
         }
      }

      /// <summary>
      /// Get the amount of free memory at the moment
      /// </summary>
      public ulong FreeMemory
      {
         get
         {
            UIntPtr f = new UIntPtr();
            GpuInvoke.gpuDeviceInfoFreeMemInfo(_ptr, ref f);
            return f.ToUInt64();
         }
      }

      /// <summary>
      /// Get the amount of total memory
      /// </summary>
      public ulong TotalMemory
      {
         get
         {
            UIntPtr t = new UIntPtr();
            GpuInvoke.gpuDeviceInfoTotalMemInfo(_ptr, ref t);
            return t.ToUInt64();
         }
      }

      /// <summary>
      /// Indicates if the decive has the specific feature
      /// </summary>
      public bool Supports(GpuFeature feature)
      {
         return GpuInvoke.gpuDeviceInfoSupports(_ptr, feature);
      }

      /// <summary>
      /// Checks whether the GPU module can be run on the given device
      /// </summary>
      public bool IsCompatible
      {
         get
         {
            return GpuInvoke.gpuDeviceInfoIsCompatible(_ptr);
         }
      }

      /// <summary>
      /// GPU feature
      /// </summary>
      public enum GpuFeature
      {
         /// <summary>
         /// Cuda compute 1.0
         /// </summary>
         Compute10 = 10,
         /// <summary>
         /// Cuda compute 1.1
         /// </summary>
         Compute11 = 11,
         /// <summary>
         /// Cuda compute 1.2
         /// </summary>
         Compute12 = 12,
         /// <summary>
         /// Cuda compute 1.3
         /// </summary>
         Compute13 = 13,
         /// <summary>
         /// Cuda compute 2.0
         /// </summary>
         Compute20 = 20,
         /// <summary>
         /// Cuda compute 2.1
         /// </summary>
         Compute21 = 21,

         /// <summary>
         /// Global Atomic
         /// </summary>
         GlobalAtomics = Compute11,
         /// <summary>
         /// Shared Atomic
         /// </summary>
         SharedAtomics = Compute12,
         /// <summary>
         /// Native double
         /// </summary>
         NativeDouble = Compute13,
      }

      /// <summary>
      /// Release the unmanaged resource related to the GpuDevice
      /// </summary>
      protected override void DisposeObject()
      {
         GpuInvoke.gpuDeviceInfoRelease(ref _ptr);
      }
   }

   public static partial class GpuInvoke
   {
      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr gpuDeviceInfoCreate(ref int deviceId);

      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void gpuDeviceInfoRelease(ref IntPtr di);

      /// <summary>
      /// Get the compute capability of the device
      /// </summary>
      /// <param name="device">The device</param>
      /// <param name="major">The major version of the compute capability</param>
      /// <param name="minor">The minor version of the compute capability</param>
      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void gpuDeviceInfoComputeCapability(IntPtr device, ref int major, ref int minor);

      /// <summary>
      /// Get the number of multiprocessors on device
      /// </summary>
      /// <param name="device">The device</param>
      /// <returns>The number of multiprocessors on device</returns>
      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern int gpuDeviceInfoMultiProcessorCount(IntPtr device);

      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void gpuDeviceInfoFreeMemInfo(IntPtr device, ref UIntPtr free);

      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void gpuDeviceInfoTotalMemInfo(IntPtr device, ref UIntPtr total);

      /// <summary>
      /// Get the device name
      /// </summary>
      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void gpuDeviceInfoDeviceName(
         IntPtr device,
         [MarshalAs(CvInvoke.StringMarshalType)]
         StringBuilder buffer,
         int maxSizeInBytes);

      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      [return: MarshalAs(CvInvoke.BoolMarshalType)]
      internal static extern bool gpuDeviceInfoSupports(IntPtr device, GpuDeviceInfo.GpuFeature feature);

      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      [return: MarshalAs(CvInvoke.BoolMarshalType)]
      internal static extern bool gpuDeviceInfoIsCompatible(IntPtr device);
   }
}
