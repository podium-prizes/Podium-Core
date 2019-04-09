namespace Podium.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserDbModel
    {
        [Key]
        public int UserId { get; set; }
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public bool IsAdmin { get; set; }
        public bool CanLogin { get; set; }
        public bool EmailIsVerified { get; set; }
        
        public DateTime? DateTimeCreated { get; set; }
        
        // Relationships
        public virtual List<UserSessionDbModel> UserSessionList { get; set; }
    }
}