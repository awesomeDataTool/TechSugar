using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <copyright file="SmartUniteTestSampleTest.ReturnSizeOfArray.g.cs">Copyright �  2014</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace VS2015News
{
    public partial class SmartUniteTestSampleTest
    {
[TestMethod]
[PexGeneratedBy(typeof(SmartUniteTestSampleTest))]
public void ReturnSizeOfArray947()
{
    int i;
    SmartUniteTestSample s0 = new SmartUniteTestSample();
    i = this.ReturnSizeOfArray(s0, (int[])null);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)s0);
}
[TestMethod]
[PexGeneratedBy(typeof(SmartUniteTestSampleTest))]
public void ReturnSizeOfArray369()
{
    int i;
    SmartUniteTestSample s0 = new SmartUniteTestSample();
    int[] ints = new int[1];
    i = this.ReturnSizeOfArray(s0, ints);
    Assert.AreEqual<int>(1, i);
    Assert.IsNotNull((object)s0);
}
[TestMethod]
[PexGeneratedBy(typeof(SmartUniteTestSampleTest))]
public void ReturnSizeOfArray309()
{
    int i;
    SmartUniteTestSample s0 = new SmartUniteTestSample();
    int[] ints = new int[0];
    i = this.ReturnSizeOfArray(s0, ints);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)s0);
}
    }
}