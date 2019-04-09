namespace Podium.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserSessionDbModel
    {
        [Key]
        public int UserSessionId { get; set; }
        
        public string SessionToken { get; set; }
        public bool IsValid { get; set; }
        
        public DateTime? LoginDateTime { get; set; }
        public DateTime? LogoutDateTime { get; set; }
        
        public bool HasExpiry { get; set; }
        public bool HasExpired { get; set; }
        public DateTime? ExpiryDateTime { get; set; }
        
        // Relationships
        public int UserId { get; set; }
        public virtual UserDbModel UserDetails { get; set; }
    }
}