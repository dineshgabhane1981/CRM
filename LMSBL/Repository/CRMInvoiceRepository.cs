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
using System.Configuration;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon;
using Amazon.S3.IO;
using System.IO;
using LMSBL.DBModels;

namespace LMSBL.Repository
{

    public class CRMInvoiceRepository
    {
        DataRepository db = new DataRepository();
        Exceptions newException = new Exceptions();

        string AWSAccessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
        string AWSSecretKey = ConfigurationManager.AppSettings["AWSSecretKey"];
        string AWSBucketName = ConfigurationManager.AppSettings["AWSBucketName"];

        public string GetInvoiceNumber(int ClientId)
        {
            string invoiceNo = string.Empty;
            using (var context = new CRMContext())
            {
                var result = context.tblCRMInvoices.Where(x => x.InvoiceType == "Invoice" && x.CRMClientID == ClientId).OrderByDescending(y => y.InvoiceId).FirstOrDefault();
                if (result != null)
                {
                    invoiceNo = result.InvoiceNumber;
                    var theNumber = invoiceNo.Substring(4, invoiceNo.Length - 4);
                    invoiceNo = "INV-" + (Convert.ToInt32(theNumber) + 1);
                }
                else
                {
                    invoiceNo = "INV-1";
                }
            }
            return invoiceNo;
        }

        public List<SelectListItem> GetCRMCurriencies()
        {
            List<SelectListItem> lstCRMCurriencies = new List<SelectListItem>();

            List<tblCRMCurrency> lstCRMCurrency = new List<tblCRMCurrency>();
            using (var context = new CRMContext())
            {
                lstCRMCurrency = context.tblCRMCurrencies.Select(a => a).ToList();
            }
            foreach (var currency in lstCRMCurrency)
            {
                lstCRMCurriencies.Add(new SelectListItem
                {
                    Text = Convert.ToString(currency.CurrencyName),
                    Value = Convert.ToString(currency.CurrencyName)
                });
            }

            return lstCRMCurriencies;
        }
        public List<SelectListItem> GetCRMInvoices(int CRMClientId)
        {
            List<SelectListItem> lstCRMInvoices = new List<SelectListItem>();

            List<tblCRMInvoice> lstCRMInvoice = new List<tblCRMInvoice>();
            using (var context = new CRMContext())
            {
                lstCRMInvoice = context.tblCRMInvoices.Where(a => a.ClientId == CRMClientId && a.InvoiceType == "Invoice").ToList();
            }
            foreach (var invoice in lstCRMInvoice)
            {
                lstCRMInvoices.Add(new SelectListItem
                {
                    Text = Convert.ToString(invoice.InvoiceNumber),
                    Value = Convert.ToString(invoice.InvoiceNumber)
                });
            }

            return lstCRMInvoices;
        }

