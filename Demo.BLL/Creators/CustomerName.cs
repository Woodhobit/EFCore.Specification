using FunctionalApproach.Result;

namespace Demo.BLL.Creators
{
    public class CustomerName
    {
        public static Result<string> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<string>.Fail<string>("Name can't be empty");

            if (name.Length > 50)
                return Result<string>.Fail<string>("Name is too long");

            return Result<string>.Ok(name);
        }
    }
}
