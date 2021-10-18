using System;
using System.ComponentModel.DataAnnotations;

namespace hotel_booking_model
{
    public class TransactionPeriod
    {
        /// <summary>  
        /// DOB datetime data type property   
        /// to display date type control  
        /// </summary>  
        [Display(Name = "")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
             /*public TransactionPeriod()
            {
            System.DateTime transactionPeriod = new System.DateTime();
            int month = transactionPeriod.Month;
            }*/
      

    }
}