        public bool SaveInvoice(tblCRMInvoice ObjCRMInvoivce, List<tblCRMInvoiceItem> ObjCRMInvoiceItemLST)
        {
            bool status = false;
            using (var context = new CRMContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.tblCRMInvoices.AddOrUpdate(ObjCRMInvoivce);
                        context.SaveChanges();

                        var oldItems = context.tblCRMInvoiceItems.Where(x => x.InvoiceId == ObjCRMInvoivce.InvoiceId).ToList();

                        foreach (var item in oldItems)
                        {
                            context.tblCRMInvoiceItems.Remove(item);
                            context.SaveChanges();
                        }

                        int count = 1;
                        foreach (var item in ObjCRMInvoiceItemLST)
                        {
                            item.InvoiceId = ObjCRMInvoivce.InvoiceId;
                            item.ItemId = count;
                            context.tblCRMInvoiceItems.AddOrUpdate(item);
                            context.SaveChanges();
                            count++;
                        }

                        transaction.Commit();
                        status = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        newException.AddException(ex);
                        throw ex;
                    }
                }
            }
            return status;
        }

        public bool UploadInvoice(tblCRMInvoice ObjCRMInvoivce, string fileBase64)
        {
            bool status = false;
            using (var context = new CRMContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.tblCRMInvoices.AddOrUpdate(ObjCRMInvoivce);
                        context.SaveChanges();

                        //Upload File

                        IAmazonS3 client = new AmazonS3Client(AWSAccessKey, AWSSecretKey, RegionEndpoint.EUWest3);
                        TransferUtility utility = new TransferUtility(client);
                        TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

                        var clientName = GetUserFolderName(ObjCRMInvoivce.ClientId);
                        string path = @"clients/" + clientName + "/Invoice";

                        S3DirectoryInfo di = new S3DirectoryInfo(client, AWSBucketName, path);
                        if (!di.Exists)
                        {
                            di.Create();
                        }
                        request.BucketName = AWSBucketName;
                        request.Key = path + "/" + ObjCRMInvoivce.InvoiceFileName;

                        byte[] newBytes = Convert.FromBase64String(fileBase64);
                        MemoryStream ms = new MemoryStream(newBytes, 0, newBytes.Length);
                        ms.Write(newBytes, 0, newBytes.Length);
                        request.InputStream = ms;
                        utility.Upload(request);


                        transaction.Commit();
                        status = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        newException.AddException(ex);
                        throw ex;
                    }
                }
            }
            return status;
        }


        public List<tblCRMInvoice> GetInvoices(int ClientId)
        {
            List<tblCRMInvoice> ObjCRMInvoices = new List<tblCRMInvoice>();
            using (var context = new CRMContext())
            {
                ObjCRMInvoices = context.tblCRMInvoices.Where(x => x.ClientId == ClientId).ToList();
            }
            return ObjCRMInvoices;
        }

        public List<CRMDashboardInvoices> GetCRMAllInvoiceList(TblUser objUser)
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
                                   where b.ClientId == CRMClientId
                                   select new CRMDashboardInvoices
                                   {
                                       InvoiceId = a.InvoiceId,
                                       InvoiceNumber = a.InvoiceNumber,
                                       InvoiceDueDate = a.InvoiceDueDate,
                                       ClientId = a.ClientId,
                                       FullName = b.FirstName + " " + b.LastName,
                                       Amount = a.InvoiceTotal,
                                       Currency = a.InvoiceCurrency,
                                       InvoiceStatus=a.Status,
                                       InvoiceType=a.InvoiceType,
                                       UpdatedOn = a.UpdatedOn
                                   }).OrderByDescending(p => p.UpdatedOn).ToList();
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

                                   }).OrderByDescending(p => p.UpdatedOn).ToList();
                }

            }

            return lstInvoices;
        }

        public tblCRMInvoice GetInvoiceForEdit(int Id)
        {
            tblCRMInvoice ObjCRMInvoices = new tblCRMInvoice();
            using (var context = new CRMContext())
            {
                ObjCRMInvoices = context.tblCRMInvoices.FirstOrDefault(x => x.InvoiceId == Id);
            }
            return ObjCRMInvoices;
        }

        public List<tblCRMInvoiceItem> GetInvoiceItemForEdit(int Id)
        {
            List<tblCRMInvoiceItem> ObjCRMInvoiceItem = new List<tblCRMInvoiceItem>();
            using (var context = new CRMContext())
            {
                ObjCRMInvoiceItem = context.tblCRMInvoiceItems.Where(x => x.InvoiceId == Id).ToList();
            }
            return ObjCRMInvoiceItem;
        }

        public bool MarkPaidInvoice(int invoiceId, int updatedId)
        {
            bool status = false;
            try
            {
                using (var context = new CRMContext())
                {
                    tblCRMInvoice invoice = new tblCRMInvoice();
                    invoice = context.tblCRMInvoices.FirstOrDefault(x => x.InvoiceId == invoiceId);

                    if (invoice != null)
                    {
                        invoice.Status = "Paid";
                        invoice.UpdatedBy = updatedId;
                        invoice.UpdatedOn = DateTime.Now;
                        context.tblCRMInvoices.AddOrUpdate(invoice);
                        context.SaveChanges();
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                newException.AddException(ex);
            }
            return status;
        }

        public string DownloadFileFromS3(int id, int clientId)
        {
            string returnLocation = string.Empty;
            try
            {
                using (var context = new CRMContext())
                {
                    var objInvoice = context.tblCRMInvoices.FirstOrDefault(x => x.InvoiceId == id);
                    var filelink = clientId + "/" + objInvoice.ClientId + "/Invoice/" + objInvoice.InvoiceFileName;
                    string _FilePath = ConfigurationManager.AppSettings["SharedLocation"];
                    string FileLocation = _FilePath + "/" + objInvoice.InvoiceFileName; ;
                    FileStream fs = File.Create(FileLocation);
                    fs.Close();
                    string path = @"clients/" + filelink;
                    IAmazonS3 client = new AmazonS3Client(AWSAccessKey, AWSSecretKey, RegionEndpoint.EUWest3);
                    TransferUtility fileTransferUtility = new TransferUtility(client);
                    fileTransferUtility.Download(FileLocation, AWSBucketName, path);
                    fileTransferUtility.Dispose();
                    returnLocation = objInvoice.InvoiceFileName;
                }
            }
            catch (Exception ex)
            {
                newException.AddException(ex);
            }

            return returnLocation;
        }
        public string GetUserFolderName(int UserId)
        {
            string name = string.Empty;
            try
            {
                using (var context = new CRMContext())
                {
                    var lstResult = (from a in context.tblCRMUsers
                                     join b in context.tblCRMClients on a.ClientId equals b.ClientID
                                     where a.Id == UserId
                                     select new
                                     {
                                         AdviserCompanyName = b.ClientID + "/" + a.Id

                                     }).Select(x => x.AdviserCompanyName);
                    var result = lstResult.FirstOrDefault();
                    name = result;
                }
            }
            catch (Exception ex)
            {

                newException.AddException(ex);
            }
            return name;
        }

    }
}
