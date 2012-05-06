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

public class DescLevel : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DescLevel(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(DescLevel obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~DescLevel() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_DescLevel(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public int id {
    set {
      C4dApiPINVOKE.DescLevel_id_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.DescLevel_id_get(swigCPtr);
      return ret;
    } 
  }

  public int dtype {
    set {
      C4dApiPINVOKE.DescLevel_dtype_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.DescLevel_dtype_get(swigCPtr);
      return ret;
    } 
  }

  public int creator {
    set {
      C4dApiPINVOKE.DescLevel_creator_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.DescLevel_creator_get(swigCPtr);
      return ret;
    } 
  }

  public DescLevel(int t_id) : this(C4dApiPINVOKE.new_DescLevel__SWIG_0(t_id), true) {
  }

  public DescLevel(int t_id, int t_datatype, int t_creator) : this(C4dApiPINVOKE.new_DescLevel__SWIG_1(t_id, t_datatype, t_creator), true) {
  }

}

}