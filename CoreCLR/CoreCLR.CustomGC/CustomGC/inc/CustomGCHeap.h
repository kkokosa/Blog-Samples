#pragma once
#include "inc\common.h"
#include "inc\threads.h"
#include "inc\appdomain.h"
#include "inc\methodtable.h"
#include "inc\gcinterface.h"
#include "inc\gcinterface.ee.h"

class CustomGCHeap : public IGCHeap 
{
private:
    IGCToCLR* gcToCLR;
public:
    CustomGCHeap(IGCToCLR* gcToCLR) 
    {
        this->gcToCLR = gcToCLR;
    }

    // Inherited via IGCHeap
    virtual bool IsValidSegmentSize(size_t size) override;
    virtual bool IsValidGen0MaxSize(size_t size) override;
    virtual size_t GetValidSegmentSize(bool large_seg = false) override;
    virtual void SetReservedVMLimit(size_t vmlimit) override;
    virtual void WaitUntilConcurrentGCComplete() override;
    virtual bool IsConcurrentGCInProgress() override;
    virtual void TemporaryEnableConcurrentGC() override;
    virtual void TemporaryDisableConcurrentGC() override;
    virtual bool IsConcurrentGCEnabled() override;
    virtual HRESULT WaitUntilConcurrentGCCompleteAsync(int millisecondsTimeout) override;
    virtual bool FinalizeAppDomain(AppDomain * pDomain, bool fRunFinalizers) override;
    virtual void SetFinalizeQueueForShutdown(bool fHasLock) override;
    virtual size_t GetNumberOfFinalizable() override;
    virtual bool ShouldRestartFinalizerWatchDog() override;
    virtual Object * GetNextFinalizable() override;
    virtual void SetFinalizeRunOnShutdown(bool value) override;
    virtual int GetGcLatencyMode() override;
    virtual int SetGcLatencyMode(int newLatencyMode) override;
    virtual int GetLOHCompactionMode() override;
    virtual void SetLOHCompactionMode(int newLOHCompactionMode) override;
    virtual bool RegisterForFullGCNotification(uint32_t gen2Percentage, uint32_t lohPercentage) override;
    virtual bool CancelFullGCNotification() override;
    virtual int WaitForFullGCApproach(int millisecondsTimeout) override;
    virtual int WaitForFullGCComplete(int millisecondsTimeout) override;
    virtual unsigned WhichGeneration(Object * obj) override;
    virtual int CollectionCount(int generation, int get_bgc_fgc_coutn = 0) override;
    virtual int StartNoGCRegion(uint64_t totalSize, bool lohSizeKnown, uint64_t lohSize, bool disallowFullBlockingGC) override;
    virtual int EndNoGCRegion() override;
    virtual size_t GetTotalBytesInUse() override;
    virtual HRESULT GarbageCollect(int generation = -1, bool low_memory_p = false, int mode = collection_blocking) override;
    virtual unsigned GetMaxGeneration() override;
    virtual void SetFinalizationRun(Object * obj) override;
    virtual bool RegisterForFinalization(int gen, Object * obj) override;
    virtual HRESULT Initialize() override;
    virtual bool IsPromoted(Object * object) override;
    virtual bool IsHeapPointer(void * object, bool small_heap_only = false) override;
    virtual unsigned GetCondemnedGeneration() override;
    virtual bool IsGCInProgressHelper(bool bConsiderGCStart = false) override;
    virtual unsigned GetGcCount() override;
    virtual bool IsThreadUsingAllocationContextHeap(gc_alloc_context * acontext, int thread_number) override;
    virtual bool IsEphemeral(Object * object) override;
    virtual uint32_t WaitUntilGCComplete(bool bConsiderGCStart = false) override;
    virtual void FixAllocContext(gc_alloc_context * acontext, bool lockp, void * arg, void * heap) override;
    virtual size_t GetCurrentObjSize() override;
    virtual void SetGCInProgress(bool fInProgress) override;
    virtual bool RuntimeStructuresValid() override;
    virtual size_t GetLastGCStartTime(int generation) override;
    virtual size_t GetLastGCDuration(int generation) override;
    virtual size_t GetNow() override;
    virtual Object * Alloc(gc_alloc_context * acontext, size_t size, uint32_t flags) override;
    virtual Object * AllocLHeap(size_t size, uint32_t flags) override;
    virtual Object * AllocAlign8(gc_alloc_context * acontext, size_t size, uint32_t flags) override;
    virtual void PublishObject(uint8_t * obj) override;
    virtual void SetWaitForGCEvent() override;
    virtual void ResetWaitForGCEvent() override;
    virtual bool IsObjectInFixedHeap(Object * pObj) override;
    virtual void ValidateObjectMember(Object * obj) override;
    virtual Object * NextObj(Object * object) override;
    virtual Object * GetContainingObject(void * pInteriorPtr, bool fCollectedGenOnly) override;
    virtual void DiagWalkObject(Object * obj, walk_fn fn, void * context) override;
    virtual void DiagWalkHeap(walk_fn fn, void * context, int gen_number, bool walk_large_object_heap_p) override;
    virtual void DiagWalkSurvivorsWithType(void * gc_context, record_surv_fn fn, void * diag_context, walk_surv_type type) override;
    virtual void DiagWalkFinalizeQueue(void * gc_context, fq_walk_fn fn) override;
    virtual void DiagScanFinalizeQueue(fq_scan_fn fn, ScanContext * context) override;
    virtual void DiagScanHandles(handle_scan_fn fn, int gen_number, ScanContext * context) override;
    virtual void DiagScanDependentHandles(handle_scan_fn fn, int gen_number, ScanContext * context) override;
    virtual void DiagDescrGenerations(gen_walk_fn fn, void * context) override;
    virtual void DiagTraceGCSegments() override;
    virtual bool StressHeap(gc_alloc_context * acontext) override;
    virtual segment_handle RegisterFrozenSegment(segment_info * pseginfo) override;
    virtual void UnregisterFrozenSegment(segment_handle seg) override;
};
