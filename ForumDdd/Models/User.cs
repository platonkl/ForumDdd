using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ForumDdd.Models;

namespace ForumDdd.Models
{
    public class User
    {
        public string Email {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
