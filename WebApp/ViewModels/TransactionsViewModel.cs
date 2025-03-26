using System.ComponentModel.DataAnnotations;
using CoreBusiness;

namespace WebApp.ViewModels
{
    public class TransactionsViewModel
    {
        [Display(Name = "收银员名字")]
        public string? CashierName { get; set; }

        [Display(Name = "开始日期")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Display(Name = "结束日期")]
        public DateTime EndDate { get; set;} = DateTime.Today;

        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
