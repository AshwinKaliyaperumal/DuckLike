public static class CoinManager
{
    // player's total balance
    private static int balance = 100;

    // player's earnings from current minigame
    public static int incomingBalance = 0;

    // adds given value to balance
    public static void AddCoins(int num)
    {
        balance += num;
    }

    // subtracts given value from balance
    public static void RemoveCoins(int num)
    {
        balance -= num;
    }

    // adds current minigame's earnings to balance and resets incomingBalance to 0
    public static int AddIncoming()
    {
        AddCoins(incomingBalance);
        incomingBalance = 0;

        return incomingBalance;
    }

    // returns current balance
    public static int GetBalance()
    {
        return balance;
    }
}
