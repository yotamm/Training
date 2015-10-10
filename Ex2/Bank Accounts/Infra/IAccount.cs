namespace Bank_Accounts
{
    public interface IAccount
    {
        double Deposit(double sum);
        double Withdraw(double sum);
    }
}