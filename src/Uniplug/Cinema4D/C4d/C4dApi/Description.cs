/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace C4d {

public class Description : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Description(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Description obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static Description Alloc() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_Alloc();
    Description ret = (cPtr == global::System.IntPtr.Zero) ? null : new Description(cPtr, false);
    return ret;
  }

  public static void Free(SWIGTYPE_p_p_Description description) {
    C4dApiPINVOKE.Description_Free(SWIGTYPE_p_p_Description.getCPtr(description));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool LoadDescription(SWIGTYPE_p_BCResourceObj bc, bool copy) {
    bool ret = C4dApiPINVOKE.Description_LoadDescription__SWIG_0(swigCPtr, SWIGTYPE_p_BCResourceObj.getCPtr(bc), copy);
    return ret;
  }

  public bool LoadDescription(int id) {
    bool ret = C4dApiPINVOKE.Description_LoadDescription__SWIG_1(swigCPtr, id);
    return ret;
  }

  public bool LoadDescription(string /* constString&_cstype */ id) {
    bool ret = C4dApiPINVOKE.Description_LoadDescription__SWIG_2(swigCPtr, id);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool SortGroups() {
    bool ret = C4dApiPINVOKE.Description_SortGroups(swigCPtr);
    return ret;
  }

  public SWIGTYPE_p_BCResourceObj GetDescription() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_GetDescription(swigCPtr);
    SWIGTYPE_p_BCResourceObj ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_BCResourceObj(cPtr, false);
    return ret;
  }

  public BaseContainer GetParameter(DescID id, BaseContainer temp, AtomArray ar) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_GetParameter(swigCPtr, DescID.getCPtr(id), BaseContainer.getCPtr(temp), AtomArray.getCPtr(ar));
    BaseContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseContainer(cPtr, false);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public BaseContainer GetParameterI(DescID id, AtomArray ar) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_GetParameterI(swigCPtr, DescID.getCPtr(id), AtomArray.getCPtr(ar));
    BaseContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseContainer(cPtr, false);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool SetParameter(DescID id, BaseContainer param, DescID groupid) {
    bool ret = C4dApiPINVOKE.Description_SetParameter(swigCPtr, DescID.getCPtr(id), BaseContainer.getCPtr(param), DescID.getCPtr(groupid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_void BrowseInit() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_BrowseInit(swigCPtr);
    SWIGTYPE_p_void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
    return ret;
  }

  public bool GetNext(SWIGTYPE_p_void handle, SWIGTYPE_p_p_BaseContainer bc, DescID id, DescID groupid) {
    bool ret = C4dApiPINVOKE.Description_GetNext__SWIG_0(swigCPtr, SWIGTYPE_p_void.getCPtr(handle), SWIGTYPE_p_p_BaseContainer.getCPtr(bc), DescID.getCPtr(id), DescID.getCPtr(groupid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void BrowseFree(SWIGTYPE_p_p_void handle) {
    C4dApiPINVOKE.Description_BrowseFree(swigCPtr, SWIGTYPE_p_p_void.getCPtr(handle));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public SWIGTYPE_p_DescEntry GetFirst(AtomArray op) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_GetFirst(swigCPtr, AtomArray.getCPtr(op));
    SWIGTYPE_p_DescEntry ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_DescEntry(cPtr, false);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_DescEntry GetNext(SWIGTYPE_p_DescEntry de) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_GetNext__SWIG_1(swigCPtr, SWIGTYPE_p_DescEntry.getCPtr(de));
    SWIGTYPE_p_DescEntry ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_DescEntry(cPtr, false);
    return ret;
  }

  public SWIGTYPE_p_DescEntry GetDown(SWIGTYPE_p_DescEntry de) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_GetDown(swigCPtr, SWIGTYPE_p_DescEntry.getCPtr(de));
    SWIGTYPE_p_DescEntry ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_DescEntry(cPtr, false);
    return ret;
  }

  public void GetDescEntry(SWIGTYPE_p_DescEntry de, SWIGTYPE_p_p_BaseContainer bc, DescID descid) {
    C4dApiPINVOKE.Description_GetDescEntry(swigCPtr, SWIGTYPE_p_DescEntry.getCPtr(de), SWIGTYPE_p_p_BaseContainer.getCPtr(bc), DescID.getCPtr(descid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public SWIGTYPE_p_SubDialog CreateDialogI() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_CreateDialogI(swigCPtr);
    SWIGTYPE_p_SubDialog ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_SubDialog(cPtr, false);
    return ret;
  }

  public void FreeDialog(SWIGTYPE_p_SubDialog dlg) {
    C4dApiPINVOKE.Description_FreeDialog(swigCPtr, SWIGTYPE_p_SubDialog.getCPtr(dlg));
  }

  public bool CreatePopupMenu(BaseContainer menu) {
    bool ret = C4dApiPINVOKE.Description_CreatePopupMenu(swigCPtr, BaseContainer.getCPtr(menu));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool GetPopupId(int id, DescID descid) {
    bool ret = C4dApiPINVOKE.Description_GetPopupId(swigCPtr, id, DescID.getCPtr(descid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool CheckDescID(DescID searchid, AtomArray ops, DescID completeid) {
    bool ret = C4dApiPINVOKE.Description_CheckDescID(swigCPtr, DescID.getCPtr(searchid), AtomArray.getCPtr(ops), DescID.getCPtr(completeid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool GetSubDescriptionWithData(DescID did, AtomArray op, SWIGTYPE_p_RESOURCEDATATYPEPLUGIN resdatatypeplugin, BaseContainer bc, DescID singledescid) {
    bool ret = C4dApiPINVOKE.Description_GetSubDescriptionWithData(swigCPtr, DescID.getCPtr(did), AtomArray.getCPtr(op), SWIGTYPE_p_RESOURCEDATATYPEPLUGIN.getCPtr(resdatatypeplugin), BaseContainer.getCPtr(bc), DescID.getCPtr(singledescid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public DescID GetSingleDescID() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Description_GetSingleDescID(swigCPtr);
    DescID ret = (cPtr == global::System.IntPtr.Zero) ? null : new DescID(cPtr, false);
    return ret;
  }

  public void SetSingleDescriptionMode(DescID descid) {
    C4dApiPINVOKE.Description_SetSingleDescriptionMode(swigCPtr, DescID.getCPtr(descid));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

}

}