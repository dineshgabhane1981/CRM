using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSBL.Common;
using LMSBL.DBModels;
using LMSBL.DBModels.CRMNew;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace LMSBL.Repository
{
    public class CRMRepository
    {
        DataRepository db = new DataRepository();
        Exceptions newException = new Exceptions();
        public List<tblCRMClient> GetClientById(int ClientId)
        {
            tblCRMClient objCRMClient = new tblCRMClient();
            try
            {
                db.parameters.Clear();
                db.AddParameter("@ClientID", SqlDbType.Int, ClientId);
                DataSet ds = db.FillData("sp_CRMClientsGetById");
                List<tblCRMClient> clientDetails = ds.Tables[0].AsEnumerable().Select(dr => new tblCRMClient
                {
                    ClientID = Convert.ToInt32(dr["ClientID"]),
                    ClientName = Convert.ToString(dr["ClientName"]),
                    ClientLogo = Convert.ToString(dr["ClientLogo"]),
                    IsActive = Convert.ToBoolean(dr["IsActive"]),
                    CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                    isLMS = Convert.ToBoolean(dr["isLMS"])
                    //TenantId = Convert.ToString(dr["TenantId"])
                    //Duration = Convert.ToInt32(dr["Duration"])


                }).ToList();
                return clientDetails;
            }
            catch (Exception ex)
            {
                newException.AddException(ex);
                throw ex;
            }
        }

        public bool UpdateCRMClient(int ClientId, string clientlogo)
        {
            bool result = false;
            using (var context = new CRMContext())
            {
                var objcrmclient = context.tblCRMClients.FirstOrDefault(a => a.ClientID == ClientId);
                objcrmclient.ClientLogo = clientlogo;
                context.tblCRMClients.AddOrUpdate(objcrmclient);
                context.SaveChanges();
                result = true;
            }
            return result;

        }
        public List<tblCRMClientStage> GetCRMStagesList(int id)
        {

            List<tblCRMClientStage> objCRMClientStage = new List<tblCRMClientStage>();
            using (var context = new CRMContext())
            {
                objCRMClientStage = context.tblCRMClientStages.Where(a => a.ClientId == id).ToList();
            }

            return objCRMClientStage;
        }
        public List<tblCRMClientSubStage> GetCRMClientSubStages(int id)
        {
            List<tblCRMClientSubStage> objCRMClientSubStage = new List<tblCRMClientSubStage>();
            using (var context = new CRMContext())
            {
                objCRMClientSubStage = context.tblCRMClientSubStages.Where(a => a.ClientId == id).ToList();
            }
            return objCRMClientSubStage;
        }
        public bool UpdateStages(List<tblCRMClientStage> lstStages, List<tblCRMClientSubStage> lstSubStage)
        {
            bool result = false;
            using (var context = new CRMContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in lstStages)
                        {
                            var objStage = context.tblCRMClientStages.FirstOrDefault(a => a.StageId == item.StageId && a.ClientId == item.ClientId);
                            objStage.StageName = item.StageName;
                            objStage.CreatedBy = item.CreatedBy;
                            objStage.CreatedOn = item.CreatedOn;

                            context.tblCRMClientStages.AddOrUpdate(objStage);
                            context.SaveChanges();
                        }

                        foreach (var item in lstSubStage)
                        {
                            var objSubStage = context.tblCRMClientSubStages.FirstOrDefault(a => a.SubStageId == item.SubStageId && a.ClientId == item.ClientId);
                            objSubStage.SubStageName = item.SubStageName;
                            objSubStage.IsActive = item.IsActive;
                            objSubStage.CreatedBy = item.CreatedBy;
                            objSubStage.CreatedOn = item.CreatedOn;

                            context.tblCRMClientSubStages.AddOrUpdate(objSubStage);
                            context.SaveChanges();
                        }

                        transaction.Commit();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        newException.AddException(ex);
                    }
                }
            }
            return result;
        }

        public List<tblUser> GetCRMAdminUsers(int ClientId)
        {
            List<tblUser> objUserList = new List<tblUser>();
            using (var context = new CRMContext())
            {
                objUserList = context.tblUsers.Where(a => a.CRMClientId == ClientId && a.roleId == 4 && a.isActive == true).ToList();
            }

            return objUserList;
        }

        public bool AddEditAdminUser(tblUser objUser)
        {
            bool result = false;
            using (var context = new CRMContext())
            {
                try
                {
                    context.tblUsers.AddOrUpdate(objUser);
                    context.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    newException.AddException(ex);
                }

            }
            return result;
        }

        public bool CheckEmailExist(string emailid)
        {
            bool result = false;
            using (var context = new CRMContext())
            {
                try
                {
                    var objUser = context.tblUsers.Where(a => a.emailId == emailid).FirstOrDefault();

                    if (objUser != null)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    newException.AddException(ex);
                }

            }
            return result;
        }
        public tblUser GetUserForEdit(int userId)
        {
            tblUser objUser = new tblUser();            
            using (var context = new CRMContext())
            {
                try
                {
                     objUser = context.tblUsers.Where(a => a.userId == userId).FirstOrDefault();
                   
                }
                catch (Exception ex)
                {
                    newException.AddException(ex);
                }

            }
            return objUser;
        }
    }
}
