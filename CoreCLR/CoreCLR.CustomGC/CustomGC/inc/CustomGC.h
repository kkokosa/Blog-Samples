// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the CUSTOMGC_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// CUSTOMGC_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
//#ifdef CUSTOMGC_EXPORTS
#define CUSTOMGC_API __declspec(dllexport)
//#else
//#define CUSTOMGC_API __declspec(dllimport)
//#endif

// This class is exported from the CustomGC.dll
class CUSTOMGC_API CCustomGC {
public:
	CCustomGC(void);
	// TODO: add your methods here.
};

extern CUSTOMGC_API int nCustomGC;

CUSTOMGC_API int fnCustomGC(void);
