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
    }
}
