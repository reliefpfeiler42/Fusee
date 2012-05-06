/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 0.0.1
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace C4d {

using System;
using System.Runtime.InteropServices;

public class BaseSelectData : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BaseSelectData(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(BaseSelectData obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~BaseSelectData() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_BaseSelectData(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public int a {
    set {
      C4dApiPINVOKE.BaseSelectData_a_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.BaseSelectData_a_get(swigCPtr);
      return ret;
    } 
  }

  public int b {
    set {
      C4dApiPINVOKE.BaseSelectData_b_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.BaseSelectData_b_get(swigCPtr);
      return ret;
    } 
  }

  public BaseSelectData() : this(C4dApiPINVOKE.new_BaseSelectData(), true) {
  }

}

}