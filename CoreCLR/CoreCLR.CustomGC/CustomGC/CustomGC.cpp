// CustomGC.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "inc\CustomGC.h"
#include "inc\CustomGCHeap.h"
#include "inc\CustomGCHandleManager.h"
#include "inc\common.h"
#include "inc\threads.h"
#include "inc\appdomain.h"
#include "inc\methodtable.h"
#include "inc\gcinterface.h"
#include "inc\gcinterface.ee.h"

// This is an example of an exported variable
CUSTOMGC_API int nCustomGC=0;

// This is an example of an exported function.
CUSTOMGC_API int fnCustomGC(void)
{
    return 42;
}

// This is the constructor of a class that has been exported.
// see CustomGC.h for the class definition
CCustomGC::CCustomGC()
{
    return;
}

#ifdef _MSC_VER
#define DLLEXPORT __declspec(dllexport)
#else
#define DLLEXPORT __attribute__ ((visibility ("default")))
#endif // _MSC_VER

extern "C" DLLEXPORT bool
InitializeGarbageCollector(
    /* In */  IGCToCLR* clrToGC,
    /* Out */ IGCHeap** gcHeap,
    /* Out */ IGCHandleManager** gcHandleManager,
    /* Out */ GcDacVars* gcDacVars
)
{
    IGCHeap* heap = new CustomGCHeap(clrToGC);
    IGCHandleManager* handleManager = new CustomGCHandleManager();
    //clrToGC->SuspendEE(SUSPEND_REASON::SUSPEND_FOR_GC);
    *gcHeap = heap;
    *gcHandleManager = handleManager;
    return true;
}