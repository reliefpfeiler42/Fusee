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

public class DocumentImported : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DocumentImported(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(DocumentImported obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~DocumentImported() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_DocumentImported(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public DocumentImported() : this(C4dApiPINVOKE.new_DocumentImported(), true) {
  }

  public BaseDocument doc {
    set {
      C4dApiPINVOKE.DocumentImported_doc_set(swigCPtr, BaseDocument.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.DocumentImported_doc_get(swigCPtr);
      BaseDocument ret = (cPtr == IntPtr.Zero) ? null : new BaseDocument(cPtr, false);
      return ret;
    } 
  }

  public int c4dversion {
    set {
      C4dApiPINVOKE.DocumentImported_c4dversion_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.DocumentImported_c4dversion_get(swigCPtr);
      return ret;
    } 
  }

  public int fileformat {
    set {
      C4dApiPINVOKE.DocumentImported_fileformat_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.DocumentImported_fileformat_get(swigCPtr);
      return ret;
    } 
  }

  public bool gui_allowed {
    set {
      C4dApiPINVOKE.DocumentImported_gui_allowed_set(swigCPtr, value);
    } 
    get {
      bool ret = C4dApiPINVOKE.DocumentImported_gui_allowed_get(swigCPtr);
      return ret;
    } 
  }

}

}