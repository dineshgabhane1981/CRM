using LMSBL.Repository;
using LMSBL.DBModels.CRMNew;
using LMSWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSBL.DBModels;
using System.Web.Script.Serialization;
using LMSWeb.App_Start;
using LMSBL.Common;

namespace LMSWeb.Controllers
{
    public class CRMUsersController : Controller
    {
        CRMNotesRepository crmNotesRepository = new CRMNotesRepository();
        CRMUsersRepository crmUsersRepository = new CRMUsersRepository();
        CRMDocumentsRepository crmDocRepo = new CRMDocumentsRepository();
        CRMInvoiceRepository invoiceRepository = new CRMInvoiceRepository();
        Exceptions newException = new Exceptions();
        public ActionResult Enquiry()
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            List<EnquiryListing> listingViewModel = new List<EnquiryListing>();
            listingViewModel = crmUsersRepository.GetCRMUsersAll(sessionUser, 1);
            ViewBag.StageForButton = 1;
            return View(listingViewModel);
        }
        public ActionResult AddEnquiry(string myid)
        {

            CRMUserViewModel objCRMUserViewModel = new CRMUserViewModel();
            if (!string.IsNullOrEmpty(myid))
            {
                //Edit mode
                CommonFunctions common = new CommonFunctions();
                myid = common.DecryptString(myid);
                int userId = Convert.ToInt32(myid);
                objCRMUserViewModel = LoadModel(userId);
            }
            else
            {
                //Add mode
                objCRMUserViewModel = FillAlldropdownLists(objCRMUserViewModel);
                tblCRMUser ObjCRMUser = new tblCRMUser();
                ObjCRMUser.CurrentStage = 1;
                objCRMUserViewModel.ObjCRMUser = ObjCRMUser;
                CRMInvoiceViewModel CRMInvoiceModelView = new CRMInvoiceViewModel();
                tblCRMInvoice ObjCRMInvoivce = new tblCRMInvoice();
                CRMInvoiceModelView.ObjCRMInvoivce = ObjCRMInvoivce;
                CRMInvoiceModelView.lstCRMCurriencies = invoiceRepository.GetCRMCurriencies();
                objCRMUserViewModel.CRMInvoiceModelView = CRMInvoiceModelView;
            }

            return View(objCRMUserViewModel);
        }
        public ActionResult PotentialClients()
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            List<EnquiryListing> listingViewModel = new List<EnquiryListing>();
            listingViewModel = crmUsersRepository.GetCRMUsersAll(sessionUser, 2);
            ViewBag.StageForButton = 2;
            return View("Enquiry", listingViewModel);
        }
        public ActionResult AddPotentialClient(string myid)
        {
            CRMUserViewModel objCRMUserViewModel = new CRMUserViewModel();
            if (!string.IsNullOrEmpty(myid))
            {
                //Edit mode
                CommonFunctions common = new CommonFunctions();
                myid = common.DecryptString(myid);
                int userId = Convert.ToInt32(myid);
                objCRMUserViewModel = LoadModel(userId);

            }
            else
            {
                //Add mode
                objCRMUserViewModel = FillAlldropdownLists(objCRMUserViewModel);
                tblCRMUser ObjCRMUser = new tblCRMUser();
                ObjCRMUser.CurrentStage = 2;
                objCRMUserViewModel.ObjCRMUser = ObjCRMUser;
                CRMInvoiceViewModel CRMInvoiceModelView = new CRMInvoiceViewModel();
                tblCRMInvoice ObjCRMInvoivce = new tblCRMInvoice();
                CRMInvoiceModelView.ObjCRMInvoivce = ObjCRMInvoivce;
                CRMInvoiceModelView.lstCRMCurriencies = invoiceRepository.GetCRMCurriencies();
                objCRMUserViewModel.CRMInvoiceModelView = CRMInvoiceModelView;
            }

            return View("AddEnquiry", objCRMUserViewModel);
        }

        public ActionResult Clients()
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            CRMClientViewModel objCRMClientViewModel = new CRMClientViewModel();
            objCRMClientViewModel.lstClientSubStages = crmUsersRepository.GetCRMClientSubStages(Convert.ToInt32(sessionUser.CRMClientId));
            objCRMClientViewModel.objClientTicketLST = crmUsersRepository.GetCRMTicketsAll(sessionUser, 3);
            //List<EnquiryListing> listingViewModel = new List<EnquiryListing>();
            //listingViewModel = crmUsersRepository.GetCRMUsersAll(Convert.ToInt32(sessionUser.CRMClientId), 3);
            ViewBag.StageForButton = 3;
            return View(objCRMClientViewModel);
        }

        public ActionResult AddClient(string myid, string clone)
        {
            CRMUserViewModel objCRMUserViewModel = new CRMUserViewModel();
            if (!string.IsNullOrEmpty(myid))
            {
                //Edit mode
                CommonFunctions common = new CommonFunctions();
                myid = common.DecryptString(myid);
                int userId = Convert.ToInt32(myid);
                objCRMUserViewModel = LoadModel(userId);
                objCRMUserViewModel.Clone = clone;

            }
            else
            {
                //Add mode
                objCRMUserViewModel = FillAlldropdownLists(objCRMUserViewModel);
                tblCRMUser ObjCRMUser = new tblCRMUser();
                ObjCRMUser.CurrentStage = 3;
                objCRMUserViewModel.ObjCRMUser = ObjCRMUser;
                CRMInvoiceViewModel CRMInvoiceModelView = new CRMInvoiceViewModel();
                tblCRMInvoice ObjCRMInvoivce = new tblCRMInvoice();
                CRMInvoiceModelView.ObjCRMInvoivce = ObjCRMInvoivce;
                CRMInvoiceModelView.lstCRMCurriencies = invoiceRepository.GetCRMCurriencies();
                objCRMUserViewModel.CRMInvoiceModelView = CRMInvoiceModelView;
            }

            return View("AddEnquiry", objCRMUserViewModel);

        }

        [HttpPost]
        public string AddCRMUser(CRMUserViewModel objCRMUserViewModel)
        {
            int id = 0;
            int oldId = objCRMUserViewModel.ObjCRMUser.Id;
            string returnId = string.Empty;
            string url = "";
            TblUser sessionUser = (TblUser)Session["UserSession"];
            objCRMUserViewModel.ObjCRMUser.CreatedBy = sessionUser.UserId;
            objCRMUserViewModel.ObjCRMUser.CreatedOn = DateTime.Now;
            objCRMUserViewModel.ObjCRMUser.UpdatedBy = sessionUser.UserId;
            objCRMUserViewModel.ObjCRMUser.UpdatedOn = DateTime.Now;
            objCRMUserViewModel.ObjCRMNote.CreatedDate = DateTime.Now;
            objCRMUserViewModel.ObjCRMNote.CreatedBy = sessionUser.UserId;
            objCRMUserViewModel.ObjCRMUser.ClientId = Convert.ToInt32(sessionUser.CRMClientId);
            if (sessionUser.RoleId != 2)
            {
                objCRMUserViewModel.ObjCRMUser.AssignedTo = sessionUser.UserId;
            }
            if (!string.IsNullOrEmpty(objCRMUserViewModel.Clone))
            {
                id = crmUsersRepository.CloneUserData(objCRMUserViewModel.ObjCRMUser, objCRMUserViewModel.ObjCRMUsersVisaDetail, objCRMUserViewModel.ObjCRMUsersINZLoginDetail);
            }
            else
            {
                id = crmUsersRepository.SaveUserData(objCRMUserViewModel.ObjCRMUser, objCRMUserViewModel.ObjCRMUsersBillingAddress, objCRMUserViewModel.ObjCRMUsersPassportDetail,
                    objCRMUserViewModel.ObjCRMUsersVisaDetail, objCRMUserViewModel.ObjCRMUsersMedicalDetail,
                    objCRMUserViewModel.ObjCRMUsersPoliceCertificateInfo, objCRMUserViewModel.ObjCRMUsersINZLoginDetail,
                    objCRMUserViewModel.ObjCRMUsersNZQADetail, objCRMUserViewModel.ObjCRMNote, objCRMUserViewModel.ObjLoginAndQualificationDetails);

            }
            if (oldId == 0)
            {
                if (id > 0)
                {
                    CommonFunctions common = new CommonFunctions();
                    returnId = common.EncryptString(Convert.ToString(id));
                }
                if (objCRMUserViewModel.ObjCRMUser.CurrentStage == 1)
                {
                    url = "CRMUsers/AddEnquiry?myid=" + returnId;
                }
                if (objCRMUserViewModel.ObjCRMUser.CurrentStage == 2)
                {
                    url = "CRMUsers/AddPotentialClient?myid=" + returnId;
                }
                if (objCRMUserViewModel.ObjCRMUser.CurrentStage == 3)
                {
                    url = "CRMUsers/AddClient?myid=" + returnId;
                }
            }
            // CRMUsers / AddEnquiry ? myid =
            return url;
        }

        [HttpPost]
        public ActionResult MoveUser(int id, int stage, int currentstage)
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];

            var result = crmUsersRepository.UpdateStage(id, stage);
            List<EnquiryListing> listingViewModel = new List<EnquiryListing>();
            listingViewModel = crmUsersRepository.GetCRMUsersAll(sessionUser, currentstage);
            ViewBag.StageForButton = currentstage;
            return PartialView("_EnquiryList", listingViewModel);
        }

        [HttpPost]
        public string MoveUserToSubStage(int uId, int sId)
        {
            List<string> lstResult = new List<string>();
            TblUser sessionUser = (TblUser)Session["UserSession"];
            var currentUserStage = crmUsersRepository.GetCRMUserById(uId);
            lstResult.Add(Convert.ToString(currentUserStage.CurrentSubStage));

            var result = crmUsersRepository.UpdateSubStage(uId, sId);

            var currentNoOfUsers = crmUsersRepository.GetCRMUsersBySubStageId(Convert.ToInt32(sessionUser.CRMClientId), Convert.ToInt32(currentUserStage.CurrentSubStage));
            lstResult.Add(Convert.ToString(currentNoOfUsers.Count));

            var noOfUsers = crmUsersRepository.GetCRMUsersBySubStageId(Convert.ToInt32(sessionUser.CRMClientId), sId);
            lstResult.Add(Convert.ToString(noOfUsers.Count));

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            var jsonData = json_serializer.Serialize(lstResult);

            return jsonData;
        }


        public CRMUserViewModel LoadModel(int userId)
        {
            CRMUserViewModel objModel = new CRMUserViewModel();
            objModel = FillAlldropdownLists(objModel);
            objModel.ObjCRMUser = crmUsersRepository.GetCRMUserById(userId);
            objModel.ObjCRMUsersBillingAddress = crmUsersRepository.GetCRMUserBillingAddressById(userId);
            objModel.ObjCRMUsersPassportDetail = crmUsersRepository.GetCRMUserPassportDetailById(userId);
            objModel.ObjCRMUsersVisaDetail = crmUsersRepository.GetCRMUserVisaDetailById(userId);
            objModel.ObjCRMUsersMedicalDetail = crmUsersRepository.GetCRMUserMedicalDetailById(userId);
            objModel.ObjCRMUsersPoliceCertificateInfo = crmUsersRepository.GetCRMUserPoliceCertificateInfoById(userId);
            objModel.ObjCRMUsersINZLoginDetail = crmUsersRepository.GetCRMUserINZLoginDetailById(userId);
            objModel.ObjCRMUsersNZQADetail = crmUsersRepository.GetCRMUserNZQADetailById(userId);
            objModel.ObjCRMNoteLST = crmUsersRepository.GetCRMUserFileNotesById(userId);
            objModel.lstNotes = crmNotesRepository.GetCRMUserFileNotesById(userId);
            objModel.lstNotesSubStages = crmNotesRepository.GetCRMUserFileNotesSubStagesById(userId);
            objModel.ObjCRMDocumentLST = crmDocRepo.GetCRMDocumentList(userId);
            objModel.ObjCRMUserQualificationList = crmUsersRepository.GetCRMUserQualification(userId);
            objModel.ObjLoginAndQualificationDetails = crmUsersRepository.GetCRMUserLoginQualificationDetail(userId);

            CRMInvoiceViewModel CRMInvoiceModelView = new CRMInvoiceViewModel();
            tblCRMInvoice ObjCRMInvoivce = new tblCRMInvoice();
            TblUser sessionUser = (TblUser)Session["UserSession"];
            var clientId = Convert.ToInt32(sessionUser.CRMClientId);

            ObjCRMInvoivce.InvoiceNumber = invoiceRepository.GetInvoiceNumber(clientId);
            CRMInvoiceModelView.ObjCRMInvoivce = ObjCRMInvoivce;
            CRMInvoiceModelView.ObjCRMInvoivceLST = invoiceRepository.GetInvoices(userId);
            CRMInvoiceModelView.lstCRMCurriencies = invoiceRepository.GetCRMCurriencies();
            objModel.CRMInvoiceModelView = CRMInvoiceModelView;

            return objModel;

        }

        public CRMUserViewModel FillAlldropdownLists(CRMUserViewModel objModel)
        {
            objModel.VisaCountriesList = crmUsersRepository.GetVisaCountries();
            objModel.CountriesCodes = crmUsersRepository.GetCountryCodes();
            objModel.WhereDidYouFindUsList = crmUsersRepository.WhereDidYouFindUs();
            objModel.JobSectorsList = crmUsersRepository.GetJobSector();
            objModel.UserCountryList = crmUsersRepository.GetCountries();
            objModel.CurrentVisaTypeList = crmUsersRepository.GetVisaType();
            objModel.VisaStatusList = crmUsersRepository.GetVisaStatus();


            TblUser sessionUser = (TblUser)Session["UserSession"];
            objModel.SubStagesList = crmNotesRepository.GetCRMClientSubStages(Convert.ToInt32(sessionUser.CRMClientId));
            objModel.StagesList = crmUsersRepository.GetCRMStagesList(Convert.ToInt32(sessionUser.CRMClientId));
            objModel.UserList = crmUsersRepository.GetCRMAdminUsers(Convert.ToInt32(sessionUser.CRMClientId));
            return objModel;
        }

        [HttpPost, ValidateInput(false)]
        public bool adddocuments(string jsonData)
        {
            tblCRMDocument objDocument = new tblCRMDocument();
            string base64string = string.Empty;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            object[] objDocData = (object[])json_serializer.DeserializeObject(jsonData);
            foreach (Dictionary<string, object> item in objDocData)
            {
                objDocument.ClientId = Convert.ToInt32(item["ClientId"]);
                objDocument.DocumentName = Convert.ToString(item["DocName"]);
                objDocument.DocumentfileName = Convert.ToString(item["FileName"]);
                base64string = Convert.ToString(item["base64string"]);
            }
            bool status = false;
            TblUser sessionUser = (TblUser)Session["UserSession"];

            objDocument.UpdatedBy = sessionUser.UserId;
            objDocument.UpdatedDate = DateTime.Now;
            //objCRMDocumentsViewModel.objCRMDocument.DocumentLink = objCRMDocumentsViewModel.documentFileName;
            status = crmDocRepo.AddDocument(objDocument, base64string, objDocument.DocumentfileName);

            return status;
        }

        [HttpPost]
        public bool addqualification(string jsonData)
        {
            bool status = false;
            tblCRMUsersQualification objQualification = new tblCRMUsersQualification();
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            object[] objQualificationData = (object[])json_serializer.DeserializeObject(jsonData);
            foreach (Dictionary<string, object> item in objQualificationData)
            {
                objQualification.QualificationId = 0;
                objQualification.ClientId = Convert.ToInt32(item["ClientId"]);
                objQualification.Qualification = Convert.ToString(item["Qualification"]);
                objQualification.AwardingBody = Convert.ToString(item["AwardingBody"]);
                objQualification.DateAwarded = Convert.ToDateTime(item["QualificationAwarded"]);
                objQualification.Country = Convert.ToString(item["QualificationCountry"]);
                objQualification.Exempt = Convert.ToBoolean(item["IsExempt"]);
                objQualification.AddedDate = DateTime.Now;
            }
            status = crmUsersRepository.AddQualification(objQualification);

            return status;

        }
        public ActionResult GetSearchClient(string SearchText)
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            CRMClientViewModel objCRMClientViewModel = new CRMClientViewModel();
            objCRMClientViewModel.lstClientSubStages = crmUsersRepository.GetCRMClientSubStages(Convert.ToInt32(sessionUser.CRMClientId));
            objCRMClientViewModel.objClientTicketLST = crmUsersRepository.GetCRMTicketsAll(sessionUser, 3);

            objCRMClientViewModel.objClientTicketLST = objCRMClientViewModel.objClientTicketLST.Where(x => x.UserName.ToLower().Contains(SearchText.ToLower())).ToList();
            ViewBag.StageForButton = 3;
            return View("_ClientList", objCRMClientViewModel);
        }

        public bool DeleteQualification(string Id)
        {
            bool result = false;
            result = crmUsersRepository.DeleteQualification(Convert.ToInt32(Id));
            return result;
        }

        public ActionResult GetAllQualification(string ClientId)
        {
            CRMUserViewModel objModel = new CRMUserViewModel();
            objModel.ObjCRMUserQualificationList = crmUsersRepository.GetCRMUserQualification(Convert.ToInt32(ClientId));
            return View("_QualificationList", objModel);
        }

        [HttpPost]
        public bool UploadInvoice(string jsonData)
        {
            bool result = false;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            object[] objInvoiceData = (object[])json_serializer.DeserializeObject(jsonData);

            tblCRMInvoice objInvoice = new tblCRMInvoice();
            TblUser sessionUser = (TblUser)Session["UserSession"];
            objInvoice.CreatedBy = sessionUser.UserId;
            objInvoice.CreatedOn = DateTime.Now;
            objInvoice.UpdatedBy = sessionUser.UserId;
            objInvoice.UpdatedOn = DateTime.Now;
            objInvoice.CRMClientID = Convert.ToInt32(sessionUser.CRMClientId);
            string filebase64 = string.Empty;

            foreach (Dictionary<string, object> item in objInvoiceData)
            {

                objInvoice.ClientId = Convert.ToInt32(item["ClientID"]);
                objInvoice.InvoiceNumber = Convert.ToString(item["InvoiceNumber"]);
                objInvoice.Status = Convert.ToString(item["Status"]);
                objInvoice.InvoiceType = Convert.ToString(item["InvoiceType"]);
                if (Convert.ToString(item["InvoiceType"]) == "Receipt")
                {
                    objInvoice.InvoiceNumber = Convert.ToString(item["InvoiceNo"]) + "_Receipt";
                }
                //objInvoice.ClientId = Convert.ToString(item["InvoiceNo"]);
                objInvoice.InvoiceFileName = Convert.ToString(item["UploadedFileName"]);
                filebase64 = Convert.ToString(item["filebase64"]);

            }
            result = invoiceRepository.UploadInvoice(objInvoice, filebase64);


            return result;
        }

        [HttpPost]
        public bool AddInvoice(string jsonData)
        {
            bool result = false;
            try
            {
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                json_serializer.MaxJsonLength = int.MaxValue;
                object[] objInvoiceData = (object[])json_serializer.DeserializeObject(jsonData);

                tblCRMInvoice objInvoice = new tblCRMInvoice();
                TblUser sessionUser = (TblUser)Session["UserSession"];
                objInvoice.CreatedBy = sessionUser.UserId;
                objInvoice.CreatedOn = DateTime.Now;
                objInvoice.UpdatedBy = sessionUser.UserId;
                objInvoice.UpdatedOn = DateTime.Now;
                objInvoice.CRMClientID = Convert.ToInt32(sessionUser.CRMClientId);
                string filebase64 = string.Empty;

                foreach (Dictionary<string, object> item in objInvoiceData)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(item["InvoiceId"])))
                    {
                        objInvoice.InvoiceId = Convert.ToInt32(item["InvoiceId"]);
                    }
                    objInvoice.ClientId = Convert.ToInt32(item["ClientID"]);
                    objInvoice.InvoiceNumber = Convert.ToString(item["InvoiceNumber"]);
                    objInvoice.Status = Convert.ToString(item["Status"]);
                    objInvoice.InvoiceType = "Invoice";
                    objInvoice.InvoiceDate = Convert.ToDateTime(item["InvoiceDate"]);
                    objInvoice.InvoiceDueDate = Convert.ToDateTime(item["DueDate"]);
                    objInvoice.GSTNumber = Convert.ToString(item["GSTNo"]);
                    objInvoice.Reference = Convert.ToString(item["Reference"]);
                    objInvoice.InvoiceCurrency = Convert.ToString(item["Currency"]);
                    objInvoice.GSTRate = Convert.ToDecimal(item["GSTRate"]);
                    objInvoice.SubTotal = Convert.ToDecimal(item["SubTotal"]);
                    objInvoice.InvoiceTotal = Convert.ToDecimal(item["Total"]);

                    List<tblCRMInvoiceItem> lstInvoiceItems = new List<tblCRMInvoiceItem>();
                    foreach (Dictionary<string, object> itemInvoice in (object[])item["ItemJson"])
                    {
                        tblCRMInvoiceItem InvoiveItem = new tblCRMInvoiceItem();

                        if (!string.IsNullOrEmpty(Convert.ToString(item["InvoiceId"])))
                        {
                            InvoiveItem.InvoiceId = Convert.ToInt32(item["InvoiceId"]);
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(itemInvoice["InvoiceItemId"])))
                        {
                            InvoiveItem.ItemId = Convert.ToInt32(itemInvoice["InvoiceItemId"]);
                        }
                        InvoiveItem.ItemDescription = Convert.ToString(itemInvoice["ItemDesc"]);
                        InvoiveItem.Price = Convert.ToDecimal(itemInvoice["ItemPrice"]);
                        InvoiveItem.Amount = Convert.ToDecimal(itemInvoice["ItemAmount"]);
                        lstInvoiceItems.Add(InvoiveItem);
                    }
                    result = invoiceRepository.SaveInvoice(objInvoice, lstInvoiceItems);
                }

            }
            catch(Exception ex)
            {
                newException.AddException(ex);
            }

            return result;
        }
        public ActionResult GetInvoices(int clientId)
        {
            CRMInvoiceViewModel CRMInvoiceModelView = new CRMInvoiceViewModel();
            CRMInvoiceModelView.ObjCRMInvoivceLST = invoiceRepository.GetInvoices(clientId);
            return PartialView("~/Views/Invoice/_InvoiceList.cshtml", CRMInvoiceModelView);
        }

    }
}