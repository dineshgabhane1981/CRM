using LMSBL.DBModels.CRMNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSWeb.ViewModel
{
    public class CRMInvoiceViewModel
    {
        public tblCRMInvoice ObjCRMInvoivce { get; set; }
        public tblCRMUser ObjCRMUser { get; set; }
        public tblCRMClient ObjCRMClient { get; set; }
        public List<tblCRMInvoice> ObjCRMInvoivceLST { get; set; }
        public List<tblCRMInvoice> ObjCRMAllInvoivceLST { get; set; }
        public List<tblCRMInvoiceItem> ObjCRMInvoiceItemLST { get; set; }
        public List<SelectListItem> lstCRMclient { get; set; }
        public List<SelectListItem> lstCRMCurriencies { get; set; }
        public List<SelectListItem> lstCRMInvoices { get; set; }
        public List<CRMDashboardInvoices> lstAllInvoices { get; set; }
        public string uploadInvoiceNo { get; set; }
        public string JsonData { get; set; }
        public string filebase64 { get; set; }
        public string UploadedFileName { get; set; }
        public int Client { get; set; }
        public SelectListItem[] Type()
        {
            return new SelectListItem[2] { new SelectListItem() { Text = "Invoice",Value="Invoice" }, new SelectListItem() { Text = "Receipt", Value = "Receipt" } };
        }
    }
}