using anyweb.Models;
using System;
using System.Collections.Generic;

namespace anyweb.ViewModels
{
    public class DocumentViewModel
    {
        public int AppDocId { get; set; }
        public int? ApplicationId { get; set; }
        
        public string FileName { get; set; }
        public string ClassName { get; set; }
        public string FilePath { get; set; }
        public string Approved { get; set; }
        public string Description { get; set; }
        public DateTime? UploadedOn { get; set; }
        public int Priority { get; set; }

        public List<ApplicantDocument> Documents { get; set; }
        public string DocumentType { get; set; }
    }
}