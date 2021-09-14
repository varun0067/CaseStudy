using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationServiceAPI.Models
{
    public class User
    {
        #region
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public long Mobile { get; set; }
        #endregion

    }
}
