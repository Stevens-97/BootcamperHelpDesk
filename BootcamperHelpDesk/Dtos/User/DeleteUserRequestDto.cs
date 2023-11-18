﻿namespace bootcamper_helpdesk.Dtos.User
{
    public class DeleteUserRequestDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int AutherisationLevel { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
