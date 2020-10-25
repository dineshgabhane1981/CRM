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

namespace LMSBL.Repository
{
    public class CRMDashboardRepository
    {
        DataRepository db = new DataRepository();
        Exceptions newException = new Exceptions();

        public List<tblCRMUser> GetCRMDashboardEnquiryList(int clientID, int stage)
        {
            List<tblCRMUser> objCRMEnquiryList = new List<tblCRMUser>();
            using (var context = new CRMContext())
            {
                objCRMEnquiryList = context.tblCRMUsers.Where(x => x.ClientId == clientID && x.CurrentStage == stage)
                    .OrderByDescending(p => p.CreatedOn).Take(5).ToList();
            }
            return objCRMEnquiryList;
        }
        public List<CRMDashboardClients> GetCRMDashboardClientList(int clientID, int stage)
        {
            List<CRMDashboardClients> lstClientDetails = new List<CRMDashboardClients>();
            List<tblCRMUser> objCRMEnquiryList = new List<tblCRMUser>();
            using (var context = new CRMContext())
            {
                objCRMEnquiryList = context.tblCRMUsers.Where(x => x.ClientId == clientID && x.CurrentStage == stage)
                    .OrderByDescending(p => p.CreatedOn).Take(5).ToList();


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
        public List<tblCRMUser> GetCRMDocumentList(int clientID, int stage)
        {
            //This function is not working, result is not getting, getting error
            List<tblCRMUser> objCRMEnquiryList = new List<tblCRMUser>();
            using (var context = new CRMContext())
            {
                objCRMEnquiryList = context.tblCRMUsers.Where(x => x.ClientId == clientID && x.CurrentStage == stage)
                    .OrderByDescending(p => p.CreatedOn).Take(5).ToList();


                var docs = context.tblCRMDocuments.OrderByDescending(m => m.UpdatedDate).ToLookup(p => p.ClientId).Select(coll => coll.FirstOrDefault()).ToList();

                var lstResult = from a in context.tblCRMUsers
                                join c in docs on a.Id equals c.ClientId
                                where a.ClientId == clientID && a.CurrentStage == stage
                                select new
                                {
                                    a.ClientId,
                                    a.FirstName,
                                    a.LastName,
                                    c.UpdatedDate
                                };

                var result = lstResult.Select(x => x.ClientId).ToList();


            }
            return objCRMEnquiryList;
        }

        public List<CRMDashboardInvoices> GetCRMDashboardInvoiceList(int clientID)
        {
            List<CRMDashboardInvoices> lstInvoices = new List<CRMDashboardInvoices>();
            using (var context = new CRMContext())
            {
                //lstInvoices = context.tblCRMInvoices.Where(x => x.ClientId == clientID).OrderByDescending(p => p.UpdatedOn).Take(5).ToList();

                lstInvoices = (from a in context.tblCRMInvoices
                               join b in context.tblCRMUsers on a.ClientId equals b.Id
                               where b.ClientId == clientID && a.InvoiceType == "Invoice" && a.Status != "Uploaded"
                               select new CRMDashboardInvoices
                               {
                                   InvoiceId = a.InvoiceId,
                                   InvoiceNumber = a.InvoiceNumber,
                                   InvoiceDueDate = a.InvoiceDueDate,
                                   ClientId = a.ClientId,
                                   FullName = b.FirstName + " " + b.LastName,
                                   Amount = a.InvoiceTotal,
                                   Currency = a.InvoiceCurrency,
                                   UpdatedOn=a.UpdatedOn

                               }).OrderByDescending(p => p.UpdatedOn).Take(5).ToList();



            }

            return lstInvoices;
        }
    }
}
