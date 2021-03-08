using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMSBL.DBModels.CRMNew;

namespace LMSWeb.ViewModel
{
    public class CheckListViewModel
    {
        public tblCRMCheckList CheckListObject { get; set; }
        public List<tblCRMCheckListItem> lstCheckListItem { get; set; }
    }
}