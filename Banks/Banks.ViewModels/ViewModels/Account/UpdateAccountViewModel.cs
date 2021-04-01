﻿using Banks.Entities.Enums;
using Banks.ViewModels.Models;

namespace Banks.ViewModels.ViewModels.Account
{
    /// <summary>       
    /// ViewModel to set new datas and update.
    /// </summary>
    public class UpdateAccountViewModel:BaseViewModel
    {
        /// <summary>
        /// Gets or sets number of account.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets kind of currency in integer format matches to enum.
        /// </summary>
        public Currencies Currency { get; set; }
    }
}
