//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using Emgu.CV;

#if NETFX_CORE
using Windows.UI;
#else
using System.Drawing;
#endif

namespace Emgu.CV.Structure
{
   ///<summary> 
   ///Defines a Bgr565 (Blue Green Red) color
   ///</summary>
   [ColorInfo(ConversionCodename = "BGR565")]
   public struct Bgr565 : IColor, IEquatable<Bgr565>
   {
      /// <summary>
      /// The MCvScalar representation of the color intensity
      /// </summary>
      private MCvScalar _scalar;

      ///<summary> Create a Bgr565 color using the specific values</summary>
      ///<param name="blue"> The blue value for this color </param>
      ///<param name="green"> The green value for this color </param>
      ///<param name="red"> The red value for this color </param>
      public Bgr565(double red, double green, double blue)
      {
         //_scalar = new MCvScalar(red, green, blue);
         throw new NotImplementedException("Not implemented");

         //TODO: implement this
      }

      /// <summary>
      /// Create a Bgr565 color using the System.Drawing.Color
      /// </summary>
      /// <param name="winColor">System.Drawing.Color</param>
      public Bgr565(Color winColor)
         : this(winColor.R, winColor.G, winColor.B)
      {
      }
      
      ///<summary> Get or set the intensity of the red color channel </summary>
      [DisplayColor(0, 0, 255)]
      public double Red { get { return _scalar.v0; } set { _scalar.v0 = value; } }

      ///<summary> Get or set the intensity of the green color channel </summary>
      [DisplayColor(0, 255, 0)]
      public double Green { get { return _scalar.v1; } set { _scalar.v1 = value; } }

      ///<summary> Get or set the intensity of the blue color channel </summary>
      [DisplayColor(255, 0, 0)]
      public double Blue { get { return _scalar.v2; } set { _scalar.v2 = value; } }
      
      #region IEquatable<Rgb> Members
      /// <summary>
      /// Return true if the two color equals
      /// </summary>
      /// <param name="other">The other color to compare with</param>
      /// <returns>true if the two color equals</returns>
      public bool Equals(Bgr565 other)
      {
         return MCvScalar.Equals(other.MCvScalar);
      }

      #endregion

      #region IColor Members
      /// <summary>
      /// Get the dimension of this color
      /// </summary>
      public int Dimension
      {
         get { return 2; }
      }

      /// <summary>
      /// Get or Set the equivalent MCvScalar value
      /// </summary>
      public MCvScalar MCvScalar
      {
         get
         {
            return _scalar;
         }
         set
         {
            _scalar = value;
         }
      }
      #endregion

      /// <summary>
      /// Represent this color as a String
      /// </summary>
      /// <returns>The string representation of this color</returns>
      public override string ToString()
      {
         return String.Format("[{0},{1},{2}]", Red, Green, Blue);
      }
   }
}
