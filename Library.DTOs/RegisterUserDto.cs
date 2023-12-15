namespace Library.DTOs
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set;}
        public string Surname { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
