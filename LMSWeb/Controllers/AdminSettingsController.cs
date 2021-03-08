using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSBL.Common;
using LMSBL.DBModels;
using LMSBL.Repository;
using LMSWeb.App_Start;
using System.Net;
using System.Collections;
using LMSWeb.ViewModel;
using LMSBL.DBModels.CRMNew;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;
using Rotativa;

namespace LMSWeb.Controllers
{

    public class AdminSettingsController : Controller
    {
        UserRepository ur = new UserRepository();
        Exceptions newException = new Exceptions();
        CRMRepository cr = new CRMRepository();
        CRMUsersRepository crmUsersRepository = new CRMUsersRepository();
        // GET: AdminSettings
        public ActionResult Index()
        {
            TblUserViewModel objuserviewmodel = new TblUserViewModel();
            try
            {                
                TblUser sessionUser = (TblUser)Session["UserSession"];                
                sessionUser.IsMyProfile = true;

                List<tblCRMClient> clientdetails = new List<tblCRMClient>();
                clientdetails = cr.GetClientById(Convert.ToInt32(sessionUser.CRMClientId));
                objuserviewmodel.objtblCRMClient = clientdetails[0];
                objuserviewmodel.objtbluser = sessionUser;

                objuserviewmodel.lstClientStages = cr.GetCRMStagesList(Convert.ToInt32(sessionUser.CRMClientId));
                objuserviewmodel.lstClientSubStages = cr.GetCRMClientSubStages(Convert.ToInt32(sessionUser.CRMClientId));
                objuserviewmodel.lstUsers = cr.GetCRMAdminUsers(Convert.ToInt32(sessionUser.CRMClientId));
                objuserviewmodel.lstVisaType = crmUsersRepository.GetVisaType();

                tblCRMCheckList objCRMCheckList = new tblCRMCheckList();
                objuserviewmodel.objChecklist = objCRMCheckList;
                objuserviewmodel.objChecklistList = cr.GetCRMCheckList(Convert.ToInt32(sessionUser.CRMClientId));
                tblCRMAgreement objCRMAgreement = new tblCRMAgreement();
                objuserviewmodel.objCRMAgreement = objCRMAgreement;
                objuserviewmodel.lstCRMAgreement = cr.GetCRMAgreements(Convert.ToInt32(sessionUser.CRMClientId));


            }
            catch (Exception ex)
            {
                newException.AddException(ex);                
            }
            return View("Index", objuserviewmodel);

        }
        [HttpPost]
        public bool UpdateUser(TblUserViewModel objUserviewmodel, HttpPostedFileBase file)
        {
            bool status = false;
            try
            {
                TblUser model = (TblUser)Session["UserSession"];
                int rows = 0;
                bool ResultUpdate;
                string path = string.Empty;
                if (!string.IsNullOrEmpty(objUserviewmodel.imageName))
                {

                    var profileURL = System.Configuration.ConfigurationManager.AppSettings["CRMLogoImages"];
                    var profilePhysicalURL = System.Configuration.ConfigurationManager.AppSettings["CRMLogoPhysicalURL"];

                    if (!System.IO.Directory.Exists(profilePhysicalURL + "\\" + model.CRMClientId))
                    {
                        System.IO.Directory.CreateDirectory(profilePhysicalURL + "\\" + model.CRMClientId);
                    }

                    string filePhysicalPath = System.IO.Path.Combine(profilePhysicalURL + "\\" + model.CRMClientId + "\\");
                    path = System.IO.Path.Combine(profileURL + "/" + model.CRMClientId + "/" + model.CRMClientId + ".jpg");

                    string base64String = Convert.ToString(objUserviewmodel.imageJson);

                    byte[] newBytes = Convert.FromBase64String(base64String);
                    MemoryStream ms = new MemoryStream(newBytes, 0, newBytes.Length);
                    ms.Write(newBytes, 0, newBytes.Length);
                    var fileName = Convert.ToString(model.CRMClientId + ".jpg");
                    FileStream fileNew = new FileStream(filePhysicalPath + "\\" + fileName, FileMode.Create, FileAccess.Write);
                    ms.WriteTo(fileNew);
                    fileNew.Close();
                    ms.Close();
                }

                rows = ur.EditUser(objUserviewmodel.objtbluser);
                if (!string.IsNullOrEmpty(objUserviewmodel.imageName))
                {
                    ResultUpdate = cr.UpdateCRMClient(Convert.ToInt32(model.CRMClientId), path);
                }
                if (objUserviewmodel.objtbluser.IsMyProfile)
                {
                    if (!string.IsNullOrEmpty(objUserviewmodel.objtbluser.OldPassword) && !string.IsNullOrEmpty(objUserviewmodel.objtbluser.Password))
                    {
                        CommonFunctions common = new CommonFunctions();
                        objUserviewmodel.objtbluser.OldPassword = common.GetEncodePassword(objUserviewmodel.objtbluser.OldPassword);
                        objUserviewmodel.objtbluser.Password = common.GetEncodePassword(objUserviewmodel.objtbluser.Password);
                        var result = ur.ChangePassword(objUserviewmodel.objtbluser, objUserviewmodel.objtbluser.Password);

                    }

                }
                if (objUserviewmodel.objtbluser.IsMyProfile)
                {
                    var userDetails = ur.GetUserById(model.UserId);
                    Session["UserSession"] = userDetails[0];
                    status = true;
                }
            }
            catch (Exception ex)
            {
                newException.AddException(ex);
            }
            return status;
        }

