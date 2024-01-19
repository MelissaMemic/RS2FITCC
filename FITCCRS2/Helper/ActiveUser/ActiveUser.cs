namespace FITCCRS2.Helper.ActiveUser
{
    public class ActiveUser:IActiveUser
    {
        public Dictionary<string, int> ActiveUsersId { get; set; } = new Dictionary<string, int>();
    }
}
