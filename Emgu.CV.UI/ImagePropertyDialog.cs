//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace Emgu.CV.UI
{
   /// <summary>
   /// A dialog to display the property of an image
   /// </summary>
   internal partial class ImagePropertyDialog : Form
   {
      /// <summary>
      /// Constructor
      /// </summary>
      public ImagePropertyDialog(ImageBox imageBox)
      {
         InitializeComponent();
         imagePropertyControl.ImageBox = imageBox;
      }

      /// <summary>
      /// Get the image property panel
      /// </summary>
      public ImageProperty ImagePropertyControl
      {
         get
         {
            return imagePropertyControl;
         }
      }
   }
}
