﻿
		/*
 * Copyright (C) 2007 Trivantis Corporation
 */

	
var _Debug=false;var _NoError=0;var _GeneralError=101;var _ServerBusy=102;var _InvalidArgumentError=201;var _ElementCannotHaveChildren=202;var _ElementIsNotAnArray=203;var _NotInitialized=301;var _NotImplementedError=401;var _InvalidSetValue=402;var _ElementIsReadOnly=403;var _ElementIsWriteOnly=404;var _IncorrectDataType=405;var apiHandle=null;var API=null;var findAPITries=0;var lmsFinishCalled=false;var lmsInitCalled=false;function LMSInitialize(){var A=getAPIHandle();if (A==null){alert("Unable to locate the LMS's API Implementation.\nLMSInitialize was not successful.");return "false";};if(lmsInitCalled==false){var B=A.LMSInitialize("");if (B.toString()!="true"){ErrorHandler("LMSInitialize Error: "+A.LMSGetLastError());};lmsInitCalled=true;lmsFinishCalled=false;try {if(this.myTop&&this.myTop.apiHandle){this.myTop.lmsInitCalled=lmsInitCalled;this.myTop.lmsFinishCalled=lmsFinishCalled;}} catch (e) {};return B.toString();}else if (_Debug){alert("LMSInitialize already called");};return "true";};function LMSFinish(){var A="false";var B=getAPIHandle();if (B==null){alert("Unable to locate the LMS's API Implementation.\nLMSFinish was not successful.");return "false";}else{var C=lmsFinishCalled;lmsFinishCalled=true;lmsInitCalled=false;try {if(this.myTop&&this.myTop.apiHandle){this.myTop.lmsInitCalled=lmsInitCalled;this.myTop.lmsFinishCalled=lmsFinishCalled;}} catch (e) {};if(C==false){A=B.LMSFinish("");if (A==u) A='true';}else if (_Debug){alert("LMSFinish already called");}};return A.toString();};function LMSGetValue(A){var B=getAPIHandle();if (B==null){alert("Unable to locate the LMS's API Implementation.\nLMSGetValue was not successful.");return "";}else if (lmsFinishCalled==true){if(_Debug) alert('Unable to perform LMSGetValue after LMSFinish already called');return "";}else{var C=B.LMSGetValue(A);var D=C.toString();trivLogMsg('LMSGetValue for '+A+' = ['+D+']',16);return D;}};function LMSSetValue(A,B){var C=getAPIHandle();if (C==null){alert("Unable to locate the LMS's API Implementation.\nLMSSetValue was not successful.");return;}else if (lmsFinishCalled==true){if(_Debug) alert('Unable to perform LMSSetValue after LMSFinish already called');}else{var D=C.LMSSetValue(A,B);if (D.toString()!="true"){var E=ErrorHandler("LMSSetValue Error: "+A+" to ["+B+"] ");trivLogMsg('Error ['+E+'] from LMSSetValue for '+A+' to ['+B+']',16);}else{trivLogMsg('LMSSetValue for '+A+' to ['+B+']',16);}};return;};function LMSCommit(){var A="false";var B=getAPIHandle();if (B==null){alert("Unable to locate the LMS's API Implementation.\nLMSCommit was not successful.");return "false";}else if (lmsFinishCalled==true){if(_Debug) alert('Unable to perform LMSCommit after LMSFinish already called');}else{A=B.LMSCommit("");if (A.toString()!="true"){ErrorHandler("LMSCommit Error: ");}};return A.toString();};function LMSGetLastError(){var A=getAPIHandle();if (A==null){alert("Unable to locate the LMS's API Implementation.\nLMSGetLastError was not successful.");return _GeneralError;};return A.LMSGetLastError().toString();};function LMSGetErrorString(A){var B=getAPIHandle();if (B==null){alert("Unable to locate the LMS's API Implementation.\nLMSGetErrorString was not successful.");};return B.LMSGetErrorString(A).toString();};function LMSGetDiagnostic(A){var B=getAPIHandle();if (B==null){alert("Unable to locate the LMS's API Implementation.\nLMSGetDiagnostic was not successful.");};return B.LMSGetDiagnostic(A).toString();};function LMSIsInitialized(){var A=getAPIHandle();if (A==null){alert("Unable to locate the LMS's API Implementation.\nLMSIsInitialized() failed.");return false;}else if (lmsFinishCalled==true){return false;}else{var B=A.LMSGetValue("cmi.core.student_name");if(B.toString().length==0){var C=parseInt(A.LMSGetLastError().toString(),10);if (C==_NotInitialized) return false;};return true;}};function ErrorHandler(A){var B=getAPIHandle();if (B==null){alert("Unable to locate the LMS's API Implementation.\nCannot determine LMS error code.");return;};var C=parseInt(B.LMSGetLastError().toString(),10);if (C!=_NoError){var D=B.LMSGetErrorString(C);if (_Debug==true){D+="\n";D+=B.LMSGetDiagnostic(null);};alert(A+D);};return C;};function getAPIHandle(){if (apiHandle==null){apiHandle=getAPI();};return apiHandle;};function findAPI(A){while ((A.API==null)&&(A.parent!=null)&&(A.parent!=A)){findAPITries++;if (findAPITries>7){alert("Error finding API -- too deeply nested.");return null;};A=A.parent;};return A.API;};function getAPI(){var A=window,B=findAPI(A);if (!B){if (A.opener) B=findAPI(A.opener);while (!B&&A.parent.window&&A.parent!=A){A=A.parent;if (A.opener) B=findAPI(A.opener);}};if ((B==null)&&(top.opener!=null)&&(top.opener.top!=null)&&(top.opener.top.opener!=null)&&(typeof (top.opener.top.opener)!="undefined")){B=findAPI(top.opener.top.opener);};if (B==null){alert("Unable to find an API adapter");};return B;};