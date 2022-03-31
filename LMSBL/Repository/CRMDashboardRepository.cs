using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSBL.Common;
using LMSBL.DBModels.CRMNew;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LMSBL.DBModels;

namespace LMSBL.Repository
{
    public class CRMDashboardRepository
    {
        DataRepository db = new DataRepository();
        Exceptions newException = new Exceptions();

        public List<tblCRMUser> GetCRMDashboardEnquiryList(TblUser objUser, int stage)
        {
            List<tblCRMUser> objCRMEnquiryList = new List<tblCRMUser>();
            using (var context = new CRMContext())
            {
                int CRMClientId = Convert.ToInt32(objUser.CRMClientId);
                if (objUser.RoleId == 2)
                {
                    objCRMEnquiryList = context.tblCRMUsers.Where(x => x.ClientId == CRMClientId && x.CurrentStage == stage)
                    .OrderByDescending(p => p.CreatedOn).Take(5).ToList();
                }
                else
                {
                    objCRMEnquiryList = context.tblCRMUsers.Where(x => x.ClientId == CRMClientId && x.CurrentStage == stage && x.AssignedTo == objUser.UserId)
                    .OrderByDescending(p => p.CreatedOn).Take(5).ToList();
                }
            }
            return objCRMEnquiryList;
        }
        public List<CRMDashboardClients> GetCRMDashboardClientList(TblUser objUser, int stage)
        {
            List<CRMDashboardClients> lstClientDetails = new List<CRMDashboardClients>();
            List<tblCRMUser> objCRMEnquiryList = new List<tblCRMUser>();
            using (var context = new CRMContext())
            {
                int CRMClientId = Convert.ToInt32(objUser.CRMClientId);
                if (objUser.RoleId == 2)
                {
                    objCRMEnquiryList = context.tblCRMUsers.Where(x => x.ClientId == CRMClientId && x.CurrentStage == stage)
                    .OrderByDescending(p => p.CreatedOn).Take(5).ToList();
                }
                else
                {
                    objCRMEnquiryList = context.tblCRMUsers.Where(x => x.ClientId == CRMClientId && x.CurrentStage == stage && x.AssignedTo == objUser.UserId)
                   .OrderByDescending(p => p.CreatedOn).Take(5).ToList();
                }

                lstClientDetails = (from a in objCRMEnquiryList
                                    join b in context.tblCRMUsersVisaDetails on a.Id equals b.CRMUserId
                                    join c in context.tblCRMClientSubStages on a.CurrentSubStage equals c.SubStageId
                                    where c.ClientId == CRMClientId

                                    select new CRMDashboardClients
                                    {
                                        ClientId = a.Id,
                                        FullName = a.FirstName + " " + a.LastName,
                                        UpdatedOn = a.CreatedOn,
                                        LodgementDate = b.DueDate,
                                        SubStageName = c.SubStageName

                                    }).ToList();


            }
            return lstClientDetails;
        }

