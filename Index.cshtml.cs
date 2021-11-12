using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGenerator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        //constructor
        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public string PageTitle { get; set; }
        public int currentPasswordLength = 0;
        Random charactor = new Random();
        public string allCharactors = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@$#.";
        public string randomPassword = "";

        private void passwordGenerator(int passwordLength)
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomNum = charactor.Next(0, allCharactors.Length);
                randomPassword += allCharactors[randomNum];

            }

        }

        private void passwordLength()
        {
            currentPasswordLength = 8;
            passwordGenerator(currentPasswordLength);
        }

        public void OnGet()
        {
            PageTitle = _config["PasswordPageTitle"];
            passwordLength();
        }
    }
}

