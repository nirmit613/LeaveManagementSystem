using LeaveManagementSystem.Models.Interfaces;
using LeaveManagementSystem.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace LeaveManagementSystem.Models.Repository
{
    public class UserRepository:IUserRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region Constructors
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(u=>u.Role).ToList();
        }
        public User GetUserbyId(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
        }

        public int AddUser(User user)
        {
            _context.Add(user);
            if (_context.SaveChanges() > 0)
            {
                var leaveTypeBalances = new Dictionary<int, int>
        {
            { 1, 10 },  
            { 2, 12 }, 
            { 3, 18 }   
        };

                foreach (var kvp in leaveTypeBalances)
                {
                    _context.LeaveBalances.Add(new LeaveBalance
                    {
                        UserId = user.Id,
                        LeaveTypeId = kvp.Key,
                        Balance = kvp.Value
                    });
                }
                if (_context.SaveChanges() > 0)
                {
                    return user.Id;
                }
                else
                {
                    return 0; 
                }
            }
            else
            {
                return 0; 
            }
        }
        #endregion
    }
}