        public List<CRMDashboardInvoices> GetCRMDashboardInvoiceList(TblUser objUser)
        {
            List<CRMDashboardInvoices> lstInvoices = new List<CRMDashboardInvoices>();
            using (var context = new CRMContext())
            {
                //lstInvoices = context.tblCRMInvoices.Where(x => x.ClientId == clientID).OrderByDescending(p => p.UpdatedOn).Take(5).ToList();
                int CRMClientId = Convert.ToInt32(objUser.CRMClientId);
                if (objUser.RoleId == 2)
                {
                    lstInvoices = (from a in context.tblCRMInvoices
                                   join b in context.tblCRMUsers on a.ClientId equals b.Id
                                   where b.ClientId == CRMClientId && a.InvoiceType == "Invoice" && a.Status != "Uploaded"
                                   select new CRMDashboardInvoices
                                   {
                                       InvoiceId = a.InvoiceId,
                                       InvoiceNumber = a.InvoiceNumber,
                                       InvoiceDueDate = a.InvoiceDueDate,
                                       ClientId = a.ClientId,
                                       FullName = b.FirstName + " " + b.LastName,
                                       Amount = a.InvoiceTotal,
                                       Currency = a.InvoiceCurrency,
                                       UpdatedOn = a.UpdatedOn

                                   }).OrderByDescending(p => p.UpdatedOn).Take(5).ToList();
                }
                else
                {
                    lstInvoices = (from a in context.tblCRMInvoices
                                   join b in context.tblCRMUsers on a.ClientId equals b.Id
                                   where b.ClientId == CRMClientId && a.InvoiceType == "Invoice" && a.Status != "Uploaded" && b.AssignedTo == objUser.UserId
                                   select new CRMDashboardInvoices
                                   {
                                       InvoiceId = a.InvoiceId,
                                       InvoiceNumber = a.InvoiceNumber,
                                       InvoiceDueDate = a.InvoiceDueDate,
                                       ClientId = a.ClientId,
                                       FullName = b.FirstName + " " + b.LastName,
                                       Amount = a.InvoiceTotal,
                                       Currency = a.InvoiceCurrency,
                                       UpdatedOn = a.UpdatedOn

                                   }).OrderByDescending(p => p.UpdatedOn).Take(5).ToList();
                }



            }

            return lstInvoices;
        }



        public List<tblCRMUser> GetSearchDashboardList(TblUser objUser, string searchText)
        {
            List<tblCRMUser> objResult = new List<tblCRMUser>();
            using (var context = new CRMContext())
            {
                objResult = context.tblCRMUsers.Where(x => x.FirstName.Contains(searchText) || x.LastName.Contains(searchText)).OrderByDescending(a => a.UpdatedOn).ToList();

            }

            return objResult;
        }
        public List<tblCRMUser> GetStatusReportList(TblUser objUser, int searchText)
        {
            List<tblCRMUser> objResult = new List<tblCRMUser>();
            int CRMClientId = Convert.ToInt32(objUser.CRMClientId);
            using (var context = new CRMContext())
            {
                objResult = context.tblCRMUsers.Where(x => x.CurrentSubStage == searchText && x.ClientId== CRMClientId).OrderByDescending(a => a.UpdatedOn).ToList();
                
            }

            return objResult;
        }

        public List<tblCRMUser> GetTypeReportList(TblUser objUser, string searchText)
        {
            List<tblCRMUser> objResult = new List<tblCRMUser>();
            int CRMClientId = Convert.ToInt32(objUser.CRMClientId);
            using (var context = new CRMContext())
            {
                //objResult = context.tblCRMUsers.Where(x => x.FirstName.Contains(searchText) || x.LastName.Contains(searchText)).OrderByDescending(a => a.UpdatedOn).ToList();
                var objResult1 = (from a in context.tblCRMUsersVisaDetails
                                  join b in context.tblCRMUsers on a.CRMUserId equals b.Id
                                  where a.VisaType == searchText && b.ClientId == CRMClientId
                                  select new ReportList
                                  {
                                      Id = b.Id,
                                      FirstName = b.FirstName,
                                      LastName = b.LastName,
                                      CurrentStage = b.CurrentStage,
                                      Email = b.Email,
                                      MobileNo = b.MobileNo,
                                      CreatedOn = b.CreatedOn

                                  }).OrderByDescending(p => p.CreatedOn).ToList();

                foreach (var item in objResult1)
                {
                    tblCRMUser objItem = new tblCRMUser();
                    objItem.Id = item.Id;
                    objItem.FirstName = item.FirstName;
                    objItem.LastName = item.LastName;
                    objItem.CurrentStage = item.CurrentStage;
                    objItem.Email = item.Email;
                    objItem.MobileNo = item.MobileNo;
                    objItem.CreatedOn = item.CreatedOn;

                    objResult.Add(objItem);
                }
            }

            return objResult;
        }
    }
}