        public bool UpdateStages(string jsonStageData, string jsonSubStageData)
        {
            bool status = false;
            TblUser sessionUser = (TblUser)Session["UserSession"];
            List<tblCRMClientStage> lstStage = new List<tblCRMClientStage>();

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            object[] objStageData = (object[])json_serializer.DeserializeObject(jsonStageData);

            foreach (Dictionary<string, object> item in objStageData)
            {
                tblCRMClientStage objStage = new tblCRMClientStage();
                objStage.StageId = Convert.ToInt32(item["StageId"]);
                objStage.StageName = Convert.ToString(item["StageName"]);
                objStage.ClientId = Convert.ToInt32(sessionUser.CRMClientId);
                objStage.CreatedBy = sessionUser.UserId;
                objStage.CreatedOn = DateTime.Now;

                lstStage.Add(objStage);
            }
            List<tblCRMClientSubStage> lstSubStage = new List<tblCRMClientSubStage>();
            object[] objSubStageData = (object[])json_serializer.DeserializeObject(jsonSubStageData);
            foreach (Dictionary<string, object> item in objSubStageData)
            {
                tblCRMClientSubStage objSubStage = new tblCRMClientSubStage();
                objSubStage.SubStageId = Convert.ToInt32(item["SubStageID"]);
                objSubStage.SubStageName = Convert.ToString(item["SubStageName"]);
                objSubStage.IsActive = Convert.ToBoolean(item["SubStageIsActive"]);
                objSubStage.ClientId = Convert.ToInt32(sessionUser.CRMClientId);
                objSubStage.CreatedBy = sessionUser.UserId;
                objSubStage.CreatedOn = DateTime.Now;
                lstSubStage.Add(objSubStage);

            }
            status = cr.UpdateStages(lstStage, lstSubStage);

            return status;
        }

        public bool AddAdminUser(string jsonData)
        {
            bool result = false;
            TblUser model = (TblUser)Session["UserSession"];
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            object[] objUserData = (object[])json_serializer.DeserializeObject(jsonData);

            foreach (Dictionary<string, object> item in objUserData)
            {
                //var objUser = context.tblUsers.Where(a => a.userId == Convert.ToInt32(item["UserId"])).FirstOrDefault();
                tblUser objUser = new tblUser();
                if (string.IsNullOrEmpty(Convert.ToString(item["UserId"])))
                {
                    if (cr.CheckEmailExist(Convert.ToString(item["Email"])))
                    {
                        objUser.firstName = Convert.ToString(item["FirstName"]);
                        objUser.emailId = Convert.ToString(item["Email"]);
                        objUser.contactNo = Convert.ToString(item["Contact"]);
                        objUser.lastName = Convert.ToString(item["LastName"]);
                        CommonFunctions common = new CommonFunctions();
                        objUser.password = common.GetEncodePassword(Convert.ToString(item["Password"]));
                        objUser.CRMClientId = Convert.ToInt32(model.CRMClientId);
                        objUser.tenantId = Convert.ToInt32(model.TenantId);
                        objUser.roleId = 4;
                        objUser.createdBy = Convert.ToInt32(model.UserId);
                        objUser.createdOn = DateTime.Now;
                        objUser.isActive = true;
                        objUser.isLMS = true;
                        objUser.isNew = false;

                        result = cr.AddEditAdminUser(objUser);
                    }
                }
                else
                {
                    objUser = cr.GetUserForEdit(Convert.ToInt32(item["UserId"]));
                    objUser.firstName = Convert.ToString(item["FirstName"]);
                    objUser.emailId = Convert.ToString(item["Email"]);
                    objUser.contactNo = Convert.ToString(item["Contact"]);
                    objUser.lastName = Convert.ToString(item["LastName"]);
                    CommonFunctions common = new CommonFunctions();
                    objUser.password = common.GetEncodePassword(Convert.ToString(item["Password"]));
                    result = cr.AddEditAdminUser(objUser);
                }
            }


            return result;
        }

