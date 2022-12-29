using anyweb.Models;
using System.Collections.Generic;

namespace anyweb.ViewModels
{
    public class TestCenterViewModel
    {
        public int? TestCenterId { get; set; }
        public int? ApplicationId { get; set; }
        public List<TestCenter> TestCenters { get; set; }
    }
}