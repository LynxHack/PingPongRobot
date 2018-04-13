//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;

namespace Emgu.CV.ML
{
   /// <summary>
   /// A Normal Bayes Classifier
   /// </summary>
   public class NormalBayesClassifier : StatModel
   {
      /// <summary>
      /// Create a normal Bayes classifier
      /// </summary>
      public NormalBayesClassifier()
      {
         _ptr = MlInvoke.CvNormalBayesClassifierDefaultCreate();
      }

      /*
      /// <summary>
      /// Create a normal bayes classifier using the specific training data
      /// </summary>
      /// <param name="trainData">The training data. A 32-bit floating-point, single-channel matrix, one vector per row</param>
      /// <param name="responses">A floating-point matrix of the corresponding output vectors, one vector per row. </param>
      /// <param name="varIdx">Can be null if not needed. When specified, identifies variables (features) of interest. It is a Matrix&gt;int&lt; of nx1</param>
      /// <param name="sampleIdx">Can be null if not needed. When specified, identifies samples of interest. It is a Matrix&gt;int&lt; of nx1</param>
      public NormalBayesClassifier(Matrix<float> trainData, Matrix<int> responses, Matrix<Byte> varIdx, Matrix<Byte> sampleIdx)
      {
         _ptr = MlInvoke.CvNormalBayesClassifierCreate(
            trainData.Ptr, 
            responses.Ptr, 
            varIdx == null ? IntPtr.Zero : varIdx.Ptr, 
            sampleIdx == null ? IntPtr.Zero : sampleIdx.Ptr);
      }*/

      /// <summary>
      /// Release the memory associated with this classifier
      /// </summary>
      protected override void DisposeObject()
      {
         MlInvoke.CvNormalBayesClassifierRelease(ref _ptr);
      }

      /// <summary>
      /// Train the classifier using the specific data
      /// </summary>
      /// <param name="trainData">The training data. A 32-bit floating-point, single-channel matrix, one vector per row</param>
      /// <param name="responses">A floating-point matrix of the corresponding output vectors, one vector per row. </param>
      /// <param name="varIdx">Can be null if not needed. When specified, identifies variables (features) of interest. It is a Matrix&gt;int&lt; of nx1</param>
      /// <param name="sampleIdx">Can be null if not needed. When specified, identifies samples of interest. It is a Matrix&gt;int&lt; of nx1</param>
      /// <param name="update">If true, the training data is used to update the classifier; Otherwise, the data in the classifier are cleared before training is performed</param>
      /// <returns>The number of done iterations</returns>
      public bool Train(Matrix<float> trainData, Matrix<int> responses, Matrix<Byte> varIdx, Matrix<Byte> sampleIdx, bool update)
      {
         return MlInvoke.CvNormalBayesClassifierTrain(
            _ptr, 
            trainData.Ptr, 
            responses.Ptr, 
            varIdx == null ? IntPtr.Zero : varIdx.Ptr, 
            sampleIdx == null ? IntPtr.Zero : sampleIdx.Ptr, 
            update);
      }

      /// <summary>
      /// Given the NormalBayesClassifier, predit the probability of the <paramref name="samples"/>
      /// </summary>
      /// <param name="samples">The input samples</param>
      /// <param name="results">The prediction results, should have the same # of rows as the <paramref name="samples"/></param>
      /// <returns>In case of classification the method returns the class label, in case of regression - the output function value</returns>
      public float Predict(Matrix<float> samples, Matrix<int> results)
      {
         return MlInvoke.CvNormalBayesClassifierPredict(
            _ptr, 
            samples.Ptr, 
            results == null? IntPtr.Zero: results.Ptr);
      }

   }
}