        public ActionResult GetAllAdminUsers()
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            TblUserViewModel objuserviewmodel = new TblUserViewModel();
            objuserviewmodel.lstUsers = cr.GetCRMAdminUsers(Convert.ToInt32(sessionUser.CRMClientId));
            return PartialView("_ManageUser", objuserviewmodel);
        }

        public ActionResult GetAdminUserForEdit(string UserId)
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            TblUserViewModel objuserviewmodel = new TblUserViewModel();
            var userobject = ur.GetUserById(Convert.ToInt32(UserId));
            objuserviewmodel.objAdminUser = userobject[0];
            return PartialView("_AddAdminUser", objuserviewmodel);
        }

        public string GetClientLogo()
        {
            string logoPath = string.Empty;
            TblUser model = (TblUser)Session["UserSession"];
            LMSBL.Repository.CRMRepository CRMRepo = new LMSBL.Repository.CRMRepository();
            var clientModel = CRMRepo.GetClientById(Convert.ToInt32(model.CRMClientId));
            logoPath = clientModel[0].ClientLogo;
            return logoPath;
        }

        [HttpPost]
        public ActionResult GetClientStages()
        {
            TblUser model = (TblUser)Session["UserSession"];
            LMSBL.Repository.CRMRepository CRMRepo = new LMSBL.Repository.CRMRepository();
            var stageModel = CRMRepo.GetCRMStagesList(Convert.ToInt32(model.CRMClientId));
            return Json(stageModel, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public bool AddCheckList(string jsonData)
        {
            bool status = false;
            TblUser model = (TblUser)Session["UserSession"];
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            object[] objChecklistData = (object[])json_serializer.DeserializeObject(jsonData);
            tblCRMCheckList objCheckList = new tblCRMCheckList();
            List<tblCRMCheckListItem> objCheckListItemList = new List<tblCRMCheckListItem>();
            foreach (Dictionary<string, object> item in objChecklistData)
            {
                objCheckList.CRMClientID = Convert.ToInt32(model.CRMClientId);
                objCheckList.CreatedOn = DateTime.Now;
                objCheckList.Id = Convert.ToInt32(item["Id"]);
                objCheckList.CheckListName = Convert.ToString(item["CheckListName"]);
                objCheckList.VisaType = Convert.ToInt32(item["VisaType"]);
                int count = 0;
                foreach (Dictionary<string, object> itemChecklist in (object[])item["Items"])
                {
                    count++;
                    tblCRMCheckListItem objtblCRMCheckListItem = new tblCRMCheckListItem();
                    objtblCRMCheckListItem.ItemId = count;
                    objtblCRMCheckListItem.ItemName = Convert.ToString(itemChecklist["ItemDesc"]);
                    objtblCRMCheckListItem.CreatedDate = DateTime.Now;
                    objCheckListItemList.Add(objtblCRMCheckListItem);
                }
            }
            status = cr.AddCheckList(objCheckList, objCheckListItemList);
            return status;
        }

        public ActionResult GetCheckListData()
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            TblUserViewModel objuserviewmodel = new TblUserViewModel();
            objuserviewmodel.objChecklistList = cr.GetCRMCheckList(Convert.ToInt32(sessionUser.CRMClientId));
            return PartialView("_CheckList", objuserviewmodel);
        }
        public ActionResult GetCheckListItems(string ChecklistId)
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            CheckListViewModel objChecklist = new CheckListViewModel();
            objChecklist.CheckListObject = cr.GetCRMCheckListByID(Convert.ToInt32(sessionUser.CRMClientId), Convert.ToInt32(ChecklistId));
            objChecklist.lstCheckListItem = cr.GetCRMCheckListItem(Convert.ToInt32(ChecklistId));
            return Json(objChecklist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowCheckListItems(int id, string hide, string clientId)
        {     
            if(string.IsNullOrEmpty(clientId))
            {
                TblUser sessionUser = (TblUser)Session["UserSession"];
                clientId = sessionUser.CRMClientId;
            }
            
            CheckListViewModel objChecklist = new CheckListViewModel();
            objChecklist.CheckListObject = cr.GetCRMCheckListByID(Convert.ToInt32(clientId), Convert.ToInt32(id));
            objChecklist.lstCheckListItem = cr.GetCRMCheckListItem(Convert.ToInt32(id));
            ViewBag.CheckListID = id;
            ViewBag.Hide = hide;
            return View(objChecklist);
        }
        public ActionResult PrintCheckList(string id)
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            var report = new ActionAsPdf("ShowCheckListItems", new { id = Convert.ToInt32(id), hide=1, clientId=sessionUser.CRMClientId });
            return report;
        }      

    }
}