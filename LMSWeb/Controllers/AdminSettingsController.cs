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

namespace LMSWeb.Controllers
{

    public class AdminSettingsController : Controller
    {
        UserRepository ur = new UserRepository();
        Exceptions newException = new Exceptions();
        CRMRepository cr = new CRMRepository();
        // GET: AdminSettings
        public ActionResult Index()
        {

            TblUser sessionUser = (TblUser)Session["UserSession"];
            TblUserViewModel objuserviewmodel = new TblUserViewModel();
            sessionUser.IsMyProfile = true;

            List<tblCRMClient> clientdetails = new List<tblCRMClient>();
            clientdetails = cr.GetClientById(Convert.ToInt32(sessionUser.CRMClientId));
            objuserviewmodel.objtblCRMClient = clientdetails[0];
            objuserviewmodel.objtbluser = sessionUser;

            objuserviewmodel.lstClientStages = cr.GetCRMStagesList(Convert.ToInt32(sessionUser.CRMClientId));
            objuserviewmodel.lstClientSubStages = cr.GetCRMClientSubStages(Convert.ToInt32(sessionUser.CRMClientId));
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
                objSubStage.SubStageId= Convert.ToInt32(item["SubStageID"]);
                objSubStage.SubStageName = Convert.ToString(item["SubStageName"]);
                objSubStage.IsActive= Convert.ToBoolean(item["SubStageIsActive"]);
                objSubStage.ClientId = Convert.ToInt32(sessionUser.CRMClientId);
                objSubStage.CreatedBy = sessionUser.UserId;
                objSubStage.CreatedOn = DateTime.Now;
                lstSubStage.Add(objSubStage);

            }
            status = cr.UpdateStages(lstStage, lstSubStage);

            return status;
        }


    }
}