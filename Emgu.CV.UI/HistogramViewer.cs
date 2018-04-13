//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Emgu.CV.UI
{
   /// <summary>
   /// A view for histogram
   /// </summary>
   public partial class HistogramViewer : Form
   {
      /// <summary>
      /// A histogram viewer
      /// </summary>
      public HistogramViewer()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Display the histograms of the specific image
      /// </summary>
      /// <param name="image">The image to retrieve hostigram from</param>
      public static void Show(IImage image)
      {
         Show(image, 256);
      }

      /// <summary>
      /// Display the histograms of the specific image
      /// </summary>
      /// <param name="image">The image to retrieve hostigram from</param>
      /// <param name="numberOfBins">The numebr of bins in the histogram</param>
      public static void Show(IImage image, int numberOfBins)
      {
         HistogramViewer viewer = new HistogramViewer();
         viewer.HistogramCtrl.GenerateHistograms(image, numberOfBins);
         viewer.HistogramCtrl.Refresh();
         viewer.Show();
      }

      /// <summary>
      /// Display the specific histogram
      /// </summary>
      /// <param name="hist">The 1 dimension histogram to be displayed</param>
      /// <param name="title">The name of the histogram</param>
      public static void Show(DenseHistogram hist, string title)
      {
         HistogramViewer viewer = new HistogramViewer();
         if (hist.Dimension == 1)
            viewer.HistogramCtrl.AddHistogram(title, Color.Black, hist);
         
         viewer.HistogramCtrl.Refresh();
         viewer.Show();
      }

      /// <summary>
      /// Get the histogram control of this viewer
      /// </summary>
      public HistogramBox HistogramCtrl
      {
         get
         {
            return histogramCtrl1;
         }
      }
   }
}
