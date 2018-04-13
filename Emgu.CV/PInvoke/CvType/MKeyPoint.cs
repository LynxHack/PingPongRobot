//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

namespace Emgu.CV.Structure
{
   /// <summary>
   /// OpenCV's KeyPoint class
   /// </summary>
#if !NETFX_CORE
   [Serializable]
#endif
   [StructLayout(LayoutKind.Sequential)]
   public struct MKeyPoint
   {
      /// <summary>
      /// The location of the keypoint
      /// </summary>
      public PointF Point;
      /// <summary>
      /// Size of the keypoint
      /// </summary>
      public float Size;
      /// <summary>
      /// Orientation of the keypoint
      /// </summary>
      public float Angle;
      /// <summary>
      /// Response of the keypoint
      /// </summary>
      public float Response;
      /// <summary>
      /// octave
      /// </summary>
      public int Octave;
      /// <summary>
      /// class id
      /// </summary>
      public int ClassId;
   }
}
